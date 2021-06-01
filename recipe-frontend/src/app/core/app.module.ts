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
import { environment } from 'src/environments/environment';
import { HttpClientModule } from '@angular/common/http';
import { ACCESS_TOKEN_KEY } from './services/auth_service';

export function tokenGetter()
{
  return localStorage.getItem(ACCESS_TOKEN_KEY);
}

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
    FormsModule,
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
