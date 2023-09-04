﻿//2.this was autogenerated by a tool. Do not modify! Use partial
using System;
using System.Collections.Generic;

namespace Generated;

public partial class SearchTbl_TEXT:  GeneratorFromDB.Search<eTbl_TEXTColumns,Tbl_TEXT>
{
    //private SimpleTablesMultipleData _context;
    //public SearchTbl_TEXT(SimpleTablesMultipleData context){
    //    _context= context;
    //}
public static SearchTbl_TEXT FromSearch(GeneratorFromDB.SearchCriteria sc, eTbl_TEXTColumns colToSearch, string value)
    {
        var search = new SearchTbl_TEXT();
        var orderBy = new GeneratorFromDB.OrderBy<eTbl_TEXTColumns>();
                orderBy.FieldName = eTbl_TEXTColumns.ID ;;
        
        orderBy.Asc = false;
        search.OrderBys = new[] { orderBy };
        search.PageNumber = 1;
        search.PageSize = int.MaxValue - 1;
        var s = new GeneratorFromDB.SearchField<eTbl_TEXTColumns>();
        s.Criteria = sc;
        s.FieldName = colToSearch;
        s.Value = value;
        search.SearchFields = new[] { s };
        return search;
    }
   public override IOrderedQueryable<Tbl_TEXT> TransformToOrder(IQueryable<Tbl_TEXT> data){
        if(OrderBys == null || OrderBys.Length ==0){
            OrderBys =new GeneratorFromDB.OrderBy<eTbl_TEXTColumns>[1];
            OrderBys[0]= new GeneratorFromDB.OrderBy<eTbl_TEXTColumns>()
            {
                //maybe find PK ...
                FieldName = eTbl_TEXTColumns.ID,
                Asc=false
            };
        }
        var order = OrderBys[0]!;
        IOrderedQueryable<Tbl_TEXT> ret;
        //TODO: maybe utilize EF.Property ? 
        switch(order.FieldName){
                    case eTbl_TEXTColumns.ID:
                if(order.Asc)
                    ret = data.OrderBy(it=>it.ID);
                else
                    ret = data.OrderByDescending(it=>it.ID);
                
                break;

                    case eTbl_TEXTColumns.DataColumn:
                if(order.Asc)
                    ret = data.OrderBy(it=>it.DataColumn);
                else
                    ret = data.OrderByDescending(it=>it.DataColumn);
                
                break;

                    default:
                throw new ArgumentException(" cannot order Tbl_TEXT by "+ order.FieldName);
            
        }
        for(var i=1;i<OrderBys.Length;i++){
            order=OrderBys[i];
            switch(order.FieldName){
                    case eTbl_TEXTColumns.ID:
                if(order.Asc)
                    ret = ret.ThenBy(it=>it.ID);
                else
                    ret = ret.ThenByDescending(it=>it.ID);
                
                break;
                    case eTbl_TEXTColumns.DataColumn:
                if(order.Asc)
                    ret = ret.ThenBy(it=>it.DataColumn);
                else
                    ret = ret.ThenByDescending(it=>it.DataColumn);
                
                break;
                    default:
                throw new ArgumentException(" cannot order Tbl_TEXT by "+ order.FieldName);
            
        }
        }
        return ret;
        
    }
    public override  IQueryable<Tbl_TEXT> TransformToWhere(IQueryable<Tbl_TEXT> data){
        if(SearchFields == null || SearchFields.Length ==0)        
            return data;
        var returnValue = data;
        foreach(var s in SearchFields){
            switch(s.FieldName ){
                case eTbl_TEXTColumns.None :
                    continue;
                    
            case eTbl_TEXTColumns.ID:
                //int isNullable False
                if(s.Value == null)
        {
                            throw new ArgumentException("Tbl_TEXT.ID cannot be null");
                                }//end if s.value is null -search for null
        //if we are here, s.Value is not null
        { //use this to define value in smaller scope
                        var valueArray = s.Value
                    .Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .Select(it=>int.Parse(it))
                    .ToArray();
                var value = valueArray[0];
                  
          
        switch(s.Criteria){

            case GeneratorFromDB.SearchCriteria.Between:
                if(valueArray?.Length != 2){
                    throw new ArgumentException("between must have 2 args, separated by comma => value is:" + s.Value);
                }
                                    returnValue =returnValue.Where(it=>it.ID >= valueArray[0] && it.ID <= valueArray[1]);
                  
                continue;
            case GeneratorFromDB.SearchCriteria.NotBetween:
            
            if(valueArray?.Length != 2){
                    throw new ArgumentException("not between must have 2 args, separated by comma => value is:" + s.Value);
                }
                                    returnValue =returnValue.Where(it=>it.ID < valueArray[0] || it.ID > valueArray[1]);
                  
                continue;
            case GeneratorFromDB.SearchCriteria.InArray:
                        returnValue =returnValue.Where(it=> valueArray!.Contains(it.ID));
                  
                continue;
            case GeneratorFromDB.SearchCriteria.NotInArray:
                        returnValue =returnValue.Where(it=> !valueArray!.Contains(it.ID));
                  
                continue;
            case GeneratorFromDB.SearchCriteria.Equal:
                returnValue =returnValue.Where(it=>it.ID==value);
                continue;
            case GeneratorFromDB.SearchCriteria.Different:
                returnValue =returnValue.Where(it=>it.ID!=value);
                continue;
            
            case GeneratorFromDB.SearchCriteria.Less:
                                                returnValue =returnValue.Where(it=>it.ID<value);
                                                
                        continue;
                    case GeneratorFromDB.SearchCriteria.LessOrEqual:
                                                
                        returnValue =returnValue.Where(it=>it.ID<=value);
                                                
                        continue;
                    case GeneratorFromDB.SearchCriteria.Greater:
                                                
                        returnValue =returnValue.Where(it=>it.ID>value);
                                                continue;
                    case GeneratorFromDB.SearchCriteria.GreaterOrEqual:
                                                returnValue =returnValue.Where(it=>it.ID>=value);
                                                continue;
                                                                        

            default:
                throw new ArgumentException($"not found Criteria {(int)s.Criteria} {s.Criteria} for {s.FieldName}");
        }//end switch after s.Criteria

                //continue;
        } //end use this to define value in smaller scope
            
                    
            case eTbl_TEXTColumns.DataColumn:
                //string isNullable True
                if(s.Value == null)
        {
                            switch(s.Criteria){
                    case GeneratorFromDB.SearchCriteria.Equal:
                        returnValue =returnValue.Where(it=>it.DataColumn==null);
                        continue;
                    case GeneratorFromDB.SearchCriteria.Different:
                        returnValue =returnValue.Where(it=>it.DataColumn!=null);
                        continue;
                    default:
                        throw new ArgumentException($"null cannot have {(int)s.Criteria} {s.Criteria} for {s.FieldName}");
                    }
                
            
                                }//end if s.value is null -search for null
        //if we are here, s.Value is not null
        { //use this to define value in smaller scope
                                var value = s.Value;
                var valueArray= s.Value?.Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .ToArray();
                ;
          
          
        switch(s.Criteria){

            case GeneratorFromDB.SearchCriteria.Between:
                if(valueArray?.Length != 2){
                    throw new ArgumentException("between must have 2 args, separated by comma => value is:" + s.Value);
                }
                                    returnValue =returnValue.Where(it=>String.Compare(it.DataColumn,valueArray[0]) >= 0  && String.Compare(it.DataColumn,valueArray[1]) <= 0);
                  
                continue;
            case GeneratorFromDB.SearchCriteria.NotBetween:
            
            if(valueArray?.Length != 2){
                    throw new ArgumentException("not between must have 2 args, separated by comma => value is:" + s.Value);
                }
                                    returnValue =returnValue.Where(it=>String.Compare(it.DataColumn,valueArray[0]) < 0  || String.Compare(it.DataColumn,valueArray[1]) > 0);
                  
                continue;
            case GeneratorFromDB.SearchCriteria.InArray:
                        returnValue =returnValue.Where(it=> valueArray!.Contains(it.DataColumn));
                  
                continue;
            case GeneratorFromDB.SearchCriteria.NotInArray:
                        returnValue =returnValue.Where(it=> !valueArray!.Contains(it.DataColumn));
                  
                continue;
            case GeneratorFromDB.SearchCriteria.Equal:
                returnValue =returnValue.Where(it=>it.DataColumn==value);
                continue;
            case GeneratorFromDB.SearchCriteria.Different:
                returnValue =returnValue.Where(it=>it.DataColumn!=value);
                continue;
            
            case GeneratorFromDB.SearchCriteria.Less:
                                                    returnValue =returnValue.Where(it=>String.Compare(it.DataColumn,value) < 0 );
                                                
                        continue;
                    case GeneratorFromDB.SearchCriteria.LessOrEqual:
                                                    returnValue =returnValue.Where(it=>String.Compare(it.DataColumn,value) <= 0 );
                                                
                        continue;
                    case GeneratorFromDB.SearchCriteria.Greater:
                                                    returnValue =returnValue.Where(it=>String.Compare(it.DataColumn,value) > 0 );
                                                continue;
                    case GeneratorFromDB.SearchCriteria.GreaterOrEqual:
                                                    returnValue =returnValue.Where(it=>String.Compare(it.DataColumn,value) >= 0 );
                                                continue;
                                            case GeneratorFromDB.SearchCriteria.Contains:
                        returnValue =returnValue.Where(it=>it.DataColumn != null && it.DataColumn.Contains(value));
                        continue;
                    case GeneratorFromDB.SearchCriteria.StartsWith:
                        returnValue =returnValue.Where(it=>it.DataColumn != null &&  it.DataColumn.StartsWith(value));
                        continue;
                    case GeneratorFromDB.SearchCriteria.EndsWith:
                        returnValue =returnValue.Where(it=>it.DataColumn != null && it.DataColumn.EndsWith(value));
                        continue;
                    /*case SearchCriteria.Contains:
                        returnValue =returnValue.Where(it=> it.DataColumn != null && it.DataColumn.Contains(value));
                        continue;
                    */
                                                            

            default:
                throw new ArgumentException($"not found Criteria {(int)s.Criteria} {s.Criteria} for {s.FieldName}");
        }//end switch after s.Criteria

                //continue;
        } //end use this to define value in smaller scope
            
                }//end switch  
       }//end foreach
    return returnValue;
    //throw new NotImplementedException("not");
    }

    public int ID { get; set; }

    public string? DataColumn { get; set; }
}