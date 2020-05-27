import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { ProductService } from './product.service'
import { Product } from './product.model';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { MatSort, MatTableModule, MatTableDataSource, MatTable } from '@angular/material';
import { NgxSpinnerService } from 'ngx-spinner';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import * as jwt_decode from 'jwt-decode';

const ELEMENT_DATA: Product[] = [
  { id: 1, name: 'Hydrogen', description: 'H', price: 1.0079},
  { id: 2, name: 'Helium', description: 'He', price: 4.0026},
  { id: 3, name: 'Lithium', description: 'Li', price: 6.941 },
  { id: 4, name: 'Beryllium', description: 'Be', price: 9.0122},
  { id: 5, name: 'Boron', description: 'B', price: 10.811 },
  { id: 6, name: 'Carbon', description: 'C', price: 12.0107 },
  { id: 7, name: 'Nitrogen', description: 'N', price: 14.0067 },
  { id: 8, name: 'Oxygen', description: 'O', price: 15.9994 },
  { id: 9, name: 'Fluorine', description: 'F', price: 18.9984},
  { id: 10, name: 'Neon', description: 'Ne', price: 20.1797 },
];

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})

export class ProductComponent implements OnInit {


  productForm: FormGroup;
  products: Array<Product>;



  displayedColumns: string[] = ['id', 'name', 'description', 'price'];
  
  dataSource = new MatTableDataSource(ELEMENT_DATA);

  name: FormControl;
  description: FormControl;
  price: FormControl;

  isUserLogged: boolean;

  @ViewChild(MatSort, { static: true }) sort: MatSort;


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

    this.name = new FormControl('', Validators.required);
    this.description = new FormControl('');
    this.price = new FormControl('', Validators.min(0.01));
    if (this.isUserLogged == true) {
      this.getAllProducts();
    }
    
    //console.log("And here is " + JSON.stringify(this.products));
    //this.dataSource = new MatTableDataSource(this.products);

    //this.dataSource.sort = this.sort;

    this.productForm = new FormGroup({
      name: this.name,
      description: this.description,
      price: this.price
    });
  }


  constructor(private formBuilder: FormBuilder, private productService: ProductService, private spinnerService: NgxSpinnerService, private router: Router) {
  }

  save() {
    this.spinnerService.show();
    let formData = this.productForm.getRawValue() as Product;
    console.log('product post data is ' + JSON.stringify(formData));
    this.productService.post(formData).subscribe(res => {
      console.log("Inserted customer " + JSON.stringify(res) + " in database.");
      //It is better to add the new record to existing this.products and not to make a call to return everything. For performance.
      this.getAllProducts();
    });
  }

  getAllProducts() {
    this.spinnerService.show();
    console.log("hit getAllProducts");
    this.productService.get().subscribe(res => {
      this.products = res;
      //console.log("products are " + JSON.stringify(this.products));
      this.dataSource = new MatTableDataSource(this.products);

      this.dataSource.sort = this.sort;
      this.spinnerService.hide();
      //this.dataSource = new MatTableDataSource(ELEMENT_DATA);
    });
    //this.dataSource = new MatTableDataSource(res);
  }
}

