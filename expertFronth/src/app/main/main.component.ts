import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from '../login.service';
declare var $:any;
@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {
userName:string;
password:string;
  constructor(private logService:LoginService,private route: Router) { }

  ngOnInit(): void {
    $('.parallax').parallax();
  }
login(){
  var data = {
    UserName:this.userName,
    Password:this.password
  }
  this.logService.authUser(data).subscribe((data:any)=>{
    console.log(data);
    if (data.token != "") {
      localStorage.setItem("name", data.user);
      localStorage.setItem("token", data.token);
      
      this.route.navigate(["/portal"]);
    }}
  ,(err)=>{
    alert("can not login")
  })
  
}
}
