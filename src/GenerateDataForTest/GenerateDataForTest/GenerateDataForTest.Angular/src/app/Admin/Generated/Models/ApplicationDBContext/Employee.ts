//2.this was autogenerated by a tool. Do not modify! Use partial
 import JsonStreamDecoder from "../../../Common/asyncEnumerable";
 import { HttpClient } from "@angular/common/http";;
 import { MatTableDataSource } from "@angular/material/table";
 import { concatMap, delay, map,Observable,of,scan } from "rxjs";
 import { environment } from "src/environments/environment";;
 import {Component, Injectable , OnInit } from "@angular/core";;



export class ApplicationDBContext_Employee_Table 
{

baseUrl:string = '';
    constructor(cc: Partial<ApplicationDBContext_Employee_Table> | null = null) {

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

@Injectable({
    providedIn: 'root'
})
export class ApplicationDBContext_Employee_Table_Interaction {
    baseUrl:string = environment.url;
    constructor(private http: HttpClient) {
    }

    
    public getAllCount():Observable<number>{

        var data=this.http.get<number>(this.baseUrl+'AdvancedSearch_ApplicationDBContext_Employee/GetAllCount')
          return data;
    }
    /*
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
    */
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
//let inputValueSearch_Employee = '';
@Component({
    selector: 'app-tabledata-Employee',
    //templateUrl: './Employee-gui.component.html',
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

<ng-container matColumnDef="idemployee">
  <mat-header-cell *matHeaderCellDef mat-sort-header> IDEmployee </mat-header-cell>
  <mat-cell *matCellDef="let element"> {{element.idemployee}} </mat-cell>
</ng-container>
<ng-container matColumnDef="name">
  <mat-header-cell *matHeaderCellDef mat-sort-header> Name </mat-header-cell>
  <mat-cell *matCellDef="let element"> {{element.name}} </mat-cell>
</ng-container>
<ng-container matColumnDef="iddepartment">
  <mat-header-cell *matHeaderCellDef mat-sort-header> IDDepartment </mat-header-cell>
  <mat-cell *matCellDef="let element"> {{element.iddepartment}} </mat-cell>
</ng-container>
<mat-header-row *matHeaderRowDef="columns"></mat-header-row>
    <mat-row *matRowDef="let row; columns: columns;"></mat-row>    
</mat-table>
    


    `,
    //styleUrls: ['./Employee-gui.component.css']
  })

export class TableData_Employee implements OnInit
{
    public nameTable = 'Employee';
    public nameDB = 'ApplicationDBContext';
    constructor(private interaction:ApplicationDBContext_Employee_Table_Interaction){
    }
      public dataTable:ApplicationDBContext_Employee_Table[] | null = null;
      public dataTableFiltered:ApplicationDBContext_Employee_Table[] | null = null;
      public  dataSource : MatTableDataSource<ApplicationDBContext_Employee_Table> | null = null;
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
        
      ,'idemployee'

    ,'name'

    ,'iddepartment'

  
];

/*
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
                {true  &&
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
*/
}
