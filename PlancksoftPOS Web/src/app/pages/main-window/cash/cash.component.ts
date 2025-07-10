import { Component, OnInit, HostListener } from "@angular/core";
import { LocalDataSource } from "ng2-smart-table";
import { SmartTableData } from "../../../@core/data/smart-table";
import {
  NbDialogService,
  NbSortDirection,
  NbSortRequest,
  NbToastrService,
  NbTreeGridDataSource,
  NbTreeGridDataSourceBuilder,
  NbWindowService,
} from "@nebular/theme";
import { CloseModelRegisterComponent } from "../close-model-register/close-model-register.component";
import { PublisherService } from "../../../services/publisher.service";
import { OpenRegisterModalComponent } from "../open-register-modal/open-register-modal.component";
import { UpdateQuantityComponent } from "../update-quantity/update-quantity.component";
import { PaymentModalComponent } from "../../screens/payment-modal/payment-modal.component";
import { PickItemModalComponent } from "../pick-item-modal/pick-item-modal.component";
import { PerivousBillComponent } from "../perivous-bill/perivous-bill.component";
import { RefundItemModalComponent } from "../refund-item-modal/refund-item-modal.component";

@Component({
  selector: "ngx-cash",
  templateUrl: "./cash.component.html",
  styleUrls: ["./cash.component.scss"],
})
export class CashComponent implements OnInit {
  data: any;
  filterdata: any;

  defaultColumns = [
    "Picture",
    "ItemName",
    "ItemQuantity",
    "ItemBarcode",
    "ClientPrice",
    "Action",
  ];

  allColumns = [...this.defaultColumns];

  dataSource: NbTreeGridDataSource<any>;

  ScannedBarcode = '';

  currentSelectedBill :any = null;

  sortColumn: string;
  sortDirection: NbSortDirection = NbSortDirection.NONE;
  Userdata: any;
  userID: any;
  date: Date;
  message: any;
  logo: any;
  currentdate: Date;
  dataa: any[] = [];
  selectedfilter: any[] = [];
  UpdateTable: any[] = [];
  itemlist: any[] = [];
  secoundDeleteTable: any[] = [];
  deleteitem: any[] = [];
  perviousitem: any[] = [];
  pandingdata: any[] = [];
  allbills: any[] = [];
  perivoustotal: number;
  perivouspaid: number;
  perivousreminder: number;
  pandingbill: any;
  billno: any;
  bill: number;
  billID: any;
  demoID: number;
  PreviousPickedItem: any[] = [];
  codegenerate: any[] = [];
  paydata: any[] = [];
  paydataa: any[] = [];
  random: number;
  random2: number;
  billquantity = 0;
  total: number;
  filtercode: any;
  storeName: any;
  
  @HostListener('document:keypress', ['$event'])
handleKeyboardEvent(event: KeyboardEvent) {
  this.ScannedBarcode += event.key;

  var obj = { ItemBarCode: this.ScannedBarcode };

  this.publisherService.PostRequest("SearchInventoryItemsWithBarCode", obj).subscribe((res: any) => {
    const response = JSON.parse(res);
    const data = response.ResponseMessage.Item1;

    if (!data?.ItemName) return;

    this.ScannedBarcode = '';

    const baseItem = {
      ItemID: data.ItemID,
      Picture: 'data:image/png;base64,' + (data.Picture || '').slice(1, -1),
      ItemName: data.ItemName,
      ItemQuantity: 1,
      ItemBuyPrice: data.ItemBuyPrice,
      ItemPrice: data.ItemPrice,
      ItemPriceTax: data.ItemPriceTax,
      favoriteCategoryName: data.favoriteCategoryName,
      FavoriteCategory: data.FavoriteCategory,
      warehouseName: data.warehouseName,
      ItemTypeName: data.ItemTypeName,
      ItemBarCode: data.ItemBarCode,
      RandomCode: this.random,
    };

    const newItem = { data: baseItem, randomcode: this.random2 };

    // Check if item already exists in codegenerate for this bill
    const index = this.codegenerate.findIndex(item =>
      item.data.ItemBarCode === baseItem.ItemBarCode &&
      item.data.RandomCode === this.random &&
      item.randomcode === this.random2
    );

    if (index !== -1) {
      // ✅ Already exists: Increase quantity
      this.codegenerate[index].data.ItemQuantity += 1;
    } else {
      // ✅ Doesn't exist: Add new
      this.codegenerate.push(newItem);
    }

    // 🔄 Refresh local views
    this.paydata = this.codegenerate.filter(a => a.data.RandomCode === this.random && a.randomcode === this.random2);
    this.paydataa = this.paydata.map(a => a.data);
    this.dataa = [...this.paydata]; // for legacy compatibility
    this.itemlist = [...this.paydata]; // used in pending data
    this.pandingdata = [...this.itemlist];

    // 🧮 Update bill summary
    let totalAmount = 0;
    let totalQty = 0;
    this.paydata.forEach(el => {
      totalAmount += el.data.ItemQuantity * el.data.ItemPrice;
      totalQty += el.data.ItemQuantity;
    });

    this.billquantity = this.paydata.length;

    const billIndex = this.allbills.findIndex(a => a.randomcode === this.random2);
    if (billIndex !== -1) {
      this.allbills[billIndex].data.ItemName = this.billquantity;
      this.allbills[billIndex].data.ItemQuantity = totalQty;
      this.allbills[billIndex].data.ItemPrice = totalAmount;
    }

    this.dataSource = this.dataSourceBuilder.create(this.paydata);
  });
}

  @HostListener('document:keydown', ['$event'])
  handleEscapeKey(event: KeyboardEvent) {
    if (event.key === 'Escape') {
      console.log('Escape key was pressed');
      this.ScannedBarcode = '';
    }
  }

  @HostListener("document:keydown.f1", ["$event"])
  handleF1Key(event: KeyboardEvent) {
    event.preventDefault(); // Prevent the default behavior of the F1 key (e.g., opening browser help)
    this.openDialog(); // Call a function to open your dialog
  }

  openDialog() {
    // Use NbDialogService to open your dialog
    this.windowService.open(RefundItemModalComponent, {
      title: `Item Refund`,
    });
  }
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
    private dialogService: NbDialogService,
    private publisherService: PublisherService,
    private windowService: NbWindowService,
    private dataSourceBuilder: NbTreeGridDataSourceBuilder<any>,
    private toastrService: NbToastrService
  ) {
    var user = sessionStorage.getItem("userData");
    this.Userdata = JSON.parse(user);
    this.userID = this.Userdata.uid;

    this.date = new Date();
  }

  ngOnInit(): void {
    this.random = this.getRandomNumber(1, 1000000);
    this.random2 = this.getRandomNumber(1, 1000000);
  console.log("random: " + this.random);
  console.log("random2 :" + this.random2);
    // Step 1: Load system settings (e.g. store name)
    this.publisherService
      .PostRequest("RetrieveSystemSettings", "")
      .subscribe((res: any) => {
        const response = JSON.parse(res);
        const message = JSON.parse(response.ResponseMessage.Item1);
        this.storeName = message[0]?.SystemName ?? '';
      });

    // Step 2: Load all items
    const requestObj = { locale: 1 };
    this.publisherService
      .PostRequest("RetrieveItems", requestObj)
      .subscribe((res: any) => {
        const response = JSON.parse(res);
        const data = response.ResponseMessage.Item1;

        this.filterdata = data;

        // Step 3: Map items into structured format used by PickItem()
        this.data = data.map(el => {
          let picture = '';
          try {
            picture = el.Picture?.slice(1, -1) || '';
          } catch (err) {
            picture = '';
          }

          return {
            data: {
              ItemID: el.ItemID,
              Picture: 'data:image/png;base64,' + picture,
              ItemName: el.ItemName,
              ItemQuantity: el.ItemQuantity,
              ItemBuyPrice: el.ItemBuyPrice,
              ItemPrice: el.ItemPrice,
              ItemPriceTax: el.ItemPriceTax,
              favoriteCategoryName: el.favoriteCategoryName,
              FavoriteCategory: el.FavoriteCategory,
              warehouseName: el.warehouseName,
              ItemTypeName: el.ItemTypeName,
              ItemBarCode: el.ItemBarCode,
            },
          };
        });
      });
}

  newinvoice() {
  // Step 1: Filter previous bill items before resetting
  const previousRandom = this.random;
  const previousRandom2 = this.random2;

  const previousItems = this.codegenerate.filter(
    item => item.data.RandomCode === previousRandom && item.randomcode === previousRandom2
  );

  if (previousItems.length === 0) {
    this.toastrService.warning("No items to add to the previous bill.");
    return;
  }

  const exists = this.allbills.some(
  bill =>
    bill.randomcode === previousRandom2 &&
    bill.data?.randomcode === previousRandom
  );

  if (exists) {
    // Step 6: Reset views
    this.currentSelectedBill = null;
    this.dataSource = this.dataSourceBuilder.create([]);
    this.pandingdata = [];
    this.paydata = [];
    this.dataa = [];
    this.PreviousPickedItem = [];
    this.itemlist = [];
    this.random = this.getRandomNumber(1, 1000000);
    this.random2 = this.getRandomNumber(1, 1000000);
    console.log("random: " + this.random);
    console.log("random2 :" + this.random2);
  } else {
    // Step 2: Calculate bill totals
    let billAmount = 0;
    let totalquantity = 0;

    previousItems.forEach(el => {
      billAmount += el.data.ItemQuantity * el.data.ItemPrice;
      totalquantity += el.data.ItemQuantity;
    });

    const billquantity = previousItems.length;

    // Step 3: Add the bill summary to allbills
    const billSummary = {
      data: {
        ItemName: billquantity,
        ItemQuantity: totalquantity,
        ItemPrice: billAmount,
        randomcode: previousItems[0].data.RandomCode,
      },
      randomcode: previousRandom2,
    };

    this.allbills.push(billSummary);

    // Step 4: Update bill totals
    let totalAmount = 0;
    this.allbills.forEach(el => {
      totalAmount += el.data.ItemPrice;
    });
    this.perivoustotal = totalAmount;

    // Step 6: Reset views
    this.currentSelectedBill = null;
    this.dataSource = this.dataSourceBuilder.create([]);
    this.pandingdata = [];
    this.paydata = [];
    this.dataa = [];
    this.PreviousPickedItem = [];
    this.itemlist = [];
    this.random = this.getRandomNumber(1, 1000000);
    this.random2 = this.getRandomNumber(1, 1000000);
    console.log("random: " + this.random);
    console.log("random2 :" + this.random2);
  }
}

  update(Barcode) {
  // Find item to update from current bill (in codegenerate)
  const SelectedData = this.codegenerate.find(
    (el) => el.data.ItemBarCode === Barcode &&
            el.randomcode === this.random2 &&
            el.data.RandomCode === this.random
  );

  if (!SelectedData) {
    this.toastrService.danger("Item not found", "Update Error");
    return;
  }

  const obj = {
    ItemQuantity: SelectedData.data.ItemQuantity,
    ItemBarCode: Barcode,
  };

  const data = this.windowService.open(UpdateQuantityComponent, {
    title: `Update Quantity`,
    context: obj,
  });

  data.onClose.subscribe((res) => {
    if (res && res.ItemQuantity !== 0) {
      // Update item quantity in codegenerate
      const itemIndex = this.codegenerate.findIndex(
        (el) => el.data.ItemBarCode === Barcode &&
                el.randomcode === this.random2 &&
                el.data.RandomCode === this.random
      );

      if (itemIndex !== -1) {
        this.codegenerate[itemIndex].data.ItemQuantity = res.ItemQuantity;
      }

      // Rebuild paydata and dataSource from codegenerate
      const updatedBillItems = this.codegenerate.filter(
        (el) => el.randomcode === this.random2 && el.data.RandomCode === this.random
      );

      this.paydata = [...updatedBillItems];
      this.paydataa = updatedBillItems.map(el => el.data);
      this.dataSource = this.dataSourceBuilder.create(this.paydata);

      // Update bill totals in allbills
      const billIndex = this.allbills.findIndex(b => b.randomcode === this.random2);

      if (billIndex !== -1) {
        let billAmount = 0;
        let totalQuantity = 0;

        updatedBillItems.forEach((el) => {
          billAmount += el.data.ItemQuantity * el.data.ItemPrice;
          totalQuantity += el.data.ItemQuantity;
        });

        this.billquantity = updatedBillItems.length;

        this.allbills[billIndex].data.ItemName = this.billquantity;
        this.allbills[billIndex].data.ItemQuantity = totalQuantity;
        this.allbills[billIndex].data.ItemPrice = billAmount;

        // Update grand total
        const totalAmount = this.allbills.reduce((sum, bill) => sum + bill.data.ItemPrice, 0);
        console.log("Updated Bill Amount:", billAmount);
        console.log("Updated Total:", totalAmount);
      }

      // Clear stale filters
      this.selectedfilter = this.paydataa.map(el => ({
        ItemName: el.ItemName,
        ItemQuantity: el.ItemQuantity,
        ItemPrice: el.ItemPrice,
        RandomCode: el.RandomCode
      }));

      this.pandingdata = [];
      this.PreviousPickedItem = [];
    }

    this.ScannedBarcode = '';
  });
}

  updatebill() {
  let totalAmount = 0;

  // Get items of current selected bill from codegenerate
  const currentBillItems = this.codegenerate.filter(
    (el) => el.randomcode === this.random2 && el.data.RandomCode === this.random
  );

  // Calculate total amount
  currentBillItems.forEach((el) => {
    const individualAmount = el.data.ItemQuantity * el.data.ItemPrice;
    totalAmount += individualAmount;
    console.log("Item Total:", individualAmount);
  });

  // Create payment context
  const obj = {
    AmountRequired: totalAmount,
    itemlist: currentBillItems.map(el => el.data),
  };

  // Open payment modal
  const dt = this.windowService.open(PaymentModalComponent, {
    title: `Payment`,
    context: obj,
  });

  // On confirm/submit payment
  dt.componentInstance.modalClose.subscribe((res) => {
    console.log("Closing current bill:", this.random, this.random2);

    // Remove the bill from allbills and codegenerate
    this.allbills = this.allbills.filter(
      (item) => item.randomcode !== this.random2
    );
    this.codegenerate = this.codegenerate.filter(
      (item) => item.randomcode !== this.random2
    );

    // Reset table & state
    this.pandingbill = this.allbills.length;
    this.paydata = [];
    this.paydataa = [];
    this.dataa = [];
    this.itemlist = [];
    this.selectedfilter = [];
    this.deleteitem = [];
    this.dataSource = this.dataSourceBuilder.create([]);
    this.ScannedBarcode = '';
    this.ngOnInit();
  });

  // On close (cancel), update grand total (optional)
  dt.onClose.subscribe((res) => {
    const closedBill = this.allbills.find(
      (a) => a.randomcode === res?.randomcode
    );
    if (closedBill) {
      this.total = this.perivoustotal - closedBill.data.ItemPrice;
      this.perivoustotal = this.total;
    }
  });
}

  Perivousbill() {
  const data = this.windowService.open(PerivousBillComponent, {
    title: `Pick Bill`,
    context: this.allbills,
  });

  data.onClose.subscribe((res) => {
    if (res) {
      // Filter all items from codegenerate matching selected bill session
      const selectedItems = this.codegenerate.filter(
        (a) => a.data.RandomCode === res
      );

      if (selectedItems.length === 0) {
        this.toastrService.warning("No items found for selected bill.");
        return;
      }

      const billCode = selectedItems[0].randomcode;
      const billSession = selectedItems[0].data.RandomCode;

      // Set current bill identifiers
      this.random = billSession;
      this.random2 = billCode;

      // Set current selected bill (optional full array or just code)
      this.currentSelectedBill = selectedItems;

      // Update dataSource with items of selected bill
      this.dataSource = this.dataSourceBuilder.create(
        selectedItems.filter(
          (el) =>
            el.randomcode === this.random2 &&
            el.data.RandomCode === this.random
        )
      );

      // Clean legacy arrays (optional, for safety)
      this.paydata = [];
      this.paydataa = [];
      this.dataa = [];
      this.itemlist = [];
      this.selectedfilter = [];
      this.filtercode = 0;

      // Log for verification
      console.log("Selected Bill Items:", selectedItems);
      console.log("Updated Identifiers:", this.random, this.random2);
    }
  });
}

  getRandomNumber(min: number, max: number): number {
    return Math.floor(Math.random() * (max - min + 1)) + min;
  }

  PickItem() {
  const data = this.windowService.open(PickItemModalComponent, {
    title: `Pick Item`,
  });

  data.onClose.subscribe((res) => {
    if (!res) return;

    const selected = this.data.find((a) => a.data.ItemBarCode == res);
    if (!selected) return;

    const newItem = {
      data: {
        ItemID: selected.data.ItemID,
        Picture: selected.data.Picture,
        ItemName: selected.data.ItemName,
        ItemQuantity: 1,
        ItemBuyPrice: selected.data.ItemBuyPrice,
        ItemPrice: selected.data.ItemPrice,
        ItemPriceTax: selected.data.ItemPriceTax,
        favoriteCategoryName: selected.data.favoriteCategoryName,
        FavoriteCategory: selected.data.FavoriteCategory,
        warehouseName: selected.data.warehouseName,
        ItemTypeName: selected.data.ItemTypeName,
        ItemBarCode: selected.data.ItemBarCode,
        RandomCode: this.random, // attach bill session ID
      },
      randomcode: this.random2, // attach bill unique code
    };

    const currentBillCode = this.random2;
    const currentRandomCode = this.random;

    // Check if item already exists in the current bill
    const exists = this.codegenerate.some(
      (item) =>
        item.randomcode === currentBillCode &&
        item.data.RandomCode === currentRandomCode &&
        item.data.ItemBarCode === newItem.data.ItemBarCode
    );

    if (exists) {
      this.toastrService.danger("This item Is already exist", "Try another item");
      return;
    }

    // Add new item only to current bill
    this.codegenerate.push(newItem);

    // Rebuild current bill item list
    const currentBillItems = this.codegenerate.filter(
      (item) =>
        item.randomcode === currentBillCode &&
        item.data.RandomCode === currentRandomCode
    );

    // Update data source with just this bill's items
    this.dataSource = this.dataSourceBuilder.create(currentBillItems);

    // Update bill totals in allbills
    const billIndex = this.allbills.findIndex((b) => b.randomcode === currentBillCode);
    if (billIndex !== -1) {
      let billAmount = 0;
      let totalQuantity = 0;

      currentBillItems.forEach((item) => {
        billAmount += item.data.ItemQuantity * item.data.ItemPrice;
        totalQuantity += item.data.ItemQuantity;
      });

      this.billquantity = currentBillItems.length;
      this.allbills[billIndex].data.ItemName = this.billquantity;
      this.allbills[billIndex].data.ItemQuantity = totalQuantity;
      this.allbills[billIndex].data.ItemPrice = billAmount;
    }

    // Optionally update grand total
    const grandTotal = this.allbills.reduce(
      (sum, bill) => sum + (bill.data.ItemPrice || 0),
      0
    );
    console.log("Grand Total:", grandTotal);
  });
}

  Delete(id) {
  const billCode = this.random2;
  const billSession = this.random;

  // Filter out the item from codegenerate
  const indexBefore = this.codegenerate.length;
  this.codegenerate = this.codegenerate.filter(
    item => !(item.data.ItemBarCode === id && item.randomcode === billCode && item.data.RandomCode === billSession)
  );
  const indexAfter = this.codegenerate.length;

  if (indexBefore === indexAfter) {
    this.toastrService.warning("Item not found in selected bill.");
    return;
  }

  // Push to deleted items list (optional)
  this.secoundDeleteTable.push({
    data: {
      ItemBarCode: id,
      ItemName: "Deleted",
      ItemQuantity: 1,
      ItemPrice: 0,
      Picture: null
    }
  });
  this.deleteitem.push({
    ItemBarCode: id,
    ItemName: "Deleted",
    ItemQuantity: 1,
    ItemPrice: 0
  });

  // Rebuild bill item list
  const currentBillItems = this.codegenerate.filter(
    item => item.randomcode === billCode && item.data.RandomCode === billSession
  );

  // Update bill data source view
  this.dataSource = this.dataSourceBuilder.create(currentBillItems);

  // Update bill in allbills
  const billIndex = this.allbills.findIndex(bill => bill.randomcode === billCode);
  if (billIndex !== -1) {
    if (currentBillItems.length === 0) {
      this.allbills.splice(billIndex, 1); // Remove empty bill
    } else {
      let billAmount = 0;
      let totalQuantity = 0;

      currentBillItems.forEach((item) => {
        billAmount += item.data.ItemQuantity * item.data.ItemPrice;
        totalQuantity += item.data.ItemQuantity;
      });

      this.billquantity = currentBillItems.length;
      this.allbills[billIndex].data.ItemName = this.billquantity;
      this.allbills[billIndex].data.ItemQuantity = totalQuantity;
      this.allbills[billIndex].data.ItemPrice = billAmount;
    }
  }

  // Optionally recalculate total amount across all bills
  const grandTotal = this.allbills.reduce(
    (sum, bill) => sum + (bill.data.ItemPrice || 0),
    0
  );
  console.log("Updated Grand Total:", grandTotal);
}
}
