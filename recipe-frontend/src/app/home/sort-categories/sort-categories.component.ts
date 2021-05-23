import { Component, Input } from '@angular/core';
import { Category } from '../sort/sort.component';

@Component({
  selector: 'app-sort-categories',
  templateUrl: './sort-categories.component.html',
  styleUrls: ['./sort-categories.component.css']
})
export class SortCategoriesComponent  {

  @Input()
  category!: Category

}
