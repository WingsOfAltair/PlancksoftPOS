import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { NbDialogRef, NbDialogService, NbWindowRef } from '@nebular/theme';
import { PublisherService } from '../../../services/publisher.service';

@Component({
  selector: 'ngx-close-model-register',
  templateUrl: './close-model-register.component.html',
  styleUrls: ['./close-model-register.component.scss']
})
export class CloseModelRegisterComponent implements OnInit {

  AddData: FormGroup

  constructor(
    private fb: FormBuilder,
    private publisherService: PublisherService, 
    private windowRef: NbWindowRef

  ) { }

  ngOnInit(): void {

    this.AddData = this.fb.group({
      Amount:[]
    })

  }

  submit(){

    

    var obj = {
      cashierName:"admin",
      moneyInRegister: this.AddData.value.Amount
    }

    this.publisherService.PostRequest('SaveRegisterClose', obj).subscribe((res: any) => {
      console.log(JSON.parse(res));
      this.ngOnInit()
    });
    this.windowRef.close("");

  }

}
