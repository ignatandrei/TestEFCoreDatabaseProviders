//5.this was autogenerated by a tool. Do not modify! Use partial
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Generated;
[ApiController]
[Route("api/[controller]/[action]")]    
public partial class AdvancedSearch_SimpleTablesMultipleData_Tbl_XMLController : Controller
{
    private ISearchDataTbl_XML _search;
    public AdvancedSearch_SimpleTablesMultipleData_Tbl_XMLController(ISearchDataTbl_XML search)
	{
        _search=search;
	}
    [HttpGet]
    public async Task<long> GetAllCount()
    {
       return await _search.GetAllCount();
        
    }
    
    [HttpGet]
    public async IAsyncEnumerable<Tbl_XML_Table> GetAll()
    {
        await foreach(var item in _search.Tbl_XMLFind_AsyncEnumerable(null))
        {
            yield return (Tbl_XML_Table)item!;
        }
        
    }
    [HttpGet]   
    public async IAsyncEnumerable<Tbl_XML_Table> GetSearchSimple(string ColumnName, string Operator, string Value){
           var search = new SearchTbl_XML();
           search.PageSize = int.MaxValue - 1;
        search.SearchFields = new SearchField<eTbl_XMLColumns>[1];
        search.SearchFields[0]= new SearchField<eTbl_XMLColumns>();
        if(Enum.TryParse< eTbl_XMLColumns >(ColumnName,true ,out var valField)){
            search.SearchFields[0].FieldName = valField;
        }
        else
        {
            search.SearchFields[0].FieldName = (eTbl_XMLColumns )int.Parse(ColumnName);;
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
        await foreach (var item in _search.Tbl_XMLFind_AsyncEnumerable(search))
        {
            yield return (Tbl_XML_Table)item!;
        }

    }
    [HttpGet]
    public async IAsyncEnumerable<Tbl_XML_Table> GetWithSearch(SearchTbl_XML s)
    {
        await foreach(var item in _search.Tbl_XMLFind_AsyncEnumerable(s))
        {
            yield return (Tbl_XML_Table)item!;
        }
        
    }
    [HttpGet]
    public async Task<long> GetWithSearchCount(SearchTbl_XML? s)
    {
        if (s == null)
            return await GetAllCount();

        return await _search.GetAllCount(s);
    }

//has one key
    [HttpGet]
    public async Task<Tbl_XML_Table?> GetSingle(int id){
        var data=await _search.Tbl_XMLGetSingle(id);
       if(data == null)
        return null;
       return (Tbl_XML_Table)data;
    }

        
    [HttpGet]
    public async IAsyncEnumerable<Tbl_XML_Table> ID_EqualValue( int  value)
    {
        var sc = GeneratorFromDB.SearchCriteria.Equal;
        await foreach (var item in _search.Tbl_XMLSimpleSearch_ID(sc, value))
        {
            yield return (Tbl_XML_Table)item!;
        }
    }
    [HttpGet]
    public async IAsyncEnumerable<Tbl_XML_Table> ID_DifferentValue( int  value)
    {
        var sc = GeneratorFromDB.SearchCriteria.Different;
        await foreach (var item in _search.Tbl_XMLSimpleSearch_ID(sc, value))
        {
            yield return (Tbl_XML_Table)item!;
        }
    }
    [HttpGet]
    public  async IAsyncEnumerable<Tbl_XML_Table> ID_SimpleSearch(GeneratorFromDB.SearchCriteria sc,  int value){
        await foreach(var item in _search.Tbl_XMLSimpleSearch_ID(sc,value))
        {
            yield return (Tbl_XML_Table)item!;
        }
    }

         
     [HttpGet]
    public async IAsyncEnumerable<Tbl_XML_Table> ID_EqualValues( int[]  values)
    {
        string? value=null;
        if(values.Length>0)
            value=string.Join( ",",values);
        var sc=SearchTbl_XML.FromSearch(GeneratorFromDB.SearchCriteria.InArray,eTbl_XMLColumns.ID,value);
        await foreach (var item in _search.Tbl_XMLFind_AsyncEnumerable(sc))
        {
        
            yield return (Tbl_XML_Table)item!;
        }
    }
     [HttpGet]
    public async IAsyncEnumerable<Tbl_XML_Table> ID_DifferentValues( int[]  values)
    {
        string? value=null;
        if(values.Length>0)
            value=string.Join( ",",values);
        var sc=SearchTbl_XML.FromSearch(GeneratorFromDB.SearchCriteria.NotInArray,eTbl_XMLColumns.ID,value);
        await foreach (var item in _search.Tbl_XMLFind_AsyncEnumerable(sc))
        {
        
            yield return (Tbl_XML_Table)item!;
        }
    }
              [HttpGet]
    public async IAsyncEnumerable<Tbl_XML_Table> ID_LessOrEqual(int  val)
    {
        var sc = SearchTbl_XML.FromSearch(GeneratorFromDB.SearchCriteria.LessOrEqual, eTbl_XMLColumns.ID  , val.ToString());
        await foreach (var item in _search.Tbl_XMLFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_XML_Table)item!;
        }
    }
     [HttpGet]
    public async IAsyncEnumerable<Tbl_XML_Table> ID_Less(int  val)
    {
        var sc = SearchTbl_XML.FromSearch(GeneratorFromDB.SearchCriteria.Less, eTbl_XMLColumns.ID  , val.ToString());
        await foreach (var item in _search.Tbl_XMLFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_XML_Table)item!;
        }
    }
     
      [HttpGet]
    public async IAsyncEnumerable<Tbl_XML_Table> ID_GreaterOrEqual(int  val)
    {
        var sc = SearchTbl_XML.FromSearch(GeneratorFromDB.SearchCriteria.GreaterOrEqual, eTbl_XMLColumns.ID  , val.ToString());
        await foreach (var item in _search.Tbl_XMLFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_XML_Table)item!;
        }
    }
     [HttpGet]
    public async IAsyncEnumerable<Tbl_XML_Table> ID_Greater(int  val)
    {
        var sc = SearchTbl_XML.FromSearch(GeneratorFromDB.SearchCriteria.Greater, eTbl_XMLColumns.ID  , val.ToString());
        await foreach (var item in _search.Tbl_XMLFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_XML_Table)item!;
        }
    }
     [HttpGet]
    public async IAsyncEnumerable<Tbl_XML_Table> ID_Between( int  valStart, int valEnd)
    {
        var sc = SearchTbl_XML.FromSearch(GeneratorFromDB.SearchCriteria.Between, eTbl_XMLColumns.ID, valStart +","+ valEnd);
        await foreach (var item in _search.Tbl_XMLFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_XML_Table)item!;
        }
    }    

    [HttpGet]
    public async IAsyncEnumerable<Tbl_XML_Table> ID_NotBetween( int  valStart, int valEnd)
    {
        var sc = SearchTbl_XML.FromSearch(GeneratorFromDB.SearchCriteria.NotBetween, eTbl_XMLColumns.ID, valStart +","+ valEnd);
        await foreach (var item in _search.Tbl_XMLFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_XML_Table)item!;
        }
    }    

        
    [HttpGet]
    public async IAsyncEnumerable<Tbl_XML_Table> DataColumn_EqualValue( string  value)
    {
        var sc = GeneratorFromDB.SearchCriteria.Equal;
        await foreach (var item in _search.Tbl_XMLSimpleSearch_DataColumn(sc, value))
        {
            yield return (Tbl_XML_Table)item!;
        }
    }
    [HttpGet]
    public async IAsyncEnumerable<Tbl_XML_Table> DataColumn_DifferentValue( string  value)
    {
        var sc = GeneratorFromDB.SearchCriteria.Different;
        await foreach (var item in _search.Tbl_XMLSimpleSearch_DataColumn(sc, value))
        {
            yield return (Tbl_XML_Table)item!;
        }
    }
    [HttpGet]
    public  async IAsyncEnumerable<Tbl_XML_Table> DataColumn_SimpleSearch(GeneratorFromDB.SearchCriteria sc,  string value){
        await foreach(var item in _search.Tbl_XMLSimpleSearch_DataColumn(sc,value))
        {
            yield return (Tbl_XML_Table)item!;
        }
    }

        [HttpGet]
    public async IAsyncEnumerable<Tbl_XML_Table> DataColumn_FindNull(){
        var sc = GeneratorFromDB.SearchCriteria.Equal;
        await foreach(var item in _search.Tbl_XMLSimpleSearchNull_DataColumn(sc))
        {
            yield return (Tbl_XML_Table)item!;
        }
    }
    [HttpGet]
    public async IAsyncEnumerable<Tbl_XML_Table> DataColumn_FindNotNull(){
        var sc = GeneratorFromDB.SearchCriteria.Different;
        await foreach(var item in _search.Tbl_XMLSimpleSearchNull_DataColumn(sc))
        {
            yield return (Tbl_XML_Table)item!;
        }
    }
         
     [HttpGet]
    public async IAsyncEnumerable<Tbl_XML_Table> DataColumn_EqualValues( string[]  values)
    {
        string? value=null;
        if(values.Length>0)
            value=string.Join( ",",values);
        var sc=SearchTbl_XML.FromSearch(GeneratorFromDB.SearchCriteria.InArray,eTbl_XMLColumns.DataColumn,value);
        await foreach (var item in _search.Tbl_XMLFind_AsyncEnumerable(sc))
        {
        
            yield return (Tbl_XML_Table)item!;
        }
    }
     [HttpGet]
    public async IAsyncEnumerable<Tbl_XML_Table> DataColumn_DifferentValues( string[]  values)
    {
        string? value=null;
        if(values.Length>0)
            value=string.Join( ",",values);
        var sc=SearchTbl_XML.FromSearch(GeneratorFromDB.SearchCriteria.NotInArray,eTbl_XMLColumns.DataColumn,value);
        await foreach (var item in _search.Tbl_XMLFind_AsyncEnumerable(sc))
        {
        
            yield return (Tbl_XML_Table)item!;
        }
    }
         [HttpGet]
    public async IAsyncEnumerable<Tbl_XML_Table> DataColumn_Contains(string  val)
    {
        var sc = SearchTbl_XML.FromSearch(GeneratorFromDB.SearchCriteria.Contains, eTbl_XMLColumns.DataColumn  , val);
        await foreach (var item in _search.Tbl_XMLFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_XML_Table)item!;
        }
    }

     [HttpGet]
    public async IAsyncEnumerable<Tbl_XML_Table> DataColumn_EndsWith(string  val)
    {
        var sc = SearchTbl_XML.FromSearch(GeneratorFromDB.SearchCriteria.EndsWith, eTbl_XMLColumns.DataColumn  , val);
        await foreach (var item in _search.Tbl_XMLFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_XML_Table)item!;
        }
    }

      [HttpGet]
    public async IAsyncEnumerable<Tbl_XML_Table> DataColumn_StartsWith(string  val)
    {
        var sc = SearchTbl_XML.FromSearch(GeneratorFromDB.SearchCriteria.StartsWith, eTbl_XMLColumns.DataColumn  , val);
        await foreach (var item in _search.Tbl_XMLFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_XML_Table)item!;
        }
    }


              [HttpGet]
    public async IAsyncEnumerable<Tbl_XML_Table> DataColumn_LessOrEqual(string  val)
    {
        var sc = SearchTbl_XML.FromSearch(GeneratorFromDB.SearchCriteria.LessOrEqual, eTbl_XMLColumns.DataColumn  , val.ToString());
        await foreach (var item in _search.Tbl_XMLFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_XML_Table)item!;
        }
    }
     [HttpGet]
    public async IAsyncEnumerable<Tbl_XML_Table> DataColumn_Less(string  val)
    {
        var sc = SearchTbl_XML.FromSearch(GeneratorFromDB.SearchCriteria.Less, eTbl_XMLColumns.DataColumn  , val.ToString());
        await foreach (var item in _search.Tbl_XMLFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_XML_Table)item!;
        }
    }
     
      [HttpGet]
    public async IAsyncEnumerable<Tbl_XML_Table> DataColumn_GreaterOrEqual(string  val)
    {
        var sc = SearchTbl_XML.FromSearch(GeneratorFromDB.SearchCriteria.GreaterOrEqual, eTbl_XMLColumns.DataColumn  , val.ToString());
        await foreach (var item in _search.Tbl_XMLFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_XML_Table)item!;
        }
    }
     [HttpGet]
    public async IAsyncEnumerable<Tbl_XML_Table> DataColumn_Greater(string  val)
    {
        var sc = SearchTbl_XML.FromSearch(GeneratorFromDB.SearchCriteria.Greater, eTbl_XMLColumns.DataColumn  , val.ToString());
        await foreach (var item in _search.Tbl_XMLFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_XML_Table)item!;
        }
    }
     [HttpGet]
    public async IAsyncEnumerable<Tbl_XML_Table> DataColumn_Between( string  valStart, string valEnd)
    {
        var sc = SearchTbl_XML.FromSearch(GeneratorFromDB.SearchCriteria.Between, eTbl_XMLColumns.DataColumn, valStart +","+ valEnd);
        await foreach (var item in _search.Tbl_XMLFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_XML_Table)item!;
        }
    }    

    [HttpGet]
    public async IAsyncEnumerable<Tbl_XML_Table> DataColumn_NotBetween( string  valStart, string valEnd)
    {
        var sc = SearchTbl_XML.FromSearch(GeneratorFromDB.SearchCriteria.NotBetween, eTbl_XMLColumns.DataColumn, valStart +","+ valEnd);
        await foreach (var item in _search.Tbl_XMLFind_AsyncEnumerable(sc))
        {

            yield return (Tbl_XML_Table)item!;
        }
    }    

            


    


}//end class

