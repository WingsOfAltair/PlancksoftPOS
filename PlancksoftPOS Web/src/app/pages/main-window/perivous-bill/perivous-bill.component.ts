import { Component, OnInit } from "@angular/core";
import {
  NbSortDirection,
  NbSortRequest,
  NbTreeGridDataSource,
  NbTreeGridDataSourceBuilder,
  NbWindowRef,
} from "@nebular/theme";

@Component({
  selector: "ngx-perivous-bill",
  templateUrl: "./perivous-bill.component.html",
  styleUrls: ["./perivous-bill.component.scss"],
})
export class PerivousBillComponent implements OnInit {
  filterdata: any;
  data: any;
  billdata: any[] = [];

  defaultColumns = [
    "ItemName",
    // "ItemBarcode",
    "ItemQuantity",
    "totalamount",
    // "Paidamount",
    // "reminder",
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
    private dataSourceBuilder: NbTreeGridDataSourceBuilder<any>,
    private windowRef: NbWindowRef
  ) {}

  ngOnInit(): void {
    this.data = this.windowRef.config.context;
    
    if (this.data) {
      const flattenedData = this.data.reduce(
        (acc, curr) => acc.concat(curr),
        []
      );

      this.billdata = flattenedData.map((el) => {
        return {
          data: {
            ItemName: el.data.ItemName,
            ItemQuantity: el.data.ItemQuantity,
            ItemBuyPrice: el.data.ItemBuyPrice,
            ItemPrice: el.data.ItemPrice,
            ItemPriceTax: el.data.ItemPriceTax,
            favoriteCategoryName: el.data.favoriteCategoryName,
            FavoriteCategory: el.data.FavoriteCategory,
            warehouseName: el.data.warehouseName,
            ItemTypeName: el.data.ItemTypeName,
            ItemBarCode: el.data.ItemBarCode,
            RandomCode: el.data.randomcode,
          },
        };
      });

      this.dataSource = this.dataSourceBuilder.create(this.billdata);
    }
  }

  pickItem(code) {
    
    this.windowRef.close(code);
  }
}
