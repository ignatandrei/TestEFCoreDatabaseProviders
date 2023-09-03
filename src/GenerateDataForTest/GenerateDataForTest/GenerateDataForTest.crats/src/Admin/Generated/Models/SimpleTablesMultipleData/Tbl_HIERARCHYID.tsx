﻿//6.this was autogenerated by a tool. Do not modify! Use partial
 import DatabaseTableSelector, { SearchData } from "../../../DatabaseTableSelector";
 import JsonStreamDecoder from "../../../Common/asyncEnumerable";
 import useRxObs from "../../../../useRXEffect";
 import useSearchURL from "../../../searchMatches";
 import { Button,Input ,Spin, Table } from "antd";
 import { ColumnsType } from "antd/es/table";
 import { Link } from "react-router-dom";
 import { ajax } from "rxjs/ajax";
 import { concatMap, delay, map,Observable,of,scan } from "rxjs";
 import { useState,useEffect } from "react";



export class SimpleTablesMultipleData_Tbl_HIERARCHYID_Table 
{

baseUrl:string = '';
    constructor(cc: Partial<SimpleTablesMultipleData_Tbl_HIERARCHYID_Table> | null = null) {
      this.baseUrl=process.env.REACT_APP_URL+'api/'; 

    if (cc != null) {
      // Object.keys(tilt).forEach((key) => {
      //   (this as any)[key] = (tilt as any)[key];
      // });
      Object.assign(this,cc);
    }
    }

        public id : number  = 0;
        }
export class SimpleTablesMultipleData_Tbl_HIERARCHYID_Table_Interaction {
    baseUrl:string = '';
    constructor() {
      this.baseUrl=process.env.REACT_APP_URL+'api/'; 
    }

    
    public getAllCount():Observable<number>{

        var data=ajax.getJSON(this.baseUrl+'AdvancedSearch_SimpleTablesMultipleData_Tbl_HIERARCHYID/GetAllCount')
        .pipe(
            map(response => {

                return response as number;
            })
            //takeUntil(cancel)
          );
          return data;
    }    
     public getSearchSimple(searchData:SearchData ):Observable<SimpleTablesMultipleData_Tbl_HIERARCHYID_Table[]>{
        
        var url= this.baseUrl+'AdvancedSearch_SimpleTablesMultipleData_Tbl_HIERARCHYID/';
        url+=`GetSearchSimple?ColumnName=${searchData.ColumnName}&Operator=${searchData.Operator}&Value=${searchData.Value}`;        
        var data=JsonStreamDecoder.fromFetchStream<SimpleTablesMultipleData_Tbl_HIERARCHYID_Table>(url)                
        .pipe(
            map(it=>new SimpleTablesMultipleData_Tbl_HIERARCHYID_Table(it)),                    
            concatMap((x:SimpleTablesMultipleData_Tbl_HIERARCHYID_Table,index:number)=>{
              if((index+1) % 100 === 0)
              return of<SimpleTablesMultipleData_Tbl_HIERARCHYID_Table>(x).pipe(delay(5*1000));
            else
              return of<SimpleTablesMultipleData_Tbl_HIERARCHYID_Table>(x);
            }),
            
            scan((acc:SimpleTablesMultipleData_Tbl_HIERARCHYID_Table[],value:SimpleTablesMultipleData_Tbl_HIERARCHYID_Table)=>[...acc, value] as SimpleTablesMultipleData_Tbl_HIERARCHYID_Table[], [] as SimpleTablesMultipleData_Tbl_HIERARCHYID_Table[]),
            
          );
          return data as Observable<SimpleTablesMultipleData_Tbl_HIERARCHYID_Table[]>;

    }

            public getAll():Observable<SimpleTablesMultipleData_Tbl_HIERARCHYID_Table[]>{
                //var data=ajax.getJSON(this.baseUrl+'AdvancedSearch_SimpleTablesMultipleData_Tbl_HIERARCHYID/GetAll')
                //.pipe(
                //    map(response => {        
                //        return response as SimpleTablesMultipleData_Tbl_HIERARCHYID_Table[];
                //    })
                //  );
                                var data=JsonStreamDecoder.fromFetchStream<SimpleTablesMultipleData_Tbl_HIERARCHYID_Table>(this.baseUrl+'AdvancedSearch_SimpleTablesMultipleData_Tbl_HIERARCHYID/GetAll')                
                .pipe(
                    map(it=>new SimpleTablesMultipleData_Tbl_HIERARCHYID_Table(it)),                    
                    concatMap((x:SimpleTablesMultipleData_Tbl_HIERARCHYID_Table,index:number)=>{
                      if((index+1) % 100 === 0)
                      return of<SimpleTablesMultipleData_Tbl_HIERARCHYID_Table>(x).pipe(delay(5*1000));
                    else
                      return of<SimpleTablesMultipleData_Tbl_HIERARCHYID_Table>(x);
                    }),
                    
                    scan((acc:SimpleTablesMultipleData_Tbl_HIERARCHYID_Table[],value:SimpleTablesMultipleData_Tbl_HIERARCHYID_Table)=>[...acc, value] as SimpleTablesMultipleData_Tbl_HIERARCHYID_Table[], [] as SimpleTablesMultipleData_Tbl_HIERARCHYID_Table[]),
                    
                  );
                  return data as Observable<SimpleTablesMultipleData_Tbl_HIERARCHYID_Table[]>;

            }
         }
let inputValueSearch_Tbl_HIERARCHYID = '';
export default function TableData_Tbl_HIERARCHYID() 
{
    const nameTable = 'Tbl_HIERARCHYID';
    const nameDB = 'SimpleTablesMultipleData';
    const [loading,setLoading]= useState<boolean>(false);
    const [showAll, searchSimpleData]=useSearchURL();
    
    const interaction=new SimpleTablesMultipleData_Tbl_HIERARCHYID_Table_Interaction();
    const [dataTable,setDataTable]= useState<SimpleTablesMultipleData_Tbl_HIERARCHYID_Table[]|null>(null);
const [dataTableFiltered, setDataTableFiltered] = useState<SimpleTablesMultipleData_Tbl_HIERARCHYID_Table[] | null>(null);
    
const columns : ColumnsType<SimpleTablesMultipleData_Tbl_HIERARCHYID_Table> =[
    {
        title: 'ID',
        dataIndex: 'id',
        key: 'id',
        width: '5%',
        render:(item: any, record: SimpleTablesMultipleData_Tbl_HIERARCHYID_Table, index: any)=>(<>{index+1}</>)
      }

     ,{
    title: 'ID',
    dataIndex: 'id',
    key: 'id',
    sorter: (a:SimpleTablesMultipleData_Tbl_HIERARCHYID_Table, b:SimpleTablesMultipleData_Tbl_HIERARCHYID_Table) => 
    {
        if(a.id == null && b.id == null)
            return 0;
        
        if(a.id == null)
            return -1;
        if(b.id == null)
            return 1;
                    return a.id - b.id;
            }
  } 

  
];


    const filterData = (val: string, data: SimpleTablesMultipleData_Tbl_HIERARCHYID_Table[]) => {
        if (val == null || val === '') {
            setDataTableFiltered(data);
            return;
        }
        if (data == null) {
            setDataTableFiltered(null);
            return;
        }
        val = val.toLowerCase();
        var f = data.filter(it => {
    if (it.id != null)
       if (it.id.toString().toLowerCase().includes(val))
        return true;

        return false;
        });
        setDataTableFiltered(f);
    }
    useEffect(()=>{
        document.title = nameTable+" - "+nameDB;
    })
    const [isLoadingNrRec, errorNrRect, nrRecords]= useRxObs(interaction.getAllCount());
    
    

    const showAllClickHandler=()=>{
        setDataTable(null);
        setLoading(true);
        interaction.getAll().subscribe({
          next: (data:SimpleTablesMultipleData_Tbl_HIERARCHYID_Table[])=>{
                
                setDataTable(data);
                filterData(inputValueSearch_Tbl_HIERARCHYID, data);
            },
            complete:()=>{ setLoading(false);}
          }
        )
    };
    const searchSimple=(searchData: SearchData)=>{
        if(!searchData.IsValid()){
            window.alert("Invalid search data");
            return;
        }
        setDataTable(null);
        setLoading(true);
        interaction.getSearchSimple(searchData).subscribe({
          next: (data:SimpleTablesMultipleData_Tbl_HIERARCHYID_Table[])=>{
                
                setDataTable(data);
                filterData(inputValueSearch_Tbl_HIERARCHYID, data);
            },
            complete:()=>{ setLoading(false);}
          }
        )

    };
    useEffect(()=>{
        if (typeof showAll==="boolean" &&  showAll){
            showAllClickHandler();
        }
        else{
            //console.log('basd',searchSimpleData,searchSimpleData != null && typeof searchSimpleData !== "boolean" && searchSimpleData.IsValid());
            if (searchSimpleData != null && typeof searchSimpleData !== "boolean" && searchSimpleData.IsValid())
                searchSimple(searchSimpleData);
        }
            
    // eslint-disable-next-line react-hooks/exhaustive-deps
    },[]);

    return (
    <>
        Table {nameTable} 
        {isLoadingNrRec && <Spin />} 
        {errorNrRect && <> - error loading data </>}
        {nrRecords != null && <> - {nrRecords} records</>}
        <p></p>
        <Button type="primary" loading={loading} onClick={showAllClickHandler}>Load All Tbl_HIERARCHYID</Button>
        <Link to="/Admin/Databases/SimpleTablesMultipleData/tables/Tbl_HIERARCHYID/search/showall" target={"_blank"}>Direct Link</Link>

        <DatabaseTableSelector DBName={nameDB} TableName={nameTable} loadingData={loading} searchSimple={searchSimple}  />                    <div>
            {dataTable == null && "no data loaded"}
            {dataTable !=null &&             
                <>
                Number rows loaded {dataTable?.length} {loading && <Spin />} / filtered {dataTableFiltered?.length} / Search -{inputValueSearch_Tbl_HIERARCHYID}-
                {true /*!loading*/ &&
                            <Input placeholder="SearchHere" onChange={(e) => {
                                inputValueSearch_Tbl_HIERARCHYID=(e.target.value);
                                filterData(inputValueSearch_Tbl_HIERARCHYID, dataTable!);
                            }
                            } />
                        }
                        
  <Table pagination= {false} dataSource={dataTableFiltered!} columns={columns} />;
  </>
            }
        </div>

    </>
    )
}
