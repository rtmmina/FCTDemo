import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Customer, Login } from './customer.model';
import { NgForm } from '@angular/forms';


@Injectable()

export class CustomerService {
  private headers: HttpHeaders;
  private accessPointUrl: string = 'https://localhost:44330/api/customer';

  constructor(private http: HttpClient) {
    let token = localStorage.getItem("jwt");
    console.log("token new is " + token);
    var headers_object = new HttpHeaders().set("Authorization", "Bearer " + token);
    this.headers = headers_object;
    //this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
  }

  public get(): Observable<Array<Customer>> {
    // Get all jogging data
    return this.http.get<Array<Customer>>(this.accessPointUrl, { headers: this.headers });
  }

  public post(obj: Customer): Observable<Customer> {
    return this.http.post<Customer>(this.accessPointUrl, obj, { headers: this.headers });
  }

  public login(obj: Login): Observable<Login> {
    return this.http.post<Login>(this.accessPointUrl + '/login', obj, { headers: this.headers })      
  };
}
