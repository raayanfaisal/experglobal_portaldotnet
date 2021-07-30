import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UrlLinkService } from './url-link.service';

@Injectable({
  providedIn: 'root'
})
export class InqueriesService {

  constructor(private http: HttpClient,private url:UrlLinkService) {
   
  }
  postNewInquery(data){
    return this.http.post(`${this.url.link}Inquery`,data);
  }
}
