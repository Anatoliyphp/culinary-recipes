import { DatePipe, Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IComment } from 'src/app/features/recipes/models/comment';
import { idGetter, nameGetter } from '../../app.module';
import { FullRecipe } from '../../models/fullrecipe';
import { Recipe } from '../../models/recipe';
import { onClose, toEditRecipe } from '../../services/logination_routing';
import { RecipeService } from '../../services/recipe_service';

@Component({
  selector: 'app-change-recipe',
  templateUrl: './full-recipe.component.html',
  styleUrls: ['../../../../styles/full-recipe.component.css'],
  providers: [DatePipe]
})
export class FullRecipeComponent implements OnInit {

  constructor(
    private a_router: ActivatedRoute,
    private router: Router,
    private recipeServ: RecipeService,
    private loc: Location,
    private datePipe: DatePipe
    ) { }

  ngOnInit(): void {
    this.recipeServ.getFullRecipe(this.a_router.snapshot.paramMap.get('id'))
      .subscribe(value => {
        this.recipe = value
        this.recipe.ingridients.forEach(element => {
          element.list = element.list.split("\\n").join('\n');
        })
        this.recipeDemo = {
          id: this.recipe.id,
          img: this.recipe.img,
          name: this.recipe.name,
          description: this.recipe.description,
          time: this.recipe.time,
          persons: this.recipe.persons,
          likes: this.recipe.likes,
          comments: this.recipe.comments.length,
          isLike: this.recipe.isLike,
          favourites: this.recipe.favourites,
          isFavourite: this.recipe.isFavourite,
          userId: this.recipe.userId,
          tags: this.recipe.tags
        }
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
  recipeDemo!: Recipe;
  commentText!: string;
  commentError: boolean = false;

  addComment(){
    var date = new Date();
    var time = this.datePipe.transform(date, 'yyyy.MM.dd h:mm:ss') as string;
    time.replace('T', ' ');
    time.replace('-', '.');
    console.log(time);
    if (this.commentText.length == 0 || this.commentText.length > 20){
      this.commentError = true;
      return;
    }
    var comment: IComment = {userId: Number(idGetter() as string), author: nameGetter() as string, time: time, text: this.commentText, id: 0}
    this.recipeServ.addComment(this.a_router.snapshot.paramMap.get('id'), comment).subscribe(value => {this.recipe.comments.push(value)});
    this.commentError = false;
  }

  showComments: boolean = false;
  showCommentsValue: string = "Показать комментарии";

  onShowComments(){
    this.showComments = this.showComments ? false : true;
    this.showCommentsValue = this.showComments ? "Скрыть комментарии" : "Показать комментарии"
  }

}
