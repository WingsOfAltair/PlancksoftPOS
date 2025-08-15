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
  data: any;
  ClientID: any;

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
    this.data = this.windowRef.config.context;

    this.client = this.fb.group({
      clientname: [],
      clientphone: [],
      clientaddress: [],
      clientemail: [],
    });

    this.ClientID = this.data.ClientID;

    this.client.patchValue({
      clientname: this.data.ClientName,
      clientphone: this.data.ClientPhone,
      clientaddress: this.data.ClientAddress,
      clientemail: this.data.ClientEmail,
    })
  }

  UpdateData(){
    
    var obj = {
      ClientToUpdate: {
        clientID: this.ClientID,
        clientName: this.client.value.clientname,
        clientPhone: this.client.value.clientphone,
        clientAddress: this.client.value.clientaddress,
        clientEmail: this.client.value.clientemail,
      },
    };

    this.publisherService
      .PostRequest("UpdateClientVendor", obj)
      .subscribe((res: any) => {
        console.log(JSON.parse(res));
            this.closeModal();
      });

    this.windowRef.close();
  }
}