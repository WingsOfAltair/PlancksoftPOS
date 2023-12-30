import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup } from "@angular/forms";
import { NbToastrService, NbWindowRef, NbWindowService } from "@nebular/theme";
import { PublisherService } from "../../../services/publisher.service";
import { AddSellItemComponent } from "../add-sell-item/add-sell-item.component";
import { Router } from "@angular/router";

@Component({
  selector: "ngx-add-bill-item-modal",
  templateUrl: "./add-bill-item-modal.component.html",
  styleUrls: ["./add-bill-item-modal.component.scss"],
})
export class AddBillItemModalComponent implements OnInit {

  AdditemData: FormGroup;
  filterdata: any;
  data: any;
  list:any
  updateList:any

  constructor(
    private fb: FormBuilder,
    private publisherService: PublisherService,
    private toastrService: NbToastrService,
    private windowService: NbWindowService,
    public windowRef: NbWindowRef,
    private router: Router

  ) {}

  ngOnInit(): void {
    

    this.updateList = this.windowRef.config.context;

   

    this.AdditemData = this.fb.group({
      Itemname: [],
      ItemQuantity: [],
    });

    this.AdditemData.patchValue({
      Itemname: this.updateList.ItemName,
      ItemQuantity: this.updateList.ItemQuantity
    })

    var obj = {
      locale: 1,
    };

    this.publisherService
      .PostRequest("RetrieveItems", obj)
      .subscribe((res: any) => {
        ;
        console.log(JSON.parse(res));

        var responce = JSON.parse(res);
        var data = responce.ResponseMessage.Item1;

        this.filterdata = data;

        var list = [];
        data.forEach((el) => {
          var obj = {
            data: {
              ItemID: el["ItemID"],
              ItemName: el["ItemName"],
              ItemQuantity: el["ItemQuantity"],
              ItemBuyPrice: el["ItemBuyPrice"],
              ItemPrice: el["ItemPrice"],
              ItemPriceTax: el["ItemPriceTax"],
              favoriteCategoryName: el["favoriteCategoryName"],
              warehouseName: el["warehouseName"],
              ItemTypeName: el["ItemTypeName"],
              ItemBarCode: el["ItemBarCode"],
            },
          };
          list.push(obj);
        });

        this.data = list;


        console.log(this.data);
      });
  }

  AddData() {
    var obj = {
      ItemName :  this.list.ItemName,
      ItemBarCode: this.AdditemData.value.Itemname ,
      ItemQuantity: this.AdditemData.value.ItemQuantity
    }

    // this.publisherService.data = obj;
    this.windowRef.close(obj);
  }

  onSelectChange(event){

    

    var selected = this.data.filter(a => a.data.ItemBarCode == event)[0]

    var obj ={
      ItemName : selected.data.ItemName,
      ItemBarcode: selected.data.ItemBarCode,
      ItemQuantity: this.AdditemData.value.ItemQuantity      
    }

    this.list = obj

    console.log(obj)

  }

  UpdateData(){
    
    this.updateList

    if(this.updateList.ItemName == null)
    this.updateList.ItemName = this.list.ItemName
    
    if(this.AdditemData.value.Itemname == '')
    this.AdditemData.value.Itemname = this.updateList.ItemBarcode
    
    if(this.AdditemData.value.ItemQuantity == '')
    this.AdditemData.value.ItemQuantity = this.updateList.ItemQuantity
    

    var obj = {
      ItemName :  this.updateList.ItemName,
      ItemBarCode: this.AdditemData.value.Itemname ,
      ItemQuantity: this.AdditemData.value.ItemQuantity
    }

    // this.publisherService.data = obj;
    this.windowRef.close(obj);
  }
}
