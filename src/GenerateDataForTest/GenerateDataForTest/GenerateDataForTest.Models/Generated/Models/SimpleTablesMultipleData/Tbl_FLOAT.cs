﻿//7.this was autogenerated by a tool. Do not modify! Use partial
using System;
using System.Collections.Generic;
using GeneratorFromDB;

namespace Generated;

//ADDED by code generator
public interface I_Tbl_FLOAT_Table 
{
        int ID { get; set; }
                double? DataColumn { get; set; }
        }

public class Tbl_FLOAT_Table : I_Tbl_FLOAT_Table
{
    public static MetaTable metaData = new("Tbl_FLOAT");
    static Tbl_FLOAT_Table (){
        MetaColumn mc=null;
        mc=new ("ID","int",false);                
        mc.IsPk = true ;
        mc.TypeJS = "number";
        metaData.AddColumn(mc);
        mc=new ("DataColumn","double?",true);                
        mc.IsPk = false ;
        mc.TypeJS = "number";
        metaData.AddColumn(mc);
 //done with foreach property in static constructor
    }
        public int ID { get; set; }
                public double? DataColumn { get; set; }
             public void CopyFrom(I_Tbl_FLOAT_Table other)  {
        this.ID = other.ID;
                this.DataColumn = other.DataColumn;
            }

    public static explicit operator Tbl_FLOAT_Table?(Tbl_FLOAT obj) { 
        if(obj == null)
            return null;
            //System.Diagnostics.Debugger.Break();
         var ret= new Tbl_FLOAT_Table();
         ret.CopyFrom(obj as I_Tbl_FLOAT_Table );
         return ret;
     }
     public static explicit operator Tbl_FLOAT?(Tbl_FLOAT_Table obj) { 
        if(obj == null)
            return null;
            //System.Diagnostics.Debugger.Break();
         var ret= new Tbl_FLOAT();
         ret.CopyFrom(obj as I_Tbl_FLOAT_Table) ;
         return ret;
     }



}
public partial class Tbl_FLOAT : I_Tbl_FLOAT_Table
{
     public void CopyFrom(I_Tbl_FLOAT_Table other)  {
        this.ID = other.ID;
                this.DataColumn = other.DataColumn;
            }

}

//for Tbl_FLOAT 
public enum eTbl_FLOATColumns {
    None = 0
        ,ID 
                ,DataColumn 
        }

//finish ADDED by code generator


public partial class Tbl_FLOAT
{
    public int ID { get; set; }

    public double? DataColumn { get; set; }
}

