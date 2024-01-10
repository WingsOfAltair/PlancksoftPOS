import { Component, OnInit } from "@angular/core";
import { LocalDataSource } from "ng2-smart-table";
import { SmartTableData } from "../../../@core/data/smart-table";
import {
  NbSortDirection,
  NbSortRequest,
  NbTreeGridDataSource,
  NbTreeGridDataSourceBuilder,
} from "@nebular/theme";
import { PublisherService } from "../../../services/publisher.service";
import { debug } from "console";

@Component({
  selector: "ngx-imcoming-outgoingsale",
  templateUrl: "./imcoming-outgoingsale.component.html",
  styleUrls: ["./imcoming-outgoingsale.component.scss"],
})
export class ImcomingOutgoingsaleComponent implements OnInit {
  data: any;

  defaultColumns = [
    "BillID",
    "CashierName",
    "NetAmount",
    "PaidAmount",
    "Remainder",
    "PaymentMethod",
  ];

  allColumns = [...this.defaultColumns];

  dataSource: NbTreeGridDataSource<any>;

  sortColumn: string;
  sortDirection: NbSortDirection = NbSortDirection.NONE;
  BillData: any[];

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

  defaultColumns1 = [
    "BillID",
    "CashierName",
    "NetAmount",
    "PaidAmount",
    "Remainder",
    "PaymentMethod",
    "Total",
  ];

  allColumns1 = [...this.defaultColumns1];

  dataSource1: NbTreeGridDataSource<any>;

  sortColumn1: string;
  sortDirection1: NbSortDirection = NbSortDirection.NONE;

  updateSort1(sortRequest: NbSortRequest): void {
    this.sortColumn1 = sortRequest.column;
    this.sortDirection1 = sortRequest.direction;
  }

  getSortDirection1(column: string): NbSortDirection {
    if (this.sortColumn1 === column) {
      return this.sortDirection1;
    }
    return NbSortDirection.NONE;
  }
  getShowOn1(index: number) {
    const minWithForMultipleColumns = 400;
    const nextColumnStep = 100;
    return minWithForMultipleColumns + nextColumnStep * index;
  }

  constructor(
    private service: SmartTableData,
    private dataSourceBuilder: NbTreeGridDataSourceBuilder<any>,
    private publisherService: PublisherService
  ) {}
  ngOnInit(): void {
    this.publisherService
      .PostRequest("RetrieveBills", "")
      .subscribe((res: any) => {
        console.log(JSON.parse(res));

        var response = JSON.parse(res);
        var array = response.ResponseMessage.Item1;
        
        var list = [];
        array.forEach((el) => {
          var obj = {
            data: {
              BillNumber: el.BillNumber,
              CashierName: el.CashierName,
              totalAmount: el.totalAmount,
              paidAmount: el.paidAmount,
              RemainderAmount: el.RemainderAmount,
              PayByCash: el.PayByCash,
            },
          };
          list.push(obj);
        });

        this.data = list;
        this.dataSource = this.dataSourceBuilder.create(this.data);

        console.log(this.dataSource);
      });

    this.publisherService
      .PostRequest("RetrievePortedBills", "")
      .subscribe((res: any) => {
        console.log(JSON.parse(res));

        var response = JSON.parse(res);
        var array = response.ResponseMessage.Item1;

        var list = [];

        array.forEach((el) => {
          var obj = {
            data: {
              // EmployeeAddress: el["Employee Address"],
              ClientID: el["ClientID"],
              ClientName: el["Client ID"],
              CashierName: el["Cashier Name"],
              BillNumber: el["Bill Number"],
              Date: el["Date"],
              PaidAmount: el["Paid Amount"],
              RemainderAmount: el["Remainder Amount"],
              Status: el["Status"],
              TotalAmount: el["Total Amount"],
            },
          };
          list.push(obj);
        });

        this.data = list;
        this.dataSource1 = this.dataSourceBuilder.create(this.data);

        console.log(this.dataSource);
      });
  }
}
