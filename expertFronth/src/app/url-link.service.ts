import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class UrlLinkService {
  link: string = 'http://localhost:5000/api/';
  constructor() {}
}
