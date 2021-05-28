import { Component, Input } from '@angular/core';
import { Recipe } from '../../../../core/models/recipe';
import { Likes } from '../../../../core/constants/like';
import { FavouritesStars } from '../../../../core/constants/favouritesStar';

@Component({
  selector: 'app-recipe',
  templateUrl: './recipe.component.html',
  styleUrls: ['../../../../../styles/recipe.component.css']
})
export class RecipeComponent{

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
