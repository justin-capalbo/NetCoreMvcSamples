//Made with json2ts, takes a shape we constructed and verify the shape is correct (it gives us interfaces)
//we actually need an instance to send to the server, though.  Now we have one file importing two things.

export class Order {
    orderId: number;
    orderDate: Date = new Date(); //Current date and time, allows user to replace later
    orderNumber: string;
    items: Array<OrderItem> = new Array<OrderItem>(); //Easier to add and reomve from

    public itemCount(): number {
        return (this.items.length === 0)
            ? this.items.length
            : this.items.map(i => i.quantity).reduce((a, b) => a + b);
    }
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