import { Component, OnInit } from "@angular/core";
import {
  NbDateService,
  NbDialogService,
  NbSortDirection,
  NbSortRequest,
  NbToastrService,
  NbTreeGridDataSource,
  NbTreeGridDataSourceBuilder,
  NbWindowService,
} from "@nebular/theme";
import { SmartTableData } from "../../../@core/data/smart-table";
import { LocalDataSource } from "ng2-smart-table";
import { FormBuilder, FormGroup } from "@angular/forms";
import { PublisherService } from "../../../services/publisher.service";
import { DatePipe } from "@angular/common";
import { AddItemModalComponent } from "../add-item-modal/add-item-modal.component";

@Component({
  selector: "ngx-inventory",
  templateUrl: "./inventory.component.html",
  styleUrls: ["./inventory.component.scss"],
})
export class InventoryComponent implements OnInit {
  min: Date;
  max: Date;
  currentDateTime: any;
  message: any;
  wearhouse: any;
  Type: any;
  data: any;
  filterdata: any;

  additem: FormGroup;

  defaultColumns = [
    "ItemName",
    // "ItemID",
    "ItemBarcode",
    "ItemQuantity",
    // "ItemBuyPrice",
    "SellPrice",
    "SellPriceTax",
    "FavoriteCategory",
    "Warehouse",
    "ItemType",
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
    private dialogService: NbDialogService,
    protected dateService: NbDateService<Date>,
    private fb: FormBuilder,
    private publisherService: PublisherService,
    private toastrService: NbToastrService,
    public datepipe: DatePipe,
    private windowService: NbWindowService,
    private dataSourceBuilder: NbTreeGridDataSourceBuilder<any>
  ) {
    const data = this.service.getData();
    this.min = this.dateService.addDay(this.dateService.today(), -5);
    this.max = this.dateService.addDay(this.dateService.today(), 5);
  }

  onDeleteConfirm(event): void {
    if (window.confirm("Are you sure you want to delete?")) {
      event.confirm.resolve();
    } else {
      event.confirm.reject();
    }
  }

  ngOnInit(): void {
    this.currentDateTime = this.datepipe.transform(new Date(), "MM/dd/yyyy");

    console.log(this.currentDateTime);

    this.publisherService
      .PostRequest("RetrieveFavoriteCategories", "")
      .subscribe((res: any) => {
        console.log(JSON.parse(res));

        var response = JSON.parse(res);
        this.message = response.ResponseMessage;

        console.log(this.message);
      });

    this.publisherService
      .PostRequest("RetrieveWarehouses", "")
      .subscribe((res: any) => {
        console.log(JSON.parse(res));

        var response = JSON.parse(res);
        this.wearhouse = response.ResponseMessage;

        console.log(this.wearhouse);
      });

    this.publisherService
      .PostRequest("RetrieveItemTypes", "")
      .subscribe((res: any) => {
        console.log(JSON.parse(res));

        var response = JSON.parse(res);
        this.Type = response.ResponseMessage;

        console.log(this.Type);
      });

    var obj = {
      locale: 0,
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
              warehouseName: el["warehouseName"],
              ItemTypeName: el["ItemTypeName"],
              ItemBarCode: el["ItemBarCode"],
            },
          };

          list.push(obj);
        });

        this.data = list;
        this.dataSource = this.dataSourceBuilder.create(this.data);

      });
  }

  dateconvert() {
    const dateString = "this.filterdata.EntryDate";
    const milliseconds = parseInt(dateString.substr(6));
    const date = new Date(milliseconds);

    console.log(date);
  }



  openwindow() {
    
    var data = this.windowService.open(AddItemModalComponent, {
      title: `Insert Item`,
    });

    data.onClose.subscribe((res) => {
      this.ngOnInit();
    });
    this.ngOnInit();

  }

  Delete(ID) {
    var obj = {
      ItemBarCode: ID,
    };

    this.publisherService
      .PostRequest("DeleteItem", obj)
      .subscribe((res: any) => {
        console.log(JSON.parse(res));
        this.ngOnInit();
      });
  }

  update(Barcode) {
    
    var SelectedData = this.filterdata.filter(
      (a) => a.ItemBarCode == Barcode
    )[0];
    var obj = {
      ItemName: SelectedData.ItemName,
      ItemBarCode: SelectedData.ItemBarCode,
      ItemQuantity: SelectedData.ItemQuantity,
      QuantityWarning: SelectedData.QuantityWarning,
      ItemPriceTax: SelectedData.ItemPriceTax,
      EntryDate: SelectedData.EntryDate,
      ExpirationDate: SelectedData.ExpirationDate,
      ProductionDate: SelectedData.ProductionDate,
      ItemPrice: SelectedData.ItemPrice,
      ItemBuyPrice: SelectedData.ItemBuyPrice,
      ItemTypeName: SelectedData.ItemTypeID,
      favoriteCategoryName: SelectedData.FavoriteCategory,
      warehouseName: SelectedData.Warehouse_ID,
    };

    var data = this.windowService.open(AddItemModalComponent, {
      title: `Update Employee`,
      context: obj,
    });

    data.onClose.subscribe((res) => {
      this.ngOnInit();
    });
  }
}
