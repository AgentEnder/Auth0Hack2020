import { Component, OnInit } from '@angular/core';
import { AuthService } from './core/services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Auth0HackFrontend';
  user = {};

  constructor(public auth: AuthService) {}

  ngOnInit(){
    this.auth.userProfile$.subscribe(x => this.user = x);
  }

  login(){
    this.auth.login();
  }
}
