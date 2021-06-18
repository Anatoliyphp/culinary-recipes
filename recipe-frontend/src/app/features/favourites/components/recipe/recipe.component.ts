import { Component, Input, OnInit } from '@angular/core';
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
export class RecipeComponent implements OnInit{

  constructor(private router: Router, private auth: AuthService){}

  ngOnInit(): void {
    this.currLike = this.recipe.isLike ? Likes.like : Likes.dislike;
    this.currStar = this.recipe.isFavourite ? FavouritesStars.fullStar : FavouritesStars.emptyStar;
  }

  onClick(){
    if (this.auth.isAuthenticated())
    {
      toChangeRecipe(this.router);
    }
  }

  @Input()
  recipe!: Recipe;

  currLike!: string;
  currStar!: string;

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
