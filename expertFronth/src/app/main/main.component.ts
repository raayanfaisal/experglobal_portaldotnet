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
    
      localStorage.setItem("name", data.user);
      localStorage.setItem("token", data.token);
      localStorage.setItem("roles",data.roles);
      localStorage.setItem("idcard",data.iDcard);
      
      this.route.navigate(["/portal/inquery"]);
    }
  ,(err)=>{
    alert("can not login")
  })
  
}
}
