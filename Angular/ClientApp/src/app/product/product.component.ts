import { Component, Inject, OnInit } from '@angular/core';
import { ProductService } from './product.service'
import { Product } from './product.model';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html'
})

export class ProductComponent implements OnInit {
  productForm: FormGroup;
  products: Array<Product>;

  ngOnInit() {

  }


  constructor(private formBuilder: FormBuilder, private productService: ProductService) {
    this.productForm = formBuilder.group({
      name: new FormControl(''),
      description: new FormControl('')
    });
    this.getAllProducts();
  }

  save() {
    let formData = this.productForm.getRawValue() as Product;
    this.productService.post(formData).subscribe(res => {
      console.log("Inserted customer " + JSON.stringify(res) + " in database.");
      //It is better to add the new record to existing this.products and not to make a call to return everything. For performance.
      this.getAllProducts();
    });
  }

  getAllProducts() {
    console.log("hit getAllProducts");
    this.productService.get().subscribe(res => {
      this.products = res;
    });
  }
}

