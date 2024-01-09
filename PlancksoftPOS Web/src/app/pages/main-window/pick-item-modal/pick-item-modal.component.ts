import { Component, OnInit } from "@angular/core";
import { FormBuilder } from "@angular/forms";
import {
  NbSortDirection,
  NbSortRequest,
  NbTreeGridDataSource,
  NbTreeGridDataSourceBuilder,
  NbWindowRef,
} from "@nebular/theme";
import { PublisherService } from "../../../services/publisher.service";

@Component({
  selector: "ngx-pick-item-modal",
  templateUrl: "./pick-item-modal.component.html",
  styleUrls: ["./pick-item-modal.component.scss"],
})
export class PickItemModalComponent implements OnInit {
  
  filterdata: any;
  data: any;

  defaultColumns = [
    "ItemName",
    "ItemBarcode",
    "ItemQuantity",
    "Action",
  ];

  allColumns = [...this.defaultColumns];

  dataSource: NbTreeGridDataSource<any>;

  sortColumn: string;
  sortDirection: NbSortDirection = NbSortDirection.NONE;
  message: any;

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
    private fb: FormBuilder,
    private dataSourceBuilder: NbTreeGridDataSourceBuilder<any>,
    private publisherService: PublisherService,
    private windowRef: NbWindowRef
  ) {}

  ngOnInit(): void {

    var obj = {
      locale: 1,
    };

    this.publisherService
      .PostRequest("RetrieveItems", obj)
      .subscribe((res: any) => {
        console.log(JSON.parse(res));

        var response = JSON.parse(res);
        var data = response.ResponseMessage.Item1;

        this.filterdata = data;

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
              FavoriteCategory: el["FavoriteCategory"],
              warehouseName: el["warehouseName"],
              ItemTypeName: el["ItemTypeName"],
              ItemBarCode: el["ItemBarCode"],
            },
          };
          list.push(obj);
        });

        this.data = list;
        this.dataSource = this.dataSourceBuilder.create(this.data);

        console.log(this.dataSource);
      });

      this.publisherService
      .PostRequest("RetrieveFavoriteCategories", "")
      .subscribe((res: any) => {
        console.log(JSON.parse(res));

        var response = JSON.parse(res);
        this.message = response.ResponseMessage;

        console.log(this.message);
      });
  }

  Filterdata(id) {
    debugger
    var filterlist = [];
    this.dataSource = this.dataSourceBuilder.create([]);

    var selected = this.data.filter((a) => a.data.FavoriteCategory == id);

    selected.forEach((el) => {
      var obj = {
        data: {
          ItemName: el.data.ItemName,
          ItemQuantity: el.data["ItemQuantity"],
          ItemBuyPrice: el.data["ItemBuyPrice"],
          ItemPrice: el.data["ItemPrice"],
          ItemPriceTax: el.data["ItemPriceTax"],
          favoriteCategoryName: el.data["favoriteCategoryName"],
          FavoriteCategory: el.data["FavoriteCategory"],
          warehouseName: el.data["warehouseName"],
          ItemTypeName: el.data["ItemTypeName"],
          ItemBarCode: el.data["ItemBarCode"],
        },
      };

      filterlist.push(obj);
      this.dataSource = this.dataSourceBuilder.create(filterlist);
    });
  }

  pickItem(barcode) {
    console.log(barcode);
    this.windowRef.close(barcode);
  }
}
