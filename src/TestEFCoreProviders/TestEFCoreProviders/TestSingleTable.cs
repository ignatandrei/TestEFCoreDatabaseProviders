namespace TestEFCoreProviders;
public partial class TestSingleTable:IScenarioTearDown
{
    IContainer? Container; 
    async Task<string> GetConnectionString(EFCoreProvider provider)
    {
        var newDB = "test" + Guid.NewGuid().ToString("N");
        switch (provider)
        {
            case EFCoreProvider.Microsoft_EntityFrameworkCore_SqlServer:
                MsSqlContainer msSql =new MsSqlBuilder()
                    .WithPortBinding(1433)
                    .Build();
                await msSql.StartAsync();
                this.Container = msSql;
                SqlConnectionStringBuilder builder = new (msSql.GetConnectionString());
                builder.InitialCatalog=newDB;

                return builder.ConnectionString;
            case EFCoreProvider.Microsoft_EntityFrameworkCore_In_Memory:
                return newDB;
            case EFCoreProvider.Microsoft_EntityFrameworkCore_Sqlite_In_Memory:
                return $"Filename=:memory:";
            case EFCoreProvider.Microsoft_EntityFrameworkCore_Sqlite_File:
                return $"Data Source={newDB}.db";
            case EFCoreProvider.Npgsql_EntityFrameworkCore_PostgreSQL:
                var postgreSqlContainer = new PostgreSqlBuilder()
                    .WithImage("postgres:15.1")
                    .Build();
                await postgreSqlContainer.StartAsync();
                this.Container = postgreSqlContainer;
                NpgsqlConnectionStringBuilder builder1 = new (postgreSqlContainer.GetConnectionString());
                builder1.Database=newDB;
                return builder1.ConnectionString;
            case EFCoreProvider.Pomelo_EntityFrameworkCore_MySql:
                var mySqlContainer = new MySqlBuilder()
                  .WithImage("mysql:8.0")
                  .WithPortBinding(3306)
                  .Build();
                await mySqlContainer.StartAsync();
                this.Container = mySqlContainer;
                PomeloCN.MySqlConnectionStringBuilder builder2 = new(mySqlContainer.GetConnectionString());
                builder2.Database = newDB;
                return builder2.ConnectionString;
            case EFCoreProvider.MySql_EntityFrameworkCore:
                var mySqlContainer2 = new MySqlBuilder()
                  .WithImage("mysql:8.0")
                  .WithPortBinding(3306)
                  .Build();
                await mySqlContainer2.StartAsync();
                this.Container = mySqlContainer2;
                MySqlOracle.MySqlConnectionStringBuilder builder3 = new(mySqlContainer2.GetConnectionString());
                builder3.Database = newDB;
                builder3.PersistSecurityInfo = true;
                return builder3.ConnectionString;
            case EFCoreProvider.Microsoft_EntityFrameworkCore_Cosmos:
                var cosmosDbContainer = new CosmosDbBuilder()
  .WithImage("mcr.microsoft.com/cosmosdb/linux/azure-cosmos-emulator:latest")
  .Build();
                await cosmosDbContainer.StartAsync();
                this.Container=cosmosDbContainer;
                return cosmosDbContainer.GetConnectionString();
            default:
                throw new ArgumentException("not know database");
        }
    }
    public T? GetContext<T>(string con, EFCoreProvider provider)
        where T : DbContext
    {
        DbContextOptionsBuilder<SimpleTableDBContext> builder = new();
        switch (provider)
        { 
            case EFCoreProvider.Microsoft_EntityFrameworkCore_SqlServer:
                builder.UseSqlServer(con);
                break;
            case EFCoreProvider.Microsoft_EntityFrameworkCore_In_Memory:
                builder.UseInMemoryDatabase(con);
                break;
            case EFCoreProvider.Microsoft_EntityFrameworkCore_Sqlite_In_Memory:
                _connection = new SqliteConnection(con);
                _connection.Open();
                builder.UseSqlite(_connection);
                break;
            case EFCoreProvider.Npgsql_EntityFrameworkCore_PostgreSQL:
                builder.UseNpgsql(con);
                break;
            case EFCoreProvider.Pomelo_EntityFrameworkCore_MySql:

                var serverVersion = PomeloEF.ServerVersion.AutoDetect(con);
                StepExecution.Current.Comment("version " + serverVersion.ToString());
                PomeloMySqlCNB.UseMySql(builder,con, serverVersion)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
                StepExecution.Current.Comment("after use mysql");

                break;
            case EFCoreProvider.MySql_EntityFrameworkCore:
                MySqlCNBOracle.UseMySQL(builder,con);
                break;
            case EFCoreProvider.Microsoft_EntityFrameworkCore_Cosmos:
                builder.UseCosmos(con, "test", clientOptions =>
                {
                    clientOptions.HttpClientFactory(() => {
                        HttpMessageHandler httpMessageHandler = new HttpClientHandler()
                        {
                            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                        };

                        return new HttpClient(httpMessageHandler);
                    });
                    clientOptions.ConnectionMode(ConnectionMode.Gateway);
                });
                break;
            default:

                throw new ArgumentException("in get context " + provider);
        }
        return Activator.CreateInstance(typeof(T), builder.Options) as T;
        

    }

    
    [Scenario]
    //[MultiAssert]
    [InlineData(EFCoreProvider.Microsoft_EntityFrameworkCore_SqlServer)]
    [InlineData(EFCoreProvider.Microsoft_EntityFrameworkCore_In_Memory)]
    [InlineData(EFCoreProvider.Microsoft_EntityFrameworkCore_Sqlite_In_Memory)]
    [InlineData(EFCoreProvider.Npgsql_EntityFrameworkCore_PostgreSQL)]
    [InlineData(EFCoreProvider.Pomelo_EntityFrameworkCore_MySql)]
    [InlineData(EFCoreProvider.MySql_EntityFrameworkCore)]
    //[InlineData(EFCoreProvider.Microsoft_EntityFrameworkCore_Cosmos)]
    public async Task CrudSimpleTable(EFCoreProvider provider)
    {
        var nrDeps = 5;
        await Runner
            .AddAsyncSteps(
            _ => Given_The_Database_IsCreated(provider),
            _=> Then_Number_Of_Dep_Are_Nr(0),
            _=> When_Creating_Nr_Departments(nrDeps),
            _=>Then_Number_Of_Dep_Are_Nr(nrDeps),
            _=> When_Deleting_Department_With_id(2),
            _=>Then_Number_Of_Dep_Are_Nr(nrDeps-1)
            )
            .RunAsync();
        

        //await Task.Delay(160_000);

    }

    [Fact(Skip = "interface")]
    public async Task OnScenarioTearDown()
    {
        TestOutput.WriteLine("tear down "+Container?.Name);
        if (Container != null)
        {
            await Container.StopAsync();
            await Container.DisposeAsync();
            await Task.Delay(10_000);
        }
    }
}