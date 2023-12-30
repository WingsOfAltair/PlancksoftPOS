import { Component, OnInit } from "@angular/core";
import { NbToastrService, NbWindowRef } from "@nebular/theme";
import { PublisherService } from "../../../services/publisher.service";
import { FormBuilder, FormGroup } from "@angular/forms";

@Component({
  selector: "ngx-update-quantity",
  templateUrl: "./update-quantity.component.html",
  styleUrls: ["./update-quantity.component.scss"],
})
export class UpdateQuantityComponent implements OnInit {
  data: any;

  firstFormGroup: FormGroup;

  constructor(
    private fb: FormBuilder,
    private publisherService: PublisherService,
    private toastrService: NbToastrService,
    private windowRef: NbWindowRef
  ) {}

  ngOnInit(): void {
    this.data = this.windowRef.config.context;
    

    this.firstFormGroup = this.fb.group({
      quantity: [],
    });

    this.firstFormGroup.patchValue({
      quantity: this.data.ItemQuantity,
    });
  }

  submit() {
    var obj = {
      ItemQuantity: this.firstFormGroup.value.quantity,
      ItemBarCode: this.data.ItemBarCode,
    };

    this.windowRef.close(obj);
  }

  convertDateToJSONFormat(date) {
    var milliseconds = date.getTime();
    return "/Date(" + milliseconds + ")/";
  }
}
