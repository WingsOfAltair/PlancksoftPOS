import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup } from "@angular/forms";
import { NbToastrService, NbWindowRef } from "@nebular/theme";
import { PublisherService } from "../../../services/publisher.service";

@Component({
  selector: "ngx-client-add-modal",
  templateUrl: "./client-add-modal.component.html",
  styleUrls: ["./client-add-modal.component.scss"],
})
export class ClientAddModalComponent implements OnInit {
  client: FormGroup;

  constructor(
    private fb: FormBuilder,
    private publisherService: PublisherService,
    private toastrService: NbToastrService,
    public windowRef: NbWindowRef

  ) {}

  ngOnInit(): void {
    this.client = this.fb.group({
      clientname: [],
      clientphone: [],
      clientaddress: [],
      clientemail: [],
    });
  }

  submit() {

    

    var obj = {
      ClientToInsert: {
        clientName: this.client.value.clientname,
        clientPhone: this.client.value.clientphone,
        clientAddress: this.client.value.clientaddress,
        clientEmail: this.client.value.clientemail,
        buyPrice: 0,
        sellPrice: 0,
        sellPriceTax: 0,
        clientPrice: 0,
      },
    };

    this.publisherService
      .PostRequest("RegisterClient", obj)
      .subscribe((res: any) => {
        console.log(JSON.parse(res));
        this.windowRef.close("res");
      });

    

  }
}
