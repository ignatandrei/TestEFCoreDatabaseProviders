﻿//2.this was autogenerated by a tool. Do not modify! Use partial
using System;
using System.Collections.Generic;

namespace Generated;

public partial class SearchTbl_SMALLDATETIME:  GeneratorFromDB.Search<eTbl_SMALLDATETIMEColumns,Tbl_SMALLDATETIME>
{
    //private SimpleTablesMultipleData _context;
    //public SearchTbl_SMALLDATETIME(SimpleTablesMultipleData context){
    //    _context= context;
    //}
public static SearchTbl_SMALLDATETIME FromSearch(GeneratorFromDB.SearchCriteria sc, eTbl_SMALLDATETIMEColumns colToSearch, string value)
    {
        var search = new SearchTbl_SMALLDATETIME();
        var orderBy = new GeneratorFromDB.OrderBy<eTbl_SMALLDATETIMEColumns>();
                orderBy.FieldName = eTbl_SMALLDATETIMEColumns.ID ;;
        
        orderBy.Asc = false;
        search.OrderBys = new[] { orderBy };
        search.PageNumber = 1;
        search.PageSize = int.MaxValue - 1;
        var s = new GeneratorFromDB.SearchField<eTbl_SMALLDATETIMEColumns>();
        s.Criteria = sc;
        s.FieldName = colToSearch;
        s.Value = value;
        search.SearchFields = new[] { s };
        return search;
    }
   public override IOrderedQueryable<Tbl_SMALLDATETIME> TransformToOrder(IQueryable<Tbl_SMALLDATETIME> data){
        if(OrderBys == null || OrderBys.Length ==0){
            OrderBys =new GeneratorFromDB.OrderBy<eTbl_SMALLDATETIMEColumns>[1];
            OrderBys[0]= new GeneratorFromDB.OrderBy<eTbl_SMALLDATETIMEColumns>()
            {
                //maybe find PK ...
                FieldName = eTbl_SMALLDATETIMEColumns.ID,
                Asc=false
            };
        }
        var order = OrderBys[0]!;
        IOrderedQueryable<Tbl_SMALLDATETIME> ret;
        //TODO: maybe utilize EF.Property ? 
        switch(order.FieldName){
                    case eTbl_SMALLDATETIMEColumns.ID:
                if(order.Asc)
                    ret = data.OrderBy(it=>it.ID);
                else
                    ret = data.OrderByDescending(it=>it.ID);
                
                break;

                    case eTbl_SMALLDATETIMEColumns.DataColumn:
                if(order.Asc)
                    ret = data.OrderBy(it=>it.DataColumn);
                else
                    ret = data.OrderByDescending(it=>it.DataColumn);
                
                break;

                    default:
                throw new ArgumentException(" cannot order Tbl_SMALLDATETIME by "+ order.FieldName);
            
        }
        for(var i=1;i<OrderBys.Length;i++){
            order=OrderBys[i];
            switch(order.FieldName){
                    case eTbl_SMALLDATETIMEColumns.ID:
                if(order.Asc)
                    ret = ret.ThenBy(it=>it.ID);
                else
                    ret = ret.ThenByDescending(it=>it.ID);
                
                break;
                    case eTbl_SMALLDATETIMEColumns.DataColumn:
                if(order.Asc)
                    ret = ret.ThenBy(it=>it.DataColumn);
                else
                    ret = ret.ThenByDescending(it=>it.DataColumn);
                
                break;
                    default:
                throw new ArgumentException(" cannot order Tbl_SMALLDATETIME by "+ order.FieldName);
            
        }
        }
        return ret;
        
    }
    public override  IQueryable<Tbl_SMALLDATETIME> TransformToWhere(IQueryable<Tbl_SMALLDATETIME> data){
        if(SearchFields == null || SearchFields.Length ==0)        
            return data;
        var returnValue = data;
        foreach(var s in SearchFields){
            switch(s.FieldName ){
                case eTbl_SMALLDATETIMEColumns.None :
                    continue;
                    
            case eTbl_SMALLDATETIMEColumns.ID:
                //int isNullable False
                if(s.Value == null)
        {
                            throw new ArgumentException("Tbl_SMALLDATETIME.ID cannot be null");
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
            
                    
            case eTbl_SMALLDATETIMEColumns.DataColumn:
                //DateTime? isNullable True
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
                        var valueArray = s.Value
                    .Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .Select(it=>DateTime.Parse(it))
                    .ToArray();
                var value = valueArray[0];
                  
          
        switch(s.Criteria){

            case GeneratorFromDB.SearchCriteria.Between:
                if(valueArray?.Length != 2){
                    throw new ArgumentException("between must have 2 args, separated by comma => value is:" + s.Value);
                }
                                    returnValue =returnValue.Where(it=>it.DataColumn >= valueArray[0] && it.DataColumn <= valueArray[1]);
                  
                continue;
            case GeneratorFromDB.SearchCriteria.NotBetween:
            
            if(valueArray?.Length != 2){
                    throw new ArgumentException("not between must have 2 args, separated by comma => value is:" + s.Value);
                }
                                    returnValue =returnValue.Where(it=>it.DataColumn < valueArray[0] || it.DataColumn > valueArray[1]);
                  
                continue;
            case GeneratorFromDB.SearchCriteria.InArray:
                        returnValue =returnValue.Where(it=>it.DataColumn != null && valueArray!.Contains(it.DataColumn.Value));
                  
                continue;
            case GeneratorFromDB.SearchCriteria.NotInArray:
                        returnValue =returnValue.Where(it=>it.DataColumn != null && !valueArray!.Contains(it.DataColumn.Value));
                  
                continue;
            case GeneratorFromDB.SearchCriteria.Equal:
                returnValue =returnValue.Where(it=>it.DataColumn==value);
                continue;
            case GeneratorFromDB.SearchCriteria.Different:
                returnValue =returnValue.Where(it=>it.DataColumn!=value);
                continue;
            
            case GeneratorFromDB.SearchCriteria.Less:
                                                returnValue =returnValue.Where(it=>it.DataColumn<value);
                                                
                        continue;
                    case GeneratorFromDB.SearchCriteria.LessOrEqual:
                                                
                        returnValue =returnValue.Where(it=>it.DataColumn<=value);
                                                
                        continue;
                    case GeneratorFromDB.SearchCriteria.Greater:
                                                
                        returnValue =returnValue.Where(it=>it.DataColumn>value);
                                                continue;
                    case GeneratorFromDB.SearchCriteria.GreaterOrEqual:
                                                returnValue =returnValue.Where(it=>it.DataColumn>=value);
                                                continue;
                                                case GeneratorFromDB.SearchCriteria.EqualYear:
            {//for variable year
                var year=  value.Year;
                var yearStart=new DateTime(year,1,1);
                var yearEnd=new DateTime(year+1,1,1);
                returnValue =returnValue.Where(it=>it.DataColumn>=yearStart && it.DataColumn<yearEnd);
                }//end for variable year
                continue;
            case GeneratorFromDB.SearchCriteria.DifferentYear:
            {//for variable year
                var year=  value.Year;
                var yearStart=new DateTime(year,1,1);
                var yearEnd=new DateTime(year+1,1,1);
                returnValue =returnValue.Where(it=>it.DataColumn<yearStart || it.DataColumn>=yearEnd);
                }//end for variable year
                continue;
            case GeneratorFromDB.SearchCriteria.GreaterYear:
            {//for variable year
                var year=  value.Year;
                
                var yearStart=new DateTime(year+1,1,1);
                returnValue =returnValue.Where(it=>it.DataColumn > yearStart);
                }//end for variable year
                continue;
            case GeneratorFromDB.SearchCriteria.GreaterOrEqualYear:
            {//for variable year
                var year=  value.Year;
                
                var yearStart=new DateTime(year,1,1);
                returnValue =returnValue.Where(it=>it.DataColumn > yearStart);
                }//end for variable year
                continue;
                    
            case GeneratorFromDB.SearchCriteria.LessYear:
            {//for variable year
                var year=  value.Year;
                
                var yearEnd=new DateTime(year,1,1).AddMicroseconds(-1);
                returnValue =returnValue.Where(it=>it.DataColumn <= yearEnd);
                }//end for variable year
                continue;
            case GeneratorFromDB.SearchCriteria.LessOrEqualYear:
            {//for variable year
                var year=  value.Year;
                
                var yearEnd=new DateTime(year+1,1,1).AddMicroseconds(-1);
                returnValue =returnValue.Where(it=>it.DataColumn <= yearEnd);
                }//end for variable year
                continue;

                                                

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

    public DateTime? DataColumn { get; set; }
}
