import { Component, OnInit } from '@angular/core';
declare var $:any;
@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.css']
})
export class ClientComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    $('.modal').modal();
  }

}
