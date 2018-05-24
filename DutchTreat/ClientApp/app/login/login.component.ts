import { Component } from '@angular/core';
import { DataService } from '../shared/dataService';
import { Router } from '@angular/router';

@Component({
    selector: 'login',
    templateUrl: 'login.component.html',
    styleUrls: []
})
export class Login {
    constructor(private data: DataService, private router: Router) { }

    public creds = {
        username: '',
        password: ''
    };

    onLogin() {
        //Call the login service.  Model binding gives the data from the form.
        //And also passes changes back. 
        alert(this.creds.username);
        this.creds.username += "!";
    }
}