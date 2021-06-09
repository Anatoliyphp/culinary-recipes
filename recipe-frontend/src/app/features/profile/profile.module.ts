import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfileComponent } from './components/profile-component/profile.component';
import { StatComponent } from './components/stat/stat.component';
import { FavouritesModule } from '../favourites/favourites.module';
import { Router, RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    ProfileComponent,
    StatComponent
  ],
  imports: [
    CommonModule,
    FavouritesModule,
    RouterModule
  ]
})
export class ProfileModule { }
