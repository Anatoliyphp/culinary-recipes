import { Component, OnInit } from '@angular/core';
import { Recipe } from 'src/app/core/models/recipe';
import { Stat } from '../../models/stat';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['../../../../../styles/profile.component.css']
})
export class ProfileComponent {

  type = "password";

  onShowPass()
  {
    this.type = this.type == "password" ? "text" : "password";
  }

  stats: Stat[] = [
    {title: "Всего рецептов", number: 15},
    {title: "Всего лайков", number: 15},
    {title: "В избранных", number: 15}
  ]

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
