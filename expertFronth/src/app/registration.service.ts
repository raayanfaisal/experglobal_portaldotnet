import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UrlLinkService } from './url-link.service';

@Injectable({
  providedIn: 'root'
})
export class RegistrationService {

  constructor(private http: HttpClient,private url:UrlLinkService) { }

  regCustomer(data){
    return this.http.post(`${this.url.link}CustomerReg`,data);
  }
  getRegRequest(){
    return this.http.get(`${this.url.link}CustomerReg`);
  }
  acceptClientReg(data:number){
    return this.http.get(`${this.url.link}admin/accept-client-reg/${data}`);
  }
}
