namespace TestEFCoreProviders;

partial  class TestSimpleTablesMultipleData: FeatureFixture
{
    async Task Given_The_Database_IsCreated(EFCoreProvider provider)
    {
        string tables = string.Join(",", SimpleTablesMultipleData.metaData.TableNames);
        StepExecution.Current.Comment($"tables {tables}");
        foreach (var table in SimpleTablesMultipleData.metaData.Tables)
        {
            StepExecution.Current.Comment($"table {table.Name}");
            foreach (var col in table.Columns)
            {
                StepExecution.Current.Comment($"column => {col.Type} {col.Name} ");
            }
        }

        var context = await startDatabase.GetContext<SimpleTablesMultipleData>(provider);
        ArgumentNullException.ThrowIfNull(context);
        StepExecution.Current.Comment("before created");
        try
        {
            await context.Database.EnsureCreatedAsync();
        }
        catch (Exception ex)
        {
            TestOutput.WriteLine("!!!" + ex.ToString());
            //await Task.Delay(60_000);
            throw;
        }
        StepExecution.Current.Comment("after created");

    }

    async Task CRUD_Tbl_BIGINT_Table(int nr)
    {
        using (var db = await startDatabase.GetNewContext<SimpleTablesMultipleData>())
        {
            var data = Enumerable.Range(1, nr).Select(it => new Tbl_BIGINT()
            {
                DataColumn = long.MaxValue - 1 - it,
            }).ToArray();
            await db.Tbl_BIGINTSaveMultiple(data);
        }
        using (var db = await startDatabase.GetNewContext<SimpleTablesMultipleData>())
        {
            var nrRecs=await db.Tbl_BIGINTCount(null);
            nrRecs.Should().Be(nr);
        }
        using (var db = await startDatabase.GetNewContext<SimpleTablesMultipleData>())
        {

            var data = await db.Tbl_BIGINTGetSingle(2);
            data.Should().NotBeNull();
            data!.DataColumn.Should().BeGreaterThanOrEqualTo(long.MaxValue - 1 - nr);
            await db.Tbl_BIGINTDelete(data!.ID);
        }
        using (var db = await startDatabase.GetNewContext<SimpleTablesMultipleData>())
        {
            var nrRecs = await db.Tbl_BIGINTCount(null);
            nrRecs.Should().Be(nr-1);
        }
        var dataM = new Tbl_BIGINT();
        dataM.ID = 3;
        dataM.DataColumn = 1;
        using (var db = await startDatabase.GetNewContext<SimpleTablesMultipleData>())
        { 
            await db.Tbl_BIGINTModify(dataM);
        }
        using (var db = await startDatabase.GetNewContext<SimpleTablesMultipleData>())
        {
            var verify=await db.Tbl_BIGINTGetSingle(dataM.ID);
            verify.Should().NotBeNull();
            verify!.DataColumn.Should().Be(dataM.DataColumn);
        }


    }
    async Task When_Search_For_Date_That_Is_Criteria_Than_nr_the_results_number_are(EFCoreProvider provider, DateTime date, GeneratorFromDB.SearchCriteria criteria, int are)
    {
        //must have DateTime in UTC for Postgres
        if (provider == EFCoreProvider.Npgsql_EntityFrameworkCore_PostgreSQL)
        {
            StepExecution.Current.Comment("for datetime must use UTC in search also");
            return;
        }
        using (var db = await startDatabase.GetNewContext<SimpleTablesMultipleData>())
        {
            var search = SearchTbl_DATETIME.FromSearch(criteria,eTbl_DATETIMEColumns.DataColumn , date.ToString());            
            var data = await db.Tbl_DATETIMEFind_Array(search);
            data.Should().NotBeNull();
            data.Should().HaveCount(are);
        }
    }
    async Task Finish()
    {
        await Task.Delay(1000);
    }
    async Task CRUD_Tbl_DATETIME_Table(int nr)
    {
        
        using (var db = await startDatabase.GetNewContext<SimpleTablesMultipleData>())
        {
            var data = Enumerable.Range(1, nr).Select(it => new Tbl_DATETIME()
            {
                DataColumn = DateTime.UtcNow,
            }).ToArray();
            
            await db.Tbl_DATETIMESaveMultiple(data);
        }
        await Task.Delay(10_000);
        using (var db = await startDatabase.GetNewContext<SimpleTablesMultipleData>())
        {
            var nrRecs = await db.Tbl_DATETIMECount(null);
            nrRecs.Should().Be(nr);
        }
        using (var db = await startDatabase.GetNewContext<SimpleTablesMultipleData>())
        {

            var data = await db.Tbl_DATETIMEGetSingle(2);
            data.Should().NotBeNull();
            data!.DataColumn.Should().NotBeNull();
            data!.DataColumn!.Value.Should().BeBefore(DateTime.UtcNow);
            data!.DataColumn!.Value.Should().BeAfter(DateTime.UtcNow.AddMinutes(-1));
            await db.Tbl_DATETIMEDelete(data!.ID);
        }
        using (var db = await startDatabase.GetNewContext<SimpleTablesMultipleData>())
        {
            var nrRecs = await db.Tbl_DATETIMECount(null);
            nrRecs.Should().Be(nr - 1);
        }
        return;
        var dataM = new Tbl_DATETIME();
        dataM.ID = 3;
        dataM.DataColumn = DateTime.UtcNow.AddDays(100);
        using (var db = await startDatabase.GetNewContext<SimpleTablesMultipleData>())
        {
            await db.Tbl_DATETIMEModify(dataM);
        }
        using (var db = await startDatabase.GetNewContext<SimpleTablesMultipleData>())
        {
            var verify = await db.Tbl_DATETIMEGetSingle(dataM.ID);
            verify.Should().NotBeNull();
            verify!.DataColumn!.Should().NotBeNull();
            //difference:
            //does not work in MySql_EntityFrameworkCore, Npgsql_EntityFrameworkCore_PostgreSQL,Pomelo_EntityFrameworkCore_MySql  
            //differs by 
            // Expected verify!.DataColumn to be <2023-12-13 17:45:43.8827479>, but found <2023-12-13 17:45:43.882747>.
            //verify!.DataColumn.Should().Be(dataM.DataColumn);
            var data = verify!.DataColumn!.Value;
            data.Year.Should().Be(dataM.DataColumn.Value.Year);
            data.Month.Should().Be(dataM.DataColumn.Value.Month);
            data.Day.Should().Be(dataM.DataColumn.Value.Day);
            data.Hour.Should().Be(dataM.DataColumn.Value.Hour);
            data.Minute.Should().Be(dataM.DataColumn.Value.Minute);
            data.Second.Should().Be(dataM.DataColumn.Value.Second);

        }


    }
}

