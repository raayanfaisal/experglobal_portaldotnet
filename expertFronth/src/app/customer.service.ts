import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UrlLinkService } from './url-link.service';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  
  constructor(private http: HttpClient,private url:UrlLinkService) {
   
  }
  postClient(data){
    return this.http.post(`${this.url.link}Customer`,data);
  }
  getCustomer(){
    return this.http.get(`${this.url.link}customer`);
  }
  getSpecCustomerDetail(data:string){
    return this.http.get(`${this.url.link}customer/get-customer-info/${data}`);
  }
}
