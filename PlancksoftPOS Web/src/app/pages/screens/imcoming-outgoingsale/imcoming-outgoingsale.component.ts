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
import { FormBuilder, FormGroup } from "@angular/forms";

@Component({
  selector: "ngx-imcoming-outgoingsale",
  templateUrl: "./imcoming-outgoingsale.component.html",
  styleUrls: ["./imcoming-outgoingsale.component.scss"],
})
export class ImcomingOutgoingsaleComponent implements OnInit {
  IncomingData: FormGroup;
  OutgoingData: FormGroup;
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
    "PaymentMethod"
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
    private fb: FormBuilder,
    private dataSourceBuilder: NbTreeGridDataSourceBuilder<any>,
    private publisherService: PublisherService
  ) {}
  ngOnInit(): void {
    this.IncomingData = this.fb.group({
      Date1: [],
      Date2: [],
    });
    this.OutgoingData = this.fb.group({
      Date3: [],
      Date4: [],
    });
    
    var obj = {
      Date1: "",
      Date2: "",
    }

    this.publisherService
      .PostRequest("RetrieveUnPortedBills", obj)
      .subscribe((res: any) => {
        console.log(JSON.parse(res));

        var response = JSON.parse(res);
        var array = response.ResponseMessage.Item1;
        
        var list = [];
        var totalAmount = 0;

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
          console.log("Pay by cash");
          console.log(el.PayByCash);
          totalAmount += parseFloat(el.totalAmount);
          list.push(obj);
        });

        var obj = {
          data: {
            BillNumber: "Total",
            CashierName: '',
            totalAmount: totalAmount,
            paidAmount: '',
            RemainderAmount: '',
            PayByCash: ""
          }
        }
        list.push(obj);

        this.data = list;
        this.dataSource = this.dataSourceBuilder.create(this.data);

        console.log(this.dataSource);
      });
  }

  SearchIncoming() {
    var obj = {
      Date1: this.IncomingData.value.Date1,
      Date2: this.IncomingData.value.Date2,
    }

    this.publisherService
      .PostRequest("RetrieveUnPortedBills", obj)
      .subscribe((res: any) => {
        console.log(JSON.parse(res));

        var response = JSON.parse(res);
        var array = response.ResponseMessage.Item1;
        
        var list = [];
        var totalAmount = 0;

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
          console.log("Pay by cash");
          console.log(el.PayByCash);
          totalAmount += parseFloat(el.totalAmount);
          list.push(obj);
        });

        var obj = {
          data: {
            BillNumber: "Total",
            CashierName: '',
            totalAmount: totalAmount,
            paidAmount: '',
            RemainderAmount: '',
            PayByCash: ""
          }
        }
        list.push(obj);

        this.data = list;
        this.dataSource = this.dataSourceBuilder.create(this.data);

        console.log(this.dataSource);
      });
  }
  
  SearchOutgoing() {
    var obj = {
      Date1: this.OutgoingData.value.Date3,
      Date2: this.OutgoingData.value.Date4,
    }

    this.publisherService
      .PostRequest("RetrievePortedBills", obj)
      .subscribe((res: any) => {
        console.log(JSON.parse(res));

        var response = JSON.parse(res);
        var data = JSON.parse(response.ResponseMessage.Item2);

        var list = [];
        var totalAmount = 0;

        data.forEach((el) => {
          var obj = {
            data: {
              // EmployeeAddress: el["Employee Address"],
              BillNumber: el["Bill Number"],
              CashierName: el["Cashier Name"],
              TotalAmount: el["Total Amount"],
              PaidAmount: el["Paid Amount"],
              RemainderAmount: el["Remainder Amount"],
              Status: el["Payment Type"]
            },
          };
          totalAmount += parseFloat(el["Total Amount"]);
          list.push(obj);
        });

        var obj = {
          data: {
            BillNumber: "Total",
            CashierName: '',
            TotalAmount: '',
            PaidAmount: '',
            RemainderAmount: '',
            Status: totalAmount
          }
        }
        list.push(obj);

        console.log("list")
        console.log(list);

        this.data = list;
        this.dataSource1 = this.dataSourceBuilder.create(this.data);

        console.log(this.dataSource);
      });
  }
}
