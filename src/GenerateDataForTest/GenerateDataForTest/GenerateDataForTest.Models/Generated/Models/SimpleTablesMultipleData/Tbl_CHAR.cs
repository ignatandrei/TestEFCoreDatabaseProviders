﻿//7.this was autogenerated by a tool. Do not modify! Use partial
using System;
using System.Collections.Generic;
using GeneratorFromDB;

namespace Generated;

//ADDED by code generator
public interface I_Tbl_CHAR_Table 
{
        int ID { get; set; }
                string? DataColumn { get; set; }
        }

public class Tbl_CHAR_Table : I_Tbl_CHAR_Table
{
    public static MetaTable metaData = new("Tbl_CHAR");
    static Tbl_CHAR_Table (){
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
             public void CopyFrom(I_Tbl_CHAR_Table other)  {
        this.ID = other.ID;
                this.DataColumn = other.DataColumn;
            }

    public static explicit operator Tbl_CHAR_Table?(Tbl_CHAR obj) { 
        if(obj == null)
            return null;
            //System.Diagnostics.Debugger.Break();
         var ret= new Tbl_CHAR_Table();
         ret.CopyFrom(obj as I_Tbl_CHAR_Table );
         return ret;
     }
     public static explicit operator Tbl_CHAR?(Tbl_CHAR_Table obj) { 
        if(obj == null)
            return null;
            //System.Diagnostics.Debugger.Break();
         var ret= new Tbl_CHAR();
         ret.CopyFrom(obj as I_Tbl_CHAR_Table) ;
         return ret;
     }



}
public partial class Tbl_CHAR : I_Tbl_CHAR_Table
{
     public void CopyFrom(I_Tbl_CHAR_Table other)  {
        this.ID = other.ID;
                this.DataColumn = other.DataColumn;
            }

}

//for Tbl_CHAR 
public enum eTbl_CHARColumns {
    None = 0
        ,ID 
                ,DataColumn 
        }

//finish ADDED by code generator


public partial class Tbl_CHAR
{
    public int ID { get; set; }

    public string? DataColumn { get; set; }
}

