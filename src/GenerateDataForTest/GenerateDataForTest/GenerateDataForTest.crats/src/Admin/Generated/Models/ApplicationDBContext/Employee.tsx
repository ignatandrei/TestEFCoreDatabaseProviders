﻿//this was autogenerated by a tool. Do not modify! Use partial
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



export class ApplicationDBContext_Employee_Table 
{

baseUrl:string = '';
    constructor(cc: Partial<ApplicationDBContext_Employee_Table> | null = null) {
      this.baseUrl=process.env.REACT_APP_URL+'api/'; 

    if (cc != null) {
      // Object.keys(tilt).forEach((key) => {
      //   (this as any)[key] = (tilt as any)[key];
      // });
      Object.assign(this,cc);
    }
    }

        public idemployee : number  = 0;
                public name : string  = '';
                public iddepartment : number  = 0;
        }
export class ApplicationDBContext_Employee_Table_Interaction {
    baseUrl:string = '';
    constructor() {
      this.baseUrl=process.env.REACT_APP_URL+'api/'; 
    }

    
    public getAllCount():Observable<number>{

        var data=ajax.getJSON(this.baseUrl+'AdvancedSearch_ApplicationDBContext_Employee/GetAllCount')
        .pipe(
            map(response => {

                return response as number;
            })
            //takeUntil(cancel)
          );
          return data;
    }    
     public getSearchSimple(searchData:SearchData ):Observable<ApplicationDBContext_Employee_Table[]>{
        
        var url= this.baseUrl+'AdvancedSearch_ApplicationDBContext_Employee/';
        url+=`GetSearchSimple?ColumnName=${searchData.ColumnName}&Operator=${searchData.Operator}&Value=${searchData.Value}`;        
        var data=JsonStreamDecoder.fromFetchStream<ApplicationDBContext_Employee_Table>(url)                
        .pipe(
            map(it=>new ApplicationDBContext_Employee_Table(it)),                    
            concatMap((x:ApplicationDBContext_Employee_Table,index:number)=>{
              if((index+1) % 100 === 0)
              return of<ApplicationDBContext_Employee_Table>(x).pipe(delay(5*1000));
            else
              return of<ApplicationDBContext_Employee_Table>(x);
            }),
            
            scan((acc:ApplicationDBContext_Employee_Table[],value:ApplicationDBContext_Employee_Table)=>[...acc, value] as ApplicationDBContext_Employee_Table[], [] as ApplicationDBContext_Employee_Table[]),
            
          );
          return data as Observable<ApplicationDBContext_Employee_Table[]>;

    }

            public getAll():Observable<ApplicationDBContext_Employee_Table[]>{
                //var data=ajax.getJSON(this.baseUrl+'AdvancedSearch_ApplicationDBContext_Employee/GetAll')
                //.pipe(
                //    map(response => {        
                //        return response as ApplicationDBContext_Employee_Table[];
                //    })
                //  );
                                var data=JsonStreamDecoder.fromFetchStream<ApplicationDBContext_Employee_Table>(this.baseUrl+'AdvancedSearch_ApplicationDBContext_Employee/GetAll')                
                .pipe(
                    map(it=>new ApplicationDBContext_Employee_Table(it)),                    
                    concatMap((x:ApplicationDBContext_Employee_Table,index:number)=>{
                      if((index+1) % 100 === 0)
                      return of<ApplicationDBContext_Employee_Table>(x).pipe(delay(5*1000));
                    else
                      return of<ApplicationDBContext_Employee_Table>(x);
                    }),
                    
                    scan((acc:ApplicationDBContext_Employee_Table[],value:ApplicationDBContext_Employee_Table)=>[...acc, value] as ApplicationDBContext_Employee_Table[], [] as ApplicationDBContext_Employee_Table[]),
                    
                  );
                  return data as Observable<ApplicationDBContext_Employee_Table[]>;

            }
         }
let inputValueSearch_Employee = '';
export default function TableData_Employee() 
{
    const nameTable = 'Employee';
    const nameDB = 'ApplicationDBContext';
    const [loading,setLoading]= useState<boolean>(false);
    const [showAll, searchSimpleData]=useSearchURL();
    
    const interaction=new ApplicationDBContext_Employee_Table_Interaction();
    const [dataTable,setDataTable]= useState<ApplicationDBContext_Employee_Table[]|null>(null);
const [dataTableFiltered, setDataTableFiltered] = useState<ApplicationDBContext_Employee_Table[] | null>(null);
    
const columns : ColumnsType<ApplicationDBContext_Employee_Table> =[
    {
        title: 'ID',
        dataIndex: 'id',
        key: 'id',
        width: '5%',
        render:(item: any, record: ApplicationDBContext_Employee_Table, index: any)=>(<>{index+1}</>)
      }

     ,{
    title: 'IDEmployee',
    dataIndex: 'idemployee',
    key: 'idemployee',
    sorter: (a:ApplicationDBContext_Employee_Table, b:ApplicationDBContext_Employee_Table) => 
    {
        if(a.idemployee == null && b.idemployee == null)
            return 0;
        
        if(a.idemployee == null)
            return -1;
        if(b.idemployee == null)
            return 1;
                    return a.idemployee - b.idemployee;
            }
  } 

   ,{
    title: 'Name',
    dataIndex: 'name',
    key: 'name',
    sorter: (a:ApplicationDBContext_Employee_Table, b:ApplicationDBContext_Employee_Table) => 
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

   ,{
    title: 'IDDepartment',
    dataIndex: 'iddepartment',
    key: 'iddepartment',
    sorter: (a:ApplicationDBContext_Employee_Table, b:ApplicationDBContext_Employee_Table) => 
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

  
];


    const filterData = (val: string, data: ApplicationDBContext_Employee_Table[]) => {
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
    if (it.idemployee != null)
       if (it.idemployee.toString().toLowerCase().includes(val))
        return true;

    if (it.name != null)
       if (it.name.toString().toLowerCase().includes(val))
        return true;

    if (it.iddepartment != null)
       if (it.iddepartment.toString().toLowerCase().includes(val))
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
          next: (data:ApplicationDBContext_Employee_Table[])=>{
                
                setDataTable(data);
                filterData(inputValueSearch_Employee, data);
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
          next: (data:ApplicationDBContext_Employee_Table[])=>{
                
                setDataTable(data);
                filterData(inputValueSearch_Employee, data);
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
        <Button type="primary" loading={loading} onClick={showAllClickHandler}>Load All Employee</Button>
        <Link to="/Admin/Databases/ApplicationDBContext/tables/Employee/search/showall" target={"_blank"}>Direct Link</Link>

        <DatabaseTableSelector DBName={nameDB} TableName={nameTable} loadingData={loading} searchSimple={searchSimple}  />                    <div>
            {dataTable == null && "no data loaded"}
            {dataTable !=null &&             
                <>
                Number rows loaded {dataTable?.length} {loading && <Spin />} / filtered {dataTableFiltered?.length} / Search -{inputValueSearch_Employee}-
                {true /*!loading*/ &&
                            <Input placeholder="SearchHere" onChange={(e) => {
                                inputValueSearch_Employee=(e.target.value);
                                filterData(inputValueSearch_Employee, dataTable!);
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
