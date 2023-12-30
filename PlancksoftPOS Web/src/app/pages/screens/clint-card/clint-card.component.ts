import { Component, OnInit } from '@angular/core';

import { LocalDataSource } from 'ng2-smart-table';
import { SmartTableData } from '../../../@core/data/smart-table';


@Component({
  selector: 'ngx-clint-card',
  templateUrl: './clint-card.component.html',
  styleUrls: ['./clint-card.component.scss']
})
export class ClintCardComponent implements OnInit {

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
      ClientID: {
        title: 'Client ID',
        type: 'number',
      },
      ClientName: {
        title: 'Client Name',
        type: 'string',
      },
      ItemName: {
        title: 'Item Name',
        type: 'string',
      },
      ItemBarcode: {
        title: 'Item Barcode',
        type: 'string',
      },
      ClientPrice: {
        title: 'Client Price',
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
