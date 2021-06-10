import { Component, Input, OnInit } from '@angular/core';
import { RIngridient } from 'src/app/core/models/ingridient';
import { IIngridient } from '../../models/ingridient';
import { AddRecipeService } from '../../services/addRecipeService';

@Component({
  selector: 'app-ingridient',
  templateUrl: './ingridient.component.html',
  styleUrls: ['../../../../../styles/ingridient.component.css']
})
export class IngridientComponent {

  constructor(public addRecipeServ: AddRecipeService){}

  @Input()
  ingr!: RIngridient;

}
