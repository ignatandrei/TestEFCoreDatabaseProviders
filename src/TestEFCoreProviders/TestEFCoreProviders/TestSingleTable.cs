using Xunit.Sdk;

namespace TestEFCoreProviders;
public partial class TestSingleTable:IScenarioTearDown
{
    StartDatabase startDatabase;
    public TestSingleTable()
    {
        startDatabase = new StartDatabase();
    }

    [Scenario]
    //[MultiAssert]
    //[InlineData(EFCoreProvider.Microsoft_EntityFrameworkCore_SqlServer)]
    //[InlineData(EFCoreProvider.Microsoft_EntityFrameworkCore_In_Memory)]
    //[InlineData(EFCoreProvider.Microsoft_EntityFrameworkCore_Sqlite_In_Memory)]
    //[InlineData(EFCoreProvider.Npgsql_EntityFrameworkCore_PostgreSQL)]
    //[InlineData(EFCoreProvider.Pomelo_EntityFrameworkCore_MySql)]
    //[InlineData(EFCoreProvider.MySql_EntityFrameworkCore)]
    [InlineData(EFCoreProvider.Microsoft_EntityFrameworkCore_Cosmos)]
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
        TestOutput.WriteLine("tear down ");
        await startDatabase.DisposeAsync();
    }
}