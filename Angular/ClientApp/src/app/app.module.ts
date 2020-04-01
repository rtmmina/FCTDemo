import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';

import { CustomerComponent } from './customer/customer.component';
import { CustomerService } from './customer/customer.service';
import { ProductComponent } from './product/product.component';
import { ProductService } from './product/product.service';
import { PurchaseComponent } from './purchase/purchase.component';
import { PurchaseService } from './purchase/purchase.service';

import { JwtAuthorizatonService } from './jwtauthorization/jwtauthorization.service';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatTableModule } from '@angular/material';
import { MatSortModule } from '@angular/material/sort';


const appRoutes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'counter', component: CounterComponent },
  { path: 'fetch-data', component: FetchDataComponent },
  { path: 'customer', component: CustomerComponent },
  { path: 'product', component: ProductComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    CustomerComponent,
    ProductComponent,
    PurchaseComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'customer', component: CustomerComponent },
      { path: 'product', component: ProductComponent },
      { path: 'purchase', component: PurchaseComponent }
    ]),
    BrowserAnimationsModule,
    MatTableModule,
    MatSortModule
  ],
  providers: [
    CustomerService,
    ProductService,
    PurchaseService,
    JwtAuthorizatonService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
