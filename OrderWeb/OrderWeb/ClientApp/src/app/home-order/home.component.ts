import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeOrderComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  myAccount(event){
    alert("Đã nhận");
  }

}
