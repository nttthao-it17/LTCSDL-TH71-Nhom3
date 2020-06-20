import { Component, OnInit } from '@angular/core';
import{HttpClient} from '@angular/common/http'
import{HomeService} from './home.service'
import { Router } from '@angular/router';

declare var $:any;
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
  isLogin: boolean =  false;

  userregis: any = {
    tenNguoiDung: "",
    email: "",
    matKhau: "",
    diaChi: "",
    soDienThoai: ""
  }

  public constructor(

    private mainService : HomeService,
    private route : Router
  ) { }

  ngOnInit() {
  }


  dangNhap(){
    this.mainService.login(this.email,this.matKhau).subscribe(
      res=>{
        if(res.data != null && res.success){
          this.user = res.data
          this.isLogin = true;
          $('#darkModalForm').modal('hide');
          this.route.navigate(['/user'])
        }
        else{
          alert(res.message)
        }  
      },
      err=>{
        alert("Lỗi! Vui lòng kiểm tra lại.")
      }
    )
  }

  dangKy() {
    this.mainService.addAccount(this.userregis).subscribe(
      res => {
        if (res.data != null && res.success) {
          this.user = res.data;
          alert("Đăng ký tài khoản thành công!")
        }
        else {
          alert(res.message)
        }
      },
      err => {
        alert("Lỗi! Vui lòng kiểm tra lại.")
      }
    )
  }

  loginForm(){
    $('#darkModalForm').modal('show');
  }


}
