
using Microsoft.Data.Sqlite;

namespace TestEFCoreProviders;
public partial class TestSingleTable: FeatureFixture
{
    ApplicationDBContext? context=null;
    private SqliteConnection? _connection;//necessary for sqlite
    ApplicationDBContext ctx()
    {
        ArgumentNullException.ThrowIfNull(context);
        return context ;
    }
    async Task Given_The_Database_IsCreated(EFCoreProvider provider)
    {
        var con = await GetConnectionString(provider);
        StepExecution.Current.Comment($"connection string:{con}");
        context = GetContext<ApplicationDBContext>(con, provider);
        ArgumentNullException.ThrowIfNull(context);
        StepExecution.Current.Comment("before created");
        await context.Database.EnsureCreatedAsync();
        StepExecution.Current.Comment("after created");

    }
    async Task Then_Number_Of_Dep_Are_Nr(int nr)
    {
        (await ctx().DepartmentCount(null)).Should().Be(nr);  
    }
    async Task When_Creating_Nr_Departments(int nr)
    {
        var db = ctx();
        var deps = Enumerable.Range(1, nr).Select(it =>
        {
            var dep = new Department();
            dep.Name = $"Andrei {it}";
            return dep;
        }).ToArray();
        await db.DepartmentSaveMultiple(deps);
        
    }
    async Task When_Deleting_Department_With_id(int id)
    {
        var db = ctx();
        await db.DepartmentDelete(id);
    }


}