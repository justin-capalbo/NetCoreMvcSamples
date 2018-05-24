import { Component } from '@angular/core';
import { OrderItem } from '../shared/order';
import { DataService } from '../shared/dataService';

//Descriptor (attribute-esque)
@Component({
    selector: 'the-cart',
    templateUrl: 'cart.component.html',
    styleUrls: []
})
export class Cart {
    constructor(private data: DataService) { }
    
    removeItem(item: OrderItem) {
        this.data.removeFromOrder(item);
    }
}