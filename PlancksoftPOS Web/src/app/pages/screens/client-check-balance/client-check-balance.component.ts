import { Component, OnInit } from "@angular/core";
import {
  NbSortDirection,
  NbSortRequest,
  NbTreeGridDataSource,
  NbTreeGridDataSourceBuilder,
  NbWindowService,
  NbToastrService,
} from "@nebular/theme";
import { SmartTableData } from "../../../@core/data/smart-table";
import { PublisherService } from "../../../services/publisher.service";
import { PaymentModalComponent } from "../payment-modal/payment-modal.component";

@Component({
  selector: "ngx-client-check-balance",
  templateUrl: "./client-check-balance.component.html",
  styleUrls: ["./client-check-balance.component.scss"],
})
export class ClientCheckBalanceComponent implements OnInit {
  data: any;
  list: any[] = [];

  defaultColumns = [
    "BillNumber",
    "CashierName",
    "ClientName",
    "TotalAmount",
    "PaidAmount",
    "Rwminder",
    "Date",
    "Status",
    "PayBill",
    "Action",
  ];

  allColumns = [...this.defaultColumns];

  dataSource: NbTreeGridDataSource<any>;

  sortColumn: string;
  sortDirection: NbSortDirection = NbSortDirection.NONE;
  itemdata: unknown[];
  clientdata: any[];

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
    "Returned Quantity",
    "Item Price After Tax",
    "Item Buy Price",
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

  constructor(
    private service: SmartTableData,
    private dataSourceBuilder: NbTreeGridDataSourceBuilder<any>,
    private publisherService: PublisherService,
    private windowService: NbWindowService,
    private toastrService: NbToastrService,
  ) {}

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

    const currentTimestamp = new Date();
    console.log("Current Timestamp:", currentTimestamp);

    var obj = {
      Date: this.convertDateToJSONFormat(currentTimestamp),
    };

    this.publisherService
      .PostRequest("RetrieveLastVendorBillNumberToday", obj)
      .subscribe((res: any) => {
        var response = JSON.parse(res);
        var array = response.ResponseMessage;

        array.forEach((el) => {
          const productionDate = parseInt(el["Date"].match(/-?\d+/)[0], 10);
          const formattedDate = new Date(productionDate).toLocaleDateString();
          var obj = {
            data: {
              BillNumber: array.billNumber,
              CashierName: array.CashierName,
              TotalAmount: array.totalAmount,
              Date: array.date,
            },
          };
          this.list.push(obj);
        });

        this.data = this.list;
        this.dataSource = this.dataSourceBuilder.create(array);
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

        debugger
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
              ClientName: el["Client Name"],
              ClientID: el["Client ID"],
              Remainder: el["Remainder Amount"],
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
    var obj = {
      BillNumber: id,
    };
    
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
              ReturnedQuantity: el["ReturnedQuantity"],
            },
          };

          list.push(obj);
        });
        debugger
        this.itemdata = list;

        this.dataSource1 = this.dataSourceBuilder.create(this.itemdata);
      });
  }

  AddModal() {
    var dt = this.windowService.open(PaymentModalComponent, {
      title: `Payment`,
    });

    dt.onClose.subscribe((res) => {
      this.ngOnInit();
    });
  }

  updatebill(BillNumber) {
    var selected = this.data.filter((a) => a.data.BillNumber == BillNumber)[0];

    if (selected.data.Status == "Paid")
    {
      this.toastrService.danger("Bill is already paid.")
      return;
    }
    if (selected.data.Status == "Completely Refunded")
    {
      this.toastrService.danger("Bill is already completely refunded.")
      return;
    } 

    var selectedclient = this.clientdata.filter((a) => a.data.ClientID == selected.data.ClientID)[0];

    console.log('selected')
    console.log(selected.data)

    
    if (selected.data.Remainder < 0)
      selected.data.Remainder = selected.data.Remainder * -1;
    
    var obj = {
      BillNumber: selected.data.BillNumber,
      AmountRequired: selected.data.TotalAmount,
      Remainder: selected.data.Remainder,
      ClientPhone: selectedclient.data.ClientPhone,
      ClientID: selected.data.ClientID,
      Date: selected.data.Date,
      ClientAddress: selectedclient.data.ClientAddress,
      ClientEmail: selectedclient.data.ClientEmail,
      ClientName: selectedclient.data.ClientName,
      status: selected.data.Status
    };

    var dt = this.windowService.open(PaymentModalComponent, {
      title: `Payment`,
      context: obj,
    });

    dt.onClose.subscribe((res) => {
      this.ngOnInit();
      this.onSelectionChange(selected.data.ClientID);
    });
  }

  convertDateToJSONFormat(date) {
    var milliseconds = date.getTime();
    return "/Date(" + milliseconds + ")/";
  }
}
