import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FavouritesComponent } from './favourites-component/favourites.component';
import { RecipeComponent } from './recipe/recipe.component';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    FavouritesComponent,
    RecipeComponent,
  ],
  imports: [
    CommonModule,
    BrowserModule,
    FormsModule
  ]
})
export class FavouritesModule { }
