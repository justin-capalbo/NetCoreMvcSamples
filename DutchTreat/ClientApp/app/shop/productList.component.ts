import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { DataService } from '../shared/dataService';

//Selector later used to refer to this component when adding in our app.component.html
@Component({
    selector: 'product-list',
    templateUrl: 'productList.component.html',
    styleUrls: []
})
export class ProductList implements OnInit {
    //Taking a data service via dependency injection, declared automatically as private member
    constructor(private data: DataService) {
    }

    public products = [];

    //Included in interface.
    //Once the component is ready, loadProducts in the API and subscribe to the result.  
    //If the result is success, grab the products for our own class.
    ngOnInit(): void {
        this.data.loadProducts()
            .subscribe(success => {
                if (success) {
                    this.products = this.data.products;
                }
            });
    }
}