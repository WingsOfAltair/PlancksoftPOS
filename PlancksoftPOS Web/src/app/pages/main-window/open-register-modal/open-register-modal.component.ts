import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { PublisherService } from '../../../services/publisher.service';
import { NbWindowRef } from '@nebular/theme';

@Component({
  selector: 'ngx-open-register-modal',
  templateUrl: './open-register-modal.component.html',
  styleUrls: ['./open-register-modal.component.scss']
})
export class OpenRegisterModalComponent implements OnInit {

  AddData: FormGroup
  message: any;
  cashierName: any;

  constructor(
    private fb: FormBuilder,
    private publisherService: PublisherService, 
    private windowRef: NbWindowRef

  ) { }

  ngOnInit(): void {

    this.publisherService
      .PostRequest("RetrieveUsers", "")
      .subscribe((res: any) => {
        var responce = JSON.parse(res);
        this.message = responce.ResponseMessage.Item1;
        this.cashierName = this.message[0].name;
      });

    this.AddData = this.fb.group({
      Amount:[]
    })

  }

  submit(){

    

    var obj = {
      cashierName:this.cashierName,
      moneyInRegister: this.AddData.value.Amount
    }

    this.publisherService.PostRequest('SaveRegisterOpen', obj).subscribe((res: any) => {
      console.log(JSON.parse(res));
      this.ngOnInit()
    });

    this.windowRef.close("");


  }

}
