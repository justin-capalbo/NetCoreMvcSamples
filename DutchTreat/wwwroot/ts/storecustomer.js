//Pascal cased much like C# - Export requires others to import it and removes from global scope
//The type safety is optional.  Export works well when using a loader like webpack but we just want to use the JS.
var StoreCustomer = /** @class */ (function () {
    //Types of members include: Fields, accessors, functions, constructor
    //Constuctor
    //these parameters in the constructor are automatically created without manual assignment.
    function StoreCustomer(firstName, lastName) {
        this.firstName = firstName;
        this.lastName = lastName;
        //Exposes visits as a public member (with no type by default, or we can specify a type)
        this.visits = 0;
    }
    //function
    StoreCustomer.prototype.showName = function () {
        //Treated as a property, calls the name accessor
        alert(this.firstName + " " + this.lastName);
        return true;
    };
    Object.defineProperty(StoreCustomer.prototype, "name", {
        //Get accessor
        get: function () {
            return this.ourName;
        },
        //Set accessor
        set: function (val) {
            //'this' is required
            this.ourName = val;
        },
        enumerable: true,
        configurable: true
    });
    return StoreCustomer;
}());
//# sourceMappingURL=storecustomer.js.map