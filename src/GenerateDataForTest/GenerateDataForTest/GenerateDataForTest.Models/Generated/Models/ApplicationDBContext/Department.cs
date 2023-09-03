﻿//this was autogenerated by a tool. Do not modify! Use partial
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GeneratorFromDB;
using Microsoft.EntityFrameworkCore;

namespace Generated;

//ADDED by code generator
public interface I_Department_Table 
{
        long IDDepartment { get; set; }
                string Name { get; set; }
        }

public class Department_Table : I_Department_Table
{
    public static MetaTable metaData = new("Department");
    static Department_Table (){
        MetaColumn mc=null;
        mc=new ("IDDepartment","long",false);                
        mc.IsPk = true ;
        mc.TypeJS = "number";
        metaData.AddColumn(mc);
        mc=new ("Name","string",false);                
        mc.IsPk = false ;
        mc.TypeJS = "string";
        metaData.AddColumn(mc);
 //done with foreach property in static constructor
    }
        public long IDDepartment { get; set; }
                public string Name { get; set; }
             public void CopyFrom(I_Department_Table other)  {
        this.IDDepartment = other.IDDepartment;
                this.Name = other.Name;
            }

    public static explicit operator Department_Table?(Department obj) { 
        if(obj == null)
            return null;
            //System.Diagnostics.Debugger.Break();
         var ret= new Department_Table();
         ret.CopyFrom(obj as I_Department_Table );
         return ret;
     }
     public static explicit operator Department?(Department_Table obj) { 
        if(obj == null)
            return null;
            //System.Diagnostics.Debugger.Break();
         var ret= new Department();
         ret.CopyFrom(obj as I_Department_Table) ;
         return ret;
     }



}
public partial class Department : I_Department_Table
{
     public void CopyFrom(I_Department_Table other)  {
        this.IDDepartment = other.IDDepartment;
                this.Name = other.Name;
            }

}

//for Department 
public enum eDepartmentColumns {
    None = 0
        ,IDDepartment 
                ,Name 
        }

//finish ADDED by code generator


public partial class Department
{
    [Key]
    public long IDDepartment { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;
}


