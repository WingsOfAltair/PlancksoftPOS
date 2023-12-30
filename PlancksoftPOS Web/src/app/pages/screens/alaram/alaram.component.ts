import { Component, OnInit } from '@angular/core';
import { NbDateService, NbDialogService, NbSortDirection, NbSortRequest, NbToastrService, NbTreeGridDataSource, NbTreeGridDataSourceBuilder } from '@nebular/theme';
import { SmartTableData } from '../../../@core/data/smart-table';
import { LocalDataSource } from 'ng2-smart-table';
import { FormBuilder, FormGroup } from '@angular/forms';
import { PublisherService } from '../../../services/publisher.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'ngx-alaram',
  templateUrl: './alaram.component.html',
  styleUrls: ['./alaram.component.scss']
})
export class AlaramComponent implements OnInit {

  data:any

  currentDate: any;

  defaultColumns = [
    "ItemName",
    "ItemBarcode",  
    "CurrentQuantity",
    "ProductionDate",
    "ExpirationDate",
    "WarningLimit",
  ];

  allColumns = [...this.defaultColumns];

  dataSource: NbTreeGridDataSource<any>;

  sortColumn: string;
  sortDirection: NbSortDirection = NbSortDirection.NONE;

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
    private service: SmartTableData,
    private dialogService: NbDialogService,
    protected dateService: NbDateService<Date>,
    private fb: FormBuilder,
    private publisherService: PublisherService,
    private toastrService: NbToastrService,
    public datepipe: DatePipe,
    private dataSourceBuilder: NbTreeGridDataSourceBuilder<any>

  ) {
 
  }


  onDeleteConfirm(event): void {
    if (window.confirm('Are you sure you want to delete?')) {
      event.confirm.resolve();
    } else {
      event.confirm.reject();
    }
  }

  convertDateToJSONFormat(date) {
    ;
    var milliseconds = date.getTime();
    return "/Date(" + milliseconds + ")/";
  }

  ngOnInit(): void {

    this.currentDate = this.convertDateToJSONFormat(new Date());

    var obj = {
      Date: this.currentDate,
    };

    this.publisherService
    .PostRequest("RetrieveExpireStockToday", obj)
    .subscribe((res: any) => {
      ;
      console.log(JSON.parse(res));

      var responce = JSON.parse(res);
      var data = responce.ResponseMessage.Item1;

      var list = []
      data.forEach((el) => {
        const productionDate = parseInt(el["ProductionDate"].match(/-?\d+/)[0], 10);
        const formattedDate = new Date(productionDate).toLocaleDateString();
        const expirationDate = parseInt(el["ExpirationDate"].match(/-?\d+/)[0], 10);
        const ExpirationDate = new Date(expirationDate).toLocaleDateString();
        var obj = {
          data: {
            ItemName: el["ItemName"],
            ItemBarCode: el["ItemBarCode"],
            ExpirationDate: ExpirationDate,
            ProductionDate: formattedDate,
            QuantityWarning: el["ItemQuantity"],
            ItemQuantity: el["ItemQuantity"],
           
          }
        }
        ;
        list.push(obj);
      });

      this.data = list;
      this.dataSource = this.dataSourceBuilder.create(this.data);


      
      console.log(this.dataSource)
    });

  }

  

}
