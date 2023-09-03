
using Microsoft.Data.Sqlite;
using System.Linq;

namespace TestEFCoreProviders;
public partial class TestSingleTable: FeatureFixture
{
    SimpleTableDBContext? context = null;
    SimpleTableDBContext ctx()
    {
        ArgumentNullException.ThrowIfNull(context);
        return context ;
    }
    async Task Given_The_Database_IsCreated(EFCoreProvider provider)
    {
        string tables = string.Join(",",SimpleTableDBContext.metaData.TableNames);
        StepExecution.Current.Comment($"tables {tables}");        
        context =await startDatabase.GetContext<SimpleTableDBContext>(provider);
        ArgumentNullException.ThrowIfNull(context);
        StepExecution.Current.Comment("before created");
        try
        {
            await context.Database.EnsureCreatedAsync();
        }
        catch (Exception ex)
        {
            TestOutput.WriteLine("!!!"+ex.ToString());
            await Task.Delay(60_000);
            throw;
        }
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