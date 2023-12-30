import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { NbToastrService, NbWindowRef } from "@nebular/theme";
import { PublisherService } from "../../../services/publisher.service";
import * as CryptoJS from "crypto-js";

@Component({
  selector: "ngx-user-modal",
  templateUrl: "./user-modal.component.html",
  styleUrls: ["./user-modal.component.scss"],
})
export class UserModalComponent implements OnInit {
  firstFormGroup: FormGroup;

  data: any;
  password: any;
  message: any;
  updatedata: any[];
  Client_card_edit: any;
  discount_edit: any;
  expenses_add: any;
  inventory_edit: any;
  openclose_edit: any;
  personnel_edit: any;
  price_edit: any;
  receipt_edit: any;
  sell_edit: any;
  settings_edit: any;
  users_edit: any;
  admin: boolean;
  Userdata: any;
  userID: any;
  encryptedPassword: any;

  constructor(
    private fb: FormBuilder,
    private publisherService: PublisherService,
    private toastrService: NbToastrService,
    public windowRef: NbWindowRef
  ) {
    var user = sessionStorage.getItem("userData");
    this.Userdata = JSON.parse(user);
    this.userID = this.Userdata.uid;
  }

  ngOnInit(): void {
     ;
    this.data = this.windowRef.config.context;

    if (this.data.Authority) {
      this.admin = true;
    } else {
      this.admin = false;
    }

    this.firstFormGroup = this.fb.group({
      AdminAccountID: ["", [Validators.required]],
      Password: ["", [Validators.required]],
      UserName: ["", [Validators.required]],
      Client_card_edit: [""],
      discount_edit: [""],
      price_edit: [""],
      receipt_edit: [""],
      inventory_edit: [""],
      expenses_add: [""],
      settings_edit: [""],
      personnel_edit: [""],
      openclose_edit: [""],
      sell_edit: [""],
      admin: [""],
      users_edit: [""],
    });

    if (this.data.Uid) {
      var objj = {
        UserID: this.data.Uid,
      };

      this.publisherService
        .PostRequest("RetrieveUserPermissions", objj)
        .subscribe((res: any) => {
          console.log(JSON.parse(res));

          var responce = JSON.parse(res);
          this.message = responce.ResponseMessage;
           ;
          this.Client_card_edit = this.message.Client_card_edit;
          this.discount_edit = this.message.discount_edit;
          this.expenses_add = this.message.expenses_add;
          this.inventory_edit = this.message.inventory_edit;
          this.openclose_edit = this.message.openclose_edit;
          this.personnel_edit = this.message.personnel_edit;
          this.price_edit = this.message.price_edit;
          this.receipt_edit = this.message.receipt_edit;
          this.sell_edit = this.message.sell_edit;
          this.settings_edit = this.message.settings_edit;
          this.users_edit = this.message.users_edit;
        });

      // this.password = this.data.Password

      this.firstFormGroup.patchValue({
        AdminAccountID: this.data.Uid,
        // Password: this.data.Password,
        UserName: this.data.UserName,
      });
    }
  }

  SubmitData() {
    if (this.firstFormGroup.value.Client_card_edit == "")
      this.firstFormGroup.value.Client_card_edit = false;

    if (this.firstFormGroup.value.discount_edit == "")
      this.firstFormGroup.value.discount_edit = false;

    if (this.firstFormGroup.value.price_edit == "")
      this.firstFormGroup.value.price_edit = false;

    if (this.firstFormGroup.value.receipt_edit == "")
      this.firstFormGroup.value.receipt_edit = false;

    if (this.firstFormGroup.value.inventory_edit == "")
      this.firstFormGroup.value.inventory_edit = false;

    if (this.firstFormGroup.value.expenses_add == "")
      this.firstFormGroup.value.expenses_add = false;

    if (this.firstFormGroup.value.users_edit == "")
      this.firstFormGroup.value.users_edit = false;

    if (this.firstFormGroup.value.settings_edit == "")
      this.firstFormGroup.value.settings_edit = false;

    if (this.firstFormGroup.value.personnel_edit == "")
      this.firstFormGroup.value.personnel_edit = false;

    if (this.firstFormGroup.value.openclose_edit == "")
      this.firstFormGroup.value.openclose_edit = false;

    if (this.firstFormGroup.value.sell_edit == "")
      this.firstFormGroup.value.sell_edit = false;

    if (this.firstFormGroup.value.admin == "") {
      this.firstFormGroup.value.admin = 0;
    } else {
      this.firstFormGroup.value.admin = 1;
    }

    this.encryptedPassword = this.encryptTripleDES(
      this.encryptTripleDES(
        this.firstFormGroup.value.Password,
        "PlancksoftPOS"
      ),
      "PlancksoftPOS"
    );

    if (this.firstFormGroup.valid) {
      console.log(this.firstFormGroup.value);
      var obj = {
        AccountToRegister: {
          Uid: this.firstFormGroup.value.AdminAccountID,
          Pwd: this.encryptedPassword,
          Name: this.firstFormGroup.value.UserName,
          Client_card_edit: this.firstFormGroup.value.Client_card_edit,
          discount_edit: this.firstFormGroup.value.discount_edit,
          price_edit: this.firstFormGroup.value.price_edit,
          receipt_edit: this.firstFormGroup.value.receipt_edit,
          inventory_edit: this.firstFormGroup.value.inventory_edit,
          expenses_add: this.firstFormGroup.value.expenses_add,
          users_edit: this.firstFormGroup.value.users_edit,
          settings_edit: this.firstFormGroup.value.settings_edit,
          personnel_edit: this.firstFormGroup.value.personnel_edit,
          openclose_edit: this.firstFormGroup.value.openclose_edit,
          sell_edit: this.firstFormGroup.value.sell_edit,
          Authority: this.firstFormGroup.value.admin == true ? 1 : 0,
        },
        UID: this.userID,
        AdminOrNot: this.firstFormGroup.value.admin == true ? 1 : 0,
      };
       ;
      this.publisherService
        .PostRequest("Register", obj)
        .subscribe((res: any) => {
          console.log(JSON.parse(res));
          this.windowRef.close("");
        });
    } else {
      this.toastrService.danger("Try Again", "Error");
    }
  }

  encryptTripleDES(text, key) {
    // Convert the key to MD5 hash
    const md5Key = CryptoJS.MD5(key).toString(CryptoJS.enc.Hex);

    // Convert the text to a WordArray
    const textData = CryptoJS.enc.Utf8.parse(text);

    // Create a 3DES encryption object with the MD5 key
    const encrypted = CryptoJS.TripleDES.encrypt(
      textData,
      CryptoJS.enc.Hex.parse(md5Key),
      {
        mode: CryptoJS.mode.ECB,
        padding: CryptoJS.pad.Pkcs7,
      }
    );

    // Convert the ciphertext to a Base64 string
    const ciphertext = encrypted.toString();

    return ciphertext;
  }

  updateData() {
    
    if(this.firstFormGroup.value.Password != null){
      this.encryptedPassword = this.encryptTripleDES(
        this.encryptTripleDES(
          this.firstFormGroup.value.Password,
          "PlancksoftPOS"
        ),
        "PlancksoftPOS"
      );
    }

    var obj = {
      UserToUpdate: {
        Uid: this.firstFormGroup.value.AdminAccountID,
        Pwd: this.encryptedPassword
          ? this.encryptedPassword
          : this.firstFormGroup.value.Password,
        Name: this.firstFormGroup.value.UserName,
        Client_card_edit: this.firstFormGroup.value.Client_card_edit,
        discount_edit: this.firstFormGroup.value.discount_edit,
        price_edit: this.firstFormGroup.value.price_edit,
        receipt_edit: this.firstFormGroup.value.receipt_edit,
        inventory_edit: this.firstFormGroup.value.inventory_edit,
        expenses_add: this.firstFormGroup.value.expenses_add,
        users_edit: this.firstFormGroup.value.users_edit,
        settings_edit: this.firstFormGroup.value.settings_edit,
        personnel_edit: this.firstFormGroup.value.personnel_edit,
        openclose_edit: this.firstFormGroup.value.openclose_edit,
        sell_edit: this.firstFormGroup.value.sell_edit,
        Authority: this.firstFormGroup.value.admin == true ? 1 : 0,
      },
      cashierName: this.userID,
      AdminOrNot: this.firstFormGroup.value.admin == true ? 1 : 0,
    };
     ;
    this.publisherService
      .PostRequest("UpdateUser", obj)
      .subscribe((res: any) => {
        console.log(JSON.parse(res));
      });

    this.windowRef.close("");
  }
}
