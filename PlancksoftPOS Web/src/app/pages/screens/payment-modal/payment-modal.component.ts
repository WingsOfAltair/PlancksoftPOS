import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup } from "@angular/forms";
import { PublisherService } from "../../../services/publisher.service";

import jspdf from "jspdf";
import html2canvas from "html2canvas";
import {
  NbToastrService,
  NbTreeGridDataSourceBuilder,
  NbWindowRef,
  NbWindowService,
} from "@nebular/theme";

@Component({
  selector: "ngx-payment-modal",
  templateUrl: "./payment-modal.component.html",
  styleUrls: ["./payment-modal.component.scss"],
})
export class PaymentModalComponent implements OnInit {
  payment: FormGroup;
  clientdata: any[];
  CID: any;
  clientname: any;
  clientPhone: any;
  clientAddress: any;
  clientEmail: any;
  message: any;
  cashierName: any;
  discou: any;
  filterdata: any;
  data: any[];
  updatedata: any;
  filterrow: any;
  filteritemdata: any;
  itemdata: any[];
  Amount: any;
  AmountRemainder: any = 0;
  billdata: any[];
  totalAmount: number = 0;
  paidAmount: number = 0;
  remainingAmount: number = 0;
  getreminderdata: any;
  totalAmountRemainder: any;
  paidamount: any;
  status: any;
  bill: any;
  Discountpayment: number;
  totalprice: number;
  RemDiscountpayment: number;
  remtotalprice: number;
  userID: any;
  Userdata: any;
  itemfilterdata: any;
  ItemBarCode: any;
  logo: any;
  currentdate: Date;
  showBillContainer = false;

  requiredamount: any;
  totalquantity: any;
  Billno: any;
  billno: any;

  constructor(
    private fb: FormBuilder,
    private publisherService: PublisherService,
    private toastrService: NbToastrService,
    private windowRef: NbWindowRef,
    private dataSourceBuilder: NbTreeGridDataSourceBuilder<any>
  ) {
    var user = sessionStorage.getItem("userData");
    this.Userdata = JSON.parse(user);
    this.userID = this.Userdata.uid;
  }

  ngOnInit(): void {
    this.updatedata = this.windowRef.config.context;

    this.filteritemdata = this.updatedata.itemlist;

    this.bill = this.updatedata.BillID;
    this.totalquantity = this.updatedata.ItemQuantity;

    this.ItemBarCode = this.updatedata.ItemBarCode;

    this.publisherService
      .PostRequest("RetrieveVendorBills", "")
      .subscribe((res: any) => {
        console.log(JSON.parse(res));

        var responce = JSON.parse(res);
        var data = responce.ResponseMessage.Item1;

        this.filterdata = data.filter((a) => a.IsVendor == false);

        var list = [];
        this.filterdata.forEach((el) => {
          var obj = {
            data: {
              BillNumber: el["BillNumber"],
              TotalAmount: el["TotalAmount"],
              RemainderAmount: el["RemainderAmount"],
            },
          };

          list.push(obj);
        });

        this.billdata = list;
      });

    this.publisherService
      .PostRequest("GetRetrieveClients", "")
      .subscribe((res: any) => {
        console.log(JSON.parse(res));

        var responce = JSON.parse(res);
        var array = JSON.parse(responce.ResponseMessage);

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

    this.publisherService
      .PostRequest("RetrieveSystemSettings", "")
      .subscribe((res: any) => {
        console.log(JSON.parse(res));
        var responce = JSON.parse(res);
        this.message = JSON.parse(responce.ResponseMessage);

        this.logo = this.message[0].SystemName;
        this.currentdate = new Date();
      });

    this.payment = this.fb.group({
      AmountRequired: [""],
      Remainder: [""],
      PaidAmount: [""],
      cashpayment: [""],
      visapayment: [""],
      Discount: [""],
      Client: [""],
      billnumber: [""],
      itembarcode: [""],
    });

    if (this.updatedata.itemlist) {
      this.payment.patchValue({
        AmountRequired: this.updatedata.AmountRequired,
      });
      this.totalAmountRemainder = this.updatedata.AmountRequired;
      this.Amount = this.updatedata.AmountRequired;
    }

    if (this.updatedata.BillNumber) {
      this.Amount =
        this.updatedata.AmountRequired * this.updatedata.ItemQuantity;
      this.Autobillfunction(this.updatedata.BillNumber);
      this.payment.patchValue({
        AmountRequired: this.updatedata.AmountRequired,
        Remainder: this.updatedata.Remainder,
        Client: this.updatedata.ClientID,
        billnumber: this.updatedata.BillNumber,
      });
      this.status = this.updatedata.status;
      this.CID = this.updatedata.ClientID;
      this.clientname = this.updatedata.ClientName;
      this.clientPhone = this.updatedata.ClientPhone;
      this.clientAddress = this.updatedata.ClientAddress;
      this.clientEmail = this.updatedata.ClientEmail;
      this.totalAmountRemainder = this.updatedata.AmountRequired;
      this.getreminderdata = this.updatedata.Remainder;
      this.bill = this.updatedata.BillNumber;
    }
  }

  Autobillfunction(billNumber) {
    var obj = {
      BillNumber: billNumber,
    };

    this.publisherService
      .PostRequest("RetrieveVendorBillItems", obj)
      .subscribe((res: any) => {
        console.log(JSON.parse(res));

        var responce = JSON.parse(res);
        var data = JSON.parse(responce.ResponseMessage);

        var list = [];
        var billitemlist = [];
        data.forEach((el) => {
          var obj = {
            data: {
              ItemName: el["Item Name"],
              ItemBarCode: el["Item BarCode"],
            },
          };

          list.push(obj);
        });

        data.forEach((el) => {
          var bought = {
            ItemBarCode: el["Item BarCode"],
            itemNewBarCode: el["Item BarCode"],
            ItemQuantity: el["Item Buy Quantity"],
          };
          billitemlist.push(bought);
        });

        this.filteritemdata = billitemlist;
        this.itemdata = list;
      });
  }

  onSelectionChange(Id) {
    var selected = this.clientdata.filter((a) => a.data.ClientID == Id)[0];

    this.CID = selected.data.ClientID;
    this.clientname = selected.data.ClientName;
    this.clientPhone = selected.data.ClientPhone;
    this.clientAddress = selected.data.ClientAddress;
    this.clientEmail = selected.data.ClientEmail;
  }

  SelectionChange(billNumber) {
    var obj = {
      BillNumber: billNumber,
    };

    this.publisherService
      .PostRequest("RetrieveVendorBillItems", obj)
      .subscribe((res: any) => {
        console.log(JSON.parse(res));

        var responce = JSON.parse(res);
        var data = JSON.parse(responce.ResponseMessage);

        var list = [];
        var billitemlist = [];
        data.forEach((el) => {
          var obj = {
            data: {
              ItemName: el["Item Name"],
              ItemBarCode: el["Item BarCode"],
            },
          };

          list.push(obj);
        });

        data.forEach((el) => {
          var bought = {
            ItemBarCode: el["Item BarCode"],
            itemNewBarCode: el["Item BarCode"],
            ItemQuantity: el["Item Buy Quantity"],
          };
          billitemlist.push(bought);
        });

        this.filteritemdata = billitemlist;
        this.itemdata = list;
      });

    var selected = this.billdata.filter(
      (a) => a.data.BillNumber == billNumber
    )[0];

    this.payment.patchValue({
      AmountRequired: selected.data.TotalAmount,
      Remainder: selected.data.RemainderAmount,
    });

    this.Amount = selected.data.TotalAmount;
  }

  toggle(event) {
    this.discou = event;
  }

  Submit() {
    if (this.payment.valid) {
      this.paidAmount = this.payment.value.PaidAmount;
      console.log(this.payment.value);

      var obj = {
        billToAdd: {
          isVendor: false,
          postponed: false,
          clientID: this.CID,
          billNumber: this.payment.value.billnumber
            ? this.payment.value.billnumber
            : 0,
          remainderAmount: this.AmountRemainder,
          totalAmount: this.Amount ? this.Amount : this.totalAmountRemainder,
          paidAmount: this.payment.value.PaidAmount,
          date: this.convertDateToJSONFormat(new Date()),
          cashierName: this.userID,
          paybycash:
            this.payment.value.cashpayment == 1
              ? this.payment.value.cashpayment
              : this.payment.value.visapayment,
          clientName: this.clientname,
          clientPhone: this.clientPhone,
          clientAddress: this.clientAddress,
          clientEmail: this.clientEmail,
          itemsBought: this.filteritemdata,
        },
        cashierName: this.userID,
      };

      this.publisherService
        .PostRequest("RetrieveLastBillNumberToday", "")
        .subscribe((res: any) => {
          console.log(JSON.parse(res));
          var billNo = JSON.parse(res);

          this.billno = billNo.ResponseMessage.billNumber;

          this.bill = this.billno + 1;
          this.publisherService
            .PostRequest("PayBill", obj)
            .subscribe((ress: any) => {
              console.log(JSON.parse(ress));

              /*if (this.bill) {
                this.generatePDF(); 
              }*/

              this.windowRef.close(true);

              this.filteritemdata = []

            });
        });
    } else {
      this.toastrService.danger("Try Again", "Error");
    }
  }

  generatePDF() {
    // this.showBillContainer = true;

    const pdfContent = document.getElementById("bill-container");
    const cloneDiv: any = pdfContent.cloneNode(true);
    pdfContent.style.display = "block";
    html2canvas(pdfContent).then((canvas) => {
      const imgData = canvas.toDataURL("image/png");
      this.showBillContainer = false;

      pdfContent.style.display = "none";
      const pdf = new jspdf("p", "px", "a4");
      const pdfWidth = pdf.internal.pageSize.getWidth();
      const pdfHeight = pdf.internal.pageSize.getHeight();
      const aspectRatio = canvas.width / canvas.height;
      const width = pdfWidth - 20;
      const height = width / aspectRatio;

      pdf.addImage(imgData, "PNG", 10, 10, width, height);
      pdf.save("bill.pdf");
      this.windowRef.close("");
    });
  }

  Update() {
    if (this.payment.valid) {
      console.log(this.payment.value);
      debugger;
      var obj = {
        BillNumber: this.bill,
        paidAmount: this.payment.value.PaidAmount,
      };
      this.publisherService
        .PostRequest("PayUnpaidBill", obj)
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

  calculateRemainingAmount() {
    if (this.getreminderdata) {
      this.AmountRemainder =
        this.getreminderdata - this.payment.value.PaidAmount;
      this.payment.patchValue({
        Remainder: this.AmountRemainder,
      });
    } else {
      if (this.totalprice) {
        this.AmountRemainder = this.totalprice - this.payment.value.PaidAmount;
        this.payment.patchValue({
          Remainder: this.AmountRemainder,
        });
      } else {
        this.AmountRemainder = this.Amount - this.payment.value.PaidAmount;
        this.payment.patchValue({
          Remainder: this.AmountRemainder,
        });
      }
    }
  }

  calculateDiscountAmount() {
    this.Discountpayment = this.Amount / 100;
    const price = this.Discountpayment * this.payment.value.Discount;
    this.totalprice = this.Amount - price;

    if (this.AmountRemainder) {
      this.RemDiscountpayment = this.AmountRemainder / 100;
      const remprice = this.RemDiscountpayment * this.payment.value.Discount;
      this.remtotalprice = this.AmountRemainder - remprice;
    } else {
      this.RemDiscountpayment = this.getreminderdata / 100;
      const remprice = this.RemDiscountpayment * this.payment.value.Discount;
      this.remtotalprice = this.getreminderdata - remprice;
    }

    this.payment.patchValue({
      AmountRequired: this.totalprice,
      Remainder: this.remtotalprice,
    });
  }
}
