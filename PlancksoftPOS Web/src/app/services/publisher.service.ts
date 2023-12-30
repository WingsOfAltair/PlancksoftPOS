import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PublisherService {

  environment = environment
  FullPath = environment.ApiUrl;

  constructor(
    private httpclient: HttpClient,
  ) {
    console.log("Current API URL:", this.environment.ApiUrl);
  }

  PostRequest(method: string, data: any) {
    var request = {
      Method: method,
      Data: data
    }
    return this.httpclient.post(this.FullPath, request);
  }
}
