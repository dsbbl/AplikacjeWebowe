import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from '../models/product.model';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.css']
})
export class ProductAddComponent {
  product!: Product;

  constructor(
    private productService: ProductService,
    private route: ActivatedRoute,
    private router: Router) { }

  async onSave(form: NgForm) {
    const nowy = new Product(form.value.id, form.value.name, form.value.description, form.value.price, form.value.quantity);

    this.productService.add(nowy).subscribe(
      () => this.router.navigate(['home']));
  }
}
