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

  imageSrc: any;
  imageByteArray: any;

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
    "Picture",
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
        var data = JSON.parse(response.ResponseMessage.Item2);
        console.log("item 2: " + data[0]);

        this.filterdata = data;

        var list = [];
        data.forEach((el) => {
          var obj = {
            data: {
              ItemID: el["Item ID"],
              ItemName: el["Item Name"],
              ItemQuantity: el["Item Quantity"],
              ItemBuyPrice: el["Item Buy Price"],
              ItemPrice: el["Item Price"],
              ItemPriceTax: el["Item Price Tax"],
              favoriteCategoryName: el["Favorite Category"],
              warehouseName: el["InventoryItemWarehouse"],
              ItemTypeName: el["InventoryItemType"],
              ItemBarCode: el["Item BarCode"],
              Picture: 'data:' + 'image/png' + ';base64,' + el["Item Picture"],
            },
          };

          console.log("picture: " + obj.data.Picture);
          list.push(obj);
        });

        this.data = list;
        this.dataSource = this.dataSourceBuilder.create(this.data);

      });
  }

  convertDataURIToBinary(dataURI) {
    var base64Index = dataURI.indexOf(';base64,') + ';base64,'.length;
    var base64 = dataURI.substring(base64Index);
    var raw = window.atob(base64);
    var rawLength = raw.length;
    var array = new Uint8Array(new ArrayBuffer(rawLength));
  
    for(var i = 0; i < rawLength; i++) {
      array[i] = raw.charCodeAt(i);
    }
    return array;
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
    
    console.log(Barcode);
    var obj = {"ItemBarCode":Barcode};

    this.publisherService
      .PostRequest("SearchItems", obj)
      .subscribe((res: any) => {
        console.log(JSON.parse(res));
        
        var response = JSON.parse(res);
        var data = JSON.parse(response.ResponseMessage.Item1);

        var obj = {
            ItemName: data[0]["Item Name"],
            ItemQuantity: data[0]["Item Quantity"],
            QuantityWarning: 0,
            ItemBuyPrice: data[0]["Item Buy Price"],
            ItemPrice: data[0]["Item Price"],
            ItemPriceTax: data[0]["Item Price Tax"],
            favoriteCategoryName: data[0]["Favorite Category"],
            warehouseName: data[0]["InventoryItemWarehouse"],
            ItemTypeName: data[0]["InventoryItemType"],
            ItemBarCode: data[0]["Item BarCode"],
            Picture: 'data:' + 'image/png' + ';base64,' + data[0]["Item Picture"],
          };

          console.log("Picture: " + obj.Picture);
        });

        var data = this.windowService.open(AddItemModalComponent, {
          title: `Update Item`,
          context: obj,
        });
    
        data.onClose.subscribe((res) => {
          this.ngOnInit();
        });

      /*ItemName: SelectedData.ItemName,
      ItemQuantity: SelectedData.ItemQuantity,
      QuantityWarning: SelectedData.QuantityWarning,
      ItemBuyPrice: SelectedData.ItemBuyPrice,
      ItemPrice: SelectedData.ItemPrice,
      ItemPriceTax: SelectedData.ItemPriceTax,
      EntryDate: SelectedData.EntryDate,
      ExpirationDate: SelectedData.ExpirationDate,
      ProductionDate: SelectedData.ProductionDate,
      ItemTypeName: SelectedData.ItemTypeID,
      favoriteCategoryName: SelectedData.FavoriteCategory,
      warehouseName: SelectedData.Warehouse_ID,
      picture: SelectedData.Picture,*/
  }
}
