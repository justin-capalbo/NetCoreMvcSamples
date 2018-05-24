import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

//My app components and services
import { AppComponent } from './app.component';
import { ProductList } from './shop/productList.component';
import { Cart } from './shop/cart.component';
import { DataService } from './shared/dataService';

@NgModule({
    declarations: [
        AppComponent,
        ProductList, //Allows the component to be used on the page by its' selector
        Cart
    ],
    imports: [
        BrowserModule,
        HttpClientModule
    ],
    providers: [DataService], //Provided to the dependency/constructor injection system.
    bootstrap: [AppComponent]
})
export class AppModule { }
