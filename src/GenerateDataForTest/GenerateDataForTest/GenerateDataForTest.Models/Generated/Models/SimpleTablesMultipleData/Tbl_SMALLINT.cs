﻿//7.this was autogenerated by a tool. Do not modify! Use partial
using System;
using System.Collections.Generic;
using GeneratorFromDB;

namespace Generated;

//ADDED by code generator
public interface I_Tbl_SMALLINT_Table 
{
        int ID { get; set; }
                short? DataColumn { get; set; }
        }

public class Tbl_SMALLINT_Table : I_Tbl_SMALLINT_Table
{
    public static MetaTable metaData = new("Tbl_SMALLINT");
    static Tbl_SMALLINT_Table (){
        MetaColumn mc=null;
        mc=new ("ID","int",false);                
        mc.IsPk = true ;
        mc.TypeJS = "number";
        metaData.AddColumn(mc);
        mc=new ("DataColumn","short?",true);                
        mc.IsPk = false ;
        mc.TypeJS = "number";
        metaData.AddColumn(mc);
 //done with foreach property in static constructor
    }
        public int ID { get; set; }
                public short? DataColumn { get; set; }
             public void CopyFrom(I_Tbl_SMALLINT_Table other)  {
        this.ID = other.ID;
                this.DataColumn = other.DataColumn;
            }

    public static explicit operator Tbl_SMALLINT_Table?(Tbl_SMALLINT obj) { 
        if(obj == null)
            return null;
            //System.Diagnostics.Debugger.Break();
         var ret= new Tbl_SMALLINT_Table();
         ret.CopyFrom(obj as I_Tbl_SMALLINT_Table );
         return ret;
     }
     public static explicit operator Tbl_SMALLINT?(Tbl_SMALLINT_Table obj) { 
        if(obj == null)
            return null;
            //System.Diagnostics.Debugger.Break();
         var ret= new Tbl_SMALLINT();
         ret.CopyFrom(obj as I_Tbl_SMALLINT_Table) ;
         return ret;
     }



}
public partial class Tbl_SMALLINT : I_Tbl_SMALLINT_Table
{
     public void CopyFrom(I_Tbl_SMALLINT_Table other)  {
        this.ID = other.ID;
                this.DataColumn = other.DataColumn;
            }

}

//for Tbl_SMALLINT 
public enum eTbl_SMALLINTColumns {
    None = 0
        ,ID 
                ,DataColumn 
        }

//finish ADDED by code generator


public partial class Tbl_SMALLINT
{
    public int ID { get; set; }

    public short? DataColumn { get; set; }
}


