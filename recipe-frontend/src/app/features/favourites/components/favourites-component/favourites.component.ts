import { Component, OnInit } from '@angular/core';
import { Filters } from 'src/app/core/constants/filters';
import { RecipeService } from 'src/app/core/services/recipe_service';
import { Recipe } from '../../../../core/models/recipe';

@Component({
  selector: 'app-favourites',
  templateUrl: './favourites.component.html',
  styleUrls: ['../../../../../styles/favourites.component.css']
})
export class FavouritesComponent implements OnInit {

  constructor(private recipeServ: RecipeService){}

  ngOnInit(): void {
    this.recipeServ.getFavourites(Filters.ByLikes)
      .subscribe(value => {
        this.recipes = value;
         if (this.recipes.length < 1)
         {
           this.hasFavourites = false
          }
         else{
           this.hasFavourites = true
          }
        })
  }

  filters: string[] = ["По лайкам", "По избранному", "По комментариям"]

  onChooseFilter(event: any){
      var currentFilter: string = event.target.value;
      var currentFilterNumber: number = 0;
      switch (currentFilter){
        case this.filters[0]:
          currentFilterNumber = 1
          break;
        case this.filters[1]:
          currentFilterNumber = 2
          break;
        case this.filters[2]:
          currentFilterNumber = 3
          break;
        default:
          currentFilterNumber = 1;
      }
      this.recipeServ.getFavourites(currentFilterNumber)
      .subscribe(value => {
        this.recipes = value;
         if (this.recipes.length < 1)
         {
           this.hasFavourites = false
          }
         else{
           this.hasFavourites = true
          }
        })
  }

  recipes!: Recipe[];

  hasFavourites = false;
  
}
