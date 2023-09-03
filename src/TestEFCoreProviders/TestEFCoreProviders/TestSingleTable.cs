
//dotnet watch test --filter "DisplayName~Memory"
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
    
    [InlineData(EFCoreProvider.Microsoft_EntityFrameworkCore_In_Memory)]
    [InlineData(EFCoreProvider.Microsoft_EntityFrameworkCore_SqlServer)]
    [InlineData(EFCoreProvider.Microsoft_EntityFrameworkCore_Sqlite_File)]
    [InlineData(EFCoreProvider.Npgsql_EntityFrameworkCore_PostgreSQL)]
    [InlineData(EFCoreProvider.Pomelo_EntityFrameworkCore_MySql)]
    [InlineData(EFCoreProvider.MySql_EntityFrameworkCore)]
    //[InlineData(EFCoreProvider.Microsoft_EntityFrameworkCore_Cosmos)]
    public async Task CrudSimpleTable(EFCoreProvider provider)
    {
        var nrDeps = 5;
        string newName = Guid.NewGuid().ToString("N");

        await Runner
            .AddAsyncSteps(
            _ => Given_The_Database_IsCreated(provider),
            _=> Then_Number_Of_Dep_Are_Nr(0),
            _=> When_Creating_Nr_Departments(nrDeps),
            _=>Then_Number_Of_Dep_Are_Nr(nrDeps),
            _=> When_Deleting_Department_With_id(2),
            _=>Then_Number_Of_Dep_Are_Nr(nrDeps-1),
            _=> When_Modify_Department_With_id_and_name(nrDeps-1,newName),
            _=> Then_For_id_has_name(nrDeps-1,newName)

            )
            .RunAsync();
        

        //await Task.Delay(160_000);

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
    public async Task SearchSimpleTable(EFCoreProvider provider)
    {
        var nrDeps = 22;
        string newName = Guid.NewGuid().ToString("N");

        await Runner
            .AddAsyncSteps(
            _ => Given_The_Database_IsCreated(provider),
            _ => When_Creating_Nr_Departments(nrDeps),
            _ => When_Search_For_id1_and_id2_is_success(nrDeps-1,nrDeps-2),
             _ => When_Search_For_Id_That_Is_Criteria_Than_nr_the_results_number_are(1, GeneratorFromDB.SearchCriteria.Different, nrDeps-1),
             _ => When_Search_For_Id_That_Is_Criteria_Than_nr_the_results_number_are(nrDeps+100, GeneratorFromDB.SearchCriteria.Different, nrDeps),
            _ => When_Search_For_Id_That_Is_Criteria_Than_nr_the_results_number_are(1,GeneratorFromDB.SearchCriteria.GreaterOrEqual,nrDeps),
            _ => When_Search_For_Id_That_Is_Criteria_Than_nr_the_results_number_are(1, GeneratorFromDB.SearchCriteria.Greater, nrDeps-1),
            _ => When_Search_For_Id_That_Is_Criteria_Than_nr_the_results_number_are(1, GeneratorFromDB.SearchCriteria.Less, 0),
            _ => When_Search_For_Id_That_Is_Criteria_Than_nr_the_results_number_are(1, GeneratorFromDB.SearchCriteria.LessOrEqual, 1),
            _=> When_Search_For_Name_That_Is_Criteria_For_searchString_the_results_number_are("An",GeneratorFromDB.SearchCriteria.StartsWith,nrDeps),
            _ => When_Search_For_Name_That_Is_Criteria_For_searchString_the_results_number_are("XAn", GeneratorFromDB.SearchCriteria.StartsWith, 0),
            _ => When_Search_For_Name_That_Is_Criteria_For_searchString_the_results_number_are("Andrei 1", GeneratorFromDB.SearchCriteria.StartsWith, 1+10),
            _ => When_Search_For_Name_That_Is_Criteria_For_searchString_the_results_number_are("11", GeneratorFromDB.SearchCriteria.EndsWith, 1)
            


            )
            .RunAsync();
    }

        [Fact(Skip = "interface")]
    public async Task OnScenarioTearDown()
    {
        TestOutput.WriteLine("tear down ");
        await startDatabase.DisposeAsync();
    }
}