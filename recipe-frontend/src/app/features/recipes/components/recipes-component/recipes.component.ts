import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Recipe } from 'src/app/core/models/recipe';
import { AuthService } from 'src/app/core/services/auth_service';
import { toAddRecipe, toAuthorize, toRegister } from 'src/app/core/services/logination_routing';
import { RecipeService } from 'src/app/core/services/recipe_service';
import { SortCategories } from 'src/app/features/home/constants/categouries';

@Component({
  selector: 'app-recipes',
  templateUrl: './recipes.component.html',
  styleUrls: ['../../../../../styles/recipes.component.css']
})
export class RecipesComponent implements OnInit {

  constructor(private router: Router, private auth: AuthService, private rec: RecipeService){}

  ngOnInit(): void {
    this.rec.getAllRecipes()
      .subscribe(value => {this.recipes = value})
  }
  
  @Input()
  categories = SortCategories;

  currNumberOfItems = 4;

  allRecipes!: Recipe[];

  recipes!: Recipe[];

  pushRecipes(start: number, end: number): void
  {
    if (this.allRecipes.length < end)
    {
      end = this.allRecipes.length - 1;
    }
    for (let i = start; i <= end; i++)
    {
      this.recipes.push(this.allRecipes[i]);
    }
  }

  onLoadMore(): void
  {
    let currIndex = this.currNumberOfItems;
    this.pushRecipes(currIndex, currIndex + 3);
    this.currNumberOfItems += 4;
  }

  onAddRecipe()
  {
    if (this.auth.isAuthenticated())
    {
      toAddRecipe(this.router);
    }
    else
    {
      toAuthorize(this.router);
    }
  }

}
