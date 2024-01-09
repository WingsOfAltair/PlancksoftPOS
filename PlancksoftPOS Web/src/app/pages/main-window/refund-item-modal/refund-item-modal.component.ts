import { Component, OnInit } from "@angular/core";
import {
  NbSortDirection,
  NbSortRequest,
  NbTreeGridDataSource,
  NbTreeGridDataSourceBuilder,
  NbWindowRef,
} from "@nebular/theme";
import { PublisherService } from "../../../services/publisher.service";
import { FormBuilder, Validators } from "@angular/forms";

@Component({
  selector: "ngx-refund-item-modal",
  templateUrl: "./refund-item-modal.component.html",
  styleUrls: ["./refund-item-modal.component.scss"],
})
export class RefundItemModalComponent implements OnInit {
  filterdata: any;
  data: any;

  defaultColumns = [
    "BillNumber",
    "CashierName",
    "Date",
    "Action",
  ];

  allColumns = [...this.defaultColumns];

  dataSource: NbTreeGridDataSource<any>;

  sortColumn: string;
  sortDirection: NbSortDirection = NbSortDirection.NONE;
  message: any;
  clientdata: any[];
  itemdata: any[];
  BillId: any = 0;
  Barcode: any = "";
  itemquantity: any = "";
  ItembillID: any;
  pickbilltable = 1;
  pickitemtable = 0;
  updatequantity = 0;
  Userdata: any;
  userID: any;
  defaultReturnQuantity: number = 0;

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

  defaultColumns2 = [
    "Item Name",
    "Item Barcode",
    "Sold Quantity",
    "Item Price After Tax",
    "Action",
  ];

  allColumns1 = [...this.defaultColumns2];

  dataSource1: NbTreeGridDataSource<any>;

  sortColumn2: string;
  sortDirection2: NbSortDirection = NbSortDirection.NONE;

  updateSort2(sortRequest: NbSortRequest): void {
    this.sortColumn2 = sortRequest.column;
    this.sortDirection2 = sortRequest.direction;
  }

  getSortDirection2(column: string): NbSortDirection {
    if (this.sortColumn2 === column) {
      return this.sortDirection2;
    }
    return NbSortDirection.NONE;
  }
  getShowOn2(index: number) {
    const minWithForMultipleColumns = 400;
    const nextColumnStep = 100;
    return minWithForMultipleColumns + nextColumnStep * index;
  }

  firstformgroup = this.fb.group({
    ItemName: [''],
    ItemBarCode: [0],
    ItemQuantity: [0],
    ReturnQuantity: [0, [Validators.required]],
  });

  constructor(
    private fb: FormBuilder,
    private dataSourceBuilder: NbTreeGridDataSourceBuilder<any>,
    private publisherService: PublisherService,
    private windowRef: NbWindowRef
  ) {
    var user = sessionStorage.getItem("userData");
    this.Userdata = JSON.parse(user);
    this.userID = this.Userdata.uid;



  }
  ngOnInit(): void {
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

  onSelectionChange(Id) {
    var obj = {
      ClientID: Id,
    };
    this.publisherService
      .PostRequest("RetrieveClientBills", obj)
      .subscribe((res: any) => {
        console.log(JSON.parse(res));

        debugger;
        var response = JSON.parse(res);
        var array = JSON.parse(response.ResponseMessage);

        var list = [];

        array.forEach((el) => {
          const productionDate = parseInt(el["Date"].match(/-?\d+/)[0], 10);
          const formattedDate = new Date(productionDate).toLocaleDateString();
          var obj = {
            data: {
              BillNumber: el["Bill Number"],
              CashierName: el["Cashier Name"],
              TotalAmount: el["Total Amount"],
              ClientName: el["Client ID"],
              ClientID: el["ClientID"],
              Rwminder: el["Remainder Amount"],
              PaidAmount: el["Paid Amount"],
              Status: el["Status"],
              Date: formattedDate,
            },
          };
          list.push(obj);
        });

        this.data = list;
        this.dataSource = this.dataSourceBuilder.create(this.data);
      });
  }

  Bill(id) {
    this.pickbilltable = 0;
    this.pickitemtable = 2;
    debugger;
    var obj = {
      BillNumber: id,
    };

    this.BillId = id;

    this.publisherService
      .PostRequest("RetrieveBillItems", obj)
      .subscribe((res: any) => {
        var response = JSON.parse(res);
        var array = response.ResponseMessage.Item1;

        var list = [];

        array.forEach((el) => {
          var obj = {
            data: {
              ItemName: el["ItemName"],
              ItemBarcode: el["ItemBarCode"],
              ItemBuyPrice: el["ItemBuyPrice"],
              ItemPriceTax: el["ItemPriceTax"],
              ItemQuantity: el["ItemQuantity"],
            },
          };

          list.push(obj);
        });
        debugger;
        this.itemdata = list;

        this.dataSource1 = this.dataSourceBuilder.create(this.itemdata);
      });
  }

  pickitem(barcode) {
    this.pickbilltable = 0;
    this.pickitemtable = 0;
    this.updatequantity = 3;

    debugger;
    this.Barcode = barcode;
    var selected = this.itemdata.filter((a) => a.data.ItemBarcode == barcode);
    this.itemquantity = selected[0].data.ItemQuantity;

    this.firstformgroup.patchValue({
      ItemName: selected[0].data.ItemName,
      ItemBarCode: selected[0].data.ItemBarcode,
      ItemQuantity: selected[0].data.ItemQuantity,
    });
  }

  submit(){
    if(this.firstformgroup.valid){
      var obj = {
        ItemName: this.firstformgroup.value.ItemName,
        ItemBarCode: this.firstformgroup.value.ItemBarCode,
        ItemQuantity: this.firstformgroup.value.ReturnQuantity,
        cashierName: this.userID,
        BillID: this.BillId
      }

      this.publisherService.PostRequest("ReturnItem" ,obj).subscribe(res => {

      })

    }
  }
}
