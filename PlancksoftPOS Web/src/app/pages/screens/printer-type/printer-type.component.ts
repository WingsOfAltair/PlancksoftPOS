import { Component, OnInit } from '@angular/core';
import { PrinterTypeModalComponent } from '../printer-type-modal/printer-type-modal.component';
import { NbSortDirection, NbSortRequest, NbToastrService, NbTreeGridDataSource, NbTreeGridDataSourceBuilder, NbWindowService } from '@nebular/theme';
import { FormBuilder, FormGroup } from '@angular/forms';
import { PublisherService } from '../../../services/publisher.service';
import { SmartTableData } from '../../../@core/data/smart-table';

@Component({
  selector: 'ngx-printer-type',
  templateUrl: './printer-type.component.html',
  styleUrls: ['./printer-type.component.scss']
})
export class PrinterTypeComponent implements OnInit {

  data:any
  PrinterID:any
  Fildata:any

  Return:FormGroup
  
  defaultColumns = [
    "ItemName",
    "ItemBarcode",
    "Action",
  ];
  
  allColumns = [...this.defaultColumns];

  dataSource: NbTreeGridDataSource<any>;

  sortColumn: string;
  sortDirection: NbSortDirection = NbSortDirection.NONE;

 
  constructor(
    private service: SmartTableData,
    private fb: FormBuilder,
    private publisherService: PublisherService,
    private toastrService: NbToastrService,
    private dataSourceBuilder: NbTreeGridDataSourceBuilder<any>,
    private windowService: NbWindowService,

  ) { }

  ngOnInit(): void {

    this.Return = this.fb.group({
      itemName:[],
      itemBarcode:[],
      ItemAmount:[],

    })  

    var obj = {
      machineName: "machine"
    };

    this.publisherService
    .PostRequest("RetrievePrinters", obj)
    .subscribe((res: any) => {
      ;
      console.log(JSON.parse(res));

      var response = JSON.parse(res);
      var data = response.ResponseMessage;

      console.log(this.data);

      var list = []
      data.forEach((el) => {
        var obj = {
          data: {
            
            ID: el["ID"],
            Name: el["Name"],
          
          }
        }
        ;
        list.push(obj);
      });

      this.data = list;

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

  AddModal(){
    
    var dt = this.windowService.open(PrinterTypeModalComponent, {
      title: `Insert Printer Info`,
    });

    dt.componentInstance.modalClose.subscribe((res) => {
      this.ngOnInit() 

      if (this.PrinterID != null) {
        this.Filterdata(this.PrinterID);
      }
    });

    dt.onClose.subscribe((res) => { this.ngOnInit() })

  }

  
  delete(id){
    var obj = {
      printerID: this.PrinterID,
      itemTypeID: id
    }

    this.publisherService
    .PostRequest("DeletePrinterItemType", obj)
    .subscribe((res: any) => {
      this.ngOnInit()

      console.log(JSON.parse(res));

      console.log("filter data 1");
      
      this.Filterdata(this.PrinterID);
    });
  }

  Filterdata(id){
    console.log("filter data 2");

    this.PrinterID = id

    var obj = {
      printerID: id
    };

    this.publisherService
    .PostRequest("RetrievePrinterItemTypes", obj)
    .subscribe((res: any) => {
      ;
      console.log(JSON.parse(res));

      var response = JSON.parse(res);
      var data = response.ResponseMessage;

      console.log(this.data);

      var list = []
      data.forEach((el) => {
        var obj = {
          data: {
            
            ID: el["ID"],
            Name: el["Name"],
          
          }
        }
        ;
        list.push(obj);
      });

      this.Fildata = list;
      this.dataSource = this.dataSourceBuilder.create(this.Fildata);

      console.log(this.dataSource)

     });

  }


}
