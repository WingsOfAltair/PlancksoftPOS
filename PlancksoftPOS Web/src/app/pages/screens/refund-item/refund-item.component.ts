import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup } from "@angular/forms";
import {
  NbSortDirection,
  NbSortRequest,
  NbToastrService,
  NbTreeGridDataSource,
  NbTreeGridDataSourceBuilder,
  NbWindowService,
} from "@nebular/theme";
import { PublisherService } from "../../../services/publisher.service";
import { LocalDataSource } from "ng2-smart-table";
import { SmartTableData } from "../../../@core/data/smart-table";
import { ReturnItemModalComponent } from "../return-item-modal/return-item-modal.component";

@Component({
  selector: "ngx-refund-item",
  templateUrl: "./refund-item.component.html",
  styleUrls: ["./refund-item.component.scss"],
})
export class RefundItemComponent implements OnInit {
  data: any;
  Return: FormGroup;

  defaultColumns = [
    "ItemName",
    "ItemBarcode",
    "CurrentQuantity",
    "ProductionDate",
    "ExpirationDate",
    "warninglimit",
    "Date",
  ];
  allColumns = [...this.defaultColumns];

  dataSource: NbTreeGridDataSource<any>;

  sortColumn: string;
  sortDirection: NbSortDirection = NbSortDirection.NONE;

  constructor(
    private service: SmartTableData,
    private fb: FormBuilder,
    private windowService: NbWindowService,
    private publisherService: PublisherService,
    private toastrService: NbToastrService,
    private dataSourceBuilder: NbTreeGridDataSourceBuilder<any>
  ) {}

  ngOnInit(): void {
    this.Return = this.fb.group({
      itemName: [],
      itemBarcode: [],
      ItemAmount: [],
    });

    this.publisherService
      .PostRequest("RetrieveReturnedItems", "")
      .subscribe((res: any) => {
        debugger;
        console.log(JSON.parse(res));

        var response = JSON.parse(res);
        var data = JSON.parse(response.ResponseMessage);

        console.log(this.data);

        var list = [];
        data.forEach((el) => {
          const date = new Date(el["Transaction Date"]);
          const formattedDate = date.toLocaleString('en-US', {
            year: 'numeric',
            month: '2-digit',
            day: '2-digit',
            hour: '2-digit',
            minute: '2-digit',
            second: '2-digit',
            hour12: true, // 12-hour format
          });
          var obj = {
            data: {
              ItemName: el["Item Name"],
              BillID: el["Bill ID"],
              CashierName: el["Cashier Name"],
              ItemBarcode: el["Item BarCode"],
              ItemQuantity: el["Item Quantity"],
              TransctionID: el["Transaction ID"],
              Date: formattedDate,
            },
          };

          list.push(obj);
        });

        this.data = list;
        this.dataSource = this.dataSourceBuilder.create(this.data);

        console.log(this.dataSource);
      });
  }

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

  submit() {
    if (this.Return.valid) {
      console.log(this.Return.value);

      var obj = {
        ItemName: this.Return.value.itemName,
        ItemQuantity: parseInt(this.Return.value.ItemAmount),
        ItemBarCode: this.Return.value.itemBarcode,
        cashierName: "1",
      };

      this.publisherService
        .PostRequest("ReturnItem", obj)
        .subscribe((res: any) => {
          console.log(JSON.parse(res));
        });
    } else {
      this.toastrService.danger("Try Again", "Error");
    }

    console.log(this.Return.value);
  }

  ReturnItem() {
    this.windowService.open(ReturnItemModalComponent, {
      title: `Return Item`,
    });
  }
}
