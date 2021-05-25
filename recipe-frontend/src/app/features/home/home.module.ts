import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from '../../core/app-routing.module';
import { HomeComponent } from './components/home-component/home.component';
import { SortComponent } from './components/sort/sort.component';
import { SortCategoriesComponent } from './components/sort-categories/sort-categories.component';
import { BestRecipeComponent } from './components/best_recipe/best_recipe.component';
import { SearchComponent } from './components/search/search.component';

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
