import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UrlLinkService } from './url-link.service';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient,private url:UrlLinkService) {
   
   }
   authUser(data){
      return this.http.post(`${this.url.link}security`,data);
  }
}
