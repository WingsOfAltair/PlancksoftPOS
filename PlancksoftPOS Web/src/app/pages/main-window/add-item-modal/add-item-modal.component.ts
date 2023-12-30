import { Component, OnInit } from "@angular/core";
import { SmartTableData } from "../../../@core/data/smart-table";
import {
  NbDateService,
  NbDialogService,
  NbToastrService,
  NbWindowRef,
} from "@nebular/theme";
import { FormBuilder, FormGroup } from "@angular/forms";
import { PublisherService } from "../../../services/publisher.service";

@Component({
  selector: "ngx-add-item-modal",
  templateUrl: "./add-item-modal.component.html",
  styleUrls: ["./add-item-modal.component.scss"],
})
export class AddItemModalComponent implements OnInit {
  min: Date;
  max: Date;
  currentDateTime: any;
  message: any;
  wearhouse: any;
  Type: any;
  datee: any;

  inputValue1: number = 0;
  inputValue2: number = 0;
  sumResult: number = 0;

  inputValue3: number = 0;
  additem: FormGroup;
  source: any;
  data: any;
  ExpiryDateFormat: any;
  EntryDate: any;
  ProductionDate: any;
  itemquantity: NodeJS.Timeout;
  Selltex: any;
  tax: any;
  calcuatetex: any;

  constructor(
    private service: SmartTableData,
    private dialogService: NbDialogService,
    protected dateService: NbDateService<Date>,
    private fb: FormBuilder,
    private publisherService: PublisherService,
    private toastrService: NbToastrService,
    private windowRef: NbWindowRef
  ) {
    // const data = this.service.getData();
    // // this.source.load(data);
    // this.min = this.dateService.addDay(this.dateService.today(), -5);
    // this.max = this.dateService.addDay(this.dateService.today(), 5);
  }

  ngOnInit(): void {
    this.data = this.windowRef.config.context;

    this.additem = this.fb.group({
      itemname: [""],
      itembarcode: [""],
      itemquantity: [""],
      buyprice: [""],
      warninglimit: [""],
      sellpricetax: [""],
      ProductionDate: [""],
      ExpirationDate: [""],
      EntryDate: [""],
      FavoriteCategory: [""],
      ItemType: [""],
      Warehouse: [""],
      ItemPrice: [""],
    });

    this.publisherService
      .PostRequest("RetrieveFavoriteCategories", "")
      .subscribe((res: any) => {
        console.log(JSON.parse(res));

        var responce = JSON.parse(res);
        this.message = responce.ResponseMessage;

        console.log(this.message);
      });

    this.publisherService
      .PostRequest("RetrieveWarehouses", "")
      .subscribe((res: any) => {
        console.log(JSON.parse(res));

        var responce = JSON.parse(res);
        this.wearhouse = responce.ResponseMessage;

        console.log(this.wearhouse);
      });

    this.publisherService
      .PostRequest("RetrieveItemTypes", "")
      .subscribe((res: any) => {
        console.log(JSON.parse(res));

        var responce = JSON.parse(res);
        this.Type = responce.ResponseMessage;

        console.log(this.Type);
      });

    if (this.data.ItemBarCode) {
      
      this.inputValue1 = this.data.ItemBuyPrice;
      this.inputValue2 = this.data.ItemPrice;

      this.inputValue3 = this.data.ItemQuantity;
      this.Selltex = this.data.ItemPriceTax;

      this.ProductionDate = new Date();
      this.ExpiryDateFormat = new Date();
      this.EntryDate = new Date();

      const itemData = {
        itemname: this.data.ItemName,
        itembarcode: this.data.ItemBarCode,
        itemquantity: this.data.ItemQuantity,
        ItemPrice: this.data.ItemPrice,
        sellpricetax: this.data.ItemPriceTax,
        buyprice: this.data.ItemQuantity,
        warninglimit: this.data.QuantityWarning,
        ProductionDate: this.ProductionDate,
        ExpirationDate: this.ExpiryDateFormat,
        EntryDate: this.EntryDate,
        FavoriteCategory: this.data.favoriteCategoryName,
        ItemType: this.data.ItemTypeName,
        Warehouse: this.data.warehouseName,
      };

      this.additem.patchValue(itemData);
    }

    this.disableItemName();
  }

  disableItemName() {
    this.additem.get("itemquantity").disable();
    this.additem.get("sellpricetax").disable();
  }

  ChangeDateFormat() {
    const Expiry = this.data.ExpirationDate;
    const numericPart = Expiry.match(/-?\d+/)[0];
    const numericDate = parseInt(numericPart, 10);
    this.ExpiryDateFormat = new Date(numericDate);

    const Entry = this.data.EntryDate;
    const numeric = Entry.match(/-?\d+/)[0];
    const EntryDate = parseInt(numeric, 10);
    this.EntryDate = new Date(EntryDate);

    const Production = this.data.ProductionDate;
    const ProductionDa = Production.match(/-?\d+/)[0];
    const ProducDate = parseInt(ProductionDa, 10);
    this.ProductionDate = new Date(ProducDate);

    console.log("Formatted Date:", this.ProductionDate);
  }

  SubmitData() {
    if (this.additem.valid) {
      console.log(this.additem.value);

      var obj = {
        ItemToInsert: {
          ItemID: 0,
          ItemName: this.additem.value.itemname,
          ItemBarCode: this.additem.value.itembarcode,
          favoriteCategoryName: "",
          warehouseName: "",
          itemTypeName: "",
          ItemQuantity: 0,
          ItemBuyPrice:
            this.additem.value.buyprice > 0
              ? this.additem.value.buyprice
              : this.inputValue1,
          ItemPrice:
            this.additem.value.ItemPrice > 0
              ? this.additem.value.ItemPrice
              : this.inputValue2,
          QuantityWarning: parseInt(this.additem.value.warninglimit),
          ItemPriceTax: this.sumResult,
          ItemTypeID: parseInt(this.additem.value.ItemType),
          Warehouse_ID: parseInt(this.additem.value.Warehouse),
          FavoriteCategory: parseInt(this.additem.value.FavoriteCategory),
          Date: this.convertDateToJSONFormat(new Date()),
          picture: null,
          ItemNewBarCode: null,
          ProductionDate: this.convertDateToJSONFormat(
            this.additem.value.ProductionDate
          ),
          ExpirationDate: this.convertDateToJSONFormat(
            this.additem.value.ExpirationDate
          ),
          EntryDate: this.convertDateToJSONFormat(this.additem.value.EntryDate),
        },
      };

      this.publisherService
        .PostRequest("InsertItem", obj)
        .subscribe((res: any) => {
          console.log(JSON.parse(res));
        });
    } else {
      this.toastrService.danger("Try Again", "Error");
    }

    this.windowRef.close("");
  }

  convertDateToJSONFormat(date) {
    var milliseconds = date.getTime();
    return "/Date(" + milliseconds + ")/";
  }

  update() {
    var obj = {
      ItemToUpdate: {
        ItemID: 0,
        ItemName: this.additem.value.itemname,
        ItemBarCode: this.additem.value.itembarcode,
        itemNewBarCode: this.additem.value.itembarcode,
        favoriteCategoryName: "",
        warehouseName: "",
        itemTypeName: "",
        ItemQuantity: this.inputValue3 ? this.inputValue3 : 0,
        ItemBuyPrice: this.additem.value.buyprice,
        ItemPrice: this.additem.value.ItemPrice,
        QuantityWarning: parseInt(this.additem.value.warninglimit),
        ItemPriceTax: this.sumResult > 0 ? this.sumResult : this.Selltex,
        ItemTypeID: parseInt(this.additem.value.ItemType),
        Warehouse_ID: parseInt(this.additem.value.Warehouse),
        FavoriteCategory: parseInt(this.additem.value.FavoriteCategory),
        Date: this.convertDateToJSONFormat(new Date()),
        picture: null,
        ItemNewBarCode: this.additem.value.itembarcode,
        ProductionDate: this.convertDateToJSONFormat(
          this.additem.value.ProductionDate
        )
          ? this.convertDateToJSONFormat(this.additem.value.ProductionDate)
          : this.ProductionDate,
        ExpirationDate: this.convertDateToJSONFormat(
          this.additem.value.ExpirationDate
        )
          ? this.convertDateToJSONFormat(this.additem.value.ExpirationDate)
          : this.ExpiryDateFormat,
        EntryDate: this.convertDateToJSONFormat(this.additem.value.EntryDate)
          ? this.convertDateToJSONFormat(this.additem.value.EntryDate)
          : this.EntryDate,
      },
    };
    console.log(obj);
    this.publisherService
      .PostRequest("UpdateItem", obj)
      .subscribe((res: any) => {
        console.log(JSON.parse(res));
        this.toastrService.success("Updated", "Success");
      });
    this.windowRef.close("");
  }

  calculateSum(): void {
    this.publisherService
      .PostRequest("RetrieveSystemSettings", "")
      .subscribe((res: any) => {
        console.log(JSON.parse(res));

        var responce = JSON.parse(res);
        this.tax = JSON.parse(responce.ResponseMessage);

        this.calcuatetex = this.tax[0].SystemTax;

        var TaxRate = this.calcuatetex / 100;

        var totalTax = TaxRate * this.inputValue2;
        this.sumResult = this.inputValue2 + totalTax;
      });
  }
}
