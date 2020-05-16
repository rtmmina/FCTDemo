import { Component, Inject, OnInit } from '@angular/core';
import { CustomerService } from './customer.service'
import { Customer, Login } from './customer.model';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
//import { Observable } from 'rxjs/Observable';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators'
//import 'rxjs/add/operator/debounceTime';
//import 'rxjs/add/operator/throttleTime';
//import 'rxjs/add/observable/fromEvent';
//import 'rxjs/add/operator/debounceTime';
//import 'rxjs/add/operator/map';
//import 'rxjs/add/operator/debounceTime';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html'
})

export class CustomerComponent implements OnInit {
  customerForm: FormGroup;
  customerFormLogin: FormGroup;
  customers: Array<Customer>;
  isUserLogged: boolean;
  invalidUser: boolean;

  ngOnInit() {
    if (this.isUserLogged == true)
      this.getAllCustomers();

    //this.customerFormLogin.controls['email'].valueChanges.debounceTime(1000).subscribe(data => { console.log(data) });
  }


  constructor(private formBuilder: FormBuilder, private customerService: CustomerService, private spinnerService: NgxSpinnerService) {
    this.customerForm = formBuilder.group({
      name: new FormControl(''),
      email: new FormControl(''),
      password: new FormControl('')
    });
    this.customerFormLogin = formBuilder.group({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', Validators.required)
    })
    this.isUserLogged = false;
    this.invalidUser = false;
  }

  Login() {
    this.invalidUser = false;
    this.spinnerService.show();
    let formData = this.customerFormLogin.getRawValue() as Login;
    console.log("User mode is " + JSON.stringify(formData));
    this.customerService.login(formData).subscribe(res => {
      console.log("Inserted customer " + JSON.stringify(res) + " in database.");
      if (res.token.length > 0) {
        this.isUserLogged = true;
        let token = (<any>res).token;
        localStorage.setItem("jwt", token);
        this.spinnerService.show();
        this.getAllCustomers();
        //this.spinnerService.hide();
      }        
      else
        this.invalidUser = true;
      //It is better to add the new record to existing this.customers and not to make a call to return everything. For performance.      
    });
  }

  save() {
    this.spinnerService.show();
    let formData = this.customerForm.getRawValue() as Customer;
    this.customerService.post(formData).subscribe(res => {
      console.log("Inserted customer " + JSON.stringify(res) + " in database.");
      //It is better to add the new record to existing this.customers and not to make a call to return everything. For performance.

      this.getAllCustomers();
      this.spinnerService.hide();
    });
  }

  getAllCustomers() {
    this.spinnerService.show();
    this.customerService.get().subscribe(res => {
      this.customers = res;
      this.spinnerService.hide();
    });
  }
}

