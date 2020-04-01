import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Token, Purchase } from '../purchase/purchase.model';


@Injectable()

export class JwtAuthorizatonService {
  private headers: HttpHeaders;
  private accessPointUrl: string = 'https://localhost:44330/api/jwtauthorizaton';

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
  }

  public get(): Observable<Token> {
    // Get all jogging data
    console.log("auth get");
    return this.http.get<Token>(this.accessPointUrl, { headers: this.headers });
  }


  public buildjwt(obj: Token): Observable<Token> {
    console.log('Build JWT');
    return this.http.post<Token>(this.accessPointUrl + '/buildjwt', obj, { headers: this.headers });
  }
}
