import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { from } from 'rxjs';
import { ViewPostComponent } from './viewPost/viewPost.component';
import { NavbarComponent } from './navbar/navbar.component';
import { AuthService } from './_services/auth.service';

@NgModule({
  declarations: [
    AppComponent,
    ViewPostComponent,
    NavbarComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [AuthService],
  bootstrap: [AppComponent]
})
export class AppModule { }
