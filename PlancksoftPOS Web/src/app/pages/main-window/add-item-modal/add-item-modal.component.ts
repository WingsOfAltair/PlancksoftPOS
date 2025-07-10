import { Component, OnInit, Output, EventEmitter } from "@angular/core";
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

  imageSrc: any;
  imageByteArray: any;
  itemData: any;

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
      ProductionDate: new Date(new Date().setHours(0, 0, 0, 0)),
      ExpirationDate: new Date(new Date().setHours(0, 0, 0, 0)),
      EntryDate: new Date(new Date().setHours(0, 0, 0, 0)),
      FavoriteCategory: [""],
      ItemType: [""],
      Warehouse: [""],
      ItemPrice: [""],
      picture: null,
    });

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

    if (this.data.ItemBarCode != null) {
      

      this.ProductionDate = new Date();
      this.ExpiryDateFormat = new Date();
      this.EntryDate = new Date();

      var obj = {"ItemBarCode":this.data.ItemBarCode};
      this.publisherService
      .PostRequest("SearchItems", obj)
      .subscribe((res: any) => {
        console.log(JSON.parse(res));
        var response = JSON.parse(res);
        var dataa = JSON.parse(response.ResponseMessage.Item1)

        this.itemData = {
          itemname: dataa[0]["Item Name"],
          itembarcode: dataa[0]["Item BarCode"],
          itemquantity: dataa[0]["Item Quantity"],
          ItemPrice: dataa[0]["Item Price"],
          sellpricetax: dataa[0]["Item Price Tax"],
          buyprice: dataa[0]["Item Buy Price"],
          warninglimit: 0,
          ProductionDate: new Date(dataa[0]["Production Date"]),
          ExpirationDate: new Date(dataa[0]["Expiration Date"]),
          EntryDate: new Date(dataa[0]["Entry Date"]),
          FavoriteCategory: dataa[0]["Favorite Category Number"],
          ItemType: dataa[0]["Item Type"],
          Warehouse: dataa[0]["Warehouse ID"],
          picture: null,
        };
        this.Selltex = dataa[0]["Item Price Tax"];

        this.additem.patchValue(this.itemData);
        this.imageSrc = 'data:' + 'image/png' + ';base64,' + dataa[0]["Item Picture"];
        this.imageByteArray = this.convertDataURIToBinary(this.imageSrc);
      });
      
      this.itemData = {
        itemname: this.data.ItemName,
        itembarcode: this.data.ItemBarCode,
        itemquantity: this.data.ItemQuantity,
        ItemPrice: this.data.ItemPrice,
        sellpricetax: this.data.ItemPriceTax,
        buyprice: this.data.ItemBuyPrice,
        warninglimit: this.data.QuantityWarning,
        ProductionDate: this.ProductionDate,
        ExpirationDate: this.ExpiryDateFormat,
        EntryDate: this.EntryDate,
        FavoriteCategory: this.data.favoriteCategoryName,
        ItemType: this.data.ItemTypeName,
        Warehouse: this.data.warehouseName,
        picture: null,
      };

      this.additem.patchValue(this.itemData);
    } else {
      this.ProductionDate = new Date();
      this.ExpiryDateFormat = new Date();
      this.EntryDate = new Date();

      this.itemData = {
        itemname: "",
        itembarcode: "",
        itemquantity: 0,
        ItemPrice: 0,
        sellpricetax: 0,
        buyprice: 0,
        warninglimit: 0,
        ProductionDate: this.ProductionDate,
        ExpirationDate: this.ExpiryDateFormat,
        EntryDate: this.EntryDate,
        FavoriteCategory: 0,
        ItemType: 0,
        Warehouse: 0,
        picture: null,
      };

      this.additem.patchValue(this.itemData);
    }

    this.disableItemName();
  }

  @Output() modalClose = new EventEmitter();

  closeModal() {
    this.modalClose.emit(); // Emit custom event
    this.windowRef.close("");
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

  readUrl(event:any) {
    if (event.target.files && event.target.files[0]) {
      var reader = new FileReader();
  
      reader.readAsDataURL(event.target.files[0])

      reader.onload = (event: ProgressEvent) => {
        //this.imageSrc = (<FileReader>event.target).result;
        this.imageSrc = reader.result;
        console.log("imagesrc: " + this.imageSrc);

        this.imageByteArray = this.convertDataURIToBinary(this.imageSrc);
        console.log("image byte array: " + this.imageByteArray);
      }
    }
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

      var imageArray = null;

      if (this.imageByteArray) {
        imageArray = Object.values(this.imageByteArray)
      }

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
          PictureUpload: imageArray,
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
          this.closeModal();
        });
    } else {
      this.toastrService.danger("Try Again", "Error");
    }

  }

  convertDateToJSONFormat(date) {
    var milliseconds = date.getTime();
    return "/Date(" + milliseconds + ")/";
  }

  update() {
    this.publisherService
      .PostRequest("RetrieveSystemSettings", "")
      .subscribe((res: any) => {

        var response = JSON.parse(res);
        this.tax = JSON.parse(response.ResponseMessage.Item1);

        this.calcuatetex = this.tax[0].SystemTax;

        var TaxRate = this.calcuatetex / 100;

        var totalTax = TaxRate * this.inputValue2;
        this.sumResult = this.inputValue2 + totalTax;

        
      var imageArray = null;

      if (this.imageByteArray) {
        imageArray = Object.values(this.imageByteArray)
      }

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
            PictureUpload: imageArray,
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
        this.publisherService
          .PostRequest("UpdateItem", obj)
          .subscribe((res: any) => {
            console.log(JSON.parse(res));
            this.toastrService.success("Updated", "Success");
            this.closeModal();
          });
          
      });
  }

  calculateSum(): void {
    this.publisherService
      .PostRequest("RetrieveSystemSettings", "")
      .subscribe((res: any) => {

        var response = JSON.parse(res);
        this.tax = JSON.parse(response.ResponseMessage.Item1);

        this.calcuatetex = this.tax[0].SystemTax;

        var TaxRate = this.calcuatetex / 100;

        var totalTax = TaxRate * this.inputValue2;
        this.sumResult = this.inputValue2 + totalTax;
      });
  }
}
