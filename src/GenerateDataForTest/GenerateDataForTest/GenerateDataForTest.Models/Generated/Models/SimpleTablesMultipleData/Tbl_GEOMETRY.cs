﻿//7.this was autogenerated by a tool. Do not modify! Use partial
using System;
using System.Collections.Generic;
using GeneratorFromDB;

namespace Generated;

//ADDED by code generator
public interface I_Tbl_GEOMETRY_Table 
{
        int ID { get; set; }
        }

public class Tbl_GEOMETRY_Table : I_Tbl_GEOMETRY_Table
{
    public static MetaTable metaData = new("Tbl_GEOMETRY");
    static Tbl_GEOMETRY_Table (){
        MetaColumn mc=null;
        mc=new ("ID","int",false);                
        mc.IsPk = true ;
        mc.TypeJS = "number";
        metaData.AddColumn(mc);
 //done with foreach property in static constructor
    }
        public int ID { get; set; }
             public void CopyFrom(I_Tbl_GEOMETRY_Table other)  {
        this.ID = other.ID;
            }

    public static explicit operator Tbl_GEOMETRY_Table?(Tbl_GEOMETRY obj) { 
        if(obj == null)
            return null;
            //System.Diagnostics.Debugger.Break();
         var ret= new Tbl_GEOMETRY_Table();
         ret.CopyFrom(obj as I_Tbl_GEOMETRY_Table );
         return ret;
     }
     public static explicit operator Tbl_GEOMETRY?(Tbl_GEOMETRY_Table obj) { 
        if(obj == null)
            return null;
            //System.Diagnostics.Debugger.Break();
         var ret= new Tbl_GEOMETRY();
         ret.CopyFrom(obj as I_Tbl_GEOMETRY_Table) ;
         return ret;
     }



}
public partial class Tbl_GEOMETRY : I_Tbl_GEOMETRY_Table
{
     public void CopyFrom(I_Tbl_GEOMETRY_Table other)  {
        this.ID = other.ID;
            }

}

//for Tbl_GEOMETRY 
public enum eTbl_GEOMETRYColumns {
    None = 0
        ,ID 
        }

//finish ADDED by code generator


public partial class Tbl_GEOMETRY
{
    public int ID { get; set; }
}


