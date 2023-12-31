//5.this was autogenerated by a tool. Do not modify! Use partial
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Generated;
[ApiController]
[Route("api/[controller]/[action]")]    
public partial class AdvancedSearch_SimpleTablesMultipleData_Tbl_REALController : Controller
{
    private ISearchDataTbl_REAL _search;
    public AdvancedSearch_SimpleTablesMultipleData_Tbl_REALController(ISearchDataTbl_REAL search)
	{
        _search=search;
	}
    [HttpGet]
    public async Task<long> GetAllCount()
    {
       return await _search.GetAllCount();
        
    }
    
    [HttpGet]
    public async IAsyncEnumerable<Tbl_REAL_Table> GetAll()
    {
        await foreach(var item in _search.Tbl_REALFind_AsyncEnumerable(null))
        {
            yield return (Tbl_REAL_Table)item!;
        }
        
    }
    [HttpGet]   
    public async IAsyncEnumerable<Tbl_REAL_Table> GetSearchSimple(string ColumnName, string Operator, string Value){
           var search = new SearchTbl_REAL();
           search.PageSize = int.MaxValue - 1;
        search.SearchFields = new SearchField<eTbl_REALColumns>[1];
        search.SearchFields[0]= new SearchField<eTbl_REALColumns>();
        if(Enum.TryParse< eTbl_REALColumns >(ColumnName,true ,out var valField)){
            search.SearchFields[0].FieldName = valField;
        }
        else
        {
            search.SearchFields[0].FieldName = (eTbl_REALColumns )int.Parse(ColumnName);;
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
        await foreach (var item in _search.Tbl_REALFind_AsyncEnumerable(search))
        {
            yield return (Tbl_REAL_Table)item!;
        }

    }
    [HttpGet]
    public async IAsyncEnumerable<Tbl_REAL_Table> GetWithSearch(SearchTbl_REAL s)
    {
        await foreach(var item in _search.Tbl_REALFind_AsyncEnumerable(s))
        {
            yield return (Tbl_REAL_Table)item!;
        }
        
    }
    [HttpGet]
    public async Task<long> GetWithSearchCount(SearchTbl_REAL? s)
    {
        if (s == null)
            return await GetAllCount();

        return await _search.GetAllCount(s);
    }

//has one key
    [HttpGet]
    public async Task<Tbl_REAL_Table?> GetSingle(int id){
        var data=await _search.Tbl_REALGetSingle(id);
       if(data == null)
        return null;
       return (Tbl_REAL_Table)data;
    }

        
    [HttpGet]
    public async IAsyncEnumerable<Tbl_REAL_Table> ID_EqualValue( int  value)
    {
        var sc = GeneratorFromDB.SearchCriteria.Equal;
        await foreach (var item in _search.Tbl_REALSimpleSearch_ID(sc, value))
        {
            yield return (Tbl_REAL_Table)item!;
        }
    }
    [HttpGet]
    public async IAsyncEnumerable<Tbl_REAL_Table> ID_DifferentValue( int  value)
    {
        var sc = GeneratorFromDB.SearchCriteria.Different;
        await foreach (var item in _search.Tbl_REALSimpleSearch_ID(sc, value))
        {
            yield return (Tbl_REAL_Table)item!;
        }
    }
    [HttpGet]
    public  async IAsyncEnumerable<Tbl_REAL_Table> ID_SimpleSearch(GeneratorFromDB.SearchCriteria sc,  int value){
        await foreach(var item in _search.Tbl_REALSimpleSearch_ID(sc,value))
        {
            yield return (Tbl_REAL_Table)item!;
        }
    }

         
     [HttpGet]
    public async IAsyncEnumerable<Tbl_REAL_Table> ID_EqualValues( int[]  values)
    {
        string? value=null;
        if(values.Length>0)
            value=string.Join( ",",values);
        var sc=SearchTbl_REAL.FromSearch(GeneratorFromDB.SearchCriteria.InArray,eTbl_REALColumns.ID,value);
        await foreach (var item in _search.Tbl_REALFind_AsyncEnumerable(sc))
        {
        
            yield return (Tbl_REAL_Table)item!;
        }
    }
     [HttpGet]
    public async IAsyncEnumerable<Tbl_REAL_Table> ID_DifferentValues( int[]  values)
    {
        string? value=null;
        if(values.Length>0)
            value=string.Join( ",",values);
        var sc=SearchTbl_REAL.FromSearch(GeneratorFromDB.SearchCriteria.NotInArray,eTbl_REALColumns.ID,value);
        await foreach (var item in _search.Tbl_REALFind_AsyncEnumerable(sc))
        {
        
            yield return (Tbl_REAL_Table)item!;
        }
    }
              [HttpGet]
    public async IAsyncEnumerable<Tbl_REAL_Table> ID_LessOrEqual(int  val)
    {
        var sc = SearchTbl_REAL.FromSearch(GeneratorFromDB.SearchCriteria.LessOrEqual, eTbl_REALColumns.ID  , val.ToString());
        await foreach (var item in _search.Tbl_REALFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_REAL_Table)item!;
        }
    }
     [HttpGet]
    public async IAsyncEnumerable<Tbl_REAL_Table> ID_Less(int  val)
    {
        var sc = SearchTbl_REAL.FromSearch(GeneratorFromDB.SearchCriteria.Less, eTbl_REALColumns.ID  , val.ToString());
        await foreach (var item in _search.Tbl_REALFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_REAL_Table)item!;
        }
    }
     
      [HttpGet]
    public async IAsyncEnumerable<Tbl_REAL_Table> ID_GreaterOrEqual(int  val)
    {
        var sc = SearchTbl_REAL.FromSearch(GeneratorFromDB.SearchCriteria.GreaterOrEqual, eTbl_REALColumns.ID  , val.ToString());
        await foreach (var item in _search.Tbl_REALFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_REAL_Table)item!;
        }
    }
     [HttpGet]
    public async IAsyncEnumerable<Tbl_REAL_Table> ID_Greater(int  val)
    {
        var sc = SearchTbl_REAL.FromSearch(GeneratorFromDB.SearchCriteria.Greater, eTbl_REALColumns.ID  , val.ToString());
        await foreach (var item in _search.Tbl_REALFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_REAL_Table)item!;
        }
    }
     [HttpGet]
    public async IAsyncEnumerable<Tbl_REAL_Table> ID_Between( int  valStart, int valEnd)
    {
        var sc = SearchTbl_REAL.FromSearch(GeneratorFromDB.SearchCriteria.Between, eTbl_REALColumns.ID, valStart +","+ valEnd);
        await foreach (var item in _search.Tbl_REALFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_REAL_Table)item!;
        }
    }    

    [HttpGet]
    public async IAsyncEnumerable<Tbl_REAL_Table> ID_NotBetween( int  valStart, int valEnd)
    {
        var sc = SearchTbl_REAL.FromSearch(GeneratorFromDB.SearchCriteria.NotBetween, eTbl_REALColumns.ID, valStart +","+ valEnd);
        await foreach (var item in _search.Tbl_REALFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_REAL_Table)item!;
        }
    }    

        
    [HttpGet]
    public async IAsyncEnumerable<Tbl_REAL_Table> DataColumn_EqualValue( float?  value)
    {
        var sc = GeneratorFromDB.SearchCriteria.Equal;
        await foreach (var item in _search.Tbl_REALSimpleSearch_DataColumn(sc, value))
        {
            yield return (Tbl_REAL_Table)item!;
        }
    }
    [HttpGet]
    public async IAsyncEnumerable<Tbl_REAL_Table> DataColumn_DifferentValue( float?  value)
    {
        var sc = GeneratorFromDB.SearchCriteria.Different;
        await foreach (var item in _search.Tbl_REALSimpleSearch_DataColumn(sc, value))
        {
            yield return (Tbl_REAL_Table)item!;
        }
    }
    [HttpGet]
    public  async IAsyncEnumerable<Tbl_REAL_Table> DataColumn_SimpleSearch(GeneratorFromDB.SearchCriteria sc,  float? value){
        await foreach(var item in _search.Tbl_REALSimpleSearch_DataColumn(sc,value))
        {
            yield return (Tbl_REAL_Table)item!;
        }
    }

        [HttpGet]
    public async IAsyncEnumerable<Tbl_REAL_Table> DataColumn_FindNull(){
        var sc = GeneratorFromDB.SearchCriteria.Equal;
        await foreach(var item in _search.Tbl_REALSimpleSearchNull_DataColumn(sc))
        {
            yield return (Tbl_REAL_Table)item!;
        }
    }
    [HttpGet]
    public async IAsyncEnumerable<Tbl_REAL_Table> DataColumn_FindNotNull(){
        var sc = GeneratorFromDB.SearchCriteria.Different;
        await foreach(var item in _search.Tbl_REALSimpleSearchNull_DataColumn(sc))
        {
            yield return (Tbl_REAL_Table)item!;
        }
    }
         
     [HttpGet]
    public async IAsyncEnumerable<Tbl_REAL_Table> DataColumn_EqualValues( float?[]  values)
    {
        string? value=null;
        if(values.Length>0)
            value=string.Join( ",",values);
        var sc=SearchTbl_REAL.FromSearch(GeneratorFromDB.SearchCriteria.InArray,eTbl_REALColumns.DataColumn,value);
        await foreach (var item in _search.Tbl_REALFind_AsyncEnumerable(sc))
        {
        
            yield return (Tbl_REAL_Table)item!;
        }
    }
     [HttpGet]
    public async IAsyncEnumerable<Tbl_REAL_Table> DataColumn_DifferentValues( float?[]  values)
    {
        string? value=null;
        if(values.Length>0)
            value=string.Join( ",",values);
        var sc=SearchTbl_REAL.FromSearch(GeneratorFromDB.SearchCriteria.NotInArray,eTbl_REALColumns.DataColumn,value);
        await foreach (var item in _search.Tbl_REALFind_AsyncEnumerable(sc))
        {
        
            yield return (Tbl_REAL_Table)item!;
        }
    }
              [HttpGet]
    public async IAsyncEnumerable<Tbl_REAL_Table> DataColumn_LessOrEqual(float  val)
    {
        var sc = SearchTbl_REAL.FromSearch(GeneratorFromDB.SearchCriteria.LessOrEqual, eTbl_REALColumns.DataColumn  , val.ToString());
        await foreach (var item in _search.Tbl_REALFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_REAL_Table)item!;
        }
    }
     [HttpGet]
    public async IAsyncEnumerable<Tbl_REAL_Table> DataColumn_Less(float  val)
    {
        var sc = SearchTbl_REAL.FromSearch(GeneratorFromDB.SearchCriteria.Less, eTbl_REALColumns.DataColumn  , val.ToString());
        await foreach (var item in _search.Tbl_REALFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_REAL_Table)item!;
        }
    }
     
      [HttpGet]
    public async IAsyncEnumerable<Tbl_REAL_Table> DataColumn_GreaterOrEqual(float  val)
    {
        var sc = SearchTbl_REAL.FromSearch(GeneratorFromDB.SearchCriteria.GreaterOrEqual, eTbl_REALColumns.DataColumn  , val.ToString());
        await foreach (var item in _search.Tbl_REALFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_REAL_Table)item!;
        }
    }
     [HttpGet]
    public async IAsyncEnumerable<Tbl_REAL_Table> DataColumn_Greater(float  val)
    {
        var sc = SearchTbl_REAL.FromSearch(GeneratorFromDB.SearchCriteria.Greater, eTbl_REALColumns.DataColumn  , val.ToString());
        await foreach (var item in _search.Tbl_REALFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_REAL_Table)item!;
        }
    }
     [HttpGet]
    public async IAsyncEnumerable<Tbl_REAL_Table> DataColumn_Between( float  valStart, float valEnd)
    {
        var sc = SearchTbl_REAL.FromSearch(GeneratorFromDB.SearchCriteria.Between, eTbl_REALColumns.DataColumn, valStart +","+ valEnd);
        await foreach (var item in _search.Tbl_REALFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_REAL_Table)item!;
        }
    }    

    [HttpGet]
    public async IAsyncEnumerable<Tbl_REAL_Table> DataColumn_NotBetween( float  valStart, float valEnd)
    {
        var sc = SearchTbl_REAL.FromSearch(GeneratorFromDB.SearchCriteria.NotBetween, eTbl_REALColumns.DataColumn, valStart +","+ valEnd);
        await foreach (var item in _search.Tbl_REALFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_REAL_Table)item!;
        }
    }    

            


    


}//end class

