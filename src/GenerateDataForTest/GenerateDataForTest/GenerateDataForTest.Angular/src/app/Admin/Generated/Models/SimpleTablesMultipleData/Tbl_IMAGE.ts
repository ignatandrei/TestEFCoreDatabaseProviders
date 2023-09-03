﻿//this was autogenerated by a tool. Do not modify! Use partial
 import JsonStreamDecoder from "../../../Common/asyncEnumerable";
 import { HttpClient } from "@angular/common/http";;
 import { MatTableDataSource } from "@angular/material/table";
 import { concatMap, delay, map,Observable,of,scan } from "rxjs";
 import { environment } from "src/environments/environment";;
 import {Component, Injectable , OnInit } from "@angular/core";;



export class SimpleTablesMultipleData_Tbl_IMAGE_Table 
{

baseUrl:string = '';
    constructor(cc: Partial<SimpleTablesMultipleData_Tbl_IMAGE_Table> | null = null) {

    if (cc != null) {
      // Object.keys(tilt).forEach((key) => {
      //   (this as any)[key] = (tilt as any)[key];
      // });
      Object.assign(this,cc);
    }
    }

        public id : number  = 0;
                public datacolumn : number[]|null  = null;
        }

@Injectable({
    providedIn: 'root'
})
export class SimpleTablesMultipleData_Tbl_IMAGE_Table_Interaction {
    baseUrl:string = environment.url;
    constructor(private http: HttpClient) {
    }

    
    public getAllCount():Observable<number>{

        var data=this.http.get<number>(this.baseUrl+'AdvancedSearch_SimpleTablesMultipleData_Tbl_IMAGE/GetAllCount')
          return data;
    }
    /*
     public getSearchSimple(searchData:SearchData ):Observable<SimpleTablesMultipleData_Tbl_IMAGE_Table[]>{
        
        var url= this.baseUrl+'AdvancedSearch_SimpleTablesMultipleData_Tbl_IMAGE/';
        url+=`GetSearchSimple?ColumnName=${searchData.ColumnName}&Operator=${searchData.Operator}&Value=${searchData.Value}`;        
        var data=JsonStreamDecoder.fromFetchStream<SimpleTablesMultipleData_Tbl_IMAGE_Table>(url)                
        .pipe(
            map(it=>new SimpleTablesMultipleData_Tbl_IMAGE_Table(it)),                    
            concatMap((x:SimpleTablesMultipleData_Tbl_IMAGE_Table,index:number)=>{
              if((index+1) % 100 === 0)
              return of<SimpleTablesMultipleData_Tbl_IMAGE_Table>(x).pipe(delay(5*1000));
            else
              return of<SimpleTablesMultipleData_Tbl_IMAGE_Table>(x);
            }),
            
            scan((acc:SimpleTablesMultipleData_Tbl_IMAGE_Table[],value:SimpleTablesMultipleData_Tbl_IMAGE_Table)=>[...acc, value] as SimpleTablesMultipleData_Tbl_IMAGE_Table[], [] as SimpleTablesMultipleData_Tbl_IMAGE_Table[]),
            
          );
          return data as Observable<SimpleTablesMultipleData_Tbl_IMAGE_Table[]>;

    }
    */
            public getAll():Observable<SimpleTablesMultipleData_Tbl_IMAGE_Table[]>{
                //var data=ajax.getJSON(this.baseUrl+'AdvancedSearch_SimpleTablesMultipleData_Tbl_IMAGE/GetAll')
                //.pipe(
                //    map(response => {        
                //        return response as SimpleTablesMultipleData_Tbl_IMAGE_Table[];
                //    })
                //  );
                var data=JsonStreamDecoder.fromFetchStream<SimpleTablesMultipleData_Tbl_IMAGE_Table>(this.baseUrl+'AdvancedSearch_SimpleTablesMultipleData_Tbl_IMAGE/GetAll')                
                .pipe(
                    map(it=>new SimpleTablesMultipleData_Tbl_IMAGE_Table(it)),                    
                    concatMap((x:SimpleTablesMultipleData_Tbl_IMAGE_Table,index:number)=>{
                      if((index+1) % 100 === 0)
                      return of<SimpleTablesMultipleData_Tbl_IMAGE_Table>(x).pipe(delay(5*1000));
                    else
                      return of<SimpleTablesMultipleData_Tbl_IMAGE_Table>(x);
                    }),
                    
                    scan((acc:SimpleTablesMultipleData_Tbl_IMAGE_Table[],value:SimpleTablesMultipleData_Tbl_IMAGE_Table)=>[...acc, value] as SimpleTablesMultipleData_Tbl_IMAGE_Table[], [] as SimpleTablesMultipleData_Tbl_IMAGE_Table[]),
                    
                  );
                  return data as Observable<SimpleTablesMultipleData_Tbl_IMAGE_Table[]>;

            }
         }
//let inputValueSearch_Tbl_IMAGE = '';
@Component({
    selector: 'app-tabledata-Tbl_IMAGE',
    //templateUrl: './Tbl_IMAGE-gui.component.html',
    template: `here will be {{nameTable}} from {{nameDB}} 
    <span *ngIf="nrRecords!=null">Nr records: {{nrRecords}}</span>
    <p></p>    
     <button mat-raised-button color="primary" (click)="showAllClickHandler()">Show all</button>

     <span *ngIf="dataTable!=null">Loaded {{dataTable!.length}} records</span>
    <div *ngIf="dataTable!=null">
     <mat-table #table [dataSource]="dataSource!" matSort>

     <ng-container matColumnDef="rowIndex">
  <th mat-header-cell *matHeaderCellDef> Index </th>
  <td mat-cell *matCellDef="let element;index as i;"> {{ i +1 }} </td>
</ng-container>

<ng-container matColumnDef="id">
  <mat-header-cell *matHeaderCellDef mat-sort-header> ID </mat-header-cell>
  <mat-cell *matCellDef="let element"> {{element.id}} </mat-cell>
</ng-container>
<ng-container matColumnDef="datacolumn">
  <mat-header-cell *matHeaderCellDef mat-sort-header> DataColumn </mat-header-cell>
  <mat-cell *matCellDef="let element"> {{element.datacolumn}} </mat-cell>
</ng-container>
<mat-header-row *matHeaderRowDef="columns"></mat-header-row>
    <mat-row *matRowDef="let row; columns: columns;"></mat-row>    
</mat-table>
    


    `,
    //styleUrls: ['./Tbl_IMAGE-gui.component.css']
  })

export class TableData_Tbl_IMAGE implements OnInit
{
    public nameTable = 'Tbl_IMAGE';
    public nameDB = 'SimpleTablesMultipleData';
    constructor(private interaction:SimpleTablesMultipleData_Tbl_IMAGE_Table_Interaction){
    }
      public dataTable:SimpleTablesMultipleData_Tbl_IMAGE_Table[] | null = null;
      public dataTableFiltered:SimpleTablesMultipleData_Tbl_IMAGE_Table[] | null = null;
      public  dataSource : MatTableDataSource<SimpleTablesMultipleData_Tbl_IMAGE_Table> | null = null;
      public nrRecords:number|null=null;    
    ngOnInit(): void {
        this.interaction.getAllCount().subscribe(it=>{this.nrRecords=it;});
    }
    public showAllClickHandler(){
        this.interaction.getAll().subscribe(
            it=>{
                this.dataTable=it;
                this.dataTableFiltered=it;
                this.dataSource=new MatTableDataSource(it);
            }

        );
     }

public columns : string[] =[
    
        'rowIndex'
        
      ,'id'

    ,'datacolumn'

  
];

/*
    const filterData = (val: string, data: SimpleTablesMultipleData_Tbl_IMAGE_Table[]) => {
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

    if (it.datacolumn != null)
       if (it.datacolumn.toString().toLowerCase().includes(val))
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
          next: (data:SimpleTablesMultipleData_Tbl_IMAGE_Table[])=>{
                
                setDataTable(data);
                filterData(inputValueSearch_Tbl_IMAGE, data);
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
          next: (data:SimpleTablesMultipleData_Tbl_IMAGE_Table[])=>{
                
                setDataTable(data);
                filterData(inputValueSearch_Tbl_IMAGE, data);
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
        <Button type="primary" loading={loading} onClick={showAllClickHandler}>Load All Tbl_IMAGE</Button>
        <Link to="/Admin/Databases/SimpleTablesMultipleData/tables/Tbl_IMAGE/search/showall" target={"_blank"}>Direct Link</Link>

        <DatabaseTableSelector DBName={nameDB} TableName={nameTable} loadingData={loading} searchSimple={searchSimple}  />                    <div>
            {dataTable == null && "no data loaded"}
            {dataTable !=null &&             
                <>
                Number rows loaded {dataTable?.length} {loading && <Spin />} / filtered {dataTableFiltered?.length} / Search -{inputValueSearch_Tbl_IMAGE}-
                {true  &&
                            <Input placeholder="SearchHere" onChange={(e) => {
                                inputValueSearch_Tbl_IMAGE=(e.target.value);
                                filterData(inputValueSearch_Tbl_IMAGE, dataTable!);
                            }
                            } />
                        }
                        
  <Table pagination= {false} dataSource={dataTableFiltered!} columns={columns} />;
  </>
            }
        </div>

    </>
    )
*/
}
