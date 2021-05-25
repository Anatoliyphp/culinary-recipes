import { Component } from '@angular/core';
import {Category} from '../../models/category';

@Component({
  selector: 'app-sort',
  templateUrl: './sort.component.html',
  styleUrls: ['../../../../../styles/sort.component.css']
})
export class SortComponent{

  categories: Category[] = [
    {img: '/assets/images/ic-menu.png', header: 'Простые блюда', info: 'Время приготвления таких блюд не более 1 часа'},
    {img: '/assets/images/ic-child.png', header: 'Детское', info: 'Самые полезные блюда которые можно детям любого возраста'},
    {img: '/assets/images/ic-chef.png', header: 'От шеф-поваров', info: 'Требуют умения, времени и терпения, зато как в ресторане'},
    {img: '/assets/images/ic-party.png', header: 'На праздник', info: 'Чем удивить гостей, чтобы все были сыты за праздничным столом'}
  ]

}
