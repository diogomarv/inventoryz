import { Injectable, OnInit } from "@angular/core";
import { FormBuilder } from "@angular/forms";
// import { HttpClient } from "@angular/common/http";

@Injectable({
    providedIn: 'root'
})
export class UserService implements OnInit {
    constructor(private formBuilder: FormBuilder) { }

    formModel = this.formBuilder.group({
        UserName: [''],
        Email: [''],
        Passwords: this.formBuilder.group({
            Password: [''],
            ConfirmPassword: ['']
        })

    });

    ngOnInit(){
        
    }

    register(){
        console.log(this.formBuilder)
    }

}