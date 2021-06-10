import { Component, Input } from '@angular/core';
import { Recipe } from '../../../../core/models/recipe';
import { Likes } from '../../../../core/constants/like';
import { FavouritesStars } from '../../../../core/constants/favouritesStar';
import { Router } from '@angular/router';
import { toChangeRecipe } from 'src/app/core/services/logination_routing';
import { AuthService } from 'src/app/core/services/auth_service';

@Component({
  selector: 'app-recipe',
  templateUrl: './recipe.component.html',
  styleUrls: ['../../../../../styles/recipe.component.css']
})
export class RecipeComponent{

  constructor(private router: Router, private auth: AuthService){}

  onClick(){
    if (this.auth.isAuthenticated())
    {
      toChangeRecipe(this.router);
    }
  }

  @Input()
  recipe!: Recipe;

  currLike = Likes.dislike;
  currStar = FavouritesStars.fullStar;

  onLikeClick(): void
  {
    this.currLike = (this.currLike == Likes.dislike) ? Likes.like : Likes.dislike;
    this.recipe.likes = (this.currLike == Likes.dislike)
     ? this.recipe.likes - 1 
     : this.recipe.likes + 1;
  }

  onFavouritesClick(): void
  {
    this.currStar = (this.currStar == FavouritesStars.fullStar) 
    ? FavouritesStars.emptyStar
    : FavouritesStars.fullStar;
    this.recipe.favourites = (this.currStar == FavouritesStars.fullStar)
     ? this.recipe.favourites + 1
     : this.recipe.favourites - 1;
  }

}
