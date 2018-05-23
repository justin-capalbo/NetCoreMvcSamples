import { Component } from "@angular/core";
import { DataService } from "../shared/dataService";

//Selector later used to refer to this component when adding in our app.component.html
@Component({
    selector: "product-list",
    templateUrl: "productList.component.html",
    styleUrls: []
})
export class ProductList {
    //Taking a data service via dependency injection, declared automatically as private member
    constructor(private data: DataService) {
        this.products = data.products;
    }

    public products = [];
}