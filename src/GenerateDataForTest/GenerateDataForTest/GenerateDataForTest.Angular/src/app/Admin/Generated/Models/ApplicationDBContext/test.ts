﻿//this was autogenerated by a tool. Do not modify! Use partial
 import JsonStreamDecoder from "../../../Common/asyncEnumerable";
 import { HttpClient } from "@angular/common/http";;
 import { MatTableDataSource } from "@angular/material/table";
 import { concatMap, delay, map,Observable,of,scan } from "rxjs";
 import { environment } from "src/environments/environment";;
 import {Component, Injectable , OnInit } from "@angular/core";;



export class ApplicationDBContext_test_Table 
{

baseUrl:string = '';
    constructor(cc: Partial<ApplicationDBContext_test_Table> | null = null) {

    if (cc != null) {
      // Object.keys(tilt).forEach((key) => {
      //   (this as any)[key] = (tilt as any)[key];
      // });
      Object.assign(this,cc);
    }
    }

        public id : number  = 0;
                public name : string|null  = null;
        }

@Injectable({
    providedIn: 'root'
})
export class ApplicationDBContext_test_Table_Interaction {
    baseUrl:string = environment.url;
    constructor(private http: HttpClient) {
    }

    
    public getAllCount():Observable<number>{

        var data=this.http.get<number>(this.baseUrl+'AdvancedSearch_ApplicationDBContext_test/GetAllCount')
          return data;
    }
    /*
     public getSearchSimple(searchData:SearchData ):Observable<ApplicationDBContext_test_Table[]>{
        
        var url= this.baseUrl+'AdvancedSearch_ApplicationDBContext_test/';
        url+=`GetSearchSimple?ColumnName=${searchData.ColumnName}&Operator=${searchData.Operator}&Value=${searchData.Value}`;        
        var data=JsonStreamDecoder.fromFetchStream<ApplicationDBContext_test_Table>(url)                
        .pipe(
            map(it=>new ApplicationDBContext_test_Table(it)),                    
            concatMap((x:ApplicationDBContext_test_Table,index:number)=>{
              if((index+1) % 100 === 0)
              return of<ApplicationDBContext_test_Table>(x).pipe(delay(5*1000));
            else
              return of<ApplicationDBContext_test_Table>(x);
            }),
            
            scan((acc:ApplicationDBContext_test_Table[],value:ApplicationDBContext_test_Table)=>[...acc, value] as ApplicationDBContext_test_Table[], [] as ApplicationDBContext_test_Table[]),
            
          );
          return data as Observable<ApplicationDBContext_test_Table[]>;

    }
    */
            public getAll():Observable<ApplicationDBContext_test_Table[]>{
                //var data=ajax.getJSON(this.baseUrl+'AdvancedSearch_ApplicationDBContext_test/GetAll')
                //.pipe(
                //    map(response => {        
                //        return response as ApplicationDBContext_test_Table[];
                //    })
                //  );
                var data=JsonStreamDecoder.fromFetchStream<ApplicationDBContext_test_Table>(this.baseUrl+'AdvancedSearch_ApplicationDBContext_test/GetAll')                
                .pipe(
                    map(it=>new ApplicationDBContext_test_Table(it)),                    
                    concatMap((x:ApplicationDBContext_test_Table,index:number)=>{
                      if((index+1) % 100 === 0)
                      return of<ApplicationDBContext_test_Table>(x).pipe(delay(5*1000));
                    else
                      return of<ApplicationDBContext_test_Table>(x);
                    }),
                    
                    scan((acc:ApplicationDBContext_test_Table[],value:ApplicationDBContext_test_Table)=>[...acc, value] as ApplicationDBContext_test_Table[], [] as ApplicationDBContext_test_Table[]),
                    
                  );
                  return data as Observable<ApplicationDBContext_test_Table[]>;

            }
         }
//let inputValueSearch_test = '';
@Component({
    selector: 'app-tabledata-test',
    //templateUrl: './test-gui.component.html',
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
  <mat-header-cell *matHeaderCellDef mat-sort-header> id </mat-header-cell>
  <mat-cell *matCellDef="let element"> {{element.id}} </mat-cell>
</ng-container>
<ng-container matColumnDef="name">
  <mat-header-cell *matHeaderCellDef mat-sort-header> name </mat-header-cell>
  <mat-cell *matCellDef="let element"> {{element.name}} </mat-cell>
</ng-container>
<mat-header-row *matHeaderRowDef="columns"></mat-header-row>
    <mat-row *matRowDef="let row; columns: columns;"></mat-row>    
</mat-table>
    


    `,
    //styleUrls: ['./test-gui.component.css']
  })

export class TableData_test implements OnInit
{
    public nameTable = 'test';
    public nameDB = 'ApplicationDBContext';
    constructor(private interaction:ApplicationDBContext_test_Table_Interaction){
    }
      public dataTable:ApplicationDBContext_test_Table[] | null = null;
      public dataTableFiltered:ApplicationDBContext_test_Table[] | null = null;
      public  dataSource : MatTableDataSource<ApplicationDBContext_test_Table> | null = null;
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

    ,'name'

  
];

/*
    const filterData = (val: string, data: ApplicationDBContext_test_Table[]) => {
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
          next: (data:ApplicationDBContext_test_Table[])=>{
                
                setDataTable(data);
                filterData(inputValueSearch_test, data);
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
          next: (data:ApplicationDBContext_test_Table[])=>{
                
                setDataTable(data);
                filterData(inputValueSearch_test, data);
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
        <Button type="primary" loading={loading} onClick={showAllClickHandler}>Load All test</Button>
        <Link to="/Admin/Databases/ApplicationDBContext/tables/test/search/showall" target={"_blank"}>Direct Link</Link>

        <DatabaseTableSelector DBName={nameDB} TableName={nameTable} loadingData={loading} searchSimple={searchSimple}  />                    <div>
            {dataTable == null && "no data loaded"}
            {dataTable !=null &&             
                <>
                Number rows loaded {dataTable?.length} {loading && <Spin />} / filtered {dataTableFiltered?.length} / Search -{inputValueSearch_test}-
                {true  &&
                            <Input placeholder="SearchHere" onChange={(e) => {
                                inputValueSearch_test=(e.target.value);
                                filterData(inputValueSearch_test, dataTable!);
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