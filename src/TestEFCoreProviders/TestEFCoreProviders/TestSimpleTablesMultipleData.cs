﻿
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
        int nrRecs = 20;
        await Runner
           .AddAsyncSteps(
           _ => Given_The_Database_IsCreated(provider),
           _ => CRUD_Tbl_BIGINT_Table(nrRecs),
           _ => CRUD_Tbl_DATETIME_Table(nrRecs)
           ).RunAsync();
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
        TestOutput.WriteLine("tear down "+startDatabase.Name());
        await startDatabase.DisposeAsync();
    }
}
