import { Component, OnInit, Output, EventEmitter } from "@angular/core";
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
  updateList:any

  constructor(
    private fb: FormBuilder,
    private publisherService: PublisherService,
    private toastrService: NbToastrService,
    public windowRef: NbWindowRef

  ) {}

    @Output() modalClose = new EventEmitter();

  closeModal() {
    this.modalClose.emit(); // Emit custom event
    this.windowRef.close("");
}

  ngOnInit(): void {
    this.updateList = this.windowRef.config.context;

    this.client = this.fb.group({
      clientname: [],
      clientphone: [],
      clientaddress: [],
      clientemail: [],
    });

    this.client.patchValue({
      clientname: this.updateList.ClientName,
      clientphone: this.updateList.ClientPhone,
      clientaddress: this.updateList.ClientAddress,
      clientemail: this.updateList.ClientEmail,
    })
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

  /*UpdateData(){
    
    this.updateList

    var obj = {
      ItemName :  this.client.ClientName,
      ItemBarCode: this.client.value.ClientAddress,
      ItemQuantity: this.client.value.ClientPhone,
      : this.client.value.ClientEmail,
    }

    // this.publisherService.data = obj;
    this.windowRef.close(obj);
  }
*/
}