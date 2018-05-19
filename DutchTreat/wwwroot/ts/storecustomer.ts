//Pascal cased much like C# - Export requires others to import it and removes from global scope
//The type safety is optional.  Export works well when using a loader like webpack but we just want to use the JS.
class StoreCustomer {
    //Types of members include: Fields, accessors, functions, constructor

    //Constuctor
    //these parameters in the constructor are automatically created without manual assignment.
    constructor(private firstName:string, private lastName:string) {
    }

    //Exposes visits as a public member (with no type by default, or we can specify a type)
    public visits:number = 0;

    //Member behind the name property
    private ourName: string ;

    //function
    public showName():boolean {

        //Treated as a property, calls the name accessor
        alert(this.firstName + " " + this.lastName);

        return true;
    }

    //Set accessor
    set name(val) {
        //'this' is required
        this.ourName = val;
    }

    //Get accessor
    get name() {
        return this.ourName;
    }
}

