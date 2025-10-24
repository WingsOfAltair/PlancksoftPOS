import {
  ChangeDetectionStrategy,
  Component,
  ViewChild,
  OnInit,
} from "@angular/core";
import { LocalDataSource } from "ng2-smart-table";
import { SmartTableData } from "../../../@core/data/smart-table";
import { PublisherService } from "../../../services/publisher.service";
import { AddItemModalComponent } from "../add-item-modal/add-item-modal.component";
import {
  NbSortDirection,
  NbSortRequest,
  NbToastrService,
  NbTreeGridDataSource,
  NbTreeGridDataSourceBuilder,
  NbWindowService,
} from "@nebular/theme";
import { PickItemModalComponent } from "../pick-item-modal/pick-item-modal.component";
import { PickClientComponent } from "../pick-client/pick-client.component";
import { Observable, of } from "rxjs";
import { map } from "rxjs/operators";
import { FormBuilder, FormGroup } from "@angular/forms";

@Component({
  selector: "ngx-import-export-form",
  templateUrl: "./import-export-form.component.html",
  styleUrls: ["./import-export-form.component.scss"],
})
export class ImportExportFormComponent implements OnInit {
  firstFormGroup: FormGroup;
  itemId: any;

  @ViewChild("autoInput") input;

  wearhouse: any;
  data: any;
  DateStart: any;
  DateEnd: any;
  Date: any;
  ItemPriceTax: any;
  ItemPrice: any;
  ItemBuyPrice: any;
  favroiteCategory: any;
  ItemTypeID: any;
  filterdata: any;
  clientdata: any;
  Itemdata: any;
  object: any;
  filteredOptions$: Observable<string[]>;

  client: any;
  clientname: any;
  clientAddress: any;
  clientPhone: any;
  clientEmail: any;

  defaultColumns = [
    "ItemName",
    "ItemBarcode",
    "ItemQuantity",
    "ItemBuyPrice",
    "SellPrice",
    "Action",
  ];

  allColumns = [...this.defaultColumns];

  dataSource: NbTreeGridDataSource<any>;

  sortColumn: string;
  sortDirection: NbSortDirection = NbSortDirection.NONE;
  type: any = 0;
  Vendordata: any[];
  cashierName: any;
  message: any;
  CID: any;
  insert: any[] = [];
  favoriteCategoryName: any;
  ItemTypeName: any;
  warehouseName: any;
  imageSrc: any;

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

  openwindow() {
    var data = { id: 1, name: "hanzalla" };
    this.windowService.open(AddItemModalComponent, {
      title: `Insert Item`,
      context: data,
    });
  }

  getFilteredOptions(value: string): Observable<string[]> {
    return of(value).pipe(map((filterString) => this.clientdata(filterString)));
  }

  onChange() {
    this.filteredOptions$ = this.getFilteredOptions(this.clientdata.data.value);
  }

  formtype(event: any) {
    this.type = event;

    this.firstFormGroup.get("PickClient").reset("");
  }

  constructor(
    private service: SmartTableData,
    private publisherService: PublisherService,
    private windowService: NbWindowService,
    private dataSourceBuilder: NbTreeGridDataSourceBuilder<any>,
    private fb: FormBuilder,
    private toastrService: NbToastrService
  ) {
    const data = this.service.getData();
  }

  normalizeDate(input: any): Date {
    if (!input) return this.getNowDate();

    // Handle .NET MinValue
    if (typeof input === 'string' && input.match(/\/Date\(-62135596800000\)\//)) {
      return this.getNowDate();
    }

    // Handle /Date(...)/
    const match = typeof input === 'string' && input.match(/\/Date\((\-?\d+)\)\//);
    if (match) return new Date(parseInt(match[1], 10));

    // Handle Date object
    if (input instanceof Date && !isNaN(input.getTime())) return input;

    // Handle string or number
    const parsed = new Date(input);
    if (!isNaN(parsed.getTime())) return parsed;

    // fallback
    return this.getNowDate();
  }

  ngOnInit(): void {
    this.firstFormGroup = this.fb.group({
      ItemName: [],
      ItemBarcode: [],
      ItemQuantity: [],
      Warehouse: [],
      FormType: [],
      warningLimit: [],
      ProductionDate: [this.getNowDate()],
      ExpirationDate: [this.getNowDate()],
      EntryDate: [this.getNowDate()],
      buyprice: [],
      PickClient: [],
      PickClientId: [],
    });

    const dateControls = ['ProductionDate', 'ExpirationDate', 'EntryDate'];
    dateControls.forEach((field) => {
      const control = this.firstFormGroup.get(field);
      control.markAsTouched();
      control.updateValueAndValidity();
    });

    this.publisherService
      .PostRequest("RetrieveUsers", "")
      .subscribe((res: any) => {
        var response = JSON.parse(res);
        this.message = response.ResponseMessage.Item1;
        this.cashierName = this.message[0].name;
      });

    this.publisherService
      .PostRequest("RetrieveWarehouses", "")
      .subscribe((res: any) => {
        console.log(JSON.parse(res));

        var response = JSON.parse(res);
        this.wearhouse = response.ResponseMessage;

        console.log(this.wearhouse);
      });

    var obj = {
      locale: 1,
    };

    this.publisherService
      .PostRequest("RetrieveItems", obj)
      .subscribe((res: any) => {
        console.log(JSON.parse(res));

        var response = JSON.parse(res);
        var data = response.ResponseMessage.Item1;

        this.Itemdata = data;
      });

    this.publisherService
      .PostRequest("GetRetrieveClients", "")
      .subscribe((res: any) => {
        console.log(JSON.parse(res));

        var response = JSON.parse(res);
        var array = JSON.parse(response.ResponseMessage);

        var list = [];

        array.forEach((el) => {
          var obj = {
            data: {
              // EmployeeAddress: el["Employee Address"],
              ClientID: el["Client ID"],
              ClientName: el["Client Name"],
              ClientPhone: el["Client Phone"],
              ClientAddress: el["Client Address"],
              ClientEmail: el["Client Email"],
            },
          };
          list.push(obj);
        });

        this.clientdata = list;
      });

    this.publisherService
      .PostRequest("GetRetrieveVendors", "")
      .subscribe((res: any) => {
        console.log(JSON.parse(res));

        var response = JSON.parse(res);
        var array = JSON.parse(response.ResponseMessage);

        var list = [];

        array.forEach((el) => {
          var obj = {
            data: {
              // EmployeeAddress: el["Employee Address"],
              ID: el["Client ID"],
              ClientName: el["Client Name"],
              ClientPhone: el["Client Phone"],
              ClientAddress: el["Client Address"],
              ClientEmail: el["Client Email"],
            },
          };
          list.push(obj);
        });

        this.Vendordata = list;
      });
  }

  PickItem() {
    var data = this.windowService.open(PickItemModalComponent, {
      title: `Pick Item`,
    });

    data.onClose.subscribe((res) => {
      this.filterdata = this.Itemdata.filter((a) => a.ItemBarCode == res);

      this.favroiteCategory = this.filterdata[0].FavoriteCategory;
      this.favoriteCategoryName = this.filterdata[0].favoriteCategoryName;
      this.ItemTypeID = this.filterdata[0].ItemTypeID;
      this.ItemTypeName = this.filterdata[0].ItemTypeName;
      this.warehouseName = this.filterdata[0].warehouseName;
      this.ItemBuyPrice = this.filterdata[0].ItemBuyPrice;
      this.ItemPrice = this.filterdata[0].ItemPrice;
      this.ItemPriceTax = this.filterdata[0].ItemPriceTax;
      this.Date = this.filterdata[0].Date;
      this.DateEnd = this.filterdata[0].DateEnd;
      this.DateStart = this.filterdata[0].DateStart;
      
      var picture = "";
      try {
        picture = this.filterdata[0].Picture.slice(1, -1);
      } catch(err) {
        picture = "";
      }
      
      this.imageSrc = 'data:' + 'image/png' + ';base64,' + picture;

      this.firstFormGroup.patchValue({
        ItemName: this.filterdata[0].ItemName,
        ItemBarcode: this.filterdata[0].ItemBarCode,
        ItemQuantity: 0,
        Warehouse: this.filterdata[0].Warehouse_ID,
        warningLimit: this.filterdata[0].QuantityWarning,
        ProductionDate: this.filterdata[0].ProductionDate,
        ExpirationDate: this.filterdata[0].ExpirationDate,
        EntryDate: this.filterdata[0].EntryDate,
        buyprice: this.filterdata[0].ItemBuyPrice,
      });
      
    });
  }

  list: any[] = [];
  Deletelist: any[] = [];
  updatelist: any[] = [];
  itemboughts: any[] = [];
  UpdateTable: any[] = [];
  UpdateDeleteTable: any[] = [];
  secoundDeleteTable: any[] = [];

  AddItem() {
    const dateFields = ['ProductionDate', 'ExpirationDate', 'EntryDate'];
    const defaultDate = new Date();
    dateFields.forEach(field => {
      if (!this.firstFormGroup.value[field]) {
        this.firstFormGroup.patchValue({ [field]: defaultDate });
      }
      const control = this.firstFormGroup.get(field);
      control.markAsTouched();
      control.updateValueAndValidity();
    });

    if (!this.firstFormGroup.value.ItemQuantity) {
    this.firstFormGroup.patchValue({ ItemQuantity: 0 });
    }
    if (!this.firstFormGroup.value.buyprice) {
      this.firstFormGroup.patchValue({ buyprice: 0 });
    }
    if (!this.firstFormGroup.value.warningLimit) {
      this.firstFormGroup.patchValue({ warningLimit: 0 });
    }

    if (this.firstFormGroup.valid) {
      const form = this.firstFormGroup.value;
      const obj = {
        data: {
          ItemID: 0,
          ItemName: form.ItemName,
          ItemBarCode: form.ItemBarcode,
          favoriteCategoryName: "",
          warehouseName: "",
          itemTypeName: "",
          ItemQuantity: form.ItemQuantity,
          ItemBuyPrice: form.buyprice,
          ItemPrice: this.ItemPrice,
          QuantityWarning: parseInt(form.warningLimit),
          ItemPriceTax: this.ItemPriceTax,
          ItemTypeID: this.ItemTypeName,
          Warehouse_ID: this.warehouseName,
          FavoriteCategory: this.favoriteCategoryName,
          Date: this.convertDateToJSONFormat(this.normalizeDate(this.getNowDate())),
          picture: null,
          ItemNewBarCode: form.ItemBarcode,
          ProductionDate: this.convertDateToJSONFormat(this.normalizeDate(form.ProductionDate)),
          ExpirationDate: this.convertDateToJSONFormat(this.normalizeDate(form.ExpirationDate)),
          EntryDate: this.convertDateToJSONFormat(this.normalizeDate(form.EntryDate)),
        },
      };

      const obbj = {
        ItemsToUpdate: {
          ItemID: 0,
          ItemName: form.ItemName,
          ItemBarCode: form.ItemBarcode,
          itemNewBarCode: form.ItemBarcode,
          favoriteCategoryName: "",
          warehouseName: "",
          itemTypeName: "",
          ItemQuantity: form.ItemQuantity,
          ItemBuyPrice: form.buyprice,
          ItemPrice: this.ItemPrice,
          QuantityWarning: parseInt(form.warningLimit || 0),
          ItemPriceTax: this.ItemPrice,
          ItemTypeID: this.ItemTypeID,
          Warehouse_ID: parseInt(form.Warehouse),
          FavoriteCategory: this.favroiteCategory,
          Date: this.convertDateToJSONFormat(this.normalizeDate(this.getNowDate())),
          picture: null,
          ItemNewBarCode: null,
          ProductionDate: this.convertDateToJSONFormat(this.normalizeDate(form.ProductionDate)),
          ExpirationDate: this.convertDateToJSONFormat(this.normalizeDate(form.ExpirationDate)),
          EntryDate: this.convertDateToJSONFormat(this.normalizeDate(form.EntryDate)),
        },
      };

      var bought = {
        itemsBought: {
          ItemID: 0,
          ItemName: this.firstFormGroup.value.ItemName,
          ItemBarCode: this.firstFormGroup.value.ItemBarcode,
          itemNewBarCode: this.firstFormGroup.value.ItemBarcode,
          favoriteCategoryName: "",
          warehouseName: "",
          itemTypeName: "",
          ItemQuantity: this.firstFormGroup.value.ItemQuantity,
          ItemBuyPrice: this.firstFormGroup.value.buyprice,
          ItemPrice: this.ItemPrice,
          QuantityWarning: parseInt(
            this.firstFormGroup.value.warninglimit
              ? this.firstFormGroup.value.warninglimit
              : 0
          ),
          ItemPriceTax: this.ItemPrice,
          ItemTypeID: this.ItemTypeID,
          Warehouse_ID: parseInt(this.firstFormGroup.value.Warehouse),
          FavoriteCategory: this.favroiteCategory,
          Date: this.convertDateToJSONFormat(this.normalizeDate(this.getNowDate())),
          picture: null,
          ItemNewBarCode: null,
          ProductionDate: this.convertDateToJSONFormat(
            this.normalizeDate(this.normalizeDate(this.firstFormGroup.value.ProductionDate))
          ),
          ExpirationDate: this.convertDateToJSONFormat(
            this.normalizeDate(this.normalizeDate(this.firstFormGroup.value.ExpirationDate))
          ),
          EntryDate: this.convertDateToJSONFormat(
            this.normalizeDate(this.normalizeDate(this.firstFormGroup.value.EntryDate))
          ),
        },
      };

      if (obj) {
        if (this.UpdateDeleteTable.length > 0) {
          this.UpdateDeleteTable.push({ bought });
        } else {
          this.list.push({ ...obj });
        }

        this.updatelist.push(obbj);
        this.itemboughts.push(bought);
      }

      this.insert = this.updatelist;

      this.dataSource =
        this.UpdateDeleteTable.length > 0
          ? this.dataSourceBuilder.create(this.UpdateDeleteTable)
          : this.dataSourceBuilder.create(this.list);

       this.firstFormGroup.patchValue({
        ItemName: '',
        ItemBarcode: '',
        ItemQuantity: 0,
        Warehouse: '',
        ProductionDate: this.convertDateToJSONFormat(this.normalizeDate(this.getNowDate())),
        ExpirationDate: this.convertDateToJSONFormat(this.normalizeDate(this.getNowDate())),
        EntryDate: this.convertDateToJSONFormat(this.normalizeDate(this.getNowDate())),
        buyprice: 0,
        warningLimit: 0,
      });
      this.imageSrc = '';
    } else {
      this.toastrService.danger("Try Again", "Error");
    }
  }

  onSelectionChange(ID, type) {
    this.client = ID;

    console.log(this.client);

    if (type == 1) {
      var selected = this.clientdata.filter((a) => a.data.ClientID == ID)[0];
      this.CID = selected.data.ClientID;
      this.clientname = selected.data.ClientName;
      this.clientPhone = selected.data.ClientPhone;
      this.clientAddress = selected.data.ClientAddress;
      this.clientEmail = selected.data.ClientEmail;
    }

    if (type == 0) {
      var selected = this.Vendordata.filter((a) => a.data.ID == ID)[0];

      this.CID = selected.data.ID;
      this.clientname = selected.data.ClientName;
      this.clientPhone = selected.data.ClientPhone;
      this.clientAddress = selected.data.ClientAddress;
      this.clientEmail = selected.data.ClientEmail;
    }
  }

  Clear() {
    this.list = [];
    this.UpdateTable = [];
    this.updatelist = [];
    this.itemboughts = [];
    this.UpdateDeleteTable = [];
    this.dataSource = this.dataSourceBuilder.create([]);
    this.ngOnInit();
  }

  Delete(id) {
    var selected = this.updatelist.findIndex(
      (a) => a.ItemsToUpdate.ItemBarCode == id
    );

    var selectedbought = this.itemboughts.findIndex(
      (a) => a.itemsBought.ItemBarCode == id
    );

    var selectedlist = this.list.findIndex((a) => a.data.ItemBarCode == id);

    if (selected !== -1) {
      this.updatelist.splice(selected, 1);
      this.itemboughts.splice(selectedbought, 1);
      this.list.splice(selectedlist, 1);
      this.UpdateTable = this.updatelist.map((el) => {
        var obj = {
          data: {
            ItemName: el.ItemsToUpdate.ItemName,
            ItemBarCode: el.ItemsToUpdate.ItemBarCode,
            ItemQuantity: el.ItemsToUpdate.ItemQuantity,
            ItemPrice: el.ItemsToUpdate.ItemPrice,
            ItemBuyPrice: el.ItemToUpdate.ItemBuyPrice,
          },
        };

        this.secoundDeleteTable.push(obj);
      });

      this.dataSource = this.dataSourceBuilder.create(this.secoundDeleteTable);
    }
  }

  commitform() {
    if (this.firstFormGroup.valid) {
      console.log(this.firstFormGroup.value);
      var arr = [];
      var bouth = [];
      var amount = 0;
      this.updatelist.forEach((a) => {
        if (a.ItemsToUpdate) {
          arr.push(a.ItemsToUpdate);
        }
      });
      var update = {
        ItemsToUpdate: arr,
        EmployeeName: this.cashierName,
        EntryExitType: this.firstFormGroup.value.FormType,
      };

      this.publisherService
        .PostRequest("UpdateItemWarehouse", update)
        .subscribe((res: any) => {});

      if (this.UpdateDeleteTable.length > 0) {
        this.UpdateDeleteTable.forEach((a) => {
          if (a.data) {
            amount +=
              a.data.ItemQuantity * a.data.ItemBuyPrice
                ? a.data.ItemQuantity * a.data.ItemBuyPrice
                : 0;
            bouth.push(a.data);
          }
        });
      } else {
        this.itemboughts.forEach((a) => {
          if (a.itemsBought) {
            amount +=
              a.itemsBought.ItemQuantity * a.itemsBought.ItemBuyPrice
                ? a.itemsBought.ItemQuantity * a.itemsBought.ItemBuyPrice
                : 0;
            bouth.push(a.itemsBought);
          }
        });
      }

      var obj = {
        billToAdd: {
          itemsBought: bouth,
          billNumber: 0,
          remainderAmount: 0,
          isVendor: this.type == 1 ? false : true,
          totalAmount: amount,
          paidAmount: 0,
          clientName: this.clientname,
          clientPhone: this.clientPhone,
          clientAddress: this.clientAddress,
          clientEmail : this.clientEmail,
          clientID: this.client,
          paybycash: false,
          date: this.convertDateToJSONFormat(this.normalizeDate(this.getNowDate()),),
          cashierName: this.cashierName,
          postponed: false,
        },
        cashierName: this.cashierName,
      };

      this.publisherService
        .PostRequest("AddVendorBill", obj)
        .subscribe((res: any) => {
          this.Clear();
          this.ngOnInit();
        });

      this.toastrService.success("Upadated", "Success");
    } else {
      this.toastrService.danger("Try Again", "Error");
    }
  }

  convertDateToJSONFormat(date: any) {
    console.log('Input date:', date);

    let d: Date;

    if (!date) {
      d = new Date(); // fallback to now
    } else if (date instanceof Date && !isNaN(date.getTime())) {
      d = date;
    } else if (typeof date === 'string') {
      const match = date.match(/\/Date\((\-?\d+)\)\//);
      if (match) {
        d = new Date(parseInt(match[1], 10));
      } else {
        d = new Date(date);
      }
    } else if (typeof date === 'number') {
      d = new Date(date);
    } else if (date.year !== undefined && date.month !== undefined && date.day !== undefined) {
      d = new Date(date.year, date.month - 1, date.day);
    } else {
      d = new Date(date);
    }

    // handle .NET MinValue
    if (d.getTime() === -62135596800000 || isNaN(d.getTime())) {
      console.warn('Invalid or MinValue date detected, using current date instead');
      d = new Date();
    }

    console.log('Converted date:', d);
    return `/Date(${d.getTime()})/`;
  }

  getNowDate(): Date {
    const now = new Date();
    return now;
  }
}
