import { Component, OnInit } from '@angular/core';
import { RegistrationService } from '../registration.service';
declare var M:any;
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private regService:RegistrationService) { }
active:boolean = true;
  name:string;
  idCrad:string;
  email:string;
  contactNum:string;
  password:string;
  

  ngOnInit(): void {
  }
  regUser():void{
    var data = {
      FullName:this.name,
      IDCard:this.idCrad,
      CNumber:this.contactNum,
      Email:this.email,
      Password:this.password
    }
    this.regService.regCustomer(data).subscribe((data:any)=>{
      M.toast({html: 'Your application is accepted,we will get right back to u once approved by our staffs'})
    })
  }
  chekExist():void{
    this.regService.chekExist(this.idCrad).subscribe((data:any)=>{
      console.log(data);
      if (data.data == 1) {
      M.toast({html: `already a client with idcard number ${this.idCrad} is registered`})
        this.active = true;
      }
      else{
        this.active = false;
      }
    })
  }

}
