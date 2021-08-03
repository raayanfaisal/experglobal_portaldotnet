import { Component, OnInit } from '@angular/core';
import { VendorService } from '../vendor.service';
declare var $:any;
declare var M:any;
@Component({
  selector: 'app-vendor',
  templateUrl: './vendor.component.html',
  styleUrls: ['./vendor.component.css']
})
export class VendorComponent implements OnInit {
vendorId:string;
company:string;
department:string;
name:string;
email:string;
number:string;
p: number = 1;
collection: any[];
filter;
  constructor( private readonly VendorServicePro:VendorService) { }

  ngOnInit(): void {
    $('.modal').modal();
    this.VendorServicePro.get().subscribe((data:any)=>{
      console.log(data);
      this.collection = data.data;
    })
  }
registerVendor():void{
  console.log("vendor reg");
  var data = {
    OldKey:this.vendorId,
    Company:this.company,
    Department:this.company,
    Name:this.name,
    Email:this.email,
    ContactNumber:this.number
  }
  this.VendorServicePro.postVendor(data).subscribe((data:any)=>{
    this.VendorServicePro.get().subscribe((data:any)=>{
      console.log(data);
      this.collection = data.data;
    })
    M.toast({html: 'vendor data saved'});
  },(err)=>{

  })
}
}
