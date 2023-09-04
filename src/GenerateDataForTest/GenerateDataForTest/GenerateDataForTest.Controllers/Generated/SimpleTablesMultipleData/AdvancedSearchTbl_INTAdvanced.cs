//5.this was autogenerated by a tool. Do not modify! Use partial
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Generated;
[ApiController]
[Route("api/[controller]/[action]")]    
public partial class AdvancedSearch_SimpleTablesMultipleData_Tbl_INTController : Controller
{
    private ISearchDataTbl_INT _search;
    public AdvancedSearch_SimpleTablesMultipleData_Tbl_INTController(ISearchDataTbl_INT search)
	{
        _search=search;
	}
    [HttpGet]
    public async Task<long> GetAllCount()
    {
       return await _search.GetAllCount();
        
    }
    
    [HttpGet]
    public async IAsyncEnumerable<Tbl_INT_Table> GetAll()
    {
        await foreach(var item in _search.Tbl_INTFind_AsyncEnumerable(null))
        {
            yield return (Tbl_INT_Table)item!;
        }
        
    }
    [HttpGet]   
    public async IAsyncEnumerable<Tbl_INT_Table> GetSearchSimple(string ColumnName, string Operator, string Value){
           var search = new SearchTbl_INT();
           search.PageSize = int.MaxValue - 1;
        search.SearchFields = new SearchField<eTbl_INTColumns>[1];
        search.SearchFields[0]= new SearchField<eTbl_INTColumns>();
        if(Enum.TryParse< eTbl_INTColumns >(ColumnName,true ,out var valField)){
            search.SearchFields[0].FieldName = valField;
        }
        else
        {
            search.SearchFields[0].FieldName = (eTbl_INTColumns )int.Parse(ColumnName);;
        }
        search.SearchFields[0].Value= Value;
        var criteria= SearchCriteria.None;
        if(Enum.TryParse<SearchCriteria>(Operator,true,out var value))
        {
            criteria = value;
        }
        else
        {
            criteria = (SearchCriteria)int.Parse(Operator);
        }
        
        search.SearchFields[0].Criteria= criteria;
        await foreach (var item in _search.Tbl_INTFind_AsyncEnumerable(search))
        {
            yield return (Tbl_INT_Table)item!;
        }

    }
    [HttpGet]
    public async IAsyncEnumerable<Tbl_INT_Table> GetWithSearch(SearchTbl_INT s)
    {
        await foreach(var item in _search.Tbl_INTFind_AsyncEnumerable(s))
        {
            yield return (Tbl_INT_Table)item!;
        }
        
    }
    [HttpGet]
    public async Task<long> GetWithSearchCount(SearchTbl_INT? s)
    {
        if (s == null)
            return await GetAllCount();

        return await _search.GetAllCount(s);
    }

//has one key
    [HttpGet]
    public async Task<Tbl_INT_Table?> GetSingle(int id){
        var data=await _search.Tbl_INTGetSingle(id);
       if(data == null)
        return null;
       return (Tbl_INT_Table)data;
    }

        
    [HttpGet]
    public async IAsyncEnumerable<Tbl_INT_Table> ID_EqualValue( int  value)
    {
        var sc = GeneratorFromDB.SearchCriteria.Equal;
        await foreach (var item in _search.Tbl_INTSimpleSearch_ID(sc, value))
        {
            yield return (Tbl_INT_Table)item!;
        }
    }
    [HttpGet]
    public async IAsyncEnumerable<Tbl_INT_Table> ID_DifferentValue( int  value)
    {
        var sc = GeneratorFromDB.SearchCriteria.Different;
        await foreach (var item in _search.Tbl_INTSimpleSearch_ID(sc, value))
        {
            yield return (Tbl_INT_Table)item!;
        }
    }
    [HttpGet]
    public  async IAsyncEnumerable<Tbl_INT_Table> ID_SimpleSearch(GeneratorFromDB.SearchCriteria sc,  int value){
        await foreach(var item in _search.Tbl_INTSimpleSearch_ID(sc,value))
        {
            yield return (Tbl_INT_Table)item!;
        }
    }

         
     [HttpGet]
    public async IAsyncEnumerable<Tbl_INT_Table> ID_EqualValues( int[]  values)
    {
        string? value=null;
        if(values.Length>0)
            value=string.Join( ",",values);
        var sc=SearchTbl_INT.FromSearch(GeneratorFromDB.SearchCriteria.InArray,eTbl_INTColumns.ID,value);
        await foreach (var item in _search.Tbl_INTFind_AsyncEnumerable(sc))
        {
        
            yield return (Tbl_INT_Table)item!;
        }
    }
     [HttpGet]
    public async IAsyncEnumerable<Tbl_INT_Table> ID_DifferentValues( int[]  values)
    {
        string? value=null;
        if(values.Length>0)
            value=string.Join( ",",values);
        var sc=SearchTbl_INT.FromSearch(GeneratorFromDB.SearchCriteria.NotInArray,eTbl_INTColumns.ID,value);
        await foreach (var item in _search.Tbl_INTFind_AsyncEnumerable(sc))
        {
        
            yield return (Tbl_INT_Table)item!;
        }
    }
              [HttpGet]
    public async IAsyncEnumerable<Tbl_INT_Table> ID_LessOrEqual(int  val)
    {
        var sc = SearchTbl_INT.FromSearch(GeneratorFromDB.SearchCriteria.LessOrEqual, eTbl_INTColumns.ID  , val.ToString());
        await foreach (var item in _search.Tbl_INTFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_INT_Table)item!;
        }
    }
     [HttpGet]
    public async IAsyncEnumerable<Tbl_INT_Table> ID_Less(int  val)
    {
        var sc = SearchTbl_INT.FromSearch(GeneratorFromDB.SearchCriteria.Less, eTbl_INTColumns.ID  , val.ToString());
        await foreach (var item in _search.Tbl_INTFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_INT_Table)item!;
        }
    }
     
      [HttpGet]
    public async IAsyncEnumerable<Tbl_INT_Table> ID_GreaterOrEqual(int  val)
    {
        var sc = SearchTbl_INT.FromSearch(GeneratorFromDB.SearchCriteria.GreaterOrEqual, eTbl_INTColumns.ID  , val.ToString());
        await foreach (var item in _search.Tbl_INTFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_INT_Table)item!;
        }
    }
     [HttpGet]
    public async IAsyncEnumerable<Tbl_INT_Table> ID_Greater(int  val)
    {
        var sc = SearchTbl_INT.FromSearch(GeneratorFromDB.SearchCriteria.Greater, eTbl_INTColumns.ID  , val.ToString());
        await foreach (var item in _search.Tbl_INTFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_INT_Table)item!;
        }
    }
     [HttpGet]
    public async IAsyncEnumerable<Tbl_INT_Table> ID_Between( int  valStart, int valEnd)
    {
        var sc = SearchTbl_INT.FromSearch(GeneratorFromDB.SearchCriteria.Between, eTbl_INTColumns.ID, valStart +","+ valEnd);
        await foreach (var item in _search.Tbl_INTFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_INT_Table)item!;
        }
    }    

    [HttpGet]
    public async IAsyncEnumerable<Tbl_INT_Table> ID_NotBetween( int  valStart, int valEnd)
    {
        var sc = SearchTbl_INT.FromSearch(GeneratorFromDB.SearchCriteria.NotBetween, eTbl_INTColumns.ID, valStart +","+ valEnd);
        await foreach (var item in _search.Tbl_INTFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_INT_Table)item!;
        }
    }    

        
    [HttpGet]
    public async IAsyncEnumerable<Tbl_INT_Table> DataColumn_EqualValue( int?  value)
    {
        var sc = GeneratorFromDB.SearchCriteria.Equal;
        await foreach (var item in _search.Tbl_INTSimpleSearch_DataColumn(sc, value))
        {
            yield return (Tbl_INT_Table)item!;
        }
    }
    [HttpGet]
    public async IAsyncEnumerable<Tbl_INT_Table> DataColumn_DifferentValue( int?  value)
    {
        var sc = GeneratorFromDB.SearchCriteria.Different;
        await foreach (var item in _search.Tbl_INTSimpleSearch_DataColumn(sc, value))
        {
            yield return (Tbl_INT_Table)item!;
        }
    }
    [HttpGet]
    public  async IAsyncEnumerable<Tbl_INT_Table> DataColumn_SimpleSearch(GeneratorFromDB.SearchCriteria sc,  int? value){
        await foreach(var item in _search.Tbl_INTSimpleSearch_DataColumn(sc,value))
        {
            yield return (Tbl_INT_Table)item!;
        }
    }

        [HttpGet]
    public async IAsyncEnumerable<Tbl_INT_Table> DataColumn_FindNull(){
        var sc = GeneratorFromDB.SearchCriteria.Equal;
        await foreach(var item in _search.Tbl_INTSimpleSearchNull_DataColumn(sc))
        {
            yield return (Tbl_INT_Table)item!;
        }
    }
    [HttpGet]
    public async IAsyncEnumerable<Tbl_INT_Table> DataColumn_FindNotNull(){
        var sc = GeneratorFromDB.SearchCriteria.Different;
        await foreach(var item in _search.Tbl_INTSimpleSearchNull_DataColumn(sc))
        {
            yield return (Tbl_INT_Table)item!;
        }
    }
         
     [HttpGet]
    public async IAsyncEnumerable<Tbl_INT_Table> DataColumn_EqualValues( int?[]  values)
    {
        string? value=null;
        if(values.Length>0)
            value=string.Join( ",",values);
        var sc=SearchTbl_INT.FromSearch(GeneratorFromDB.SearchCriteria.InArray,eTbl_INTColumns.DataColumn,value);
        await foreach (var item in _search.Tbl_INTFind_AsyncEnumerable(sc))
        {
        
            yield return (Tbl_INT_Table)item!;
        }
    }
     [HttpGet]
    public async IAsyncEnumerable<Tbl_INT_Table> DataColumn_DifferentValues( int?[]  values)
    {
        string? value=null;
        if(values.Length>0)
            value=string.Join( ",",values);
        var sc=SearchTbl_INT.FromSearch(GeneratorFromDB.SearchCriteria.NotInArray,eTbl_INTColumns.DataColumn,value);
        await foreach (var item in _search.Tbl_INTFind_AsyncEnumerable(sc))
        {
        
            yield return (Tbl_INT_Table)item!;
        }
    }
              [HttpGet]
    public async IAsyncEnumerable<Tbl_INT_Table> DataColumn_LessOrEqual(int  val)
    {
        var sc = SearchTbl_INT.FromSearch(GeneratorFromDB.SearchCriteria.LessOrEqual, eTbl_INTColumns.DataColumn  , val.ToString());
        await foreach (var item in _search.Tbl_INTFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_INT_Table)item!;
        }
    }
     [HttpGet]
    public async IAsyncEnumerable<Tbl_INT_Table> DataColumn_Less(int  val)
    {
        var sc = SearchTbl_INT.FromSearch(GeneratorFromDB.SearchCriteria.Less, eTbl_INTColumns.DataColumn  , val.ToString());
        await foreach (var item in _search.Tbl_INTFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_INT_Table)item!;
        }
    }
     
      [HttpGet]
    public async IAsyncEnumerable<Tbl_INT_Table> DataColumn_GreaterOrEqual(int  val)
    {
        var sc = SearchTbl_INT.FromSearch(GeneratorFromDB.SearchCriteria.GreaterOrEqual, eTbl_INTColumns.DataColumn  , val.ToString());
        await foreach (var item in _search.Tbl_INTFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_INT_Table)item!;
        }
    }
     [HttpGet]
    public async IAsyncEnumerable<Tbl_INT_Table> DataColumn_Greater(int  val)
    {
        var sc = SearchTbl_INT.FromSearch(GeneratorFromDB.SearchCriteria.Greater, eTbl_INTColumns.DataColumn  , val.ToString());
        await foreach (var item in _search.Tbl_INTFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_INT_Table)item!;
        }
    }
     [HttpGet]
    public async IAsyncEnumerable<Tbl_INT_Table> DataColumn_Between( int  valStart, int valEnd)
    {
        var sc = SearchTbl_INT.FromSearch(GeneratorFromDB.SearchCriteria.Between, eTbl_INTColumns.DataColumn, valStart +","+ valEnd);
        await foreach (var item in _search.Tbl_INTFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_INT_Table)item!;
        }
    }    

    [HttpGet]
    public async IAsyncEnumerable<Tbl_INT_Table> DataColumn_NotBetween( int  valStart, int valEnd)
    {
        var sc = SearchTbl_INT.FromSearch(GeneratorFromDB.SearchCriteria.NotBetween, eTbl_INTColumns.DataColumn, valStart +","+ valEnd);
        await foreach (var item in _search.Tbl_INTFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_INT_Table)item!;
        }
    }    

            


    


}//end class
