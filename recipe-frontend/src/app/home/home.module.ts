import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from '../app-routing.module';
import { HomeComponent } from './home-component/home.component';
import { SortComponent } from './sort/sort.component';
import { SortCategoriesComponent } from './sort-categories/sort-categories.component';
import { BestRecipeComponent } from './best_recipe/best_recipe.component';
import { SearchComponent } from './search/search.component';

@NgModule({
  declarations: [
    HomeComponent,
    SortComponent,
    SortCategoriesComponent,
    BestRecipeComponent,
    SearchComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    AppRoutingModule
  ]
})
export class HomeModule { }
