﻿//7.this was autogenerated by a tool. Do not modify! Use partial
using System;
using System.Collections.Generic;
using GeneratorFromDB;

namespace Generated;

//ADDED by code generator
public interface I_Tbl_REAL_Table 
{
        int ID { get; set; }
                float? DataColumn { get; set; }
        }

public class Tbl_REAL_Table : I_Tbl_REAL_Table
{
    public static MetaTable metaData = new("Tbl_REAL");
    static Tbl_REAL_Table (){
        MetaColumn mc=null;
        mc=new ("ID","int",false);                
        mc.IsPk = true ;
        mc.TypeJS = "number";
        metaData.AddColumn(mc);
        mc=new ("DataColumn","float?",true);                
        mc.IsPk = false ;
        mc.TypeJS = "number";
        metaData.AddColumn(mc);
 //done with foreach property in static constructor
    }
        public int ID { get; set; }
                public float? DataColumn { get; set; }
             public void CopyFrom(I_Tbl_REAL_Table other)  {
        this.ID = other.ID;
                this.DataColumn = other.DataColumn;
            }

    public static explicit operator Tbl_REAL_Table?(Tbl_REAL obj) { 
        if(obj == null)
            return null;
            //System.Diagnostics.Debugger.Break();
         var ret= new Tbl_REAL_Table();
         ret.CopyFrom(obj as I_Tbl_REAL_Table );
         return ret;
     }
     public static explicit operator Tbl_REAL?(Tbl_REAL_Table obj) { 
        if(obj == null)
            return null;
            //System.Diagnostics.Debugger.Break();
         var ret= new Tbl_REAL();
         ret.CopyFrom(obj as I_Tbl_REAL_Table) ;
         return ret;
     }



}
public partial class Tbl_REAL : I_Tbl_REAL_Table
{
     public void CopyFrom(I_Tbl_REAL_Table other)  {
        this.ID = other.ID;
                this.DataColumn = other.DataColumn;
            }

}

//for Tbl_REAL 
public enum eTbl_REALColumns {
    None = 0
        ,ID 
                ,DataColumn 
        }

//finish ADDED by code generator


public partial class Tbl_REAL
{
    public int ID { get; set; }

    public float? DataColumn { get; set; }
}

