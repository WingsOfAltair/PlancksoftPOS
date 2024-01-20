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
  message2: any;
  imageSrc: any;
  imageByteArray: any;

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
        
        var response = JSON.parse(res);
        this.message = JSON.parse(response.ResponseMessage.Item1);

        this.firstFormGroup.patchValue({
          Storename: this.message[0].SystemName,
          Phone: this.message[0].SystemPhone,
          Address: this.message[0].SystemAddress,
          SystemTax: this.message[0].SystemTax,
          BlankSpacesInRecipt: this.message[0].SystemReceiptBlankSpaces,
          IncludeLogo: this.message[0].SystemIncludeLogoInReceipt,
        });

        this.imageSrc = 'data:' + 'image/png' + ';base64,' + this.message[0].SystemLogo;
        this.imageByteArray = this.convertDataURIToBinary(this.imageSrc);
      });
  }

  byteArrayToDataUrl(byteArray, mimeType) {
    if (byteArray && byteArray.length > 0) {
        // Convert the byte array to a base64 string
        var base64String = btoa(String.fromCharCode.apply(null, byteArray));
        console.log("image data from server: " + base64String);
        // Build the Data URL
        return 'data:' + mimeType + ';base64,' + base64String;
    }
    return '';
}

  convertDataURIToBinary(dataURI) {
    var base64Index = dataURI.indexOf(';base64,') + ';base64,'.length;
    var base64 = dataURI.substring(base64Index);
    var raw = window.atob(base64);
    var rawLength = raw.length;
    var array = new Uint8Array(new ArrayBuffer(rawLength));
  
    for(var i = 0; i < rawLength; i++) {
      array[i] = raw.charCodeAt(i);
    }
    return array;
  }

  readUrl(event:any) {
    if (event.target.files && event.target.files[0]) {
      var reader = new FileReader();
  
      reader.readAsDataURL(event.target.files[0])

      reader.onload = (event: ProgressEvent) => {
        //this.imageSrc = (<FileReader>event.target).result;
        this.imageSrc = reader.result;
        console.log("imagesrc: " + this.imageSrc);

        this.imageByteArray = this.convertDataURIToBinary(this.imageSrc);
        console.log("image byte array: " + this.imageByteArray);
      }
    }
  }

  SubmitData() {
    if (this.firstFormGroup.valid) {
      var obj = {
        SystemName: this.firstFormGroup.value.Storename,
        SystemPhone: this.firstFormGroup.value.Phone,
        SystemAddress: this.firstFormGroup.value.Address,
        SystemReceiptBlankSpaces: this.firstFormGroup.value.BlankSpacesInRecipt,
        SystemIncludeLogoInReceipt:
          this.firstFormGroup.value.IncludeLogo == true ? 1 : 0,
        SystemTax: this.firstFormGroup.value.SystemTax,
        SystemLogo: Object.values(this.imageByteArray),
      };
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
