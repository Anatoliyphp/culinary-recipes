import { Component } from '@angular/core';

export interface Category{
  img: string,
  header: string,
  info: string,
}

@Component({
  selector: 'app-sort',
  templateUrl: './sort.component.html',
  styleUrls: ['./sort.component.css']
})
export class SortComponent{

  categories: Category[] = [
    {img: '/assets/ic-menu.png', header: 'Простые блюда', info: 'Время приготвления таких блюд не более 1 часа'},
    {img: '/assets/ic-child.png', header: 'Детское', info: 'Самые полезные блюда которые можно детям любого возраста'},
    {img: '/assets/ic-chef.png', header: 'От шеф-поваров', info: 'Требуют умения, времени и терпения, зато как в ресторане'},
    {img: '/assets/ic-party.png', header: 'На праздник', info: 'Чем удивить гостей, чтобы все были сыты за праздничным столом'}
  ]

}
