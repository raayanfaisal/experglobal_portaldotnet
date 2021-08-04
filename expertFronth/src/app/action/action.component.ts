import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { InqueriesService } from '../inqueries.service';

@Component({
  selector: 'app-action',
  templateUrl: './action.component.html',
  styleUrls: ['./action.component.css']
})
export class ActionComponent implements OnInit {

  constructor(private router:ActivatedRoute,private inqueryService:InqueriesService) { }
info:any;
  ngOnInit(): void {
    var result = this.router.snapshot.params["id"];
    console.log(result);
    this.inqueryService.getSpecInquery(result).subscribe((data:any)=>{
      console.log(data);
      this.info = data;
    })
  }

}
