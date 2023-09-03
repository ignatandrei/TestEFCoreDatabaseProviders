﻿//this was autogenerated by a tool. Do not modify! Use partial
using System;
using System.Collections.Generic;
using GeneratorFromDB;
using Microsoft.EntityFrameworkCore;

namespace Generated;

public partial class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
    { 
    }

    public virtual DbSet<Department> Department { get; set; }
    //public virtual DbSet<Department_Table> Department_Table { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

//added new
public partial class ApplicationDBContext : DbContext
{
    public static MetaDB  metaData = new("ApplicationDBContext");
    [System.Runtime.CompilerServices.ModuleInitializer]
    public static void ApplicationDBContext_AddTables(){
        metaData.AddTable(Department_Table.metaData);
        AllDB.Singleton.AddDb(metaData);
    }

        public async Task<Department[]> DepartmentFind_Array( SearchDepartment? search){
 
        IQueryable<Department> data= this.Department ;
        if(search == null){
            return await data.ToArrayAsync();
        }
        data = search.TransformToWhere(data);        
        IQueryable<Department> ret= search.TransformToOrder(data);
        if(search.PageNumber>1)
            ret= ret.Skip((search.PageNumber-1)*search.PageSize);
            
        ret=ret.Take(search.PageSize);
        return await ret.ToArrayAsync();
    }

    public  IAsyncEnumerable<Department> DepartmentGetAll(){
        return this.DepartmentFind_AsyncEnumerable(null);
    }
        public async  Task<Department> DepartmentSave(Department val){

        var data= await DepartmentSaveMultiple(val);
        if(data == null)
            return null;

        return data[0];
                
    }
    public async  Task<Department[]> DepartmentSaveMultiple(params Department[] values){

        if(values == null)
            return null;
        if(values.Length == 0)
            return values;
        foreach(var value in values){
            this.Department.Add(value);
        }
        await SaveChangesAsync();
        return values;

                
    }

    public  IAsyncEnumerable<Department> DepartmentSimpleSearch(GeneratorFromDB.SearchCriteria sc, eDepartmentColumns colToSearch, string value){
        
 var search = SearchDepartment.FromSearch(sc,colToSearch,value);
 /*
        var orderBy = new GeneratorFromDB.OrderBy<eDepartmentColumns>();
                    orderBy.FieldName = eDepartmentColumns.IDDepartment;
                orderBy.Asc = false;
        search.OrderBys = new[] { orderBy };
        search.PageNumber = 1;
        search.PageSize = int.MaxValue-1;
        var s = new GeneratorFromDB.SearchField<eDepartmentColumns>();
        s.Criteria = sc;
        s.FieldName = colToSearch;
        s.Value = value;
        search.SearchFields = new[] { s };
        */
        var data = this.DepartmentFind_AsyncEnumerable(search);
        return data;
    }   
/*
    public IAsyncEnumerable<Department> DepartmentFind_AsyncEnumerable(SearchDepartment? search){
 
        IQueryable<Department> data= this.Department ;
        if(search == null){
            return data.AsAsyncEnumerable();
        }
        data = search.TransformToWhere(data);        
        IQueryable<Department> =search.TransformToOrder(data);
        if(search.PageSize>1)
            ret= ret.Skip((search.PageNumber-1)*search.PageSize);
            
        ret=ret.Take(search.PageSize);
        return ret.AsAsyncEnumerable();
    }
*/
    public Task<long> DepartmentCount( SearchDepartment? search){
     
        IQueryable<Department> data= this.Department ;
        if(search != null){
            data = search.TransformToWhere(data);        
        }        
        return data.LongCountAsync();
    }
    

    //oneKey
    
    public  async Task<bool> DepartmentDelete(long id){

        var item = await DepartmentGetSingle(id);
        if(item == null)
            return false;
       this.Department.Remove(item);
        await this.SaveChangesAsync();
        return true; 
    }
    public  async Task<bool> DepartmentModify(Department val ){
        //do the attach
        /* var item = await DepartmentGetSingle(val.??ID?????);
        if(item == null)
            return false;
        item.CopyFrom(val);        
        await this.SaveChangesAsync();
        */
        return true; 
    }
    



    public Task<Department?> DepartmentGetSingle(long id){
        return this.Department.FirstOrDefaultAsync(e => e.IDDepartment == id);
    }
    

    public IAsyncEnumerable<Department> DepartmentFind_AsyncEnumerable(SearchDepartment? search){
        IQueryable<Department> data= this.Department ;
        if(search == null){
                        return data.OrderByDescending(e => e.IDDepartment).AsAsyncEnumerable();
                    }
        data = search.TransformToWhere(data); 
        
        IQueryable<Department> ret= search.TransformToOrder(data);
        if(search.PageNumber>1)
            ret=ret.Skip((search.PageNumber-1)*search.PageSize);
            
        ret=ret.Take(search.PageSize);
        return ret.AsAsyncEnumerable();
    
    }

}
public interface I_InsertDataApplicationDBContext{
        Task<Department_Table?> InsertDepartment(Department_Table value);
        Task<Department_Table[]> InsertDepartments(params Department_Table[] values);

    }

public class InsertDataApplicationDBContext: I_InsertDataApplicationDBContext{

        private ApplicationDBContext _context;
        public InsertDataApplicationDBContext(ApplicationDBContext context){
            _context=context;
        }
        public async Task<Department_Table?> InsertDepartment(Department_Table value){
            if (value == null)
                return null;

            Department val = (Department)value!;
            _context.Department.Add(val);
            await _context.SaveChangesAsync();
            return (Department_Table)val! ;

        }
        public async Task<Department_Table[]> InsertDepartments(params Department_Table[] values){
        
        if (values == null || values.Length == 0)
            return new Department_Table[0];

        Department[] vals = values.Select(it=>(Department)it!).ToArray();
        _context.Department.AddRange(vals);
        await _context.SaveChangesAsync();
        return vals.Select(it => (Department_Table)it!  ).ToArray();
    }
    
    
}//end class InsertDataApplicationDBContext

   public interface ISearchDataDepartment {
        IAsyncEnumerable<Department> DepartmentFind_AsyncEnumerable(SearchDepartment? search);
    
    public Task<long> GetAllCount();
    public Task<long> GetAllCount(SearchDepartment? search);

        //oneKey    
    public Task<Department?> DepartmentGetSingle(long id);
    
    
    public  IAsyncEnumerable<Department> DepartmentSimpleSearch_IDDepartment(GeneratorFromDB.SearchCriteria sc,  long value);
    public  IAsyncEnumerable<Department> DepartmentSimpleSearchNull_IDDepartment(GeneratorFromDB.SearchCriteria sc);
    
    public  IAsyncEnumerable<Department> DepartmentSimpleSearch_Name(GeneratorFromDB.SearchCriteria sc,  string value);
    public  IAsyncEnumerable<Department> DepartmentSimpleSearchNull_Name(GeneratorFromDB.SearchCriteria sc);
        } //interface searchdata   

   public class SearchDataDepartment: ISearchDataDepartment{
        private ApplicationDBContext context;
        public SearchDataDepartment (ApplicationDBContext context) {
            this.context=context;
        }
           
        public async Task<long> GetAllCount(){
            return await context.DepartmentCount(null);
        }
        public async Task<long> GetAllCount(SearchDepartment? search){
            return await context.DepartmentCount(search);
        }
        public IAsyncEnumerable<Department> DepartmentFind_AsyncEnumerable(SearchDepartment? search){
            return context.DepartmentFind_AsyncEnumerable(search);
        }
        //oneKey    
    public Task<Department?> DepartmentGetSingle(long id){
            return context.DepartmentGetSingle(id);
    }
    public  IAsyncEnumerable<Department> DepartmentSimpleSearch(GeneratorFromDB.SearchCriteria sc, eDepartmentColumns colToSearch, string? value){
        var search =SearchDepartment.FromSearch(sc,colToSearch,value);
    /*
            var search = new SearchDepartment();
            var orderBy = new GeneratorFromDB.OrderBy<eDepartmentColumns>();
                              orderBy.FieldName = eDepartmentColumns.IDDepartment;
          
            orderBy.Asc = false;
            search.OrderBys = new[] { orderBy };
            search.PageNumber = 1;
            search.PageSize = int.MaxValue;
            var s = new GeneratorFromDB.SearchField<eDepartmentColumns>();
            s.Criteria = sc;
            s.FieldName = colToSearch;
            s.Value = value;
            search.SearchFields = new[] { s };
       */
            var data = this.DepartmentFind_AsyncEnumerable(search);
            return data;
        }

    
        //False
    public  IAsyncEnumerable<Department> DepartmentSimpleSearch_IDDepartment(GeneratorFromDB.SearchCriteria sc,  long value){
         return DepartmentSimpleSearch(sc,eDepartmentColumns.IDDepartment,value.ToString());

    
    }
    public  IAsyncEnumerable<Department> DepartmentSimpleSearchNull_IDDepartment(GeneratorFromDB.SearchCriteria sc){
        return DepartmentSimpleSearch(sc,eDepartmentColumns.IDDepartment,null);

    }


        //False
    public  IAsyncEnumerable<Department> DepartmentSimpleSearch_Name(GeneratorFromDB.SearchCriteria sc,  string value){
         return DepartmentSimpleSearch(sc,eDepartmentColumns.Name,value.ToString());

    
    }
    public  IAsyncEnumerable<Department> DepartmentSimpleSearchNull_Name(GeneratorFromDB.SearchCriteria sc){
        return DepartmentSimpleSearch(sc,eDepartmentColumns.Name,null);

    }


        } //class searchdata




    
   


//end added new



