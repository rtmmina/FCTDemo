import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Customer} from './customer.model';


@Injectable()

export class CustomerService {
  private headers: HttpHeaders;
  private accessPointUrl: string = 'https://localhost:44330/api/customer';

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
  }

  public get(): Observable<Array<Customer>> {
    // Get all jogging data
    return this.http.get<Array<Customer>>(this.accessPointUrl, { headers: this.headers });
  }

  public post(obj: Customer): Observable<Customer> {
    return this.http.post<Customer>(this.accessPointUrl, obj, { headers: this.headers });
  }

}
