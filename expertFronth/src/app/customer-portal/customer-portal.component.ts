import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-customer-portal',
  templateUrl: './customer-portal.component.html',
  styleUrls: ['./customer-portal.component.css']
})
export class CustomerPortalComponent implements OnInit {
name:string = localStorage.getItem("name");
  constructor() { }

  ngOnInit(): void {
  }

}
