import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from 'src/app/core/app-routing.module';
import { TopComponent } from './components/top/top.component';
import { UserComponent } from './components/user/user.component';



@NgModule({
  declarations: [
    TopComponent,
    UserComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    FormsModule,
    AppRoutingModule
  ]
})
export class UsersTopModule { }
