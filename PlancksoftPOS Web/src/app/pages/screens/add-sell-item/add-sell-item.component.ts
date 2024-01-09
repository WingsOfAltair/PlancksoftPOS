import { Component, OnInit } from "@angular/core";
import {
  NbSortDirection,
  NbSortRequest,
  NbToastrService,
  NbTreeGridDataSource,
  NbTreeGridDataSourceBuilder,
  NbWindowRef,
  NbWindowService,
} from "@nebular/theme";
import { SmartTableData } from "../../../@core/data/smart-table";
import { FormBuilder, FormGroup } from "@angular/forms";
import { PublisherService } from "../../../services/publisher.service";
import { AddBillItemModalComponent } from "../add-bill-item-modal/add-bill-item-modal.component";
import { ActivatedRoute, Router } from "@angular/router";

@Component({
  selector: "ngx-add-sell-item",
  templateUrl: "./add-sell-item.component.html",
  styleUrls: ["./add-sell-item.component.scss"],
})
export class AddSellItemComponent implements OnInit {
  Searchitem: FormGroup;
  AddBill: FormGroup;

  filterdata: any;
  data: any;
  checkitem: any = [];
  client: any;
  clientdata: any;
  clientname: any;
  clientAddress: any;
  clientEmail: any;
  clientPhone: any;
  ItemName: any;
  ItemBarcode: any;
  ItemQuantity: any;
  tabledata: any = [];
  itemList: any = [];
  id: any = 0;
  BillData: any;

  defaultColumns = ["ItemName", "ItemBarcode", "ItemQuantity", "Action"];

  allColumns = [...this.defaultColumns];

  dataSource: NbTreeGridDataSource<any>;

  sortColumn: string;
  sortDirection: NbSortDirection = NbSortDirection.NONE;
  message: any;
  cashierName: any;
  Amount: any;

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
    private publisherService: PublisherService,
    private toastrService: NbToastrService,
    private windowService: NbWindowService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.route.params.subscribe((params) => {
      if (params.id) {
        this.id = +params["id"];
        console.log("ParamsId", this.id);
      }
    });
  }

  ngOnInit(): void {
    this.AddBill = this.fb.group({
      BillNumber: [],
      RemainderAmount: [],
      TotalAmount: [],
      PaidAmount: [],
      Paycash: [],
      Postponed: [],
      ProductionDate: [],
    });

    this.AddBill.patchValue({
      ProductionDate: new Date(),
    });

    this.publisherService
      .PostRequest("RetrieveUsers", "")
      .subscribe((res: any) => {
        ;
        var response = JSON.parse(res);
        this.message = response.ResponseMessage.Item1;
        this.cashierName = this.message[0].name;
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
  }

  search() {
    var obj = {
      ItemBarCode: this.Searchitem.value.ItemBarcode,
      ItemName: this.Searchitem.value.ItemName,
      ItemType: 0,
    };

    this.publisherService
      .PostRequest("SearchItems", obj)
      .subscribe((res: any) => {
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
        console.log(JSON.parse(res));
      });
  }

  GetItem(barcode, item) {
    var obj = {
      ItemBarCode: barcode,
      ItemName: item,
      ItemType: 0,
    };

    this.publisherService
      .PostRequest("SearchItems", obj)
      .subscribe((res: any) => {
        var response = JSON.parse(res);
        var data = response.ResponseMessage.Item1;

        this.filterdata = data;

        var list = [];
        data.forEach((el) => {
          var obj = {
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
            itemNewBarCode: el["ItemNewBarCode"],
            QuantityWarning: el["QuantityWarning"],
            ItemTypeID: el["ItemTypeID"],
            Warehouse_ID: el["Warehouse_ID"],
            FavoriteCategory: el["FavoriteCategory"],
            Date: el["Date"],
            picture: null,
            ProductionDate: el["ProductionDate"],
            ExpirationDate: el["ExpirationDate"],
            EntryDate: el["EntryDate"],
          };
          list.push(obj);
        });

        this.checkitem = list;
      });
  }

  convertDateToJSONFormat(date) {
    var milliseconds = date.getTime();
    return "/Date(" + milliseconds + ")/";
  }

  AddBillitem() {
    if (this.AddBill.valid) {
      console.log(this.AddBill.value);

      if (this.AddBill.value.Paycash == null)
        this.AddBill.value.Paycash = false;

      if (this.AddBill.value.Postponed == null)
        this.AddBill.value.Postponed = false;

      var obj = {
        billToAdd: {
          itemsBought: this.itemList,
          billNumber: parseInt(this.AddBill.value.BillNumber),
          remainderAmount: parseInt(this.AddBill.value.RemainderAmount),
          totalAmount: parseInt(this.AddBill.value.TotalAmount),
          paidAmount: parseInt(this.AddBill.value.PaidAmount),
          clientName: this.clientname,
          clientPhone: this.clientPhone,
          clientAddress: this.clientAddress,
          clientEmail: this.clientEmail,
          clientID: this.client,
          paybycash: this.AddBill.value.Paycash,
          date: this.convertDateToJSONFormat(this.AddBill.value.ProductionDate),
          cashierName: this.cashierName,
          postponed: this.AddBill.value.Postponed,
        },
        cashierName: this.cashierName,
      };

      this.publisherService
        .PostRequest("AddVendorBill", obj)
        .subscribe((res: any) => {
          console.log(JSON.parse(res));
        });

      this.router.navigate(["/pages/screen/edit-invoice"]);
    } else {
      this.toastrService.danger("Try Again", "Error");
    }

    console.log(this.AddBill.value);
  }

  Delete(barcode) {}

  onSelectChange(ID) {
    this.client = ID;

    console.log(this.client);

    var selected = this.clientdata.filter((a) => a.data.ClientID == ID)[0];

    this.clientname = selected.data.ClientName;
    this.clientPhone = selected.data.ClientPhone;
    this.clientAddress = selected.data.ClientAddress;
    this.clientEmail = selected.data.ClientEmail;
  }

  addItem() {
    var bcbc = this.windowService.open(AddBillItemModalComponent, {
      title: `Add Item`,
    });
    bcbc.onClose.subscribe((res) => {
      if (res && res.ItemBarCode) {
        this.itemList.push(res);
        var dt = [];
        this.itemList.forEach((el) => {
          dt.push({ data: el });
        });
        this.dataSource = this.dataSourceBuilder.create(dt);
      }
    });
  }

  update(Barcode) {
    var selected = this.itemList.filter((a) => a.ItemBarCode == Barcode)[0];

    var obj = {
      ItemBarcode: selected.ItemBarCode,
      ItemName: selected.ItemName,
      ItemQuantity: selected.ItemQuantity,
    };

    var bcbc = this.windowService.open(AddBillItemModalComponent, {
      title: `Update Item`,
      context: obj,
    });
    bcbc.onClose.subscribe((res) => {
      if (res && res.ItemBarCode) {
        this.itemList.push(res);
        var dt = [];
        this.itemList.forEach((el) => {
          dt.push({ data: el });
        });
        this.dataSource = this.dataSourceBuilder.create(dt);
        // console.log(this.publisherService.data)
      }
    });
  }

  calculateRemainingAmount() {
    this.Amount =
      this.AddBill.value.TotalAmount - this.AddBill.value.PaidAmount;
    this.AddBill.patchValue({
      RemainderAmount: this.Amount,
    });
  }
}
