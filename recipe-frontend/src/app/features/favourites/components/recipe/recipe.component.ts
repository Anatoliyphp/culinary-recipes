import { Component, Input, OnInit } from '@angular/core';
import { Recipe } from '../../../../core/models/recipe';
import { Likes } from '../../../../core/constants/like';
import { FavouritesStars } from '../../../../core/constants/favouritesStar';
import { Router } from '@angular/router';
import { toChangeRecipe } from 'src/app/core/services/logination_routing';
import { AuthService } from 'src/app/core/services/auth_service';
import { RecipeService } from 'src/app/core/services/recipe_service';
import { Tag } from 'src/app/core/models/tag';
import { Filters } from 'src/app/core/constants/filters';

@Component({
  selector: 'app-recipe',
  templateUrl: './recipe.component.html',
  styleUrls: ['../../../../../styles/recipe.component.css']
})
export class RecipeComponent implements OnInit{

  constructor(
    private router: Router,
    private auth: AuthService, 
    private recipesServ: RecipeService
    ){}

  onSearch(tag: Tag){
    this.recipesServ.getSearchingRecipes([tag.id], "", Filters.ByLikes)
      .subscribe(value => {this.recipesServ.recipes = value});
    this.router.navigate(["/recipes"]);
  }

  ngOnInit(): void {
    this.currLike = this.recipe.isLike ? Likes.like : Likes.dislike;
    this.currStar = this.recipe.isFavourite ? FavouritesStars.fullStar : FavouritesStars.emptyStar;
  }

  onClick(){
    if (this.auth.isAuthenticated())
    {
      toChangeRecipe(this.router, this.recipe.id);
    }
  }

  @Input()
  recipe!: Recipe;

  currLike!: string;
  currStar!: string;

  onLikeClick(): void
  {
    if (this.currLike == Likes.dislike)
    {
      this.recipesServ.addLike(this.recipe.id).subscribe(value => {});
      this.currLike = Likes.like;
      this.recipe.likes++;
    } else {
      this.recipesServ.removeLike(this.recipe.id).subscribe(value => {});
      this.currLike = Likes.dislike;
      this.recipe.likes--;
    }
  }

  onFavouritesClick(): void
  {
    if (this.currStar == FavouritesStars.fullStar)
    {
      this.recipesServ.removeFromRavourites(this.recipe.id).subscribe(value => {});
      this.currStar = FavouritesStars.emptyStar;
      this.recipe.favourites--;
    } else {
      this.recipesServ.addToFavourites(this.recipe.id).subscribe(value => {});
      this.currStar = FavouritesStars.fullStar;
      this.recipe.favourites++;
    }
  }

}
