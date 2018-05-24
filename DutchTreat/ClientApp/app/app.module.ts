import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

//My app components and services
import { AppComponent } from './app.component';
import { ProductList } from './shop/productList.component';
import { Cart } from './shop/cart.component';
import { Shop } from './shop/shop.component';
import { Checkout } from './checkout/checkout.component';
import { Login } from './login/login.component';
import { DataService } from './shared/dataService';

//The module that represents the routes we are going to allow (inter-page routes)
import { RouterModule } from '@angular/router';

import { FormsModule } from '@angular/forms';


//Paths are assumed to be after the slash
let routes = [
    { path: '', component: Shop },
    { path: 'checkout', component: Checkout },
    { path: 'login', component: Login }
];

@NgModule({
    //Allows the component to be used on the page by its' selector
    declarations: [
        AppComponent,
        ProductList, 
        Cart,
        Shop,
        Checkout,
        Login
    ],
    imports: [
        BrowserModule,
        HttpClientModule,
        FormsModule,
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
