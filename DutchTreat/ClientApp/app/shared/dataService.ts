import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map }  from 'rxjs/operators';
import { Product } from './product';

//Decorated this way to indicate that this injectable service in fact needs its own dependencies!  Could be a best practice here.
@Injectable()
export class DataService {
    constructor(private http: HttpClient) { }

    //Type and then assign, to have type safety
    public products: Product[] = [];

    loadProducts(): Observable<boolean> {
        //Angular and rxjs 6 - need to use .pipe instead of map directly on observable
        return this.http.get('/api/products') .pipe(
                map((data: any[]) => {
                    this.products = data;
                    return true;
                }));
    }
}
