import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from './product.model';


@Injectable()

export class ProductService {
  private headers: HttpHeaders;
  private accessPointUrl: string = 'https://localhost:44330/api/product';

  constructor(private http: HttpClient) {
    //this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
  }

  public get(): Observable<Array<Product>> {
    let token = localStorage.getItem("jwt");
    var headers_object = new HttpHeaders().set("Authorization", "Bearer " + token);
    this.headers = headers_object;
    // Get all jogging data
    return this.http.get<Array<Product>>(this.accessPointUrl, { headers: this.headers });
  }

  public post(obj: Product): Observable<Product> {
    let token = localStorage.getItem("jwt");
    var headers_object = new HttpHeaders().set("Authorization", "Bearer " + token);
    this.headers = headers_object;

    return this.http.post<Product>(this.accessPointUrl, obj, { headers: this.headers });
  }

}
