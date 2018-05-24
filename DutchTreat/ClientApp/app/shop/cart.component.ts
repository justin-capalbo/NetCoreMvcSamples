import { Component } from '@angular/core';
import { OrderItem } from '../shared/order';
import { DataService } from '../shared/dataService';
import { Router } from '@angular/router';

//Descriptor (attribute-esque)
@Component({
    selector: 'the-cart',
    templateUrl: 'cart.component.html',
    styleUrls: []
})
export class Cart {
    constructor(private data: DataService, private router: Router) { }
    
    removeItem(item: OrderItem) {
        this.data.removeFromOrder(item);
    }

    onCheckout() {
        if (this.data.loginRequired) {
            //Force login - navigate requires an array
            this.router.navigate(['login']);
        } else {
            //Go to checkout
            this.router.navigate(['checkout']);
        }
    }
}