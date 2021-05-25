import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './components/app-component/app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeModule } from '../features/home/home.module';
import { RecipesModule } from '../features/recipes/recipes.module';
import { FavouritesModule } from '../features/favourites/favourites.module';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from '../features/home/components/home-component/home.component';
import { FavouritesComponent } from '../features/favourites/components/favourites-component/favourites.component';
import { RecipesComponent } from '../features/recipes/components/recipes-component/recipes.component';
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
