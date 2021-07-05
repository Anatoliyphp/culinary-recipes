import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfileComponent } from './components/profile-component/profile.component';
import { StatComponent } from './components/stat/stat.component';
import { FavouritesModule } from '../favourites/favourites.module';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    ProfileComponent,
    StatComponent
  ],
  imports: [
    CommonModule,
    FavouritesModule,
    RouterModule,
    FormsModule
  ]
})
export class ProfileModule { }
