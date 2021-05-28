import { Component } from '@angular/core';
import { Recipe } from '../../../../core/models/recipe';

@Component({
  selector: 'app-favourites',
  templateUrl: './favourites.component.html',
  styleUrls: ['../../../../../styles/favourites.component.css']
})
export class FavouritesComponent {

  hasFavourites = true;
  recipes: Recipe[] = [
    {img: "/assets/images/panna.png", tags: ["десерты", "клубника", "сливки"], 
      likes: 8, favourites: 10, name: "Клубничная панна-котта",
      desc: "Десерт, который невероятно легко и быстро готовится. Советую подавать его порционно в красивых бокалах,украсив взбитыми сливками, свежими ягодами и мятой.", 
      time: 35, persons: 5
    },
    {img: "/assets/images/panna.png", tags: ["десерты", "клубника", "сливки"], 
      likes: 8, favourites: 10, name: "Клубничная панна-котта",
      desc: "Десерт, который невероятно легко и быстро готовится. Советую подавать его порционно в красивых бокалах,украсив взбитыми сливками, свежими ягодами и мятой.", 
      time: 35, persons: 5
    },
  ]
}
