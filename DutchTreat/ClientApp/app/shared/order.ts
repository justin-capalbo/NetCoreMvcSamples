//Made with json2ts, takes a shape we constructed and verify the shape is correct (it gives us interfaces)
//we actually need an instance to send to the server, though.  Now we have one file importing two things.

import * as _ from "lodash";

export class Order {
    orderId: number;
    orderDate: Date = new Date(); //Current date and time, allows user to replace later
    orderNumber: string;
    items: Array<OrderItem> = new Array<OrderItem>(); //Easier to add and reomve from

    //I've seen the below implemented using the Lodash dependency.  
    //So it's a bit simpler, but might be unnecessary and adds a dependency.
    //I used it for one method just to have it as a reference.
    
    //read-only public property
    get totalitems(): number {
        //Map reduce native EcmaScript
        return (this.items.length === 0)
            ? this.items.length
            : this.items.map(i => i.quantity).reduce((a, b) => a + b);
    };

    //read-only public property
    get subtotal(): number {
        //Map reduce with Lodash.  I like that I don't need to return 0.
        return _.sum(_.map(this.items, i => i.quantity * i.unitPrice));
    };
}

export class OrderItem {
    id: number;
    quantity: number;
    unitPrice: number;
    productId: number;
    productCategory: string;
    productSize: string;
    productTitle: string;
    productArtist: string;
    productArtId: string;
}