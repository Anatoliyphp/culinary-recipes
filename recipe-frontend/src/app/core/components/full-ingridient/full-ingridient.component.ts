import { Component, Input } from '@angular/core';
import { RIngridient } from '../../models/ingridient';

@Component({
  selector: 'app-change-ingridient',
  templateUrl: './full-ingridient.component.html',
  styleUrls: ['../../../../styles/full-ingridient.component.css']
})
export class FullIngridientComponent {

  @Input()
  ingr!: RIngridient;

}
