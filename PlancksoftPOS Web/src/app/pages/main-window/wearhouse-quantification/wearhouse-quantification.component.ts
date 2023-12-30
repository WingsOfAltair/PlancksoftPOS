import { Component, OnInit } from "@angular/core";
import { LocalDataSource } from "ng2-smart-table";
import { SmartTableData } from "../../../@core/data/smart-table";
import {
  NbDateService,
  NbDialogService,
  NbSortDirection,
  NbSortRequest,
  NbToastrService,
  NbTreeGridDataSource,
  NbTreeGridDataSourceBuilder,
} from "@nebular/theme";
import { FormBuilder, FormGroup } from "@angular/forms";
import { PublisherService } from "../../../services/publisher.service";
import { DatePipe } from "@angular/common";

@Component({
  selector: "ngx-wearhouse-quantification",
  templateUrl: "./wearhouse-quantification.component.html",
  styleUrls: ["./wearhouse-quantification.component.scss"],
})
export class WearhouseQuantificationComponent implements OnInit {
  wearhouse: any;
  data: any;
  list: any;

  searchWarehouse: FormGroup;

  defaultColumns = [
    "ItemName",
    "ItemBarcode",
    "ItemQuantity",
    // "BuyPrice",
    "SellPrice",
    "SellPriceTax",
    "FavoriteCategory",
    "Warehouse",
    "ItemType",
  ];

  allColumns = [...this.defaultColumns];

  dataSource: NbTreeGridDataSource<any>;

  sortColumn: string;
  sortDirection: NbSortDirection = NbSortDirection.NONE;
  filterdata: any[];

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
    private dialogService: NbDialogService,
    protected dateService: NbDateService<Date>,
    private fb: FormBuilder,
    private publisherService: PublisherService,
    private toastrService: NbToastrService,
    public datepipe: DatePipe,
    private dataSourceBuilder: NbTreeGridDataSourceBuilder<any>
  ) {
    const data = this.service.getData();
  }

  onDeleteConfirm(event): void {
    if (window.confirm("Are you sure you want to delete?")) {
      event.confirm.resolve();
    } else {
      event.confirm.reject();
    }
  }

  ngOnInit(): void {
    this.searchWarehouse = this.fb.group({
      Warehouse: [],
    });

    this.publisherService
      .PostRequest("RetrieveWarehouses", "")
      .subscribe((res: any) => {
        console.log(JSON.parse(res));

        var responce = JSON.parse(res);
        this.wearhouse = responce.ResponseMessage;

        console.log(this.wearhouse);
      });

    var obj = {
      locale: 1,
    };

    this.publisherService
      .PostRequest("RetrieveItems", obj)
      .subscribe((res: any) => {
        console.log(JSON.parse(res));

        var responce = JSON.parse(res);
        var data = responce.ResponseMessage.Item1;

        var list = [];
        data.forEach((el) => {
          var obj = {
            data: {
              ItemID: el["ItemID"],
              ItemName: el["ItemName"],
              ItemQuantity: el["ItemQuantity"],
              ItemBuyPrice: el["ItemBuyPrice"],
              ItemPrice: el["ItemPrice"],
              ItemPriceTax: el["ItemPriceTax"],
              favoriteCategoryName: el["favoriteCategoryName"],
              warehouseName: el["warehouseName"],
              ItemTypeName: el["ItemTypeName"],
              ItemBarCode: el["ItemBarCode"],
              WearhouseID: el["Warehouse_ID"],
            },
          };
          list.push(obj);
        });

        this.data = list;
        this.dataSource = this.dataSourceBuilder.create(this.data);

        console.log(this.dataSource);
      });
  }

  onSelectChange(newValue: any) {

    var obj = {
      locale: 1,
    };
    this.publisherService
      .PostRequest("RetrieveItems", obj)
      .subscribe((res: any) => {
        console.log(JSON.parse(res));

        var responce = JSON.parse(res);
        var data = responce.ResponseMessage.Item1;

        var list = [];
        data.forEach((el) => {
          var obj = {
            data: {
              ItemID: el["ItemID"],
              ItemName: el["ItemName"],
              ItemQuantity: el["ItemQuantity"],
              ItemBuyPrice: el["ItemBuyPrice"],
              ItemPrice: el["ItemPrice"],
              ItemPriceTax: el["ItemPriceTax"],
              favoriteCategoryName: el["favoriteCategoryName"],
              warehouseName: el["warehouseName"],
              ItemTypeName: el["ItemTypeName"],
              ItemBarCode: el["ItemBarCode"],
              WearhouseID: el["Warehouse_ID"],
            },
          };
          list.push(obj);
        });

        this.filterdata = list;
        
        var selected = this.filterdata.filter((a) => a.data.WearhouseID == newValue);
        ;
        var list = [];
        selected.forEach((el) => {
          var obj = {
            data: {
              ItemID: el.data["ItemID"],
              ItemName: el.data["ItemName"],
              ItemQuantity: el.data["ItemQuantity"],
              ItemBuyPrice: el.data["ItemBuyPrice"],
              ItemPrice: el.data["ItemPrice"],
              ItemPriceTax: el.data["ItemPriceTax"],
              favoriteCategoryName: el.data["favoriteCategoryName"],
              warehouseName: el.data["warehouseName"],
              ItemTypeName: el.data["ItemTypeName"],
              ItemBarCode: el.data["ItemBarCode"],
            },
          };
          list.push(obj);
        });

        this.data = list;
        this.dataSource = this.dataSourceBuilder.create(this.data);

        console.log(this.dataSource);
      });
  }
}
