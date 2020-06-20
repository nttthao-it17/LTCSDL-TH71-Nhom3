import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { __core_private_testing_placeholder__ } from '@angular/core/testing';


const URL = "https://localhost:44387/api/User/"

const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
@Injectable({
    providedIn: 'root'
})
export class HomeService {
    constructor(private http: HttpClient) { }

    login(email,matkhau) : Observable<any>{
        return this.http.post(URL + 'login-user',
        {
            email: email,
            password: matkhau
        }
        , httpOptions);
    }

    
    addAccount(userregis): Observable<any>{
        console.log(userregis)
        return this.http.post('https://localhost:44387/api/UserRegistration/tao-tai-khoan',
        {            
            tenNguoiDung: userregis.tenNguoiDung,
            email: userregis.email,
            matKhau: userregis.matKhau,           
            diaChi: userregis.diaChi,
            soDienThoai: userregis.soDienThoai
        }
        , httpOptions);
    }
}