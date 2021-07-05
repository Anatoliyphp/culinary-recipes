import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { Recipe } from 'src/app/core/models/recipe';
import { AuthService } from 'src/app/core/services/auth_service';
import { toAddRecipe, toAuthorize, toRegister } from 'src/app/core/services/logination_routing';
import { RecipeService } from 'src/app/core/services/recipe_service';
import { SearchComponent } from 'src/app/features/home/components/search/search.component';
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
      .subscribe(value => {
        this.allRecipes = value
        if (this.rec.recipes != null){
          this.allRecipes = this.rec.recipes;
          this.rec.recipes = [];
        }
        this.pushRecipes(0, this.currNumberOfItems);
    })
  }

  @Input()
  categories = SortCategories;

  public getRecipes(recipes: any):void {
    this.allRecipes = [];
    this.allRecipes = recipes;
    console.log(this.allRecipes)
    this.recipes = [];
    this.currNumberOfItems = 4;
    this.pushRecipes(0, this.currNumberOfItems);
  }

  currNumberOfItems = 4;

  allRecipes!: Recipe[];

  recipes: Recipe[] = [];

  pushRecipes(start: number, end: number): void
  {
    if (this.allRecipes.length < end)
    {
      end = this.allRecipes.length;
    }
    console.log(end);
    for (let i = start; i < end; i++)
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
