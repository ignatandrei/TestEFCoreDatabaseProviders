﻿//7.this was autogenerated by a tool. Do not modify! Use partial
using System;
using System.Collections.Generic;
using GeneratorFromDB;

namespace Generated;

//ADDED by code generator
public interface I_Tbl_NTEXT_Table 
{
        int ID { get; set; }
                string? DataColumn { get; set; }
        }

public class Tbl_NTEXT_Table : I_Tbl_NTEXT_Table
{
    public static MetaTable metaData = new("Tbl_NTEXT");
    static Tbl_NTEXT_Table (){
        MetaColumn mc=null;
        mc=new ("ID","int",false);                
        mc.IsPk = true ;
        mc.TypeJS = "number";
        metaData.AddColumn(mc);
        mc=new ("DataColumn","string",true);                
        mc.IsPk = false ;
        mc.TypeJS = "string|null";
        metaData.AddColumn(mc);
 //done with foreach property in static constructor
    }
        public int ID { get; set; }
                public string? DataColumn { get; set; }
             public void CopyFrom(I_Tbl_NTEXT_Table other)  {
        this.ID = other.ID;
                this.DataColumn = other.DataColumn;
            }

    public static explicit operator Tbl_NTEXT_Table?(Tbl_NTEXT obj) { 
        if(obj == null)
            return null;
            //System.Diagnostics.Debugger.Break();
         var ret= new Tbl_NTEXT_Table();
         ret.CopyFrom(obj as I_Tbl_NTEXT_Table );
         return ret;
     }
     public static explicit operator Tbl_NTEXT?(Tbl_NTEXT_Table obj) { 
        if(obj == null)
            return null;
            //System.Diagnostics.Debugger.Break();
         var ret= new Tbl_NTEXT();
         ret.CopyFrom(obj as I_Tbl_NTEXT_Table) ;
         return ret;
     }



}
public partial class Tbl_NTEXT : I_Tbl_NTEXT_Table
{
     public void CopyFrom(I_Tbl_NTEXT_Table other)  {
        this.ID = other.ID;
                this.DataColumn = other.DataColumn;
            }

}

//for Tbl_NTEXT 
public enum eTbl_NTEXTColumns {
    None = 0
        ,ID 
                ,DataColumn 
        }

//finish ADDED by code generator


public partial class Tbl_NTEXT
{
    public int ID { get; set; }

    public string? DataColumn { get; set; }
}


