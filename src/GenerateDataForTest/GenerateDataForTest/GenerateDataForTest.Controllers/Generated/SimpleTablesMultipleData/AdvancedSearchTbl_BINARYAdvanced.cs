//5.this was autogenerated by a tool. Do not modify! Use partial
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Generated;
[ApiController]
[Route("api/[controller]/[action]")]    
public partial class AdvancedSearch_SimpleTablesMultipleData_Tbl_BINARYController : Controller
{
    private ISearchDataTbl_BINARY _search;
    public AdvancedSearch_SimpleTablesMultipleData_Tbl_BINARYController(ISearchDataTbl_BINARY search)
	{
        _search=search;
	}
    [HttpGet]
    public async Task<long> GetAllCount()
    {
       return await _search.GetAllCount();
        
    }
    
    [HttpGet]
    public async IAsyncEnumerable<Tbl_BINARY_Table> GetAll()
    {
        await foreach(var item in _search.Tbl_BINARYFind_AsyncEnumerable(null))
        {
            yield return (Tbl_BINARY_Table)item!;
        }
        
    }
    [HttpGet]   
    public async IAsyncEnumerable<Tbl_BINARY_Table> GetSearchSimple(string ColumnName, string Operator, string Value){
           var search = new SearchTbl_BINARY();
           search.PageSize = int.MaxValue - 1;
        search.SearchFields = new SearchField<eTbl_BINARYColumns>[1];
        search.SearchFields[0]= new SearchField<eTbl_BINARYColumns>();
        if(Enum.TryParse< eTbl_BINARYColumns >(ColumnName,true ,out var valField)){
            search.SearchFields[0].FieldName = valField;
        }
        else
        {
            search.SearchFields[0].FieldName = (eTbl_BINARYColumns )int.Parse(ColumnName);;
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
        await foreach (var item in _search.Tbl_BINARYFind_AsyncEnumerable(search))
        {
            yield return (Tbl_BINARY_Table)item!;
        }

    }
    [HttpGet]
    public async IAsyncEnumerable<Tbl_BINARY_Table> GetWithSearch(SearchTbl_BINARY s)
    {
        await foreach(var item in _search.Tbl_BINARYFind_AsyncEnumerable(s))
        {
            yield return (Tbl_BINARY_Table)item!;
        }
        
    }
    [HttpGet]
    public async Task<long> GetWithSearchCount(SearchTbl_BINARY? s)
    {
        if (s == null)
            return await GetAllCount();

        return await _search.GetAllCount(s);
    }

//has one key
    [HttpGet]
    public async Task<Tbl_BINARY_Table?> GetSingle(int id){
        var data=await _search.Tbl_BINARYGetSingle(id);
       if(data == null)
        return null;
       return (Tbl_BINARY_Table)data;
    }

        
    [HttpGet]
    public async IAsyncEnumerable<Tbl_BINARY_Table> ID_EqualValue( int  value)
    {
        var sc = GeneratorFromDB.SearchCriteria.Equal;
        await foreach (var item in _search.Tbl_BINARYSimpleSearch_ID(sc, value))
        {
            yield return (Tbl_BINARY_Table)item!;
        }
    }
    [HttpGet]
    public async IAsyncEnumerable<Tbl_BINARY_Table> ID_DifferentValue( int  value)
    {
        var sc = GeneratorFromDB.SearchCriteria.Different;
        await foreach (var item in _search.Tbl_BINARYSimpleSearch_ID(sc, value))
        {
            yield return (Tbl_BINARY_Table)item!;
        }
    }
    [HttpGet]
    public  async IAsyncEnumerable<Tbl_BINARY_Table> ID_SimpleSearch(GeneratorFromDB.SearchCriteria sc,  int value){
        await foreach(var item in _search.Tbl_BINARYSimpleSearch_ID(sc,value))
        {
            yield return (Tbl_BINARY_Table)item!;
        }
    }

         
     [HttpGet]
    public async IAsyncEnumerable<Tbl_BINARY_Table> ID_EqualValues( int[]  values)
    {
        string? value=null;
        if(values.Length>0)
            value=string.Join( ",",values);
        var sc=SearchTbl_BINARY.FromSearch(GeneratorFromDB.SearchCriteria.InArray,eTbl_BINARYColumns.ID,value);
        await foreach (var item in _search.Tbl_BINARYFind_AsyncEnumerable(sc))
        {
        
            yield return (Tbl_BINARY_Table)item!;
        }
    }
     [HttpGet]
    public async IAsyncEnumerable<Tbl_BINARY_Table> ID_DifferentValues( int[]  values)
    {
        string? value=null;
        if(values.Length>0)
            value=string.Join( ",",values);
        var sc=SearchTbl_BINARY.FromSearch(GeneratorFromDB.SearchCriteria.NotInArray,eTbl_BINARYColumns.ID,value);
        await foreach (var item in _search.Tbl_BINARYFind_AsyncEnumerable(sc))
        {
        
            yield return (Tbl_BINARY_Table)item!;
        }
    }
              [HttpGet]
    public async IAsyncEnumerable<Tbl_BINARY_Table> ID_LessOrEqual(int  val)
    {
        var sc = SearchTbl_BINARY.FromSearch(GeneratorFromDB.SearchCriteria.LessOrEqual, eTbl_BINARYColumns.ID  , val.ToString());
        await foreach (var item in _search.Tbl_BINARYFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_BINARY_Table)item!;
        }
    }
     [HttpGet]
    public async IAsyncEnumerable<Tbl_BINARY_Table> ID_Less(int  val)
    {
        var sc = SearchTbl_BINARY.FromSearch(GeneratorFromDB.SearchCriteria.Less, eTbl_BINARYColumns.ID  , val.ToString());
        await foreach (var item in _search.Tbl_BINARYFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_BINARY_Table)item!;
        }
    }
     
      [HttpGet]
    public async IAsyncEnumerable<Tbl_BINARY_Table> ID_GreaterOrEqual(int  val)
    {
        var sc = SearchTbl_BINARY.FromSearch(GeneratorFromDB.SearchCriteria.GreaterOrEqual, eTbl_BINARYColumns.ID  , val.ToString());
        await foreach (var item in _search.Tbl_BINARYFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_BINARY_Table)item!;
        }
    }
     [HttpGet]
    public async IAsyncEnumerable<Tbl_BINARY_Table> ID_Greater(int  val)
    {
        var sc = SearchTbl_BINARY.FromSearch(GeneratorFromDB.SearchCriteria.Greater, eTbl_BINARYColumns.ID  , val.ToString());
        await foreach (var item in _search.Tbl_BINARYFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_BINARY_Table)item!;
        }
    }
     [HttpGet]
    public async IAsyncEnumerable<Tbl_BINARY_Table> ID_Between( int  valStart, int valEnd)
    {
        var sc = SearchTbl_BINARY.FromSearch(GeneratorFromDB.SearchCriteria.Between, eTbl_BINARYColumns.ID, valStart +","+ valEnd);
        await foreach (var item in _search.Tbl_BINARYFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_BINARY_Table)item!;
        }
    }    

    [HttpGet]
    public async IAsyncEnumerable<Tbl_BINARY_Table> ID_NotBetween( int  valStart, int valEnd)
    {
        var sc = SearchTbl_BINARY.FromSearch(GeneratorFromDB.SearchCriteria.NotBetween, eTbl_BINARYColumns.ID, valStart +","+ valEnd);
        await foreach (var item in _search.Tbl_BINARYFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_BINARY_Table)item!;
        }
    }    

        
    [HttpGet]
    public async IAsyncEnumerable<Tbl_BINARY_Table> DataColumn_EqualValue( byte[]  value)
    {
        var sc = GeneratorFromDB.SearchCriteria.Equal;
        await foreach (var item in _search.Tbl_BINARYSimpleSearch_DataColumn(sc, value))
        {
            yield return (Tbl_BINARY_Table)item!;
        }
    }
    [HttpGet]
    public async IAsyncEnumerable<Tbl_BINARY_Table> DataColumn_DifferentValue( byte[]  value)
    {
        var sc = GeneratorFromDB.SearchCriteria.Different;
        await foreach (var item in _search.Tbl_BINARYSimpleSearch_DataColumn(sc, value))
        {
            yield return (Tbl_BINARY_Table)item!;
        }
    }
    [HttpGet]
    public  async IAsyncEnumerable<Tbl_BINARY_Table> DataColumn_SimpleSearch(GeneratorFromDB.SearchCriteria sc,  byte[] value){
        await foreach(var item in _search.Tbl_BINARYSimpleSearch_DataColumn(sc,value))
        {
            yield return (Tbl_BINARY_Table)item!;
        }
    }

        [HttpGet]
    public async IAsyncEnumerable<Tbl_BINARY_Table> DataColumn_FindNull(){
        var sc = GeneratorFromDB.SearchCriteria.Equal;
        await foreach(var item in _search.Tbl_BINARYSimpleSearchNull_DataColumn(sc))
        {
            yield return (Tbl_BINARY_Table)item!;
        }
    }
    [HttpGet]
    public async IAsyncEnumerable<Tbl_BINARY_Table> DataColumn_FindNotNull(){
        var sc = GeneratorFromDB.SearchCriteria.Different;
        await foreach(var item in _search.Tbl_BINARYSimpleSearchNull_DataColumn(sc))
        {
            yield return (Tbl_BINARY_Table)item!;
        }
    }
             


    


}//end class

