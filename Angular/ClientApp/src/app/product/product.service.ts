import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from './product.model';


@Injectable()

export class ProductService {
  private headers: HttpHeaders;
  private accessPointUrl: string = 'https://localhost:44330/api/product';

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
  }

  public get(): Observable<Array<Product>> {
    // Get all jogging data
    return this.http.get<Array<Product>>(this.accessPointUrl, { headers: this.headers });
  }

  public post(obj: Product): Observable<Product> {
    return this.http.post<Product>(this.accessPointUrl, obj, { headers: this.headers });
  }

}
