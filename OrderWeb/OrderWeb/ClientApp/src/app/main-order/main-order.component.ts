import { Component, OnInit, Inject } from '@angular/core';
import{HttpClient} from '@angular/common/http'
import{MainOrderService} from './main-order.service'
import { Router } from '@angular/router';

declare var $:any;
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
  isLogin: boolean =  false;
  constructor(

    private mainService : MainOrderService,
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
        alert("Something wrong")
      }
    )
  }

  loginForm(){
    $('#darkModalForm').modal('show');
  }

  muaNgay () {
    $('#dialog1').modal('show')
  }
  xuLy (){
    $('input.input-qty').each(function() {
      var $this = $(this),
        qty = $this.parent().find('.is-form'),
        min = Number($this.attr('min')),
        max = Number($this.attr('max')), d
      if (min == 0) {
        d = 0
      } else d = min
      $(qty).on('click', function() {
        if ($(this).hasClass('minus')) {
          if (d > min) d += -1
        } else if ($(this).hasClass('plus')) {
          //var x = Number($this.val()) + 1
          if (d <= max) d += 1
        }
        $this.attr('value', d).val(d)
      })
    })
  }

}

