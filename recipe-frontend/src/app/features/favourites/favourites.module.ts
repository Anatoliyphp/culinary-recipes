import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FavouritesComponent } from './components/favourites-component/favourites.component';
import { RecipeComponent } from './components/recipe/recipe.component';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from '../../core/app-routing.module';

@NgModule({
  declarations: [
    FavouritesComponent,
    RecipeComponent,
  ],
  imports: [
    CommonModule,
    BrowserModule,
    FormsModule,
    AppRoutingModule
  ],
  exports: [
    RecipeComponent
  ]
})
export class FavouritesModule { }
