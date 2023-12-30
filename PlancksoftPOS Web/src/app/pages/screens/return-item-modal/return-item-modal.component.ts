import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup } from "@angular/forms";
import { NbToastrService, NbWindowRef } from "@nebular/theme";
import { PublisherService } from "../../../services/publisher.service";

@Component({
  selector: "ngx-return-item-modal",
  templateUrl: "./return-item-modal.component.html",
  styleUrls: ["./return-item-modal.component.scss"],
})
export class ReturnItemModalComponent implements OnInit {
  AddData: FormGroup;

  constructor(
    private fb: FormBuilder,
    private publisherService: PublisherService,
    private toastrService: NbToastrService,
    public windowRef: NbWindowRef
  ) {}

  ngOnInit(): void {
    this.AddData = this.fb.group({
      ItemName: [],
      ItemBarCode: [],
      ItemQuantity: [],
    });
  }

  SubmitData() {
    if (this.AddData.valid) {

      var obj = {
        ItemName: this.AddData.value.ItemName,
        ItemBarCode: this.AddData.value.ItemBarCode,
        ItemQuantity: this.AddData.value.ItemQuantity,
        cashierName:"admin"
      };

      ;
      this.publisherService
        .PostRequest("ReturnItem", obj)
        .subscribe((res: any) => {
          console.log(JSON.parse(res));
        });
    } else {
      this.toastrService.danger("Try Again", "Error");
    }

    this.windowRef.close("");


  }

  UpdateData(){

  }
}
