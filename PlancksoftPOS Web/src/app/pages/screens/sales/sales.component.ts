import { Component, OnInit } from "@angular/core";
import {
  NbComponentShape,
  NbComponentSize,
  NbComponentStatus,
  NbDateService,
  NbSortDirection,
  NbSortRequest,
  NbToastrService,
  NbTreeGridDataSource,
  NbTreeGridDataSourceBuilder,
} from "@nebular/theme";
import { LocalDataSource } from "ng2-smart-table";
import { SmartTableData } from "../../../@core/data/smart-table";
import { FormBuilder, FormGroup } from "@angular/forms";
import { PublisherService } from "../../../services/publisher.service";
import jspdf from "jspdf";
import html2canvas from "html2canvas";

@Component({
  selector: "ngx-sales",
  templateUrl: "./sales.component.html",
  styleUrls: ["./sales.component.scss"],
})
export class SalesComponent implements OnInit {
  SalesData: FormGroup;

  data: any;
  filterdata: any;

  defaultColumns = [
    "ItemName",
    "ItemBarcode",
    "SoldQuantity",
    "ReturnedQuantity",
    "Price",
    "PriceafterTax",
    "BuyPrice"
  ];

  allColumns = [...this.defaultColumns];

  dataSource: NbTreeGridDataSource<any>;

  sortColumn: string;
  sortDirection: NbSortDirection = NbSortDirection.NONE;
  message: any;
  logo: any;
  currentdate: Date;
  Userdata: any;
  userID: any;
  filteritemdata: any;
  requiredamount: any;
  paidAmount: number = 0;
  AmountRemainder: any = 0;
  filter: any;
  invoiceNo: any;
  invoicedate: any;
  dataa: any[];

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
    "BillID",
    "CashierName",
    "ClientName",
    "NetTotal",
    "PaidAmount",
    "Remainder",
    "PaymentType",
    "Date",
    "Paybutton",
  ];

  allColumns1 = [...this.defaultColumns1];
  dataSource1: NbTreeGridDataSource<any>;

  sortColumn1: string;
  sortDirection1: NbSortDirection = NbSortDirection.NONE;

  updateSort1(sortRequest: NbSortRequest): void {
    this.sortColumn1 = sortRequest.column;
    this.sortDirection1 = sortRequest.direction;
  }

  getSortDirection1(column: string): NbSortDirection {
    if (this.sortColumn1 === column) {
      return this.sortDirection1;
    }
    return NbSortDirection.NONE;
  }
  getShowOn1(index: number) {
    const minWithForMultipleColumns = 400;
    const nextColumnStep = 100;
    return minWithForMultipleColumns + nextColumnStep * index;
  }

  constructor(
    private service: SmartTableData,
    private fb: FormBuilder,
    private dataSourceBuilder: NbTreeGridDataSourceBuilder<any>,
    private publisherService: PublisherService,
    private toastrService: NbToastrService
  ) {
    var user = sessionStorage.getItem("userData");
    this.Userdata = JSON.parse(user);
    this.userID = this.Userdata.uid;
  }

  convertDateToJSONFormat(date) {
    var milliseconds = date.getTime();
    return "/Date(" + milliseconds + ")/";
  }

  ngOnInit(): void {
    this.SalesData = this.fb.group({
      BillID: [],
      dateFrom: [],
      dateTo: [],
    });

    this.publisherService
      .PostRequest("RetrieveBills", "")
      .subscribe((res: any) => {
        console.log(JSON.parse(res));

        var response = JSON.parse(res);
        var array = response.ResponseMessage.Item1;

        var list = [];

        array.forEach((el) => {
          const productionDate = parseInt(el["Date"].match(/-?\d+/)[0], 10);
          const formattedDate = new Date(productionDate).toLocaleDateString();
          var obj = {
            data: {
              BillNumber: el["BillNumber"],
              CashierName: el["CashierName"],
              ClientName: el["ClientName"],
              PaidAmount: el["PaidAmount"],
              TotalAmount: el["TotalAmount"],
              RemainderAmount: el["RemainderAmount"],
              PayByCash: el["PayByCash"],
              Date: formattedDate,
            },
          };
          list.push(obj);
        });

        this.data = list;
        this.dataSource1 = this.dataSourceBuilder.create(this.data);

        console.log(this.dataSource1);
      });

    this.publisherService
      .PostRequest("RetrieveSystemSettings", "")
      .subscribe((res: any) => {
        var response = JSON.parse(res);
        this.message = JSON.parse(response.ResponseMessage.Item1);

        this.logo = this.message[0].SystemName;
        this.currentdate = new Date();
      });
  }

  Search() {
    var obj = {
      dateFrom: this.SalesData.value.dateFrom,
      dateTo: this.SalesData.value.dateTo,
      BillNumber: 0,//this.SalesData.value.BillID,
    };

    this.publisherService
      .PostRequest("SearchBills", obj)
      .subscribe((res: any) => {
        console.log(JSON.parse(res));

        var response = JSON.parse(res);
        var array = response.ResponseMessage.Item1;

        var list = [];

        array.forEach((el) => {
          const productionDate = parseInt(el["Date"].match(/-?\d+/)[0], 10);
          const formattedDate = new Date(productionDate).toLocaleDateString();
          var obj = {
            data: {
              // EmployeeAddress: el["Employee Address"],
              BillNumber: el["BillNumber"],
              CashierName: el["CashierName"],
              PaidAmount: el["PaidAmount"],
              TotalAmount: el["TotalAmount"],
              RemainderAmount: el["RemainderAmount"],
              PayByCash: el["PayByCash"],
              Date: formattedDate,
            },
          };
          list.push(obj);
        });

        this.data = list;
        this.dataSource1 = this.dataSourceBuilder.create(this.data);
      });
  }

  leastitem() {
    this.publisherService
      .PostRequest("RetrieveLeastBoughtItems", "")
      .subscribe((res: any) => {
        console.log(JSON.parse(res));
        var response = JSON.parse(res);
        var data = response.ResponseMessage.Item1;
        this.filterdata = data;
        debugger
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

        this.dataa = list;
        this.dataSource = this.dataSourceBuilder.create(this.dataa);

        console.log(this.dataSource);
      });
  }

  Mostitem() {
    this.publisherService
      .PostRequest("RetrieveMostBoughtItems", "")
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

        this.dataa = list;
        this.dataSource = this.dataSourceBuilder.create(this.dataa);

        console.log(this.dataSource);
      });
  }

  download(id) {
    this.filter = this.data.filter((a) => a.data.BillNumber == id)[0];
    debugger
    this.invoiceNo = this.filter.data.BillNumber;
    this.invoicedate = this.filter.data.Date;
    this.requiredamount = this.filter.data.TotalAmount;
    this.paidAmount = this.filter.data.PaidAmount;
    this.AmountRemainder = this.filter.data.RemainderAmount;
    this.userID = this.filter.data.CashierName

    var obj = {
      BillNumber: id,
    };

    this.publisherService
      .PostRequest("RetrieveBillItems", obj)
      .subscribe((res: any) => {
        console.log(JSON.parse(res));
        debugger;
        var response = JSON.parse(res);
        this.filteritemdata = response.ResponseMessage.Item1;

        this.generatePDF(id);
      });
  }

  view(id) {
    var obj = {
      BillNumber: id,
    };
    this.publisherService
      .PostRequest("RetrieveBillItems", obj)
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
              ReturnedQuantity: el["ReturnedQuantity"],
              warehouseName: el["warehouseName"],
              ItemTypeName: el["ItemTypeName"],
              ItemBarCode: el["ItemBarCode"],
            },
          };
          list.push(obj);
        });

        this.dataa = list;
        this.dataSource = this.dataSourceBuilder.create(this.dataa);

        console.log(this.dataSource);
      });
  }

  generatePDF(id) {
    const pdfContent = document.getElementById("bill-container");

    setTimeout(() => {
      html2canvas(pdfContent).then((canvas) => {
        const imgData = canvas.toDataURL("image/png");
        this.invoiceNo = 0;
        // Adjusting the canvas size to make it fit into a standard A4 page (595 x 842 pixels)
        const pdf = new jspdf("p", "px", "a4");
        const pdfWidth = pdf.internal.pageSize.getWidth();
        const pdfHeight = pdf.internal.pageSize.getHeight();
        const aspectRatio = canvas.width / canvas.height;
        const width = pdfWidth - 20;
        const height = width / aspectRatio;

        pdf.addImage(imgData, "PNG", 10, 10, width, height);
        pdf.save("bill-" + id + ".pdf");

        // Clear filteritemdata
        this.filteritemdata = [];

        // Refresh the component
        this.ngOnInit();
      });
    }, 2000);
  }
}
