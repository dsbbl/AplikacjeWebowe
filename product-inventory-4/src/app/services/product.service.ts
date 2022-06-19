import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { Product } from "../models/product.model";

@Injectable()
export class ProductService {
    constructor(private http: HttpClient) { }

    public get(): Observable<Array<Product>> {
        return this.http.get<Array<Product>>(environment.api);
    }

    public getProduct(id: number): Observable<Product> {
        return this.http.get<Product>(`${environment.api}/${id}`);
    }

    public searchProduct(name: string): Observable<Array<Product>> {
        return this.http.get<Array<Product>>(`${environment.api}/search/${name}`);
    }

    public update(product: Product): Observable<any> {
        return this.http.put(environment.api, product);
    }

    public add(product: Product): Observable<any> {
        return this.http.post(environment.api, product);
    }

    public delete(id: number): Observable<any> {
        return this.http.delete(`${environment.api}/${id}`);
    }
}
