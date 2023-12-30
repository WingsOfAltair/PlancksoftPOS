import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup } from "@angular/forms";
import { PublisherService } from "../../../services/publisher.service";
import { NbToastrService } from "@nebular/theme";

@Component({
  selector: "ngx-setting",
  templateUrl: "./setting.component.html",
  styleUrls: ["./setting.component.scss"],
})
export class SettingComponent implements OnInit {
  firstFormGroup: FormGroup;
  message: any;

  constructor(
    private fb: FormBuilder,
    private publisherService: PublisherService,
    private toastrService: NbToastrService
  ) {}

  ngOnInit(): void {
    this.firstFormGroup = this.fb.group({
      Storename: [],
      Phone: [],
      Address: [],
      SystemTax: [],
      BlankSpacesInRecipt: [],
      IncludeLogo: [],
      Logo: [],
    });

    this.publisherService
      .PostRequest("RetrieveSystemSettings", "")
      .subscribe((res: any) => {
        console.log(JSON.parse(res));
         ;
        var responce = JSON.parse(res);
        this.message = JSON.parse(responce.ResponseMessage);

        this.firstFormGroup.patchValue({
          Storename: this.message[0].SystemName,
          Phone: this.message[0].SystemPhone,
          Address: this.message[0].SystemAddress,
          SystemTax: this.message[0].SystemTax,
          BlankSpacesInRecipt: this.message[0].SystemReceiptBlankSpaces,
          IncludeLogo: this.message[0].SystemIncludeLogoInReceipt,
          Logo: this.message[0].SystemLogo,
        });
      });
  }

  SubmitData() {
    if (this.firstFormGroup.valid) {
      const inputString = this.firstFormGroup.value.Logo;
      const textEncoder = new TextEncoder();
      const byteArray = textEncoder.encode(inputString);
      const byteArrayAsArray = Array.from(byteArray);

       ;
      var obj = {
        SystemName: this.firstFormGroup.value.Storename,
        SystemLogo: byteArrayAsArray,
        SystemPhone: this.firstFormGroup.value.Phone,
        SystemAddress: this.firstFormGroup.value.Address,
        SystemReceiptBlankSpaces: this.firstFormGroup.value.BlankSpacesInRecipt,
        SystemIncludeLogoInReceipt:
          this.firstFormGroup.value.IncludeLogo == true ? 1 : 0,
        SystemTax: this.firstFormGroup.value.SystemTax,
      };

       ;
      this.publisherService
        .PostRequest("UpdateSystemSettings", obj)
        .subscribe((res: any) => {
          console.log(JSON.parse(res));
        });
    } else {
      this.toastrService.danger("Try Again", "Error");
    }
  }
}
