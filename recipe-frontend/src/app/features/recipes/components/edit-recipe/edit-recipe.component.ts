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
      .subscribe(value => {this.recipe = value, this.recipe.tags.forEach(element => {this.tags += element.name + " "})})
  }

  img!: File;
  tags!: string;

  onAddImage($event: any){
    this.img = $event.target.files[0];
    console.log(this.img, this.img.name);
  }

  onBack(){
    onClose(this.loc);
  }

  AddStep(){
    this.recipe.steps.push({name: "", desc: ""});
  }

  AddIngr(){
    this.recipe.ingridients.push({name: "", list: ""});
  }

  DeleteIngr(index: number){
    this.recipe.ingridients.splice(index, 1);
  }

  DeleteStep(index: number){
    this.recipe.steps.splice(index, 1);
  }

  error: boolean = false;

  onEdit(form: NgForm){
    var tags: string[] = form.value.tags.split(" ");
      this.recipeServ.editRecipe(
        parseInt(this.a_router.snapshot.paramMap.get('id') as string),
        this.img,
        form.value.name,
	      form.value.description,
		    form.value.time,
		    form.value.persons,
	      this.recipe.likes,
		    this.recipe.isLike,
		    this.recipe.favourites,
		    this.recipe.isFavourite,
		    this.recipe.userId,
		    tags,
		    form.value.ingridients,
		    form.value.steps
      ).subscribe(value => {this.error = false}, error => {this.error = true})
  }

  recipe!: FullRecipe;

}
