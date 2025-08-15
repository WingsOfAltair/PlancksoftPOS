import { Component, OnInit, Output, EventEmitter } from "@angular/core";
import { FormBuilder, FormGroup } from "@angular/forms";
import { NbToastrService, NbWindowRef } from "@nebular/theme";
import { PublisherService } from "../../../services/publisher.service";

@Component({
  selector: "ngx-vendor-add-modal",
  templateUrl: "./vendor-add-modal.component.html",
  styleUrls: ["./vendor-add-modal.component.scss"],
})
export class VendorAddModalComponent implements OnInit {
  vendor: FormGroup;
  updateList:any
  data: any;
  VendorID: any;

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

    this.vendor = this.fb.group({
      clientname: [],
      clientphone: [],
      clientaddress: [],
      clientemail: [],
    });

    this.VendorID = 0;
    if (this.data.ClientID)
    {
      this.VendorID = this.data.ClientID ? Number(this.data.ClientID) : 0;
    }

    this.vendor.patchValue({
      clientname: this.data.ClientName,
      clientphone: this.data.ClientPhone,
      clientaddress: this.data.ClientAddress,
      clientemail: this.data.ClientEmail,
    })
  }

    submit() {
    var obj = {
      ClientToInsert: {
        clientName: this.vendor.value.clientname,
        clientPhone: this.vendor.value.clientphone,
        clientAddress: this.vendor.value.clientaddress,
        clientEmail: this.vendor.value.clientemail,
      }
    }

    this.publisherService
      .PostRequest("RegisterVendor", obj)
      .subscribe((res: any) => {
        console.log(JSON.parse(res));
            this.closeModal();
      });
  }

  UpdateData(){
    
    var obj = {
      ClientToUpdate: {
        clientID: this.VendorID,
        clientName: this.vendor.value.clientname,
        clientPhone: this.vendor.value.clientphone,
        clientAddress: this.vendor.value.clientaddress,
        clientEmail: this.vendor.value.clientemail,
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