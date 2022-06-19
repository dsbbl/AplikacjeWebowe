import { Component, OnInit } from '@angular/core';
import { Product } from '../models/product.model';
import { ProductService } from '../services/product.service';

var string: string;

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  products: Array<Product> = [];
  searchedproducts: Array<Product> = [];


  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    console.log(string);
    this.getProducts();
    this.getSearchedProducts(string);
  }

  onDelete(id: number, event: Event) {
    event.stopPropagation();
    this.productService.delete(id).subscribe(
      () => this.getProducts());
  }

  private getProducts() {
    this.productService.get().subscribe(
      products => this.products = products);
  }

  // onSearch(search:string) {
  //   string = search;
  //   console.log(search);
  //   this.productService.searchProduct(search).subscribe(
  //     () => this.getSearchedProducts(search));
  //     console.log(this.searchedproducts);
  //     this.ngOnInit();
      
  // }

  private getSearchedProducts(search:string) {
    this.productService.searchProduct(search).subscribe(
      searchedproducts => this.searchedproducts = searchedproducts);
      string = search;
  }
}