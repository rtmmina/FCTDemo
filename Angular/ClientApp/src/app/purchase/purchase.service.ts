import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Purchase} from './purchase.model';


@Injectable()

export class PurchaseService {
  private headers: HttpHeaders;
  private accessPointUrl: string = 'https://localhost:44330/api/purchase';

  constructor(private http: HttpClient) {
    //this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
  }

  public get(): Observable<Array<Purchase>> {
    let token = localStorage.getItem("jwt");
    var headers_object = new HttpHeaders().set("Authorization", "Bearer " + token);
    this.headers = headers_object;
    // Get all jogging data
    return this.http.get<Array<Purchase>>(this.accessPointUrl, { headers: this.headers });
  }

  public post(obj: Purchase): Observable<Purchase> {
    let token = localStorage.getItem("jwt");
    var headers_object = new HttpHeaders().set("Authorization", "Bearer " + token);
    this.headers = headers_object;

    return this.http.post<Purchase>(this.accessPointUrl, obj, { headers: this.headers });
  }

  public delete(obj: Purchase): Observable<Purchase> {
    let token = localStorage.getItem("jwt");
    var headers_object = new HttpHeaders().set("Authorization", "Bearer " + token);
    this.headers = headers_object;

    return this.http.post<Purchase>(this.accessPointUrl + '/DeletePurchase', obj, { headers: this.headers });
  }

}
