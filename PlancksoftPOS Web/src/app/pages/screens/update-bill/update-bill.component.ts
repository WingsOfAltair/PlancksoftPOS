import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { NbToastrService, NbWindowRef } from '@nebular/theme';
import { PublisherService } from '../../../services/publisher.service';

@Component({
  selector: 'ngx-update-bill',
  templateUrl: './update-bill.component.html',
  styleUrls: ['./update-bill.component.scss']
})
export class UpdateBillComponent implements OnInit {

  data:any

  updatebill:FormGroup

  constructor(
    private fb: FormBuilder,
    public windowRef: NbWindowRef,
    private publisherService: PublisherService,
    private toastrService: NbToastrService,

  ) { }

  ngOnInit(): void {

    
    this.data = this.windowRef.config.context;

    this.updatebill = this.fb.group({
      RemainderAmount:[],
      totalAmount:[],
      PaidAmount:[],
    })

    this.updatebill.patchValue({
      RemainderAmount: this.data.RemainderAmount ,
      PaidAmount: this.data.paidAmount ,
      totalAmount: this.data.totalAmount ,
    })

  }

  UpdateData(){

    if (this.updatebill.valid) {
    var obj = {
      BillNumber: this.data.BillID,
      CashierName: this.data.CashierName,
      TotalAmount: this.updatebill.value.totalAmount,
      PaidAmount: this.updatebill.value.PaidAmount,
      RemainderAmount: this.updatebill.value.RemainderAmount,
    }

    this.publisherService.PostRequest("UpdateBill",obj).subscribe(res => {
      this.toastrService.success("", "Update bill");
    })
    this.ngOnInit()

  } else {
    this.toastrService.danger("Try Again", "Error");
  }

  this.windowRef.close("test");


  }

}
