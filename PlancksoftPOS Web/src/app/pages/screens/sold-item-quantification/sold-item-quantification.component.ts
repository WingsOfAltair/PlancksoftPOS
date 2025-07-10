import { Component, OnInit } from "@angular/core";
import { SmartTableData } from "../../../@core/data/smart-table";
import { FormBuilder, FormGroup } from "@angular/forms";
import { LocalDataSource } from "ng2-smart-table";
import {
  NbSortDirection,
  NbSortRequest,
  NbTreeGridDataSource,
  NbTreeGridDataSourceBuilder,
} from "@nebular/theme";
import { PublisherService } from "../../../services/publisher.service";

@Component({
  selector: "ngx-sold-item-quantification",
  templateUrl: "./sold-item-quantification.component.html",
  styleUrls: ["./sold-item-quantification.component.scss"],
})
export class SoldItemQuantificationComponent implements OnInit {
  SoldItemsReviewData: FormGroup;
  data: any;
  Type: any;

  defaultColumns = [
    "ItemName",
    "ItemBarcode",
    "ItemType",
    "CashierName",
    "ItemBuyPrice",
    "ItemPriceTax",
    "SoldQuantity",
    "RefundedQuantity",
    "Total",
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
    private publisherService: PublisherService
  ) {}

  ngOnInit(): void {
    this.SoldItemsReviewData = this.fb.group({
      ItemType: [0],
      CashierName: [""],
      Date1: new Date(new Date().setHours(0, 0, 0, 0)),
      Date2: new Date(new Date().setHours(23, 59, 59, 999)),
    });

    this.publisherService
      .PostRequest("RetrieveItemTypes", "")
      .subscribe((res: any) => {
        console.log(JSON.parse(res));

        var response = JSON.parse(res);
        this.Type = response.ResponseMessage;

        console.log(this.Type);
      });
  }

  SearchSoldItemsReviewsData() {
    var obj = {
      ItemTypeID: this.SoldItemsReviewData.value.ItemType,
      CashierName: this.SoldItemsReviewData.value.CashierName,
      Date1: this.convertDateToJSONFormat(this.SoldItemsReviewData.value.Date1) + " 00:00:00.000",
      Date2: this.convertDateToJSONFormat(this.SoldItemsReviewData.value.Date2) + " 23:59:59.999",
      //BillNumber: 1,
      //itemBarcode: 123,
    };

    this.publisherService
      .PostRequest("RetrieveBillItemsProfit", obj)
      .subscribe((res: any) => {
        ;
        console.log(JSON.parse(res));

        var response = JSON.parse(res);
        var data = JSON.parse(response.ResponseMessage);

        console.log(this.data);

        var list = [];
        var totalAmount = 0;
        
        data.forEach((el) => {
          var obj = {
            data: {
              CashierName: el["Cashier Name"],
              ItemBarCode: el["Item BarCode"],
              ItemName: el["Item Name"],
              ItemBuyPrice: el["Item Buy Price"],
              ItemPriceTax: el["Item Sell Price Tax"],
              ItemProfit: el["Item Profit"],
              ItemType: el["Item Type"],
              TimesSold: el["Times Sold"],
              TimesRefunded: el["Times Refunded"],
            },
          };

          totalAmount += parseFloat(el["Item Profit"]);
          list.push(obj);
        });

        var obj = {
          data: {
            CashierName: "",
            ItemBarCode: "",
            ItemName: "Total",
            ItemBuyPrice: "",
            ItemPriceTax: "",
            ItemProfit: totalAmount,
            ItemType: "",
            TimesSold: "",
            TimesRefunded: "",
          },
        };
        list.push(obj);

        this.data = list;
        this.dataSource = this.dataSourceBuilder.create(this.data);
      });
  }

  convertDateToJSONFormat(date) {
    var formattedDate = date.getFullYear() + '-' +
                        this.padZero(date.getMonth() + 1) + '-' +
                        this.padZero(date.getDate());
    return formattedDate;
  };

  // Function to pad a single digit with a leading zero
  padZero(value) {
    return value < 10 ? '0' + value : value;
  }
}
