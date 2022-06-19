import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from '../models/product.model';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit {
  product!: Product;

  constructor(
    private productService: ProductService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      const id = params['id'];
      this.productService.getProduct(id).subscribe(
        productToEdit => this.product = productToEdit);
    });
  }

  async onSave(form: NgForm) {
    this.product.name = form.value.name;
    this.product.description = form.value.description;
    this.product.price = form.value.price;
    this.product.quantity = form.value.quantity;

    this.productService.update(this.product).subscribe(
      () => this.router.navigate(['home']));
  }
}
