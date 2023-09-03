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



export class SimpleTableDBContext_Department_Table 
{

baseUrl:string = '';
    constructor(cc: Partial<SimpleTableDBContext_Department_Table> | null = null) {
      this.baseUrl=process.env.REACT_APP_URL+'api/'; 

    if (cc != null) {
      // Object.keys(tilt).forEach((key) => {
      //   (this as any)[key] = (tilt as any)[key];
      // });
      Object.assign(this,cc);
    }
    }

        public iddepartment : number  = 0;
                public name : string  = '';
        }
export class SimpleTableDBContext_Department_Table_Interaction {
    baseUrl:string = '';
    constructor() {
      this.baseUrl=process.env.REACT_APP_URL+'api/'; 
    }

    
    public getAllCount():Observable<number>{

        var data=ajax.getJSON(this.baseUrl+'AdvancedSearch_SimpleTableDBContext_Department/GetAllCount')
        .pipe(
            map(response => {

                return response as number;
            })
            //takeUntil(cancel)
          );
          return data;
    }    
     public getSearchSimple(searchData:SearchData ):Observable<SimpleTableDBContext_Department_Table[]>{
        
        var url= this.baseUrl+'AdvancedSearch_SimpleTableDBContext_Department/';
        url+=`GetSearchSimple?ColumnName=${searchData.ColumnName}&Operator=${searchData.Operator}&Value=${searchData.Value}`;        
        var data=JsonStreamDecoder.fromFetchStream<SimpleTableDBContext_Department_Table>(url)                
        .pipe(
            map(it=>new SimpleTableDBContext_Department_Table(it)),                    
            concatMap((x:SimpleTableDBContext_Department_Table,index:number)=>{
              if((index+1) % 100 === 0)
              return of<SimpleTableDBContext_Department_Table>(x).pipe(delay(5*1000));
            else
              return of<SimpleTableDBContext_Department_Table>(x);
            }),
            
            scan((acc:SimpleTableDBContext_Department_Table[],value:SimpleTableDBContext_Department_Table)=>[...acc, value] as SimpleTableDBContext_Department_Table[], [] as SimpleTableDBContext_Department_Table[]),
            
          );
          return data as Observable<SimpleTableDBContext_Department_Table[]>;

    }

            public getAll():Observable<SimpleTableDBContext_Department_Table[]>{
                //var data=ajax.getJSON(this.baseUrl+'AdvancedSearch_SimpleTableDBContext_Department/GetAll')
                //.pipe(
                //    map(response => {        
                //        return response as SimpleTableDBContext_Department_Table[];
                //    })
                //  );
                                var data=JsonStreamDecoder.fromFetchStream<SimpleTableDBContext_Department_Table>(this.baseUrl+'AdvancedSearch_SimpleTableDBContext_Department/GetAll')                
                .pipe(
                    map(it=>new SimpleTableDBContext_Department_Table(it)),                    
                    concatMap((x:SimpleTableDBContext_Department_Table,index:number)=>{
                      if((index+1) % 100 === 0)
                      return of<SimpleTableDBContext_Department_Table>(x).pipe(delay(5*1000));
                    else
                      return of<SimpleTableDBContext_Department_Table>(x);
                    }),
                    
                    scan((acc:SimpleTableDBContext_Department_Table[],value:SimpleTableDBContext_Department_Table)=>[...acc, value] as SimpleTableDBContext_Department_Table[], [] as SimpleTableDBContext_Department_Table[]),
                    
                  );
                  return data as Observable<SimpleTableDBContext_Department_Table[]>;

            }
         }
let inputValueSearch_Department = '';
export default function TableData_Department() 
{
    const nameTable = 'Department';
    const nameDB = 'SimpleTableDBContext';
    const [loading,setLoading]= useState<boolean>(false);
    const [showAll, searchSimpleData]=useSearchURL();
    
    const interaction=new SimpleTableDBContext_Department_Table_Interaction();
    const [dataTable,setDataTable]= useState<SimpleTableDBContext_Department_Table[]|null>(null);
const [dataTableFiltered, setDataTableFiltered] = useState<SimpleTableDBContext_Department_Table[] | null>(null);
    
const columns : ColumnsType<SimpleTableDBContext_Department_Table> =[
    {
        title: 'ID',
        dataIndex: 'id',
        key: 'id',
        width: '5%',
        render:(item: any, record: SimpleTableDBContext_Department_Table, index: any)=>(<>{index+1}</>)
      }

     ,{
    title: 'IDDepartment',
    dataIndex: 'iddepartment',
    key: 'iddepartment',
    sorter: (a:SimpleTableDBContext_Department_Table, b:SimpleTableDBContext_Department_Table) => 
    {
        if(a.iddepartment == null && b.iddepartment == null)
            return 0;
        
        if(a.iddepartment == null)
            return -1;
        if(b.iddepartment == null)
            return 1;
                    return a.iddepartment - b.iddepartment;
            }
  } 

   ,{
    title: 'Name',
    dataIndex: 'name',
    key: 'name',
    sorter: (a:SimpleTableDBContext_Department_Table, b:SimpleTableDBContext_Department_Table) => 
    {
        if(a.name == null && b.name == null)
            return 0;
        
        if(a.name == null)
            return -1;
        if(b.name == null)
            return 1;
                
        return a.name.toString().localeCompare(b.name.toString());
            }
  } 

  
];


    const filterData = (val: string, data: SimpleTableDBContext_Department_Table[]) => {
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
    if (it.iddepartment != null)
       if (it.iddepartment.toString().toLowerCase().includes(val))
        return true;

    if (it.name != null)
       if (it.name.toString().toLowerCase().includes(val))
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
          next: (data:SimpleTableDBContext_Department_Table[])=>{
                
                setDataTable(data);
                filterData(inputValueSearch_Department, data);
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
          next: (data:SimpleTableDBContext_Department_Table[])=>{
                
                setDataTable(data);
                filterData(inputValueSearch_Department, data);
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
        <Button type="primary" loading={loading} onClick={showAllClickHandler}>Load All Department</Button>
        <Link to="/Admin/Databases/SimpleTableDBContext/tables/Department/search/showall" target={"_blank"}>Direct Link</Link>

        <DatabaseTableSelector DBName={nameDB} TableName={nameTable} loadingData={loading} searchSimple={searchSimple}  />                    <div>
            {dataTable == null && "no data loaded"}
            {dataTable !=null &&             
                <>
                Number rows loaded {dataTable?.length} {loading && <Spin />} / filtered {dataTableFiltered?.length} / Search -{inputValueSearch_Department}-
                {true /*!loading*/ &&
                            <Input placeholder="SearchHere" onChange={(e) => {
                                inputValueSearch_Department=(e.target.value);
                                filterData(inputValueSearch_Department, dataTable!);
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
