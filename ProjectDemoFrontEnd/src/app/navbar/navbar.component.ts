import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  model: any = {};
  constructor(private authservice: AuthService) { }

  ngOnInit() {
  }

  login() {
    this.authservice.login(this.model).subscribe(next => {
      console.log('Successful');
    }, error => {
      console.log('Failed');
    });
  }

  checkLogIn() {
    const token = localStorage.getItem('token');
    return !!token;
  }

  logOut() {
    localStorage.removeItem('token');
    console.log('Logged Out');
  }

}
