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
}

