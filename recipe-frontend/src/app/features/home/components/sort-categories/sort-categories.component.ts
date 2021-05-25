import { Component, Input } from '@angular/core';
import { Category } from '../../models/category';

@Component({
  selector: 'app-sort-categories',
  templateUrl: './sort-categories.component.html',
  styleUrls: ['../../../../../styles/sort-categories.component.css']
})
export class SortCategoriesComponent  {

  @Input()
  category!: Category

}
