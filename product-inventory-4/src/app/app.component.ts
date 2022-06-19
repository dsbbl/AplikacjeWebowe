import { Component, OnInit } from '@angular/core';
import { Product } from './models/product.model';
import { ProductService } from './services/product.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})


export class AppComponent {
  title = 'product-inventory';


  searchedproducts: Array<Product> = [];

  constructor(private productService: ProductService) { }

  onSearch(search:string) {
    this.productService.searchProduct(search).subscribe(
      data => {

        this.getSearchedProducts(search);
      });
      console.log(this.searchedproducts);
      this.searchedproducts.forEach(function (value) {
        console.log(value.id);
        console.log(value.name);
        console.log(value.description);
        console.log(value.price);
        console.log(value.quantity);
      }); 
  }

  private getSearchedProducts(search:string) {
    this.productService.searchProduct(search).subscribe(
      searchedproducts => this.searchedproducts = searchedproducts);
  }


}
