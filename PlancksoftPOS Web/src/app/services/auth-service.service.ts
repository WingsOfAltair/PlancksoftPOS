import { Injectable } from '@angular/core';
import { environment } from "../../environments/environment"
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthServiceService {

  environment = environment
  FullPath = environment.ApiUrl;
  constructor(
    private httpclient: HttpClient,
  ) {
    console.log("Current API URL:", this.environment.ApiUrl);
  }

  checkauthService() {
    return this.environment.ApiUrl;
  }

  login(Obj) {
    return this.httpclient.post('http://localhost:5000/api/Publisher/publish', Obj);
   
  }

  // Change this to your file location

}
