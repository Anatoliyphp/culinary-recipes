import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { idGetter } from '../../app.module';
import { FullRecipe } from '../../models/fullrecipe';
import { Recipe } from '../../models/recipe';
import { Tag } from '../../models/tag';
import { onClose, toEditRecipe } from '../../services/logination_routing';
import { RecipeService } from '../../services/recipe_service';

@Component({
  selector: 'app-change-recipe',
  templateUrl: './full-recipe.component.html',
  styleUrls: ['../../../../styles/full-recipe.component.css']
})
export class FullRecipeComponent implements OnInit {

  constructor(
    private a_router: ActivatedRoute,
    private router: Router,
    private recipeServ: RecipeService,
    private loc: Location
    ) { }

  ngOnInit(): void {
    this.recipeServ.getFullRecipe(this.a_router.snapshot.paramMap.get('id'))
      .subscribe(value => {
        this.recipe = value
        this.recipe.ingridients.forEach(element => {
          element.list = element.list.split("\\n").join('\n');
        })
      })
  }

  onEdit(){
    if (this.recipe.userId == parseInt(idGetter() as string))
    {
      toEditRecipe(this.router, this.a_router.snapshot.paramMap.get('id'));
    }
  }

  onDelete(): void{
    this.recipeServ.deleteRecipe(this.a_router.snapshot.paramMap.get('id'))
      .subscribe(value => {})
      onClose(this.loc);
  }

  onBack(){
    onClose(this.loc);
  }

  recipe!: FullRecipe;

}
