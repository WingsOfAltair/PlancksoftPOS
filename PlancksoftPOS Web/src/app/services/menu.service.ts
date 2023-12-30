import { Injectable } from "@angular/core";
import { TranslationServiceService } from "./translation-service.service";
import { PublisherService } from "./publisher.service";
import { Router } from "@angular/router";

@Injectable({
  providedIn: "root",
})
export class MenuService {
  Userdata: any;
  userID: any;
  constructor(
    private translationService: TranslationServiceService,
    private publisherService: PublisherService,
    private route: Router
  ) {
    var user = sessionStorage.getItem("userData");
    this.Userdata = JSON.parse(user);
    this.userID = this.Userdata.uid;

    var obj = {
      UserID: this.userID,
    };

    this.publisherService
      .PostRequest("RetrieveUserPermissions", obj)
      .subscribe((res: any) => {
        console.log(JSON.parse(res));
        var responce = JSON.parse(res);
        this.message = responce.ResponseMessage;

        var list = [];
        this.Client_card_edit = this.message.Client_card_edit;
        this.discount_edit = this.message.discount_edit;
        this.expenses_add = this.message.expenses_add;
        this.inventory_edit = this.message.inventory_edit;
        this.openclose_edit = this.message.openclose_edit;
        this.personnel_edit = this.message.personnel_edit;
        this.price_edit = this.message.price_edit;
        this.receipt_edit = this.message.receipt_edit;
        this.sell_edit = this.message.sell_edit;
        this.settings_edit = this.message.settings_edit;
        this.users_edit = this.message.users_edit;
        this.loadMenus();
      });
  }


  menu: any = [];
  message: any;
  Client_card_edit: any;
  discount_edit: any;
  expenses_add: any;
  inventory_edit: any;
  openclose_edit: any;
  personnel_edit: any;
  price_edit: any;
  receipt_edit: any;
  sell_edit: any;
  settings_edit: any;
  users_edit: any;

  loadMenus() {
    this.menu = [];
    if (this.message.Client_card_edit == true) {
      this.menu.push({
        title:
          this.translationService.getSelectedLanguage() == "en"
            ? "Cash"
            : "الكاش",
        icon: "layout-outline",
        link: "/pages/main/cash",
        order: 2,
      });
    }

    if (this.message.discount_edit == true) {
      this.menu.push({
        title:
          this.translationService.getSelectedLanguage() == "en"
            ? "Sale"
            : "المبيعات",
        icon: "layout-outline",
        order: 3,
        children: [
          {
            title:
              this.translationService.getSelectedLanguage() == "en"
                ? "Sale"
                : "المبيعات",
            link: "/pages/screen/sale",
          },
          {
            title:
              this.translationService.getSelectedLanguage() == "en"
                ? "Invoice"
                : "فاتورة",
            link: "/pages/screen/edit-invoice",
          },
          {
            title:
              this.translationService.getSelectedLanguage() == "en"
                ? "Incoming Outgoing Sales"
                : "المبيعات المرحله و الغير مرحله",
            link: "/pages/screen/imcomming-outgoing",
          },
          {
            title:
              this.translationService.getSelectedLanguage() == "en"
                ? "Sold Item Qualification"
                : "جرد الكميات المباعه",
            link: "/pages/screen/sold-item-quantification",
          },
        ],
      });
    }
    if (this.message.expenses_add == true) {
      this.menu.push({
        title:
          this.translationService.getSelectedLanguage() == "en"
            ? "Expense"
            : "المصاريف",
        icon: "layout-outline",
        order: 4,
        children: [
          {
            title:
              this.translationService.getSelectedLanguage() == "en"
                ? "Expense Lookup"
                : "البحث عن المصروفات",
            link: "/pages/expense/expanse-lookup",
          },
        ],
      });
    }
    if (this.message.inventory_edit == true) {
      this.menu.push({
        title:
          this.translationService.getSelectedLanguage() == "en"
            ? "Inventory"
            : "المستودع",
        icon: "layout-outline",
        order: 5,
        children: [
          {
            title:
              this.translationService.getSelectedLanguage() == "en"
                ? "Inventory"
                : "المستودع",
            link: "/pages/main/inventory",
          },
          {
            title:
              this.translationService.getSelectedLanguage() == "en"
                ? "Wearhouse Quantification"
                : "جرد المستودعات",
            link: "/pages/main/wearhouse-quantification",
          },
          {
            title:
              this.translationService.getSelectedLanguage() == "en"
                ? "Import Export Form"
                : "سند إدخال و إخراج",
            link: "/pages/main/import-export",
          },
          {
            title:
              this.translationService.getSelectedLanguage() == "en"
                ? "Add Item Type"
                : "إضافة صنف",
            link: "/pages/main/add-type",
          },
          {
            title:
              this.translationService.getSelectedLanguage() == "en"
                ? "Add Favorite Category"
                : "إضافة مجلد مفضلات",
            link: "/pages/main/faveroite-category",
          },
          {
            title:
              this.translationService.getSelectedLanguage() == "en"
                ? "Add Wearhouse"
                : "إضافة مستودع",
            link: "/pages/main/add-wearhouse",
          },
        ],
      });
    }

    if (this.message.users_edit == true) {
      this.menu.push({
        title:
          this.translationService.getSelectedLanguage() == "en"
            ? "Users"
            : "المستخدمين",
        icon: "home-outline",
        link: "/pages/screen/user",
        order: 8,
      },
      {
        title:
          this.translationService.getSelectedLanguage() == "en"
            ? "Refunds"
            : "المرجعات",
        icon: "grid-outline",
        order: 11,
        children: [
          {
            title:
              this.translationService.getSelectedLanguage() == "en"
                ? "Item Refund"
                : "استرداد العنصر",
            link: "/pages/screen/refund-item",
          },
        ],
      }
      );
    }
    if (this.message.personnel_edit == true) {
      this.menu.push({
        title:
          this.translationService.getSelectedLanguage() == "en"
            ? "Employees Affairs"
            : "شؤون الموظفين",
        icon: "layout-outline",
        order: 9,
        children: [
          {
            title:
              this.translationService.getSelectedLanguage() == "en"
                ? "Employees Management"
                : "إدارة الموظفين",
            link: "/pages/screen/employee",
          },
          {
            title:
              this.translationService.getSelectedLanguage() == "en"
                ? "Days Off"
                : "الإجازات",
            link: "/pages/screen/employee-absence",
          },
        ],
      });
    }
    if (this.message.settings_edit == true) {
      this.menu.push({
        title:
        this.translationService.getSelectedLanguage() == "en"
          ? "Setting"
          : "جلسة",
      icon: "layout-outline",
      link: "/pages/screen/setting",
      order: 11,
        children: [
          {
            title:
              this.translationService.getSelectedLanguage() == "en"
                ? "POS Setting"
                : "إعداد نقاط البيع",
            link: "/pages/screen/setting",
          },
          {
            title:
              this.translationService.getSelectedLanguage() == "en"
                ? "Printers"
                : "الطابعات",
            link: "/pages/screen/printer",
          },
        ],
      });
    }
    // if (this.message.Client_card_edit == true) {

    //   this.menu = [
    //     {
    //       title:
    //         this.translationService.getSelectedLanguage() == "en"
    //           ? "Cash"
    //           : "الكاش",
    //       icon: "cash-outline",
    //       link: "/pages/main/cash",
    //     },
    //   ]

    // }
    // if (this.message.Client_card_edit == true) {

    //   this.menu = [
    //     {
    //       title:
    //         this.translationService.getSelectedLanguage() == "en"
    //           ? "Cash"
    //           : "الكاش",
    //       icon: "cash-outline",
    //       link: "/pages/main/cash",
    //     },
    //   ]

    // }
    // if (this.message.Client_card_edit == true) {

    //   this.menu = [
    //     {
    //       title:
    //         this.translationService.getSelectedLanguage() == "en"
    //           ? "Cash"
    //           : "الكاش",
    //       icon: "cash-outline",
    //       link: "/pages/main/cash",
    //     },
    //   ]

    // }
    // if (this.message.Client_card_edit == true) {

    //   this.menu = [
    //     {
    //       title:
    //         this.translationService.getSelectedLanguage() == "en"
    //           ? "Cash"
    //           : "الكاش",
    //       icon: "cash-outline",
    //       link: "/pages/main/cash",
    //     },
    //   ]

    // }
    this.menu.push(
      {
        title:
          this.translationService.getSelectedLanguage() == "en"
            ? "Dashboard"
            : "لوحة القيادة",
        icon: "home-outline",
        link: "/pages/iot-dashboard",
        order: 1,
      },

      // {
      //   title:
      //     this.translationService.getSelectedLanguage() == "en"
      //       ? "Sale"
      //       : "المبيعات",
      //   icon: "layout-outline",
      //   children: [
      //     {
      //       title:
      //         this.translationService.getSelectedLanguage() == "en"
      //           ? "Sale"
      //           : "المبيعات",
      //       link: "/pages/screen/sale",
      //     },
      //     {
      //       title:
      //         this.translationService.getSelectedLanguage() == "en"
      //           ? "Invoice"
      //           : "فاتورة",
      //       link: "/pages/screen/edit-invoice",
      //     },
      //     {
      //       title:
      //         this.translationService.getSelectedLanguage() == "en"
      //           ? "Incoming Outgoing Sales"
      //           : "المبيعات المرحله و الغير مرحله",
      //       link: "/pages/screen/imcomming-outgoing",
      //     },
      //     {
      //       title:
      //         this.translationService.getSelectedLanguage() == "en"
      //           ? "Sold Item Qualification"
      //           : "جرد الكميات المباعه",
      //       link: "/pages/screen/sold-item-quantification",
      //     },
      //   ],
      // },

      // {
      //   title:
      //     this.translationService.getSelectedLanguage() == "en"
      //       ? "Expense"
      //       : "المصاريف",
      //   icon: "layout-outline",
      //   children: [
      //     {
      //       title:
      //         this.translationService.getSelectedLanguage() == "en"
      //           ? "Expense Lookup"
      //           : "البحث عن المصروفات",
      //       link: "/pages/expense/expanse-lookup",
      //     },
      //   ],
      // },
      {
        title:
          this.translationService.getSelectedLanguage() == "en"
            ? "Import & Export & Capital"
            : "الصادر و الوارد و رأس المال",
        icon: "home-outline",
        link: "/pages/screen/import-export-capital",
        order: 7,
      },

      {
        title:
          this.translationService.getSelectedLanguage() == "en"
            ? "Clients Affairs"
            : "شؤون العملاء",
        icon: "layout-outline",
        children: [
          {
            title:
              this.translationService.getSelectedLanguage() == "en"
                ? "Clients Definitions"
                : "تعريف العملاء",
            link: "/pages/screen/client-defination",
          },
          {
            title:
              this.translationService.getSelectedLanguage() == "en"
                ? "Client Balance Check"
                : "كشف حساب العميل",
            link: "/pages/screen/client-check-balance",
          },
          {
            title:
              this.translationService.getSelectedLanguage() == "en"
                ? "Vendors Definitions"
                : "تعريف مورد",
            link: "/pages/screen/vendor-defination",
          },
          {
            title:
              this.translationService.getSelectedLanguage() == "en"
                ? "Vendor Balance Check"
                : "كشف حساب مورد",
            link: "/pages/screen/vendor-check-balance",
          },
        ],
      },
      {
        title:
          this.translationService.getSelectedLanguage() == "en"
            ? "Alarms"
            : "التنبيهات",
        icon: "home-outline",
        link: "/pages/screen/alaram",
      },
      {
        title:
          this.translationService.getSelectedLanguage() == "en"
            ? "Taxes"
            : "الضريبه",
        icon: "layout-outline",
        children: [
          {
            title:
              this.translationService.getSelectedLanguage() == "en"
                ? "Tax Z Report"
                : "تقرير الضريبه Z",
            link: "/pages/screen/tax-report",
          },
        ],
      },

      {
        title:
          this.translationService.getSelectedLanguage() == "en"
            ? "Printer"
            : "طابعة",
        icon: "layout-outline",
        order: 10,
        children: [
          {
            title:
              this.translationService.getSelectedLanguage() == "en"
                ? "Printer Type"
                : "نوع الطابعة",
            link: "/pages/screen/printer-type",
          },
          {
            title:
              this.translationService.getSelectedLanguage() == "en"
                ? "Printer"
                : "طابعة",
            link: "/pages/screen/printer",
          },
        ],
      },

    );

    this.menu.sort(function (a, b) {
      return a.order - b.order;
    });
  }
}
