import { Component, OnInit, Inject } from '@angular/core';
import{HttpClient} from '@angular/common/http'
import{MainOrderService} from './main-order.service'

const URL = "https://localhost:44387/api/User/"
@Component({
  selector: 'app-main-order',
  templateUrl: './main-order.component.html',
  styleUrls: ['./main-order.component.scss']
})
export class MainOrderComponent implements OnInit {

  email:any;
  matKhau:any;
  user:any;
  constructor(

    private mainService : MainOrderService

  ) { }

  ngOnInit() {
  }


  dangNhap(){
    console.log(this.email,this.matKhau)
    this.mainService.login(this.email,this.matKhau).subscribe(
      res=>{
        if(res.data != null && res.success){
          this.user = res.data
          console.log(this.user)
        }
        else{
          alert(res.message)
        }  
      },
      err=>{
        alert("Something wrong")
      }
    )
  }

}
