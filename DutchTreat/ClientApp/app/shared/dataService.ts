import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map }  from 'rxjs/operators';
import { Product } from './product';
import { Order, OrderItem} from './order';  //Other syntax
//import * as OrderNS from './order';  //More useful when bringing in a ton of types from a module

//Decorated this way to indicate that this injectable service in fact needs its own dependencies!  Could be a best practice here.
@Injectable()
export class DataService {
    constructor(private http: HttpClient) { }

    public order: Order = new Order();

    //Type and then assign, to have type safety
    public products: Product[] = [];

    public loadProducts(): Observable<boolean> {
        //Angular and rxjs 6 - need to use .pipe instead of map directly on observable
        return this.http.get('/api/products') .pipe(
                map((data: any[]) => {
                    this.products = data;
                    return true;
                }));
    }

    public addToOrder(newProduct: Product) {
        var item = this.order.items.find(i => i.productId == newProduct.id);

        if (item) {
            item.quantity++;
        } else {
            item = new OrderItem();

            item.productId = newProduct.id;
            item.productArtist = newProduct.artist;
            item.productArtId = newProduct.artId;
            item.productCategory = newProduct.category;
            item.productSize = newProduct.size;
            item.productTitle = newProduct.title;
            item.unitPrice = newProduct.price;
            item.quantity = 1;

            this.order.items.push(item);
        }
    }

    removeFromOrder(item: OrderItem) {
        var index = this.order.items.indexOf(item);
        if (index !== -1) {
            this.order.items.splice(index, 1);
        }
    }
}
