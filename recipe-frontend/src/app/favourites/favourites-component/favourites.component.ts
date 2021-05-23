import { Component } from '@angular/core';

export interface Recipe{
  img: string,
  tags:  string[],
  likes: number,
  favourites: number,
  name: string,
  desc: string,
  time: number,
  persons: number
}

@Component({
  selector: 'app-favourites',
  templateUrl: './favourites.component.html',
  styleUrls: ['./favourites.component.css']
})
export class FavouritesComponent {

  hasFavourites = true;
  limit = 2;
  i = 0;
  recipes: Recipe[] = [
    {img: "/assets/panna.png", tags: ["десерты", "клубника", "сливки"], 
      likes: 8, favourites: 10, name: "Клубничная панна-котта",
      desc: "Десерт, который невероятно легко и быстро готовится. Советую подавать его порционно в красивых бокалах,украсив взбитыми сливками, свежими ягодами и мятой.", 
      time: 35, persons: 5
    },
    {img: "/assets/panna.png", tags: ["десерты", "клубника", "сливки"], 
      likes: 8, favourites: 10, name: "Клубничная панна-котта",
      desc: "Десерт, который невероятно легко и быстро готовится. Советую подавать его порционно в красивых бокалах,украсив взбитыми сливками, свежими ягодами и мятой.", 
      time: 35, persons: 5
    },
  ]
}
