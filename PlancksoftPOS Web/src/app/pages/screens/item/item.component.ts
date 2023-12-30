import { Component, OnInit } from '@angular/core';
import { LocalDataSource } from 'ng2-smart-table';
import { SmartTableData } from '../../../@core/data/smart-table';

@Component({
  selector: 'ngx-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.scss']
})
export class ItemComponent implements OnInit {

  settings = {
    add: {
      addButtonContent: '<i class="nb-plus"></i>',
      createButtonContent: '<i class="nb-checkmark"></i>',
      cancelButtonContent: '<i class="nb-close"></i>',
    },
    edit: {
      editButtonContent: '<i class="nb-edit"></i>',
      saveButtonContent: '<i class="nb-checkmark"></i>',
      cancelButtonContent: '<i class="nb-close"></i>',
    },
    delete: {
      deleteButtonContent: '<i class="nb-trash"></i>',
      confirmDelete: true,
    },
    columns: {
      ItemID: {
        title: 'Item ID',
        type: 'number',
      },
      ItemName: {
        title: 'Item Name',
        type: 'string',
      },
      ItemBarcode: {
        title: 'Item Barcode',
        type: 'string',
      },
      ItemQuantity: {
        title: 'Item Quantity',
        type: 'string',
      },
      ItemBuyPrice: {
        title: 'Item Buy Price',
        type: 'string',
      },
      ItemPrice: {
        title: 'Item Price',
        type: 'string',
      },
      ItemPriceTax: {
        title: 'Item Price Tax',
        type: 'string',
      },
      WarehouseID: {
        title: 'Warehouse ID',
        type: 'string',
      },
      Warehouse: {
        title: 'Warehouse',
        type: 'string',
      },
      ItemTypeID: {
        title: 'Item Type ID',
        type: 'string',
      },
      ItemType: {
        title: 'Item Type',
        type: 'string',
      },
      FavoriteCategoryID: {
        title: 'Favorite Category ID',
        type: 'string',
      },
      FavoriteCategory: {
        title: 'Favorite Category',
        type: 'string',
      }

    },
  };
 
  source: LocalDataSource = new LocalDataSource();
  
  constructor(
    private service: SmartTableData,
  ) { }

  ngOnInit(): void {
  }

  onDeleteConfirm(event): void {
    if (window.confirm('Are you sure you want to delete?')) {
      event.confirm.resolve();
    } else {
      event.confirm.reject();
    }
  }  

}
