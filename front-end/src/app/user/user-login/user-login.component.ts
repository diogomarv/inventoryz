import { Component, OnInit } from '@angular/core';
import { faUserFriends } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css']
})
export class UserLoginComponent implements OnInit {

  faUser = faUserFriends;

  constructor() { }

  ngOnInit(): void {
  }

}
