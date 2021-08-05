import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UrlLinkService } from './url-link.service';

@Injectable({
  providedIn: 'root'
})
export class VendorService {

  constructor(private http: HttpClient,private url:UrlLinkService) {
   
  }
  postVendor(data){
    return this.http.post(`${this.url.link}vendor`,data);
  }
  get(){
    return this.http.get(`${this.url.link}vendor`);
  }
  getVendorOldKey(data){
   return this.http.get(`${this.url.link}vendor/get-vendor-data/${data}`);
  }
  postInqueryVendor(data){
    return this.http.post(`${this.url.link}inquery/post-vendor-inquery-inqu`,data);
  }
}
