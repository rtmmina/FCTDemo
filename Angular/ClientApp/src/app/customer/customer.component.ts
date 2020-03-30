import { Component, Inject, OnInit } from '@angular/core';
import { CustomerService} from './customer.service'
import { Customer } from './customer.model';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html'
})

export class CustomerComponent implements OnInit {
  customerForm: FormGroup;
  customers: Array<Customer>;

  ngOnInit() {
    //this.customerService.get().subscribe(res => {
    //  this.customers = res;
    //});
  }


  constructor(private formBuilder: FormBuilder, private customerService: CustomerService) {
    this.customerForm = formBuilder.group({
      name: new FormControl(''),
      email: new FormControl(''),
      password: new FormControl('')
    });
    this.getAllCustomers();
  }

  save() {    
    let formData = this.customerForm.getRawValue() as Customer;
    this.customerService.post(formData).subscribe(res => {
      console.log("Inserted customer " + JSON.stringify(res) + " in database.");
      this.getAllCustomers();
    });
  }

  getAllCustomers() {
    this.customerService.get().subscribe(res => {
      this.customers = res;
    });
  }
}

