import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../customer.service';
import { InqueriesService } from '../inqueries.service';
declare var $: any;
declare var M: any;

@Component({
  selector: 'app-inquery',
  templateUrl: './inquery.component.html',
  styleUrls: ['./inquery.component.css'],
})
export class InqueryComponent implements OnInit {
  filter:string;
  discription: string;
  customerId;
  date: Date;
  customer: string;
  name: string;
  address: string;
  email: string;
  cnum: string;
  asign: string;
  iqueryId: string;
  type: string;
  p: number = 1;
collection: any[];
  constructor(
    private inqService: InqueriesService,
    private customerService: CustomerService
  ) {}

  ngOnInit(): void {
    $('.modal').modal();
    this.inqService.getInquery().subscribe((data: any) => {
      console.log(data);
      this.collection = data.data;
    });
  }
  postNewInqu() {
    var date = new Date().toLocaleDateString();
    console.log('inqu test' + this.discription);
    var data = {
      Discription: this.discription,
      InqueryId: this.iqueryId,
      CustomerName: this.name,
      Email: this.email,
      Address: this.address,
      ContactNumber: this.cnum,
      AssignTo: this.asign,
      Date: this.date,
      Type: this.type,
      CustomerIdOld:this.customerId
    };
    this.inqService.postNewInquery(data).subscribe(
      (data) => {
        alert('data saved');
        this.discription = '';
        this.iqueryId = '';
        this.name = '';
        this.email = '';
        this.address = '';
        this.cnum = '';
        this.asign = '';

        this.type = '';

        this.inqService.getInquery().subscribe((data: any) => {
          console.log(data);
          this.collection = data.data;
        });
      },
      (err) => {}
    );
  }
  customerChange(): void {
    console.log('customer run');
    this.customerService
      .getSpecCustomerDetail(this.customerId)
      .subscribe((data: any) => {
        console.log(data);
        this.customer = data.name;
        this.name = data.name;
        this.address = data.address;
        this.email = data.contactEmail;
        this.cnum = data.contactNumber;
        console.log(this.customer);
      });
  }
  typeClick($event) {
    console.log($event.target.id);
    this.type = $event.target.id;
  }
}
