import { Location } from '@angular/common';
import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { idGetter } from 'src/app/core/app.module';
import { FullRecipe } from 'src/app/core/models/fullrecipe';
import { onClose } from 'src/app/core/services/logination_routing';
import { RecipeService } from 'src/app/core/services/recipe_service';

@Component({
  selector: 'app-add-recipe',
  templateUrl: './add-recipe.component.html',
  styleUrls: ['../../../../../styles/add-recipe.component.css']
})
export class AddRecipeComponent {

  constructor(
    private router: Router,
    private recipeServ: RecipeService,
    private loc: Location,
  ){}

  recipe: FullRecipe = {
    id: 0,
    img: "",
    name: "" ,
    description: "" ,
    time: 0,
    persons: 0 ,
    likes: 0 ,
    isLike: false ,
    favourites: 0 ,
    isFavourite: false ,
    userId: parseInt(idGetter() as string) ,
    tags: [],
    ingridients: [],
    steps: []
  };

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

  img!: File;

  onAddImage($event: any){
    this.img = $event.target.files[0];
    console.log(this.img, this.img.name);
  }

  onClose(){
    onClose(this.loc);
  }

  imgPath: string = "assets/images/section03.png";

  onAdd(form: NgForm){
    var tags: string[] = form.value.tags.split(" ");
    this.recipeServ.addRecipe(
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
    ).subscribe(value => {})
  }

}
