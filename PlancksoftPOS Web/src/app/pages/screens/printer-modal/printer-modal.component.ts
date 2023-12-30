import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { PublisherService } from '../../../services/publisher.service';
import { NbToastrService, NbWindowRef } from '@nebular/theme';

@Component({
  selector: 'ngx-printer-modal',
  templateUrl: './printer-modal.component.html',
  styleUrls: ['./printer-modal.component.scss']
})
export class PrinterModalComponent implements OnInit {

  AddData: FormGroup
  data:any

  constructor(
    private fb: FormBuilder,
    private publisherService: PublisherService,
    private toastrService: NbToastrService,
    public windowRef: NbWindowRef
  ) { }

  ngOnInit(): void {

    
    
    this.data = this.windowRef.config.context;

    this.AddData = this.fb.group({
      PrinterName:[],
    })

    if(this.data.Id > 0){

      this.AddData.patchValue({
        PrinterName: this.data.PrinterName
      })

    }

  }

  SubmitData(){

    if (this.AddData.valid) {

      var obj = {
        machineName: "machine",
        printerName: this.AddData.value.PrinterName,
      };

      
      this.publisherService
        .PostRequest("InsertPrinter", obj)
        .subscribe((res: any) => {

          console.log(JSON.parse(res));
          this.windowRef.close("res");
        });
        
    } else {
      this.toastrService.danger("Try Again", "Error");
    }
   


  }

  UpdateData(){

    if (this.AddData.valid) {

      var obj = {
        printerID: this.data.Id,
        printerName: this.AddData.value.PrinterName,
      };

      this.publisherService
        .PostRequest("UpdatePrinters", obj)
        .subscribe((res: any) => {
          console.log(JSON.parse(res));
          this.windowRef.close("res");
        });
    } else {
      this.toastrService.danger("Try Again", "Error");
    }

    
  }

}
