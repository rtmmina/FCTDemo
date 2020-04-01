import { Component, Inject, OnInit } from '@angular/core';
import { PurchaseService } from './purchase.service';
import { JwtAuthorizatonService} from '../jwtauthorization/jwtauthorization.service';
import { Purchase, Token } from './purchase.model';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-customer',
  templateUrl: './purchase.component.html'
})

export class PurchaseComponent implements OnInit {
  purchaseForm: FormGroup;
  purchases: Array<Purchase>;

  ngOnInit() {
    
  }


  constructor(private formBuilder: FormBuilder, private purchaseService: PurchaseService, private jwtAuth: JwtAuthorizatonService) {
    this.purchaseForm = formBuilder.group({
      id: new FormControl(''),
      email: new FormControl(''),
      productName: new FormControl(''),
      token: new FormControl('')
    });
    this.getAllPurchases();

    this.purchaseForm.controls['email'].valueChanges.subscribe(val => {
      var obj = new Token;
      obj.email = val;
      obj.jwtToken = "";
      console.log("Token is " + JSON.stringify(obj));
      this.jwtAuth.buildjwt(obj).subscribe(res => {
        console.log('service returns ' + res);
        this.purchaseForm.controls['token'].setValue(res.jwtToken);
      });
      //console.log('value changes');
      this.purchaseForm.controls['id'].setValue(val);
    });
  }

  Delete(id) {
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
    let token = new Token;
    token.email = "";
    token.jwtToken = this.purchaseForm.controls['token'].value;
    this.jwtAuth.buildjwt(token).subscribe(res => {
      if (res.email == this.purchaseForm.controls['email'].value) {
        let purchase = new Purchase;
        purchase.email = this.purchaseForm.controls['email'].value;
        purchase.productName = this.purchaseForm.controls['productName'].value;
        purchase.id = null;
        console.log("purchase object is " + JSON.stringify(purchase));
        this.purchaseService.post(purchase).subscribe(res => {
          console.log("sent a request to add purchase");
          this.getAllPurchases();
        });
      }
        
    });

    //let formData = this.purchaseForm.getRawValue() as Purchase;
    //this.purchaseService.post(formData).subscribe(res => {
    //  console.log("Inserted purchase " + JSON.stringify(res) + " in database.");      
    //  //It is better to add the new record to existing this.customers and not to make a call to return everything. For performance.
    //  //this.getAllPurchases();
    //});
  }

  getAllPurchases() {
    this.purchaseService.get().subscribe(res => {
      console.log("Get All Purchases are " + JSON.stringify(res));
      this.purchases = res;
    });
  }
}

