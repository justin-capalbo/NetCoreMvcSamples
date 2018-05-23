import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map }  from 'rxjs/operators';

//Decorated this way to indicate that this injectable service in fact needs its own dependencies!  Could be a best practice here.
@Injectable()
export class DataService {
    constructor(private http: HttpClient) {
        
    }

    public products = [];

    loadProducts() {
        //Angular and rxjs 6 - need to use .pipe instead of map directly on observable
        return this.http.get('/api/products') .pipe(
                map((data: any[]) => {
                    this.products = data;
                    return true;
                }));
    }
}
