import { Output, EventEmitter, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { PublisherService } from '../../../services/publisher.service';
import { NbToastrService, NbWindowRef } from '@nebular/theme';

@Component({
  selector: 'ngx-vendor-add-modal',
  templateUrl: './vendor-add-modal.component.html',
  styleUrls: ['./vendor-add-modal.component.scss']
})
export class VendorAddModalComponent implements OnInit {

  importer: FormGroup

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

    this.importer = this.fb.group({
      importername:[],
      phone:[],
      address:[],
      email:[],
    })

  }

  submit(){

    var obj = {
      ClientToInsert: {
        clientName: this.importer.value.importername,
        clientPhone: this.importer.value.phone,
        clientAddress: this.importer.value.address,
        clientEmail: this.importer.value.email,
        buyPrice: 0,
        sellPrice: 0, 
        sellPriceTax: 0,
        clientPrice: 0,
      },
    };

    this.publisherService
      .PostRequest("RegisterVendor", obj)
      .subscribe((res: any) => {
        console.log(JSON.parse(res));
        this.closeModal();
      });

  }

}
