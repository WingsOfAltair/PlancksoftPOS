import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PublisherService {

  environment = environment
  FullPath = environment.ApiUrl;

constructor(private httpclient: HttpClient) {
    const protocol = window.location.protocol; // "http:" or "https:"
    let host: string;

    if (protocol === 'https:') {
      host = '192.168.1.29:5002'; // HTTPS endpoint
    } else {
      host = '192.168.1.29:5000'; // LAN HTTP endpoint
    }

    this.FullPath = `${protocol}//${host}/api/Publish/publish`;
    console.log("Current API URL:", this.FullPath);
  }

  PostRequest(method: string, data: any) {
    var request = {
      Method: method,
      Data: data
    }
    return this.httpclient.post(this.FullPath, request);
  }
}
