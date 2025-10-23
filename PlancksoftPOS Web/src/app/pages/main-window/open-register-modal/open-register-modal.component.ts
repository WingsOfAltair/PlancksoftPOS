import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { PublisherService } from '../../../services/publisher.service';
import { NbToastrService } from '@nebular/theme';
import { NbWindowRef } from '@nebular/theme';
import { MenuService } from "../../../services/menu.service";

@Component({
  selector: 'ngx-open-register-modal',
  templateUrl: './open-register-modal.component.html',
  styleUrls: ['./open-register-modal.component.scss']
})
export class OpenRegisterModalComponent implements OnInit {

  AddData: FormGroup
  message: any;
  cashierName: any;
  moneyInRegister: any;

  constructor(
    private fb: FormBuilder,
    private publisherService: PublisherService, 
    private windowRef: NbWindowRef,
    public mainMenuService: MenuService,
    private toastrService: NbToastrService

  ) { }

  ngOnInit(): void {

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

    var obj = {
      cashierName:this.cashierName,
      cashName:localStorage.getItem("CashName"),
      moneyInRegister: this.AddData.value.Amount
    }

    this.publisherService.PostRequest('SaveRegisterOpen', obj).subscribe((res: any) => {
      console.log(JSON.parse(res));
      localStorage.setItem('moneyInRegister', this.AddData.value.Amount);
      localStorage.setItem('registerOn', JSON.stringify(true));
      this.mainMenuService.loadMenus();
      this.toastrService.success("Cash Register is open.");
      this.windowRef.close("");
    });
  }
}
