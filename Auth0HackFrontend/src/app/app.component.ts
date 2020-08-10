import { Component, OnInit } from '@angular/core';
import { AuthService } from './core/services/auth.service';
import { RandomUserService } from './core/services/random-user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Auth0HackFrontend';
  user = {};

  showSidebar = true;

  constructor(public auth: AuthService, private randomUserService: RandomUserService) {}

  ngOnInit(){
  }

  login(){
    this.auth.login();
  }
}
