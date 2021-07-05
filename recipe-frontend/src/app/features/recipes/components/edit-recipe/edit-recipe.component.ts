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
      .subscribe(value => {
        this.recipe = value,
        this.recipe.tags.forEach(element => {this.tags += element.name + " "}),
        this.tags = this.tags.substr(0, this.tags.length - 1);
        if (this.splitted == false)
        {
          console.log("what")
          this.recipe.ingridients.forEach(element => {
            element.list = element.list.split("\\n").join('\n');
            this.splitted = true;
        })
      }
        this.imgSrc= 'data:image/jpg;base64,' + this.recipe.img;
         })
  }

  recipe!: FullRecipe;
  splitted: boolean = false;
  imgSrc!: string;

  img!: File;
  tags: string = "";

  onAddImage($event: any){
    this.img = $event.target.files[0];
    let reader = new FileReader();
    reader.onload = ($event) => {
      this.imgSrc= $event.target?.result as string;
    }
    reader.readAsDataURL(this.img);
  }

  getBase64(file: File, src: string) {
    var reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = function () {
     src = reader.result as string;
    }
    console.log(src)
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
      ).subscribe(value => {this.error = false; location.reload()}, error => {this.error = true})
  }

}
