import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-customer-portal',
  templateUrl: './customer-portal.component.html',
  styleUrls: ['./customer-portal.component.css'],
})
export class CustomerPortalComponent implements OnInit {
  name: string = localStorage.getItem('name');
  client: boolean = false;
  admin: boolean = false;
  staff: boolean = false;
  constructor() {}

  ngOnInit(): void {
    var roles: string[] = localStorage.getItem('roles').split(',');
    for (const iterator of roles) {
      if( iterator.length != 0){
        switch (iterator) {
          case 'client':
            this.client = true;
            break;
          case 'Admin':
            this.admin = true;
            break;
          case 'Staffs':
            this.staff = true;
            break;
        }
      }
    
    }
  }
}
