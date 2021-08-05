import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { InqueriesService } from '../inqueries.service';
import { VendorService } from '../vendor.service';
declare var $: any;
declare var M: any;
@Component({
  selector: 'app-action',
  templateUrl: './action.component.html',
  styleUrls: ['./action.component.css'],
})
export class ActionComponent implements OnInit {
  fileter;
  inqueryId: number = 0;
  vendorId;
  vendorOldId: string;
  company: string;
  department: string;
  name: string;
  email: string;
  contactNumber: string;
  vendorInquery: any;
  constructor(
    private router: ActivatedRoute,
    private inqueryService: InqueriesService,
    private vendorService: VendorService
  ) {}
  info: any;
  ngOnInit(): void {
    $('.modal').modal();
    var result = this.router.snapshot.params['id'];
    console.log(result);
    this.inqueryService.getSpecInquery(result).subscribe((data: any) => {
      console.log(data);
      this.info = data;
      this.inqueryId = Number.parseInt(this.info.id);
      this.inqueryService
        .getInqueryVendor(this.inqueryId)
        .subscribe((data: any) => {
          console.log(data);
          this.vendorInquery = data.data;
        });
    });
  }

  onvendorChange(): void {
    console.log('value chmaged');
    this.vendorService
      .getVendorOldKey(this.vendorOldId)
      .subscribe((data: any) => {
        console.log(data);
        this.company = data.company;
        this.department = data.department;
        this.name = data.name;
        this.email = data.email;
        this.contactNumber = data.contactNumber;
        this.vendorId = data.id;
      });
  }
  addVendor(): void {
    var data = {
      VendorId: this.vendorId,
      InqueryId: this.inqueryId,
    };
    this.vendorService.postInqueryVendor(data).subscribe((data: any) => {
      this.inqueryService
      .getInqueryVendor(this.inqueryId)
      .subscribe((data: any) => {
        console.log(data);
        this.vendorInquery = data.data;
      });
      M.toast({ html: `${this.company} have been added to inquery` });
    });
  }
}
