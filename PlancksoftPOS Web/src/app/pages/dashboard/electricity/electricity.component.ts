import { Component, OnDestroy } from "@angular/core";
import {
  NbSortDirection,
  NbSortRequest,
  NbThemeService,
  NbTreeGridDataSource,
  NbTreeGridDataSourceBuilder,
} from "@nebular/theme";

import {
  Electricity,
  ElectricityChart,
  ElectricityData,
} from "../../../@core/data/electricity";
import { takeWhile } from "rxjs/operators";
import { forkJoin } from "rxjs";
import { PublisherService } from "../../../services/publisher.service";
import { FormBuilder, FormGroup } from "@angular/forms";

@Component({
  selector: "ngx-electricity",
  styleUrls: ["./electricity.component.scss"],
  templateUrl: "./electricity.component.html",
})
export class ElectricityComponent implements OnDestroy {
  private alive = true;
  data: any;
  filterdata: any;
  firstform:FormGroup

  listData: Electricity[];
  chartData: ElectricityChart[];

  defaultColumns = [
    "BillID",
    "CashierName",
    "NetTotal",
    "PaidAmount",
    "Remainder",
  ];

  allColumns = [...this.defaultColumns];

  dataSource: NbTreeGridDataSource<any>;

  sortColumn: string;
  sortDirection: NbSortDirection = NbSortDirection.NONE;
  selectedDate: Date;

  updateSort(sortRequest: NbSortRequest): void {
    this.sortColumn = sortRequest.column;
    this.sortDirection = sortRequest.direction;
  }

  getSortDirection(column: string): NbSortDirection {
    if (this.sortColumn === column) {
      return this.sortDirection;
    }
    return NbSortDirection.NONE;
  }
  getShowOn(index: number) {
    const minWithForMultipleColumns = 400;
    const nextColumnStep = 100;
    return minWithForMultipleColumns + nextColumnStep * index;
  }

  type = "week";
  types = ["week", "month", "year"];

  currentTheme: string;
  themeSubscription: any;

  constructor(
    private electricityService: ElectricityData,
    private publisherService: PublisherService,
    private dataSourceBuilder: NbTreeGridDataSourceBuilder<any>,
    private fb: FormBuilder,
    private themeService: NbThemeService
  ) {
    this.themeService
      .getJsTheme()
      .pipe(takeWhile(() => this.alive))
      .subscribe((theme) => {
        this.currentTheme = theme.name;
      });

    forkJoin(
      this.electricityService.getListData(),
      this.electricityService.getChartData(),
    )
      .pipe(takeWhile(() => this.alive))
      .subscribe(([listData, chartData]: [Electricity[], ElectricityChart[]] ) => {
        this.listData = listData;
        this.chartData = chartData;
      });

    this.publisherService
      .PostRequest("RetrieveBills", "")
      .subscribe((res: any) => {

        console.log(JSON.parse(res));

        var response = JSON.parse(res);

        var array = response.ResponseMessage.Item1;

        var todaydate = new Date()
        
        var data = array.filter(a => a.Date == todaydate)
   
        var list = [];

        array.forEach((el) => {
          var obj = {
            data: {
              // EmployeeAddress: el["Employee Address"],
              BillNumber: el["BillNumber"],
              CashierName: el["CashierName"],
              PaidAmount: el["PaidAmount"],
              TotalAmount: el["TotalAmount"],
              RemainderAmount: el["RemainderAmount"],
              paybycash: el["paybycash"],
              Date: el["Date"],
            },
          };

          list.push(obj);
        });

        this.data = list;
        this.dataSource = this.dataSourceBuilder.create(this.data);

        console.log(this.dataSource);
      });

      this.firstform = this.fb.group({
        datepicker: []
      })
  }

  convertDateToJSONFormat(date) {
    
    var milliseconds = date.getTime();
    return "/Date(" + milliseconds + ")/";
  }

  ngOnDestroy() {
    this.alive = false;

  }



  onDateSelection(){
    
    

   
    var date = this.convertDateToJSONFormat(this.firstform.value.datepicker)
    

    this.publisherService
      .PostRequest("RetrieveBills", "")
      .subscribe((res: any) => {
        ;
        console.log(JSON.parse(res));

        var response = JSON.parse(res);

        var array = response.ResponseMessage.Item1;

        var filter = array.filter(a => a.Date == date )

        
        var list = [];

        filter.forEach((el) => {
          var obj = {
            data: {
              // EmployeeAddress: el["Employee Address"],
              BillNumber: el["BillNumber"],
              CashierName: el["CashierName"],
              PaidAmount: el["PaidAmount"],
              TotalAmount: el["TotalAmount"],
              RemainderAmount: el["RemainderAmount"],
              paybycash: el["paybycash"],
              Date: el["Date"],
            },
          };
          ;
          list.push(obj);
        });

        this.data = list;
        this.dataSource = this.dataSourceBuilder.create(this.data);

        console.log(this.dataSource);
      });

  }
}
