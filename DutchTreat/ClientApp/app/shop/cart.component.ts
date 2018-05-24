import { Component } from '@angular/core';
import { Product } from '../shared/product';
import { DataService } from '../shared/dataService';

//Descriptor (attribute-esque)
@Component({
    selector: 'the-cart',
    templateUrl: 'cart.component.html',
    styleUrls: []
})
export class Cart {
    constructor(private data: DataService) { }
    
}