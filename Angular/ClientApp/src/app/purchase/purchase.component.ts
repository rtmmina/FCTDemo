import { Component, Inject, OnInit } from '@angular/core';
import { PurchaseService } from './purchase.service';
import { JwtAuthorizatonService } from '../jwtauthorization/jwtauthorization.service';
import { Purchase, Token } from './purchase.model';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import * as jwt_decode from 'jwt-decode';
//import 'rxjs/add/operator/debounceTime';
//import 'rxjs/add/operator/map';

@Component({
  selector: 'app-customer',
  templateUrl: './purchase.component.html'
})

export class PurchaseComponent implements OnInit {
  purchaseForm: FormGroup;
  purchases: Array<Purchase>;
  isUserLogged: boolean;

  ngOnInit() {
    var token = localStorage.getItem("jwt");
    if (token != null && token.length > 0) {
      var decoded = jwt_decode(token);
      var currentTime = new Date().getTime();
      console.log(decoded.exp);
      console.log(currentTime);
      if (decoded.exp * 1000 >= currentTime) {
        this.isUserLogged = true;
      }
      else {
        localStorage.removeItem("jwt");
        this.isUserLogged = false;
        this.router.navigate(['/customer']);
      }
    }


  }

  constructor(private formBuilder: FormBuilder, private purchaseService: PurchaseService, private jwtAuth: JwtAuthorizatonService, private spinnerService: NgxSpinnerService, private router: Router) {
    this.purchaseForm = formBuilder.group({
      id: new FormControl(''),
      email: new FormControl(''),
      productName: new FormControl(''),
      token: new FormControl('')
    });

    this.purchaseForm.controls['email']
      .valueChanges
      //.debounceTime(600)
      .subscribe(val => {
        var obj = new Token;
        obj.email = val;
        obj.jwtToken = "";
        console.log("Token is " + JSON.stringify(obj));

        this.purchaseForm.controls['id'].setValue(val);
      });
    if (this.isUserLogged == true) {
      this.getAllPurchases();
    }
    

  }

  Delete(id) {
    this.spinnerService.show();
    var obj = new Purchase;
    obj.id = id;
    obj.email = "";
    obj.productName = "";
    this.purchaseService.delete(obj).subscribe(res => {
      this.getAllPurchases();
    });
    console.log("about to delete " + id);
  }

  save() {
    this.spinnerService.show();
    let token = new Token;
    token.email = "";
    token.jwtToken = this.purchaseForm.controls['token'].value;
    let purchase = new Purchase;
    purchase.email = this.purchaseForm.controls['email'].value;
    purchase.productName = this.purchaseForm.controls['productName'].value;
    purchase.id = null;
    this.purchaseService.post(purchase).subscribe(res => {
      this.getAllPurchases();
    });




    //let formData = this.purchaseForm.getRawValue() as Purchase;
    //this.purchaseService.post(formData).subscribe(res => {
    //  console.log("Inserted purchase " + JSON.stringify(res) + " in database.");      
    //  //It is better to add the new record to existing this.customers and not to make a call to return everything. For performance.
    //  //this.getAllPurchases();
    //});
  }

  getAllPurchases() {
    this.spinnerService.show();

    this.purchaseService.get().subscribe(res => {
      console.log("Get All Purchases are " + JSON.stringify(res));
      this.purchases = res;
      this.spinnerService.hide();
    });
  }
}

