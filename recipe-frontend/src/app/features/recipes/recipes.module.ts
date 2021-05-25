import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RecipesComponent } from './components/recipes-component/recipes.component';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from '../../core/app-routing.module';



@NgModule({
  declarations: [
    RecipesComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    AppRoutingModule
  ]
})
export class RecipesModule { }
