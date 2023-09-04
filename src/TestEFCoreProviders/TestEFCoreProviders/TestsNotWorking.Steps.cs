namespace TestEFCoreProviders;
[Collection("NotInParallel")]
public partial class NotWorkingDateTime : FeatureFixture
{
    async Task Given_The_Database_IsCreated(EFCoreProvider provider)
    {
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

    async Task CRUD_Tbl_DATETIME_Table(int nr)
    {
        using (var db = await startDatabase.GetNewContext<SimpleTablesMultipleData>())
        {
            var data = Enumerable.Range(1, nr).Select(it => new Tbl_DATETIME()
            {
                DataColumn = DateTime.Now,
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
            data!.DataColumn!.Value.Should().BeBefore(DateTime.Now);
            data!.DataColumn!.Value.Should().BeAfter(DateTime.Now.AddMinutes(-1));
            await db.Tbl_DATETIMEDelete(data!.ID);
        }
        using (var db = await startDatabase.GetNewContext<SimpleTablesMultipleData>())
        {
            var nrRecs = await db.Tbl_DATETIMECount(null);
            nrRecs.Should().Be(nr - 1);
        }
        var dataM = new Tbl_DATETIME();
        dataM.ID = 3;
        dataM.DataColumn = DateTime.Now.AddDays(100);
        using (var db = await startDatabase.GetNewContext<SimpleTablesMultipleData>())
        {
            await db.Tbl_DATETIMEModify(dataM);
        }
        using (var db = await startDatabase.GetNewContext<SimpleTablesMultipleData>())
        {
            var verify = await db.Tbl_DATETIMEGetSingle(dataM.ID);
            verify.Should().NotBeNull();
            verify!.DataColumn!.Should().NotBeNull();
            verify!.DataColumn.Should().Be(dataM.DataColumn);

        }
    }
}