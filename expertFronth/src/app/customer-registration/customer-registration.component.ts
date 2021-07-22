import { Component, OnInit } from '@angular/core';
import { RegistrationService } from '../registration.service';
declare var M: any;
@Component({
  selector: 'app-customer-registration',
  templateUrl: './customer-registration.component.html',
  styleUrls: ['./customer-registration.component.css'],
})
export class CustomerRegistrationComponent implements OnInit {
  p: number = 1;
  collection: any[];
  constructor(private regsiService: RegistrationService) {}

  ngOnInit(): void {
    this.regsiService.getRegRequest().subscribe((data: any) => {
      console.log(data);
      this.collection = data.data;
    });
  }
  acceptReg($event): void {
    console.log($event.target.id);
    this.regsiService
      .acceptClientReg($event.target.id)
      .subscribe((data: any) => {
        M.toast({ html: 'cleint registered sucessfully!' });
        this.regsiService.getRegRequest().subscribe((data: any) => {
          console.log(data);
          this.collection = data.data;
        });
      });
  }
}
