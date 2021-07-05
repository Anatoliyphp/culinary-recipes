import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { RIngridient } from 'src/app/core/models/ingridient';
import { RecipeService } from 'src/app/core/services/recipe_service';
import { IIngridient } from '../../models/ingridient';

@Component({
  selector: 'app-ingridient',
  templateUrl: './ingridient.component.html',
  styleUrls: ['../../../../../styles/ingridient.component.css']
})
export class IngridientComponent {

  @Output() childComponentValue = new EventEmitter<any>();

  constructor(public recipeServ: RecipeService){}

  @Input()
  ingr!: RIngridient;
  @Input()
  index!: number;

  onDelete(){
    this.childComponentValue.emit(this.index);
  }

}
