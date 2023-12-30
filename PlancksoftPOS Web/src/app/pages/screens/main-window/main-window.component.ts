import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { LocalDataSource } from 'ng2-smart-table';
import { SmartTableData } from '../../../@core/data/smart-table';

@Component({
  selector: 'ngx-main-window',
  templateUrl: './main-window.component.html',
  styleUrls: ['./main-window.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class MainWindowComponent implements OnInit {
  
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
      ItemName: {
        title: 'Item Name',
        type: 'string',
      },
      ItemQuantity: {
        title: 'Item Quantity',
        type: 'string',
      },
      ItemBarcode: {
        title: 'Item Barcode',
        type: 'string',
      },
      ItemPrice: {
        title: 'Item Price',
        type: 'number',
      },
      ClientPrice: {
        title: 'Item Price after Tax',
        type: 'string',
      }
    },
  };

  source: LocalDataSource = new LocalDataSource();
  
  constructor(private service: SmartTableData) {
    const data = this.service.getData();
    this.source.load(data);
  }

  onDeleteConfirm(event): void {
    if (window.confirm('Are you sure you want to delete?')) {
      event.confirm.resolve();
    } else {
      event.confirm.reject();
    }
  }  

  ngOnInit(): void {
  }

}
