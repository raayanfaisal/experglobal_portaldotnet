import { Component, OnInit } from '@angular/core';
declare var $:any;
@Component({
  selector: 'app-inquery',
  templateUrl: './inquery.component.html',
  styleUrls: ['./inquery.component.css']
})
export class InqueryComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    $('.modal').modal();
  }

}
