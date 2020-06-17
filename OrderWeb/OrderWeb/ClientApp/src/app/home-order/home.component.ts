import { Component, OnInit } from '@angular/core';
import{HttpClient} from '@angular/common/http'
import{HomeService} from './home.service'

const URL = "https://localhost:44387/api/User/"
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeOrderComponent implements OnInit {

  email:any;
  matKhau:any;
  user:any;
  constructor(

    private mainService : HomeService

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
