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
    async Task When_Search_For_id1_and_id2_is_success(int id1,int id2)
    {
        var db = await ctx();
        var search =SearchDepartment.FromSearch(GeneratorFromDB.SearchCriteria.InArray, eDepartmentColumns.IDDepartment, $"{id1},{id2}");
        var data= await db.DepartmentFind_Array(search);
        data.Should().NotBeNull();
        data.Should().HaveCount(2);


    }
    async Task When_Search_For_Name_That_Is_Criteria_For_searchString_the_results_number_are(string  searchString, GeneratorFromDB.SearchCriteria criteria, int are)
    {
        var db = await ctx();
        var search = SearchDepartment.FromSearch(criteria, eDepartmentColumns.Name, searchString);
        var data = await db.DepartmentFind_Array(search);
        data.Should().NotBeNull();
        data.Should().HaveCount(are);


    }
    async Task When_Search_For_Id_That_Is_Criteria_Than_nr_the_results_number_are (int nr, GeneratorFromDB.SearchCriteria criteria,int are)
    {
        var db = await ctx();
        var search = SearchDepartment.FromSearch(criteria, eDepartmentColumns.IDDepartment, nr.ToString());
        var data = await db.DepartmentFind_Array(search);
        data.Should().NotBeNull();
        data.Should().HaveCount(are);


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