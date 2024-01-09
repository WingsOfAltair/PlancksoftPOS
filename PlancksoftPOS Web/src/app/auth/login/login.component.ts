import { ChangeDetectorRef, Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { NbAuthService, NbAuthSocialLink } from "@nebular/auth";
import { AuthServiceService } from "../../services/auth-service.service";
import { PublisherService } from "../../services/publisher.service";
import { NbToastrService } from "@nebular/theme";
import * as CryptoJS from "crypto-js";

@Component({
  selector: "ngx-login",
  templateUrl: "./login.component.html",
})
export class NgxLoginComponent implements OnInit {
  message: any;
  encryptedPassword: any;
  key = "U2FsdGVkX18qrZfUPtXANaF3XhX1/kvMObEFKWK4Xa8=";

  protected options: {};
  protected cd: ChangeDetectorRef;
  protected router: Router;
  redirectDelay: number;
  showMessages: any;
  strategy: string;
  errors: string[];
  messages: string[];
  user: any;
  submitted: boolean;
  socialLinks: NbAuthSocialLink[];
  rememberMe: boolean;
  constructor(
    service: NbAuthService,
    public authService: AuthServiceService,
    public route: Router,
    private formBuilder: FormBuilder,
    private publisherService: PublisherService,
    private toastrService: NbToastrService
  ) {}

  getConfigValue(key: string) {}
  // static ɵfac: ɵɵFactoryDeclaration<NgxLoginComponent, never>;
  // static ɵcmp: i0.ɵɵComponentDeclaration<NgxLoginComponent, "nb-login", never, {}, {}, never, never, false>;

  firstFormGroup: FormGroup;

  ngOnInit() {
    this.firstFormGroup = this.formBuilder.group({
      UserName: ["", [Validators.required]],
      Password: ["", [Validators.required]],
    });

    this.publisherService
      .PostRequest("RetrieveUsers", "")
      .subscribe((res: any) => {
        var response = JSON.parse(res);
        this.message = response.ResponseMessage.Item1;

        if (this.message.length <= 0) this.route.navigate(["/auth/register"]);
      });
  }

  encryptPassword(password: string) {
    const Password = password;
    this.encryptedPassword = btoa(Password + this.key);
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
    ;
    if (this.firstFormGroup.valid) {
      console.log(this.firstFormGroup.value);
      ;

      // this.encryptPassword(this.firstFormGroup.value.Password);

      this.encryptedPassword = this.encryptTripleDES(
        this.encryptTripleDES(
          this.firstFormGroup.value.Password,
          "PlancksoftPOS"
        ),
        "PlancksoftPOS"
      );

      var obj = {
        AccountToLogin: {
          uid: this.firstFormGroup.value.UserName,
          pwd: this.encryptedPassword,
        },
      };

      ;
      this.publisherService.PostRequest("Login", obj).subscribe((res: any) => {
        var response = JSON.parse(res);
        this.message = response.ResponseMessage;

        console.log(this.message);
        var dt = {
          uid: this.firstFormGroup.value.UserName,
          response: this.message,
        };
        sessionStorage.setItem("userData", JSON.stringify(dt));

        if (this.message.Item1 == true) {
          this.route.navigate(["/pages/iot-dashboard"]);
        } else {
          this.toastrService.danger("Try Again", "Login Field");
        }
      });
    } else {
    }
  }
}
