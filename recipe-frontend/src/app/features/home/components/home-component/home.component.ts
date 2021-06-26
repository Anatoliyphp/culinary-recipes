import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Recipe } from 'src/app/core/models/recipe';
import { AuthService } from 'src/app/core/services/auth_service';
import { onClose, toAddRecipe, toAuthorize, toRegister } from 'src/app/core/services/logination_routing';
import { RecipeService } from 'src/app/core/services/recipe_service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['../../../../../styles/home.component.css']
})
export class HomeComponent {

  constructor(private router: Router, private auth: AuthService, private recipeServ: RecipeService){}

  getRecipes(recipes: any){
    console.log(recipes);
    this.recipeServ.recipes = recipes;
    this.router.navigate(["/recipes"]);
  }

  recipes!: Recipe[];

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
