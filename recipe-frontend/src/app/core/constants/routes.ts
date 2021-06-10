import { Routes } from '@angular/router';
import { HomeComponent } from '../../features/home/components/home-component/home.component';
import { FavouritesComponent } from '../../features/favourites/components/favourites-component/favourites.component';
import { RecipesComponent } from '../../features/recipes/components/recipes-component/recipes.component';
import { LoginComponent } from '../../features/logination/components/login/login.component';
import { RegistrationComponent } from '../../features/logination/components/registration/registration.component';
import { AuthorizationComponent } from '../../features/logination/components/authorization/authorization.component';
import { ProfileComponent } from 'src/app/features/profile/components/profile-component/profile.component';
import { AddRecipeComponent } from 'src/app/features/recipes/components/add-recipe/add-recipe.component';
import { FullRecipeComponent } from '../components/full-recipe/full-recipe.component';
import { EditRecipeComponent } from 'src/app/features/recipes/components/edit-recipe/edit-recipe.component';

export const appRoutes: Routes =[
    { path: '', component: HomeComponent},
    { path: 'favourites', component: FavouritesComponent},
    { path: 'recipes', component: RecipesComponent },
    { path: 'login', component: LoginComponent, outlet: 'auth'},
    { path: 'registration', component: RegistrationComponent, outlet: 'auth'},
    { path: 'authorize', component: AuthorizationComponent, outlet: 'auth'},
    { path: 'profile', component: ProfileComponent},
    {path: 'add', component: AddRecipeComponent},
    {path: 'recipe/:id', component: FullRecipeComponent},
    {path: 'edit/:id', component: EditRecipeComponent}
  ];