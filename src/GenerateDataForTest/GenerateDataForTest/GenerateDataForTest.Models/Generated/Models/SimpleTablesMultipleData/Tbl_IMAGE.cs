﻿//7.this was autogenerated by a tool. Do not modify! Use partial
using System;
using System.Collections.Generic;
using GeneratorFromDB;

namespace Generated;

//ADDED by code generator
public interface I_Tbl_IMAGE_Table 
{
        int ID { get; set; }
                byte[]? DataColumn { get; set; }
        }

public class Tbl_IMAGE_Table : I_Tbl_IMAGE_Table
{
    public static MetaTable metaData = new("Tbl_IMAGE");
    static Tbl_IMAGE_Table (){
        MetaColumn mc=null;
        mc=new ("ID","int",false);                
        mc.IsPk = true ;
        mc.TypeJS = "number";
        metaData.AddColumn(mc);
        mc=new ("DataColumn","byte[]",true);                
        mc.IsPk = false ;
        mc.TypeJS = "number[]|null";
        metaData.AddColumn(mc);
 //done with foreach property in static constructor
    }
        public int ID { get; set; }
                public byte[]? DataColumn { get; set; }
             public void CopyFrom(I_Tbl_IMAGE_Table other)  {
        this.ID = other.ID;
                this.DataColumn = other.DataColumn;
            }

    public static explicit operator Tbl_IMAGE_Table?(Tbl_IMAGE obj) { 
        if(obj == null)
            return null;
            //System.Diagnostics.Debugger.Break();
         var ret= new Tbl_IMAGE_Table();
         ret.CopyFrom(obj as I_Tbl_IMAGE_Table );
         return ret;
     }
     public static explicit operator Tbl_IMAGE?(Tbl_IMAGE_Table obj) { 
        if(obj == null)
            return null;
            //System.Diagnostics.Debugger.Break();
         var ret= new Tbl_IMAGE();
         ret.CopyFrom(obj as I_Tbl_IMAGE_Table) ;
         return ret;
     }



}
public partial class Tbl_IMAGE : I_Tbl_IMAGE_Table
{
     public void CopyFrom(I_Tbl_IMAGE_Table other)  {
        this.ID = other.ID;
                this.DataColumn = other.DataColumn;
            }

}

//for Tbl_IMAGE 
public enum eTbl_IMAGEColumns {
    None = 0
        ,ID 
                ,DataColumn 
        }

//finish ADDED by code generator


public partial class Tbl_IMAGE
{
    public int ID { get; set; }

    public byte[]? DataColumn { get; set; }
}


