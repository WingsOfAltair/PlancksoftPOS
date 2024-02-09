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
  billquantity = 0;
  total: number;
  filtercode: any;
  storeName: any;
  
  @HostListener('document:keypress', ['$event'])
  handleKeyboardEvent(event: KeyboardEvent) {
    this.ScannedBarcode += event.key;
    console.log(`Key pressed: ${this.ScannedBarcode}`);

    var obj = {
      ItemBarCode: this.ScannedBarcode,
    };
    
    this.publisherService
      .PostRequest("SearchInventoryItemsWithBarCode", obj)
      .subscribe((res: any) => {
        var response = JSON.parse(res);
        var data = response.ResponseMessage.Item1;
        
        if (data.ItemName){
          this.ScannedBarcode = '';
          
          var newItem = {
            data: {
              ItemID: data.ItemID,
              Picture: 'data:' + 'image/png' + ';base64,' + data["Picture"].slice(1, -1),
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
            },
          };
  
          if (this.paydata.length > 0) {
            var barcode = this.paydata.filter((a) => a.data.ItemBarCode == newItem.data.ItemBarCode);
            ;
            console.log(barcode);
            if (barcode.length > 0) {
              var existingItemIndex = this.paydata.findIndex(
                (a) => a.data.ItemBarCode === newItem.data.ItemBarCode
              );
              if (existingItemIndex !== -1 && newItem.data.ItemQuantity !== 0) {
                this.paydata[existingItemIndex].data.ItemQuantity +=
                  1;
    
                this.paydata.forEach((el) => {
                  var obj = {
                    ItemName: el.data.ItemName,
                    ItemQuantity: el.data.ItemQuantity,
                    ItemPrice: el.data.ItemPrice,
                  };
                  this.selectedfilter.push(obj);
                });
                this.dataSource = this.dataSourceBuilder.create(this.paydata);
              } else {
                this.toastrService.danger("Try Again", "Minimum 1 Quantity");
              }
            } else {
              this.paydata.push(newItem);
              this.paydataa.push(newItem.data);
              this.pandingdata = this.paydataa;
              this.dataSource = this.dataSourceBuilder.create(this.paydata);
              this.dataa = [];
              this.itemlist = [];
            }
          } else {
            var barcode = this.dataa.filter((a) => a.data.ItemBarCode == newItem.data.ItemBarCode);
            ;
            console.log(barcode);
            if (barcode.length > 0) {
              var existingItemIndex = this.dataa.findIndex(
                (a) => a.data.ItemBarCode === newItem.data.ItemBarCode
              );
              if (existingItemIndex !== -1 && newItem.data.ItemQuantity !== 0) {
                this.dataa[existingItemIndex].data.ItemQuantity += 1;
    
                this.dataa.forEach((el) => {
                  var obj = {
                    ItemName: el.data.ItemName,
                    ItemQuantity: el.data.ItemQuantity,
                    ItemPrice: el.data.ItemPrice,
                  };
                  this.selectedfilter.push(obj);
                });
                this.dataSource = this.dataSourceBuilder.create(this.dataa);
              } else {
                this.toastrService.danger("Try Again", "Minimum 1 Quantity");
              }
            } else {
              this.dataa.push(newItem);
              this.itemlist.push(newItem.data);
              this.pandingdata = this.itemlist;
              this.dataSource = this.dataSourceBuilder.create(this.dataa);
              this.paydata = [];
              this.paydataa = [];
            }
          }
        }
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

    this.publisherService
    .PostRequest("RetrieveSystemSettings", "")
    .subscribe((res: any) => {
      var response = JSON.parse(res);
      this.message = JSON.parse(response.ResponseMessage.Item1);

      this.storeName = this.message[0].SystemName;
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

        this.filterdata = data;

        var list = [];
        data.forEach((el) => {
          var obj = {
            data: {
              ItemID: el["ItemID"],
              Picture: 'data:' + 'image/png' + ';base64,' + el["Picture"].slice(1, -1),
              ItemName: el["ItemName"],
              ItemQuantity: el["ItemQuantity"],
              ItemBuyPrice: el["ItemBuyPrice"],
              ItemPrice: el["ItemPrice"],
              ItemPriceTax: el["ItemPriceTax"],
              favoriteCategoryName: el["favoriteCategoryName"],
              FavoriteCategory: el["FavoriteCategory"],
              warehouseName: el["warehouseName"],
              ItemTypeName: el["ItemTypeName"],
              ItemBarCode: el["ItemBarCode"],
            },
          };
          list.push(obj);
        });

        this.data = list;

        console.log(this.dataSource);
      });
  }

  newinvoice() {
    this.itemlist = [];
    this.random = this.getRandomNumber(1, 1000000);
    var totalAmount = 0;
    var billAmount = 0;
    var totalquantity = 0;
    var amount = [];

    if (this.paydata.length > 0) {
      this.paydata.forEach((el) => {
        var obj = {
          data: {
            ItemID: el.data.ItemID,
            Picture: el.data.Picture,
            ItemName: el.data.ItemName,
            ItemQuantity: el.data.ItemQuantity,
            ItemBuyPrice: el.data.ItemBuyPrice,
            ItemPrice: el.data.ItemPrice,
            ItemPriceTax: el.data.ItemPriceTax,
            favoriteCategoryName: el.data.favoriteCategoryName,
            FavoriteCategory: el.data.FavoriteCategory,
            warehouseName: el.data.warehouseName,
            ItemTypeName: el.data.ItemTypeName,
            ItemBarCode: el.data.ItemBarCode,
            RandomCode: this.random,
          },
        };
        this.PreviousPickedItem.push(obj);
      });

      this.paydata.forEach((el) => {
        var obj = {
          data: {
            ItemID: el.data.ItemID,
            Picture: el.data.Picture,
            ItemName: el.data.ItemName,
            ItemQuantity: el.data.ItemQuantity,
            ItemBuyPrice: el.data.ItemBuyPrice,
            ItemPrice: el.data.ItemPrice,
            ItemPriceTax: el.data.ItemPriceTax,
            favoriteCategoryName: el.data.favoriteCategoryName,
            FavoriteCategory: el.data.FavoriteCategory,
            warehouseName: el.data.warehouseName,
            ItemTypeName: el.data.ItemTypeName,
            ItemBarCode: el.data.ItemBarCode,
            RandomCode: this.random,
          },
        };
        this.codegenerate.push(obj);
      });
    } else {
      this.dataa.forEach((el) => {
        var obj = {
          data: {
            ItemID: el.data.ItemID,
            Picture: el.data.Picture,
            ItemName: el.data.ItemName,
            ItemQuantity: el.data.ItemQuantity,
            ItemBuyPrice: el.data.ItemBuyPrice,
            ItemPrice: el.data.ItemPrice,
            ItemPriceTax: el.data.ItemPriceTax,
            favoriteCategoryName: el.data.favoriteCategoryName,
            FavoriteCategory: el.data.FavoriteCategory,
            warehouseName: el.data.warehouseName,
            ItemTypeName: el.data.ItemTypeName,
            ItemBarCode: el.data.ItemBarCode,
            RandomCode: this.random,
          },
        };
        this.PreviousPickedItem.push(obj);
      });

      this.dataa.forEach((el) => {
        var obj = {
          data: {
            ItemID: el.data.ItemID,
            Picture: el.data.Picture,
            ItemName: el.data.ItemName,
            ItemQuantity: el.data.ItemQuantity,
            ItemBuyPrice: el.data.ItemBuyPrice,
            ItemPrice: el.data.ItemPrice,
            ItemPriceTax: el.data.ItemPriceTax,
            favoriteCategoryName: el.data.favoriteCategoryName,
            FavoriteCategory: el.data.FavoriteCategory,
            warehouseName: el.data.warehouseName,
            ItemTypeName: el.data.ItemTypeName,
            ItemBarCode: el.data.ItemBarCode,
            RandomCode: this.random,
          },
        };
        this.codegenerate.push(obj);
      });
    }
    this.PreviousPickedItem.forEach((el) => {
      var individualAmount = el.data.ItemQuantity * el.data.ItemPrice;
      billAmount += individualAmount;

      console.log(individualAmount);
    });
    amount.push(billAmount);
    this.perviousitem = this.PreviousPickedItem;

    this.PreviousPickedItem.forEach((el) => {
      var individualAmount = el.data.ItemQuantity;
      totalquantity += individualAmount;

      console.log(totalquantity);
    });

    this.billquantity = this.PreviousPickedItem.length;
    var obj = {
      data: {
        ItemName: this.billquantity,
        ItemQuantity: totalquantity,
        ItemPrice: billAmount,
        ramdomcode: this.PreviousPickedItem[0].data.RandomCode,
      },
    };

    this.pandingbill = this.allbills.push(obj);

    this.allbills.forEach((el) => {
      var individualAmount = el.data.ItemPrice;
      totalAmount += individualAmount;

      console.log(individualAmount);
    });
    amount.push(totalAmount);
    this.perivoustotal = totalAmount;

    this.dataSource = this.dataSourceBuilder.create([]);
    this.pandingdata = [];
    this.dataa = [];
    this.PreviousPickedItem = [];
    this.itemlist = [];
  }

  update(Barcode) {
    if (this.paydata.length > 0) {
      var SelectedData = this.paydata.filter(
        (a) => a.data.ItemBarCode == Barcode
      )[0];
    } else {
      var SelectedData = this.dataa.filter(
        (a) => a.data.ItemBarCode == Barcode
      )[0];
    }

    var obj = {
      ItemQuantity: SelectedData.data.ItemQuantity,
      ItemBarCode: Barcode,
    };

    var data = this.windowService.open(UpdateQuantityComponent, {
      title: `Update Quantity`,
      context: obj,
    });

    data.onClose.subscribe((res) => {
      if (res) {
        if (this.paydata.length > 0) {
          var existingItemIndex = this.paydata.findIndex(
            (a) => a.data.ItemBarCode === res.ItemBarCode
          );
          if (existingItemIndex !== -1 && res.ItemQuantity !== 0) {
            this.paydata[existingItemIndex].data.ItemQuantity =
              res.ItemQuantity;

            this.paydata.forEach((el) => {
              var obj = {
                ItemName: el.data.ItemName,
                ItemQuantity: el.data.ItemQuantity,
                ItemPrice: el.data.ItemPrice,
              };
              this.selectedfilter.push(obj);
            });
            this.dataSource = this.dataSourceBuilder.create(this.paydata);
          } else {
            this.toastrService.danger("Try Again", "Minimum 1 Quantity");
          }
        } else {
          var existingItemIndex = this.dataa.findIndex(
            (a) => a.data.ItemBarCode === res.ItemBarCode
          );
          if (existingItemIndex !== -1 && res.ItemQuantity !== 0) {
            this.dataa[existingItemIndex].data.ItemQuantity = res.ItemQuantity;

            this.dataa.forEach((el) => {
              var obj = {
                ItemName: el.data.ItemName,
                ItemQuantity: el.data.ItemQuantity,
                ItemPrice: el.data.ItemPrice,
              };
              this.selectedfilter.push(obj);
            });
            this.dataSource = this.dataSourceBuilder.create(this.dataa);
          } else {
            this.toastrService.danger("Try Again", "Minimum 1 Quantity");
          }
        }
      }
    });
  }

  updatebill() {
    var totalAmount = 0;
    var amount = [];

    if (this.paydata.length > 0) {
      this.paydata.forEach((el) => {
        var individualAmount = el.data.ItemQuantity * el.data.ItemPrice;
        totalAmount += individualAmount;

        console.log(individualAmount);
      });
      amount.push(totalAmount);

      if (this.deleteitem.length > 0) {
        var obj = {
          AmountRequired: totalAmount,
          itemlist: this.paydataa,
        };
      } else {
        var obj = {
          AmountRequired: totalAmount,
          itemlist: this.paydataa,
        };
      }
    } else {
      this.dataa.forEach((el) => {
        var individualAmount = el.data.ItemQuantity * el.data.ItemPrice;
        totalAmount += individualAmount;

        console.log(individualAmount);
      });

      amount.push(totalAmount);
      if (this.deleteitem.length > 0) {
        var obj = {
          AmountRequired: totalAmount,
          itemlist: this.selectedfilter,
        };
      } else {
        var obj = {
          AmountRequired: totalAmount,
          itemlist: this.itemlist,
        };
      }
    }

    var dt = this.windowService.open(PaymentModalComponent, {
      title: `Payment`,
      context: obj,
    });

    dt.onClose.subscribe((res) => {
      if (res == true) {
        console.log("res")
        console.log(res);
        var indexToRemoveAllBills = this.allbills.findIndex(
          (a) => a.data.ramdomcode == res.ramdomcode
        );
        var indexToRemovePaydata = this.paydata.findIndex(
          (a) => a.data.ramdomcode == res.ramdomcode
        );
        var indexToRemovePaydataa = this.paydataa.findIndex(
          (a) => a.data.ramdomcode == res.ramdomcode
        );
        var indexToRemoveDataa = this.dataa.findIndex(
          (a) => a.data.ramdomcode == res.ramdomcode
        );
        var indexToRemoveCodegenerate = this.codegenerate.findIndex(
          (a) => a.data.ramdomcode == res.ramdomcode
        );
        var amount = this.allbills.filter(
          (a) => a.data.ramdomcode == res.ramdomcode
        );
        this.dataSource = this.dataSourceBuilder.create([]);

        if (indexToRemoveAllBills !== -1) {
          this.total = this.perivoustotal - amount[0].data.ItemPrice;
          this.allbills.splice(indexToRemoveAllBills, 1);
          this.paydata.splice(indexToRemovePaydata, 1);
          this.paydataa.splice(indexToRemovePaydataa, 1);
          this.dataa.splice(indexToRemoveDataa, 1);
          this.codegenerate.splice(indexToRemoveCodegenerate, 1);
          this.pandingbill = this.allbills.length;
          this.perivoustotal = this.total;

          this.paydata = [];
          this.paydataa = [];
          this.dataa = [];
          this.itemlist = [];
          this.selectedfilter = [];
        }
      }
      this.ngOnInit();
    });
  }

  Perivousbill() {
    var data = this.windowService.open(PerivousBillComponent, {
      title: `Pick Bill`,
      context: this.allbills,
    });

    data.onClose.subscribe((res) => {
      if (res) {
        var selected = this.codegenerate.filter(
          (a) => a.data.RandomCode == res
        );
        this.filtercode = res;

        if (this.filtercode > 0) {
          this.dataSource = this.dataSourceBuilder.create([]);
          this.filtercode = 0;
          this.paydata = [];
          this.paydataa = [];
          this.dataa = [];
          this.itemlist = [];
          this.selectedfilter = [];
        }

        selected.forEach((el) => {
          var obj = {
            data: {
              ItemID: el.data.ItemID,
              Picture: el.data.Picture,
              ItemName: el.data.ItemName,
              ItemQuantity: el.data.ItemQuantity,
              ItemBuyPrice: el.data.ItemBuyPrice,
              ItemPrice: el.data.ItemPrice,
              ItemPriceTax: el.data.ItemPriceTax,
              favoriteCategoryName: el.data.favoriteCategoryName,
              FavoriteCategory: el.data.FavoriteCategory,
              warehouseName: el.data.warehouseName,
              ItemTypeName: el.data.ItemTypeName,
              ItemBarCode: el.data.ItemBarCode,
            },
          };

          this.paydata.push(obj);
          this.paydataa.push(obj.data);
          this.dataSource = this.dataSourceBuilder.create(this.paydata);
        });
        this.dataa = [];
        this.itemlist = [];
        this.selectedfilter = [];
      }
    });
  }

  getRandomNumber(min: number, max: number): number {
    return Math.floor(Math.random() * (max - min + 1)) + min;
  }

  PickItem() {
    var data = this.windowService.open(PickItemModalComponent, {
      title: `Pick Item`,
    });

    data.onClose.subscribe((res) => {
      if (res) {
        var selected = this.data.filter((a) => a.data.ItemBarCode == res);

        var newItem = {
          data: {
            ItemID: selected[0].data.ItemID,
            Picture: selected[0].data.Picture,
            ItemName: selected[0].data.ItemName,
            ItemQuantity: 1,
            ItemBuyPrice: selected[0].data.ItemBuyPrice,
            ItemPrice: selected[0].data.ItemPrice,
            ItemPriceTax: selected[0].data.ItemPriceTax,
            favoriteCategoryName: selected[0].data.favoriteCategoryName,
            FavoriteCategory: selected[0].data.FavoriteCategory,
            warehouseName: selected[0].data.warehouseName,
            ItemTypeName: selected[0].data.ItemTypeName,
            ItemBarCode: selected[0].data.ItemBarCode,
          },
        };

        if (this.paydata.length > 0) {
          var barcode = this.paydata.filter((a) => a.data.ItemBarCode == res);
          debugger;
          if (barcode.length > 0) {
            this.toastrService.danger("This item Is already exist", "Try another item");

          } else {
            this.paydata.push(newItem);
            this.paydataa.push(newItem.data);
            this.pandingdata = this.paydataa;
            this.dataSource = this.dataSourceBuilder.create(this.paydata);
            this.dataa = [];
            this.itemlist = [];
          }
        } else {
          var barcode = this.dataa.filter((a) => a.data.ItemBarCode == res);
          debugger;
          if (barcode.length > 0) {
            this.toastrService.danger("This item Is already exist", "Try another item");
          } else {
            this.dataa.push(newItem);
            this.itemlist.push(newItem.data);
            this.pandingdata = this.itemlist;
            this.dataSource = this.dataSourceBuilder.create(this.dataa);
            this.paydata = [];
            this.paydataa = [];
          }
        }
      }
    });
  }

  Delete(id) {
    ;

    if (this.paydata.length > 0) {
      console.log("paydata item delete barcode")
      console.log(id);
      var selected = this.paydata.findIndex((a) => a.data.ItemBarCode == id);

      if (selected !== -1) {
        this.paydata.splice(selected, 1);

        this.paydata.forEach((el) => {
          var obj = {
            data: {
              Picture: el.data.Picture,
              ItemName: el.data.ItemName,
              ItemBarCode: el.data.ItemBarCode,
              ItemQuantity: el.data.ItemQuantity,
              ItemPrice: el.data.ItemPrice,
            },
          };
          this.secoundDeleteTable.push(obj);
          this.deleteitem.push(obj.data);
        });
        this.dataSource = this.dataSourceBuilder.create(
          this.paydata
        );
      }
    }

    if (this.dataa.length > 0) {
      console.log("dataa item delete barcode")
      console.log(id);
      var selected = this.dataa.findIndex((a) => a.data.ItemBarCode == id);
      console.log("selected")
      console.log(selected);
      if (selected !== -1) {
        this.dataa.splice(selected, 1);

        this.dataa.forEach((el) => {
          var obj = {
            data: {
              Picture: el.data.Picture,
              ItemName: el.data.ItemName,
              ItemBarCode: el.data.ItemBarCode,
              ItemQuantity: el.data.ItemQuantity,
              ItemPrice: el.data.ItemPrice,
            },
          };
          this.secoundDeleteTable.push(obj);
          this.deleteitem.push(obj.data);
        });
        this.dataSource = this.dataSourceBuilder.create(
          this.dataa
        );
      }
    }
  }
}
