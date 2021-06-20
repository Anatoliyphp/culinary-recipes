import { Component, OnInit } from '@angular/core';
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
    this.recipeServ.getFavourites()
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
