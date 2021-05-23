import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app-component/app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeModule } from './home/home.module';
import { RecipesModule } from './recipes/recipes.module';
import { FavouritesModule } from './favourites/favourites.module';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home-component/home.component';
import { FavouritesComponent } from './favourites/favourites-component/favourites.component';
import { RecipesComponent } from './recipes/recipes-component/recipes.component';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

const appRoutes: Routes =[
  { path: '', component: HomeComponent},
  { path: 'favourites', component: FavouritesComponent},
  { path: 'recipes', component: RecipesComponent }
];

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HomeModule, 
    RecipesModule,
    FavouritesModule,
    RouterModule.forRoot(appRoutes),
    CommonModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
