import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './components/app-component/app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeModule } from '../features/home/home.module';
import { RecipesModule } from '../features/recipes/recipes.module';
import { FavouritesModule } from '../features/favourites/favourites.module';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { LoginationModule } from '../features/logination/logination.module';
import { appRoutes } from './constants/routes';
import { ProfileModule } from '../features/profile/profile.module';
import { JwtModule} from '@auth0/angular-jwt';
import { HttpClientModule } from '@angular/common/http';
import { ACCESS_TOKEN_KEY, USER_ID, USER_NAME } from './services/auth_service';
import { FullRecipeComponent } from './components/full-recipe/full-recipe.component';
import { FullStepComponent } from './components/full-step/full-step.component';
import { FullIngridientComponent } from './components/full-ingridient/full-ingridient.component';
import { UsersTopModule } from '../features/users-top/users-top.module';

export function tokenGetter()
{
  return localStorage.getItem(ACCESS_TOKEN_KEY);
}

export function nameGetter()
{
  return localStorage.getItem(USER_NAME);
}

export function idGetter()
{
    return localStorage.getItem(USER_ID);
}

@NgModule({
  declarations: [
    AppComponent,
    FullRecipeComponent,
    FullStepComponent,
    FullIngridientComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HomeModule, 
    RecipesModule,
    FavouritesModule,
    UsersTopModule,
    RouterModule.forRoot(appRoutes),
    CommonModule,
    FormsModule,
    RecipesModule,
    LoginationModule,
    ProfileModule,
    HttpClientModule,

    JwtModule.forRoot({
      config: {
        tokenGetter
      }
    })
  ],
  exports: [
    HomeModule,
    FavouritesModule,
    LoginationModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
