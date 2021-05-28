import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RecipesComponent } from './components/recipes-component/recipes.component';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from '../../core/app-routing.module';
import { HomeModule } from '../home/home.module';
import { FavouritesModule } from '../favourites/favourites.module';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    RecipesComponent,
  ],
  imports: [
    CommonModule,
    BrowserModule,
    AppRoutingModule,
    HomeModule,
    FavouritesModule,
    FormsModule
  ]
})
export class RecipesModule { }
