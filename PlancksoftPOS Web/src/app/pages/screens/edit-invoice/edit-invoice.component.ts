import { Component, OnInit } from "@angular/core";
import { SmartTableData } from "../../../@core/data/smart-table";
import { FormBuilder, FormGroup } from "@angular/forms";
import { LocalDataSource } from "ng2-smart-table";
import {
  NbSortDirection,
  NbSortRequest,
  NbToastrService,
  NbTreeGridDataSource,
  NbTreeGridDataSourceBuilder,
  NbWindowService,
} from "@nebular/theme";
import { AddSellItemComponent } from "../add-sell-item/add-sell-item.component";
import { Router } from "@angular/router";
import { PublisherService } from "../../../services/publisher.service";
import { UpdateBillComponent } from "../update-bill/update-bill.component";

@Component({
  selector: "ngx-edit-invoice",
  templateUrl: "./edit-invoice.component.html",
  styleUrls: ["./edit-invoice.component.scss"],
})
export class EditInvoiceComponent implements OnInit {
  EditBillData: FormGroup;
  clientdata: any;
  BillData: any;

  defaultColumns = [
    "BillID",
    "BillCashierName",
    "NetAmount",
    "PaidAmount",
    "Remainder",
    "PaymentType",
    "Action",
  ];

  allColumns = [...this.defaultColumns];

  dataSource: NbTreeGridDataSource<any>;

  sortColumn: string;
  sortDirection: NbSortDirection = NbSortDirection.NONE;

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

  constructor(
    private service: SmartTableData,
    private fb: FormBuilder,
    private dataSourceBuilder: NbTreeGridDataSourceBuilder<any>,
    private windowService: NbWindowService,
    private router: Router,
    private publisherService: PublisherService,
    private toastrService: NbToastrService
  ) {}

  ngOnInit(): void {
    this.EditBillData = this.fb.group({
      BillID: [],
      CashierName: [],
      NetAmount: [],
      PaidAmount: [],
      Remainder: [],
    });

    this.publisherService
      .PostRequest("RetrieveBills", "")
      .subscribe((res: any) => {
        console.log(JSON.parse(res));

        var responce = JSON.parse(res);
        var array = responce.ResponseMessage.Item1;

        var list = [];
        array.forEach((el) => {
          var obj = {
            data: {
              BillNumber: el.BillNumber,
              CashierName: el.CashierName,
              totalAmount: el.totalAmount,
              paidAmount: el.paidAmount,
              RemainderAmount: el.RemainderAmount,
              paybycash: el.paybycash,
            },
          };
          list.push(obj);
        });

        this.BillData = list;
        this.dataSource = this.dataSourceBuilder.create(this.BillData);
      });
  }

  Bill() {
    this.router.navigate(["/pages/screen/sell-item"]);
  }

  update(billNumber) {
    // this.router.navigate(['/pages/screen/sell-item/' + billNumber ]);

    var selected = this.BillData.filter(
      (a) => a.data.BillNumber == billNumber
    )[0];

    var obj = {
      BillID: selected.data.BillNumber,
      CashierName: selected.data.CashierName,
      RemainderAmount: selected.data.RemainderAmount,
      totalAmount: selected.data.totalAmount,
      paidAmount: selected.data.paidAmount,
    };

    this.windowService.open(UpdateBillComponent, {
      title: `Update Bill`,
      context: obj,
    });
  }
}
