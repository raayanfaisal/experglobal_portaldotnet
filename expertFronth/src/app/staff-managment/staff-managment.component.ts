import { Component, OnInit } from '@angular/core';
import { RegistrationService } from '../registration.service';
declare var $:any;
@Component({
  selector: 'app-staff-managment',
  templateUrl: './staff-managment.component.html',
  styleUrls: ['./staff-managment.component.css']
})
export class StaffManagmentComponent implements OnInit {
userName:string;
password:string;
fullName:string;
email:string;
roles:string;
p: number = 1;
collection: any[];
  constructor(private regService:RegistrationService) { }

  ngOnInit(): void {
    $('.modal').modal();

    this.regService.getAlluser().subscribe((data:any)=>{
      console.log(data);
      this.collection = data;
      console.log(this.collection);
      console.log("test")
    })
  }
regUser(){
  var data = {
    Roles:this.roles,
    FullName:this.fullName,
    Password:this.password,
    UserName:this.userName,
    email:this.email
  }
  this.regService.regUser(data).subscribe((data:any)=>{
    alert("registered");
    this.regService.getAlluser().subscribe((data:any)=>{
      console.log(data);
      this.collection = data;
      console.log(this.collection);
      console.log("test")
    })
  },(err)=>{})
}
deletUser():void{
  let x = confirm("do u want to delete the user ?")
  
}
}
