import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

//My app components and services
import { AppComponent } from './app.component';
import { ProductList } from './shop/productList.component';
import { Cart } from './shop/cart.component';
import { Shop } from './shop/shop.component';
import { Checkout } from './checkout/checkout.component';
import { DataService } from './shared/dataService';

//The module that represents the routes we are going to allow (inter-page routes)
import { RouterModule } from '@angular/router';


//Paths are assumed to be after the slash
let routes = [
    { path: '', component: Shop },
    { path: 'checkout', component: Checkout }
];

@NgModule({
    declarations: [
        AppComponent,
        ProductList, //Allows the component to be used on the page by its' selector
        Cart,
        Shop,
        Checkout
    ],
    imports: [
        BrowserModule,
        HttpClientModule,
        RouterModule.forRoot(routes,
        {
            useHash: true,        //Assume the routing is after a hash sign in the URL rather than taking over this entire application
            enableTracing: false  //Allows us to see in the console each call that triggers a route.  Can be verbose
        })
    ],
    providers: [DataService], //Provided to the dependency/constructor injection system.
    bootstrap: [AppComponent]
})
export class AppModule { }
