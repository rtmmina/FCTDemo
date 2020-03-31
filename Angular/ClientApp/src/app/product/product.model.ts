import { DecimalPipe } from "@angular/common";

export class Product {
  id: number;
  name: string;
  price: DecimalPipe;
  description: string;  
}
