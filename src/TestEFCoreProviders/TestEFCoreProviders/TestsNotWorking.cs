namespace TestEFCoreProviders;

public partial class TestsNotWorkingDateTime : IScenarioTearDown, IAsyncLifetime
{
    StartDatabase startDatabase;

    [Scenario]
    [InlineData(EFCoreProvider.Microsoft_EntityFrameworkCore_In_Memory)]
    [InlineData(EFCoreProvider.Npgsql_EntityFrameworkCore_PostgreSQL)]
    [InlineData(EFCoreProvider.Pomelo_EntityFrameworkCore_MySql)]
    [InlineData(EFCoreProvider.MySql_EntityFrameworkCore)]
    public async Task CrudMultipleSimpleTable(EFCoreProvider provider)
    {
        int nrRecs = 20;
        await Runner
           .AddAsyncSteps(
           _ => Given_The_Database_IsCreated(provider),           
           _ => CRUD_Tbl_DATETIME_Table(nrRecs)
           ).RunAsync();
    }

    public TestsNotWorkingDateTime()
    {

        startDatabase = new StartDatabase();
    }
    [Fact(Skip = "interface")]
    public async Task DisposeAsync()
    {
        await OnScenarioTearDown();
    }
    [Fact(Skip = "interface")]
    public Task InitializeAsync()
    {
        return Task.CompletedTask;
    }

    [Fact(Skip = "interface")]
    public async Task OnScenarioTearDown()
    {
        TestOutput.WriteLine("tear down " + startDatabase.Name());
        await startDatabase.DisposeAsync();
    }
}
