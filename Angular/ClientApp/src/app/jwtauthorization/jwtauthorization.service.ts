import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Token, Purchase } from '../purchase/purchase.model';
import { Login } from './login.model';


@Injectable()

export class JwtAuthorizatonService {
  private headers: HttpHeaders;
  private accessPointUrl: string = 'https://localhost:44330/api/jwtauthorizaton';

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
  }

  public login(obj: Login): Observable<Login> {
    let token = localStorage.getItem("jwt");
    var headers_object = new HttpHeaders().set("Authorization", "Bearer " + token);
    this.headers = headers_object;

    return this.http.post<Login>(this.accessPointUrl + '/login', obj, { headers: this.headers })
  };
}
