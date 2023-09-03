
using Microsoft.Data.Sqlite;
using System.Linq;

namespace TestEFCoreProviders;
public partial class TestSingleTable: FeatureFixture
{
    
    async Task<SimpleTableDBContext> ctx()
    {
        
        return await startDatabase.GetNewContext<SimpleTableDBContext>();
        
    }
    async Task Given_The_Database_IsCreated(EFCoreProvider provider)
    {
        string tables = string.Join(",",SimpleTableDBContext.metaData.TableNames);
        StepExecution.Current.Comment($"tables {tables}");
        foreach (var table in SimpleTableDBContext.metaData.Tables)
        {
            StepExecution.Current.Comment($"table {table.Name}");
            foreach(var col in table.Columns)
            {
                StepExecution.Current.Comment($"column => {col.Type} {col.Name} ");
            }
        }
        
        var context =await startDatabase.GetContext<SimpleTableDBContext>(provider);
        ArgumentNullException.ThrowIfNull(context);
        StepExecution.Current.Comment("before created");
        try
        {
            await context.Database.EnsureCreatedAsync();
        }
        catch (Exception ex)
        {
            TestOutput.WriteLine("!!!"+ex.ToString());
            //await Task.Delay(60_000);
            throw;
        }
        StepExecution.Current.Comment("after created");

    }
    async Task Then_Number_Of_Dep_Are_Nr(int nr)
    {
        using var context = await ctx();
        (await context.DepartmentCount(null)).Should().Be(nr);  
    }
    async Task When_Creating_Nr_Departments(int nr)
    {
        var db = await ctx();
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
        var db = await ctx();
        await db.DepartmentDelete(id);
    }

    async Task When_Modify_Department_With_id_and_name(int id, string name)
    {
        using var db = await ctx();
        
        var dep=new Department();
        dep.IDDepartment= id;
        dep.Name= name;
        await db.DepartmentModify(dep);
    }
    async Task Then_For_id_has_name(int id, string name)
    {
        using var db = await ctx();
        var dep=await db.DepartmentGetSingle(id);
        dep.Should().NotBeNull();
        dep!.Name.Should().Be(name);
        
    }




}