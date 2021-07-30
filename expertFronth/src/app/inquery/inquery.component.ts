import { Component, OnInit } from '@angular/core';
import { InqueriesService } from '../inqueries.service';
declare var $:any;
@Component({
  selector: 'app-inquery',
  templateUrl: './inquery.component.html',
  styleUrls: ['./inquery.component.css']
})
export class InqueryComponent implements OnInit {
discription:string;
  constructor(private inqService:InqueriesService) { }

  ngOnInit(): void {
    $('.modal').modal();
  }
postNewInqu(){
  var date = new Date().toLocaleDateString();
  console.log("inqu test" + this.discription);
  var data = {
    IDard:localStorage.getItem("idcard"),
    CustomerName:localStorage.getItem("name"),
    Discription:this.discription,
 
  }
  this.inqService.postNewInquery(data).subscribe((data)=>{
    alert("data saved");
  },(err)=>{})
}

}
