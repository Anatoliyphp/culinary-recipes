import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { RecipeService } from 'src/app/core/services/recipe_service';
import { BestRecipe } from '../../models/best-recipe';

@Component({
  selector: 'app-best-recipe',
  templateUrl: './best_recipe.component.html',
  styleUrls: ['../../../../../styles/best_recipe.component.css']
})
export class BestRecipeComponent implements OnInit {

  constructor(private recipeServ: RecipeService){}

  ngOnInit(): void {
    this.recipeServ.getBestRecipe()
      .subscribe(value => {this.bestrecipe = value})
  }

  bestrecipe!: BestRecipe;

}
