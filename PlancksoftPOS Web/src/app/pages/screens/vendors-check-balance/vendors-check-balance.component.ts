import { Component, OnInit } from "@angular/core";
import {
  NbSortDirection,
  NbSortRequest,
  NbTreeGridDataSource,
  NbTreeGridDataSourceBuilder,
} from "@nebular/theme";
import { SmartTableData } from "../../../@core/data/smart-table";
import { PublisherService } from "../../../services/publisher.service";

@Component({
  selector: "ngx-vendors-check-balance",
  templateUrl: "./vendors-check-balance.component.html",
  styleUrls: ["./vendors-check-balance.component.scss"],
})
export class VendorsCheckBalanceComponent implements OnInit {
  data: any;
  itemdata: any;

  defaultColumns = ["Bill ID", "Importer Name", "Cashier Name", "Net Total", "Date", "Status", "Action"];

  allColumns = [...this.defaultColumns];

  dataSource: NbTreeGridDataSource<any>;

  sortColumn: string;
  sortDirection: NbSortDirection = NbSortDirection.NONE;
  Date: Date;
  alldata: any;
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

  defaultColumns1 = [
    "Item Name",
    "Item Barcode",
    "Item Buy Sale Quantity",
    "Buy Price",
  ];

  allColumns1 = [...this.defaultColumns1];

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
    private publisherService: PublisherService
  ) {}

  ngOnInit(): void {

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
      .PostRequest("RetrieveVendorBills", obj)
      .subscribe((res: any) => {
        console.log(JSON.parse(res));

        debugger
        var response = JSON.parse(res);
        var array = JSON.parse(response.ResponseMessage.Item2);

        var list = [];

        array.forEach((el) => {
          const productionDate = parseInt(el["Date"].match(/-?\d+/)[0], 10);
          const formattedDate = new Date(productionDate).toLocaleDateString();
          var obj = {
            data: {
              BillNumber: el["Bill Number"],
              ClientName: el["Vendor Name"],
              CashierName: el["Cashier Name"],
              TotalAmount: el["Total Amount"],
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
      BillNumber: id
    }

    this.publisherService
      .PostRequest("RetrieveVendorBillItems", obj)
      .subscribe((res :any ) => {
        
        var response = JSON.parse(res);
        var array = JSON.parse(response.ResponseMessage);

        
        var list = [];

        array.forEach((el) => {
          var obj = {
            data: {
              ItemName: el["Item Name"],
              ItemBarcode: el["Item BarCode"],
              ItemBuyPrice: el["Item Buy Price"],
              Itemquantity: el["Item Buy Quantity"],
            },
          };

          list.push(obj);
        });

        this.itemdata = list;

        this.dataSource1 = this.dataSourceBuilder.create(this.itemdata);

      });
  }
}
