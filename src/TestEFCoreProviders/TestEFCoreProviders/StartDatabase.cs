using System.Threading.Tasks;

namespace TestEFCoreProviders;

class StartDatabase: IAsyncDisposable
{
    
    private SqliteConnection? _connection;//necessary for sqlite
    IContainer? Container;
    string connectionStringCache = "";
    EFCoreProvider coreProviderCache = EFCoreProvider.None;
    async Task<string> GetConnectionString(EFCoreProvider provider)
    {
        if(connectionStringCache.Length>0)
            return connectionStringCache;
        var newDB = "test" + Guid.NewGuid().ToString("N");
        switch (provider)
        {
            case EFCoreProvider.Microsoft_EntityFrameworkCore_SqlServer:
                {
                    MsSqlContainer msSql = new MsSqlBuilder()
                        .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
                        .WithPortBinding(1433)
                        .WithPassword("<YourStrong@Passw0rd>")
                        .Build();
                    await msSql.StartAsync();
                    this.Container = msSql;
                    SqlConnectionStringBuilder builder = new(msSql.GetConnectionString());
                    builder.InitialCatalog = newDB;
                    builder.PersistSecurityInfo= true;
                    connectionStringCache = builder.ConnectionString;
                    break;
                }
            case EFCoreProvider.Microsoft_EntityFrameworkCore_In_Memory:
                connectionStringCache= newDB;
                break;
            case EFCoreProvider.Microsoft_EntityFrameworkCore_Sqlite_In_Memory:
                connectionStringCache= $"Filename=:memory:";
                break;
            case EFCoreProvider.Microsoft_EntityFrameworkCore_Sqlite_File:
                connectionStringCache= $"Data Source={newDB}.db";
                break;
            case EFCoreProvider.Npgsql_EntityFrameworkCore_PostgreSQL:
                {
                    var postgreSqlContainer = new PostgreSqlBuilder()
                        .WithImage("postgres:15.1")
                        .Build();
                    await postgreSqlContainer.StartAsync();
                    this.Container = postgreSqlContainer;
                    NpgsqlConnectionStringBuilder builder = new(postgreSqlContainer.GetConnectionString());
                    builder.Database = newDB;
                    builder.PersistSecurityInfo = true;
                    connectionStringCache =builder.ConnectionString;
                    break;
                }
            case EFCoreProvider.Pomelo_EntityFrameworkCore_MySql:
                {
                    var mySqlContainer = new MySqlBuilder()
                      .WithImage("mysql:8.0")
                      .WithPortBinding(3306)
                      .Build();
                    await mySqlContainer.StartAsync();
                    this.Container = mySqlContainer;
                    PomeloCN.MySqlConnectionStringBuilder builder = new(mySqlContainer.GetConnectionString());
                    builder.Database = newDB;
                    builder.PersistSecurityInfo = true;
                    builder.UserID = "root";
                    connectionStringCache = builder.ConnectionString;
                    break;
                }
            case EFCoreProvider.MySql_EntityFrameworkCore:
                {
                    var mySqlContainer2 = new MySqlBuilder()
                      .WithImage("mysql:8.0")
                      .WithPortBinding(3306)
                      .Build();
                    await mySqlContainer2.StartAsync();
                    this.Container = mySqlContainer2;
                    MySqlOracle.MySqlConnectionStringBuilder builder = new(mySqlContainer2.GetConnectionString());
                    builder.Database = newDB;
                    builder.PersistSecurityInfo = true;
                    builder.UserID = "root";
                    connectionStringCache= builder.ConnectionString;
                    break;
                }
            case EFCoreProvider.Microsoft_EntityFrameworkCore_Cosmos:
                {
                    var cosmosDbContainer = new CosmosDbBuilder()
      .WithImage("mcr.microsoft.com/cosmosdb/linux/azure-cosmos-emulator:latest")
      .Build();
                    await cosmosDbContainer.StartAsync();
                    this.Container = cosmosDbContainer;
                    connectionStringCache= cosmosDbContainer.GetConnectionString();
                    break;
                }
            default:
                throw new ArgumentException("not know database for "+ provider);
        }
        StepExecution.Current.Comment("connection : " + connectionStringCache);
        return connectionStringCache;
    }
    private T? GetContextFromConnection<T>(string con, EFCoreProvider provider)
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
            case EFCoreProvider.Microsoft_EntityFrameworkCore_Sqlite_File:
                _connection = new SqliteConnection(con);
                _connection.Open();
                builder.UseSqlite(_connection);
                break;
            case EFCoreProvider.Npgsql_EntityFrameworkCore_PostgreSQL:
                builder.UseNpgsql(con);
                break;
            case EFCoreProvider.Pomelo_EntityFrameworkCore_MySql:

                var serverVersion = PomeloEF.ServerVersion.AutoDetect(con);
                
                PomeloMySqlCNB.UseMySql(builder, con, serverVersion)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
                StepExecution.Current.Comment("after use mysql");

                break;
            case EFCoreProvider.MySql_EntityFrameworkCore:
                MySqlCNBOracle.UseMySQL(builder, con);
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
    public async Task<T> GetNewContext<T>()
         where T : DbContext
    {
        var con = await GetConnectionString(coreProviderCache);
        var data= GetContextFromConnection<T>(con, coreProviderCache);
        ArgumentNullException.ThrowIfNull(data);
        return data;
    }
    public async Task<T?> GetContext<T>(EFCoreProvider provider)
         where T : DbContext
    {
        coreProviderCache = provider;
        var con = await GetConnectionString(provider);        
        return GetContextFromConnection<T>(con, provider);
    }
    public async ValueTask DisposeAsync()
    {
        
        if (Container != null)
        {
            //await Task.Delay(60_000);
            await Container.StopAsync();
            await Container.DisposeAsync();
          
        }
        if(_connection != null)
            _connection.Dispose();
    }
}
