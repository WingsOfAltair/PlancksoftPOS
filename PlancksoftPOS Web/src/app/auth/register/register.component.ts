import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { PublisherService } from "../../services/publisher.service";
import { Router } from "@angular/router";
import * as CryptoJS from "crypto-js";

@Component({
  selector: "ngx-register",
  templateUrl: "./register.component.html",
  styleUrls: ["./register.component.scss"],
})
export class RegisterComponent implements OnInit {
  firstFormGroup: FormGroup;
  encryptedPassword: any;
  key = "U2FsdGVkX18qrZfUPtXANaF3XhX1/kvMObEFKWK4Xa8=";
  message: any;

  constructor(
    private fb: FormBuilder,
    private publisherService: PublisherService,
    public route: Router
  ) {}

  ngOnInit(): void {
    this.firstFormGroup = this.fb.group({
      AdminAccountID: ["", [Validators.required]],
      Password: ["", [Validators.required]],
      UserName: ["", [Validators.required]],
    });

    this.publisherService
      .PostRequest("RetrieveUsers", "")
      .subscribe((res: any) => {
        var responce = JSON.parse(res);
        this.message = responce.ResponseMessage.Item1;

        if (this.message.length > 0) this.route.navigate(["/auth/login"]);
      });

    this.firstFormGroup.patchValue({
      AdminAccountID: "admin",
    });
  }

  showPassword = false;

  getInputType() {
    if (this.showPassword) {
      return "text";
    }
    return "password";
  }

  toggleShowPassword() {
    this.showPassword = !this.showPassword;
  }

  Submit() {
    if (this.firstFormGroup.valid) {
      // this.encryptPassword(this.firstFormGroup.value.Password)

      this.encryptedPassword = this.encryptTripleDES(
        this.encryptTripleDES(
          this.firstFormGroup.value.Password,
          "PlancksoftPOS"
        ),
        "PlancksoftPOS"
      );

      console.log(this.firstFormGroup.value);
      var obj = {
        AccountToRegister: {
          uid: this.firstFormGroup.value.AdminAccountID,
          Pwd: this.encryptedPassword,
          Name: this.firstFormGroup.value.UserName,
          Client_card_edit: true,
          discount_edit: true,
          price_edit: true,
          receipt_edit: true,
          inventory_edit: true,
          expenses_add: true,
          users_edit: true,
          settings_edit: true,
          personnel_edit: true,
          openclose_edit: true,
          sell_edit: true,
          authority: 1,
        },
        // UID: "admin",
        // AdminOrNot: "1",
      };

      ;
      this.publisherService
        .PostRequest("RegisterAdmin", obj)
        .subscribe((res: any) => {
          console.log(JSON.parse(res));

          this.route.navigate(["/auth/login"]);
        });
    } else {
      alert("Error");
    }
  }

  // encryptPassword(password: string) {

  //   const Password = password;
  //   this.encryptedPassword = btoa(Password + this.key)

  // }

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

  decryptTripleDES(encryptedText, key) {
    // Convert the key to MD5 hash
    const md5Key = CryptoJS.MD5(key).toString(CryptoJS.enc.Hex);

    // Convert the encrypted text from Base64 to a WordArray
    const ciphertext = CryptoJS.enc.Base64.parse(encryptedText);

    // Create a 3DES decryption object with the MD5 key
    const decrypted = CryptoJS.TripleDES.decrypt(
      {
        ciphertext: ciphertext,
      },
      CryptoJS.enc.Hex.parse(md5Key),
      {
        mode: CryptoJS.mode.ECB,
        padding: CryptoJS.pad.Pkcs7,
      }
    );

    // Convert the decrypted data to a Utf8 string
    const decryptedText = decrypted.toString(CryptoJS.enc.Utf8);

    return decryptedText;
  }
}
