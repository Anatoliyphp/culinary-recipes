import { Component, Input } from '@angular/core';
import { SortCategories } from '../../constants/categouries'

@Component({
  selector: 'app-sort',
  templateUrl: './sort.component.html',
  styleUrls: ['../../../../../styles/sort.component.css']
})
export class SortComponent{

  @Input()
  categories = SortCategories;

}
