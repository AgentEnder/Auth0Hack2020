import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AuthService } from './core/services/auth.service';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

const Routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    // component: ''
  }
];

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    RouterModule.forRoot([])
  ],
  providers: [AuthService],
  bootstrap: [AppComponent]
})
export class AppModule { }
