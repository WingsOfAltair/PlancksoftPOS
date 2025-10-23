import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { NbDialogRef, NbDialogService, NbWindowRef } from '@nebular/theme';
import { NbToastrService } from '@nebular/theme';
import { PublisherService } from '../../../services/publisher.service';
import { MenuService } from "../../../services/menu.service";

@Component({
  selector: 'ngx-close-model-register',
  templateUrl: './close-model-register.component.html',
  styleUrls: ['./close-model-register.component.scss']
})
export class CloseModelRegisterComponent implements OnInit {

  AddData: FormGroup
  moneyInRegister: any;

  message: any;
  cashierName: any;

  constructor(
    private fb: FormBuilder,
    private publisherService: PublisherService, 
    private windowRef: NbWindowRef,
    public mainMenuService: MenuService,
    private toastrService: NbToastrService

  ) { }

  ngOnInit(): void {

    this.AddData = this.fb.group({
      Amount:[]
    })

    this.publisherService
      .PostRequest("RetrieveUsers", "")
      .subscribe((res: any) => {
        var response = JSON.parse(res);
        this.message = response.ResponseMessage.Item1;
        this.cashierName = this.message[0].name;
      });

    this.AddData = this.fb.group({
      Amount:[]
    })

  }

  submit(){
    this.moneyInRegister = parseFloat(localStorage.getItem('moneyInRegister')) || 0;

    if (parseFloat(this.AddData.value.Amount) < this.moneyInRegister) {
      this.toastrService.warning("There should be more money in the cash register.")
      return;
    } else {
      var obj = {
        cashierName:this.cashierName,
        cashName:localStorage.getItem("CashName"),
        moneyInRegister: this.AddData.value.Amount
      }

      this.publisherService.PostRequest('SaveRegisterClose', obj).subscribe((res: any) => {
        console.log(JSON.parse(res));
        localStorage.setItem('moneyInRegister', "0");
        localStorage.setItem('registerOn', JSON.stringify(false));
        this.mainMenuService.loadMenus();
        this.toastrService.success("Cash Register is closed.");
        this.windowRef.close("");
      });
      
    }
  }
}
