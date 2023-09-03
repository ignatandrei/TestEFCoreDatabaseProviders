
namespace TestEFCoreProviders;
[Collection("NotInParallel")]
public partial class TestSimpleTablesMultipleData :IScenarioTearDown , IAsyncLifetime
{
    StartDatabase startDatabase;
    public TestSimpleTablesMultipleData()
    {
        
        startDatabase = new StartDatabase();
    }

    [Scenario]
    //[MultiAssert]

    [InlineData(EFCoreProvider.Microsoft_EntityFrameworkCore_In_Memory)]
    [InlineData(EFCoreProvider.Microsoft_EntityFrameworkCore_SqlServer)]
    [InlineData(EFCoreProvider.Microsoft_EntityFrameworkCore_Sqlite_File)]
    [InlineData(EFCoreProvider.Npgsql_EntityFrameworkCore_PostgreSQL)]
    [InlineData(EFCoreProvider.Pomelo_EntityFrameworkCore_MySql)]
    [InlineData(EFCoreProvider.MySql_EntityFrameworkCore)]
    //[InlineData(EFCoreProvider.Microsoft_EntityFrameworkCore_Cosmos)]
    public async Task CrudMultipleSimpleTable(EFCoreProvider provider)
    {
        await Runner
           .AddAsyncSteps(
           _ => Given_The_Database_IsCreated(provider)
           ).RunAsync();
    }

    public async Task DisposeAsync()
    {
        await OnScenarioTearDown();
    }

    public async Task InitializeAsync()
    {
        await Task.Delay(1000);
    }

    [Fact(Skip = "interface")]
    public async Task OnScenarioTearDown()
    {
        TestOutput.WriteLine("tear down "+startDatabase.Name());
        await startDatabase.DisposeAsync();
    }
}
