import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../customer.service';
declare var $:any;
declare var M:any; 
@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.css']
})
export class ClientComponent implements OnInit {
name:string;
email:string;
filter;
customerId:string;
contact:string;
address:string;
p: number = 1;
collection: any[];
  constructor(private clientService:CustomerService) { }

  ngOnInit(): void {
    $('.modal').modal();
    this.clientService.getCustomer().subscribe((data:any)=>{
      console.log(data);
      this.collection = data.data;
    })
  }
  addClient(){
    var data = {
      OldId:this.customerId,
      Name:this.name,
      Address:this.address,
      ContactEmail:this.email,
      ContactNumber:this.contact
    }
    console.log("add client");
    this.clientService.postClient(data).subscribe((data:any)=>{
      this.clientService.getCustomer().subscribe((data:any)=>{
        console.log(data);
        this.collection = data.data;
      })
      M.toast({html: 'client data saved'});
    },(err)=>{})
  }

}
