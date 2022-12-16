import { DatePipe } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { idGetter } from 'src/app/core/app.module';
import { RecipeService } from 'src/app/core/services/recipe_service';
import { IComment } from '../../models/comment';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['../../../../../styles/comment.component.css']
})
export class CommentComponent {

  constructor(private route: ActivatedRoute, private recipeService: RecipeService, private datePipe: DatePipe){}
  
  @Input() comment!: IComment;

  Editing: boolean = false;
  data!: IComment;

  ngOnInit(): void{
    this.canDeleteComment = idGetter() as string == this.comment.userId.toString() && this.comment.id != 0;
    this.data = this.comment;
    var date = new Date();
    var time = this.datePipe.transform(date, 'yyyy.MM.dd h:mm:ss') as string;
    this.comment.time = time;
  }

  onDelete(){
    this.recipeService.removeComment(this.comment.id).subscribe(value => {location.reload()});
  }

  onEdit(){
    this.Editing = true;
    this.canDeleteComment = false;
  }

  onSave(){
    if (this.comment.text.length <= 30 && this.comment.text.length != 0){
      this.recipeService.updateComment(this.comment).subscribe(value => {this.Editing = false, this.canDeleteComment = true})
    }
  }

  canDeleteComment!: boolean;

}
