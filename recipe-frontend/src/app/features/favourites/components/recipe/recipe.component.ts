import { Component, Input } from '@angular/core';
import { Recipe } from '../../models/recipe';
import { Likes } from '../../constants/like';
import { FavouritesStars } from '../../constants/favouritesStar';

@Component({
  selector: 'app-recipe',
  templateUrl: './recipe.component.html',
  styleUrls: ['../../../../../styles/recipe.component.css']
})
export class RecipeComponent{

  @Input()
  recipe!: Recipe;

  currLike = "/assets/images/yellike.png";
  currStar = "/assets/images/star.png";

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
