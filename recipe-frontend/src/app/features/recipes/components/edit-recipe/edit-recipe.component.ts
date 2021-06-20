import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { FullRecipe } from 'src/app/core/models/fullrecipe';
import { onClose } from 'src/app/core/services/logination_routing';
import { RecipeService } from 'src/app/core/services/recipe_service';

@Component({
  selector: 'app-edit-recipe',
  templateUrl: './edit-recipe.component.html',
  styleUrls: ['../../../../../styles/edit-recipe.component.css']
})

export class EditRecipeComponent implements OnInit {

  constructor(private a_router: ActivatedRoute, private recipeServ: RecipeService, private loc: Location) { }

  ngOnInit(): void {
    this.recipeServ.getFullRecipe(this.a_router.snapshot.paramMap.get('id'))
      .subscribe(value => {this.recipe = value})
  }

  onBack(){
    onClose(this.loc);
  }

  onEdit(form: NgForm){
    this.recipeServ.editRecipe(
      form.value.img,
      form.value.name,
	    form.value.desc,
		  form.value.time,
		  form.value.persons,
	    this.recipe.likes,
		  this.recipe.isLike,
		  this.recipe.favourites,
		  this.recipe.isFavourite,
		  this.recipe.userId,
		  form.value.tags,
		  form.value.ingridients,
		  form.value.steps
    ).subscribe(value => {})
  }

  recipe!: FullRecipe;

}
