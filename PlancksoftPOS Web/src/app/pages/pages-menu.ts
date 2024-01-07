import { NbMenuItem } from "@nebular/theme";
import {
  Locale,
  TranslationServiceService,
} from "../services/translation-service.service";

const dt = TranslationServiceService;
export const MENU_ITEMS: NbMenuItem[] = [
  {
    title: "Dashboard",
    icon: "home-outline",
    link: "/pages/iot-dashboard",
  },
  {
    title: "Cash",
    icon: "layout-outline",
    link: "/pages/main/cash",
  },
  {
    title: "Sales",
    icon: "layout-outline",
    children: [
      {
        title: "Sales",
        link: "/pages/screen/sale",
      },
      {
        title: "Edit Invoices",
        link: "/pages/screen/edit-invoice",
      },
      {
        title: "Incoming Outgoing Sales",
        link: "/pages/screen/imcomming-outgoing",
      },
      {
        title: "Sold Item Qualification",
        link: "/pages/screen/sold-item-quantification",
      },
    ],
  },
  {
    title: "Inventory",
    icon: "layout-outline",
    children: [
      {
        title: "Inventory",
        link: "/pages/main/inventory",
      },
      // {
      //   title: 'Add Item',
      //   link: '/pages/main/add-item',
      // },
      {
        title: "Warhouse Quantification",
        link: "/pages/main/wearhouse-quantification",
      },
      {
        title: "Import Export Form",
        link: "/pages/main/import-export",
      },
      {
        title: "Add An Item Type",
        link: "/pages/main/add-type",
      },
      {
        title: "Add A Favorite Category",
        link: "/pages/main/faveroite-category",
      },
      {
        title: "Add A Wearhouse",
        link: "/pages/main/add-wearhouse",
      },
    ],
  },
  {
    title: "Expenses",
    icon: "layout-outline",
    children: [
      {
        title: "Expenses LookUP",
        link: "/pages/expense/expanse-lookup",
      },
      // {
      //   title: 'Add A Expanses',
      //   link: '/pages/expense/add-expanse',
      // }
    ],
  },
  {
    title: "Import Export Capital",
    icon: "layout-outline",
    link: "/pages/screen/import-export-capital",
  },
  {
    title: "Employees Affairs",
    icon: "layout-outline",
    children: [
      {
        title: "Employees Managemant",
        link: "/pages/screen/employee",
      },
      {
        title: "Days Off",
        link: "/pages/screen/employee-absence",
      },
    ],
  },
  {
    title: "Client Affairs",
    icon: "layout-outline",
    children: [
      {
        title: "Client Defination",
        link: "/pages/screen/client-defination",
      },
      {
        title: "Client Check Balance",
        link: "/pages/screen/client-check-balance",
      },
      {
        title: "Vendors Defination",
        link: "/pages/screen/vendor-defination",
      },
      {
        title: "Vendor Balance Check",
        link: "/pages/screen/vendor-check-balance",
      },
    ],
  },
  {
    title: "Alarams",
    icon: "layout-outline",
    link: "/pages/screen/alaram",
  },

  {
    title: "Taxes",
    icon: "layout-outline",
    children: [
      {
        title: "Tax Z Report",
        link: "/pages/screen/tax-report",
      },
    ],
  },
  {
    title: "Users",
    icon: "layout-outline",
    link: "/pages/screen/user",
  },
  {
    title: "Settings",
    icon: "layout-outline",
    children: [
      {
        title: "POS Settings",
        link: "/pages/screen/setting",
      },
      {
        title: "Printers' Settings",
        link: "/pages/screen/printer",
      },
    ],
  },
  // {
  //   title: "Setting",
  //   icon: "layout-outline",
  //   link: "/pages/screen/setting",
  // },
  {
    title: "Refund",
    icon: "layout-outline",
    children: [
      {
        title: "Item Refund",
        link: "/pages/screen/refund-item",
      },
    ],
  },
];
