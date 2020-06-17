
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
export class MainOrderService {
    constructor(private http: HttpClient) { }



    login(email,matkhau) : Observable<any>{
        return this.http.post(URL + 'login-user',
        {
            email: email,
            password: matkhau
        }
        , httpOptions);
    }
    
}