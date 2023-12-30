import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup } from "@angular/forms";
import { NbToastrService, NbWindowRef } from "@nebular/theme";
import { PublisherService } from "../../../services/publisher.service";

@Component({
  selector: "ngx-printer-type-modal",
  templateUrl: "./printer-type-modal.component.html",
  styleUrls: ["./printer-type-modal.component.scss"],
})
export class PrinterTypeModalComponent implements OnInit {
  AddData: FormGroup;

  Type: any;
  data: any;

  constructor(
    private fb: FormBuilder,
    private publisherService: PublisherService,
    private toastrService: NbToastrService,
    public windowRef: NbWindowRef
  ) {}

  ngOnInit(): void {
    this.AddData = this.fb.group({
      ItemType: [],
      Printer: [],
    });

    var obj = {
      machineName: "machine",
    };

    this.publisherService
      .PostRequest("RetrievePrinters", obj)
      .subscribe((res: any) => {
        console.log(JSON.parse(res));

        var responce = JSON.parse(res);
        var data = responce.ResponseMessage;

        console.log(this.data);

        var list = [];
        data.forEach((el) => {
          var obj = {
            data: {
              ID: el["ID"],
              Name: el["Name"],
            },
          };
          list.push(obj);
        });

        this.data = list;
      });

    this.publisherService
      .PostRequest("RetrieveItemTypes", obj)
      .subscribe((res: any) => {
        console.log(JSON.parse(res));

        var responce = JSON.parse(res);
        var data = responce.ResponseMessage;

        console.log(this.data);

        var list = [];
        data.forEach((el) => {
          var obj = {
            data: {
              ID: el["ID"],
              Name: el["Name"],
            },
          };
          list.push(obj);
        });

        this.Type = list;
      });
  }

  SubmitData() {
    if (this.AddData.valid) {
      var obj = {
        printerID: parseInt(this.AddData.value.Printer),
        itemTypeID: parseInt(this.AddData.value.ItemType),
      };

      this.publisherService
        .PostRequest("AddPrinterItemType", obj)
        .subscribe((res: any) => {
          console.log(JSON.parse(res));
        });
    } else {
      this.toastrService.danger("Try Again", "Error");
    }

    this.windowRef.close("");
  }

  UpdateData() {}
}
