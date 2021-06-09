import { Component, Input, OnInit } from '@angular/core';
import { RIngridient } from '../../models/ingridient';

@Component({
  selector: 'app-change-ingridient',
  templateUrl: './change-ingridient.component.html',
  styleUrls: ['../../../../styles/change-ingridient.component.css']
})
export class ChangeIngridientComponent {

  @Input()
  ingr!: RIngridient;

}
