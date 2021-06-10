import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RecipesComponent } from './components/recipes-component/recipes.component';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from '../../core/app-routing.module';
import { HomeModule } from '../home/home.module';
import { FavouritesModule } from '../favourites/favourites.module';
import { FormsModule } from '@angular/forms';
import { AddRecipeComponent } from './components/add-recipe/add-recipe.component';
import { StepComponent } from './components/step/step.component';
import { IngridientComponent } from './components/ingridient/ingridient.component';
import { EditRecipeComponent } from './components/edit-recipe/edit-recipe.component';

@NgModule({
  declarations: [
    RecipesComponent,
    AddRecipeComponent,
    StepComponent,
    IngridientComponent,
    EditRecipeComponent,
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
