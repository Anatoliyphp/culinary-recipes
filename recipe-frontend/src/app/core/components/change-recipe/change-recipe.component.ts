import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RIngridient } from '../../models/ingridient';
import { Recipe } from '../../models/recipe';
import { RStep } from '../../models/step';
import { toAddRecipe } from '../../services/logination_routing';

@Component({
  selector: 'app-change-recipe',
  templateUrl: './change-recipe.component.html',
  styleUrls: ['../../../../styles/change-recipe.component.css']
})
export class ChangeRecipeComponent {

  constructor(private router: Router) { }

  onEdit(){
    toAddRecipe(this.router);
  }

  recipe: Recipe =
    {img: "/assets/images/panna.png", tags: ["десерты", "клубника", "сливки"], 
      likes: 8, favourites: 10, name: "Клубничная панна-котта",
      desc: "Десерт, который невероятно легко и быстро готовится. Советую подавать его порционно в красивых бокалах,украсив взбитыми сливками, свежими ягодами и мятой.", 
      time: 35, persons: 5
    }

  ingrs: RIngridient[] = [
    {header: "Для панна котты",
      desc: "Сливки-20-30% - 500мл. Молоко - 100мл. Желатин - 2ч.л. Сахар - 3ст.л. Ванильный сахар - 2 ч.л."
    },
    {header: "Для панна котты",
      desc: "Сливки-20-30% - 500мл. Молоко - 100мл. Желатин - 2ч.л. Сахар - 3ст.л. Ванильный сахар - 2 ч.л."
    }
  ]

  steps: RStep[] = [
    {header: "Шаг 1", 
      desc: "Приготовим панна котту: Зальем желатин молоком и поставим на 30 минут для набухания. В сливки добавим сахар и ванильный сахар. Доводим до кипения (не кипятим!)."
    },
    {header: "Шаг 1", 
      desc: "Приготовим панна котту: Зальем желатин молоком и поставим на 30 минут для набухания. В сливки добавим сахар и ванильный сахар. Доводим до кипения (не кипятим!)."
    },
    {header: "Шаг 1", 
      desc: "Приготовим панна котту: Зальем желатин молоком и поставим на 30 минут для набухания. В сливки добавим сахар и ванильный сахар. Доводим до кипения (не кипятим!)."
    },
    {header: "Шаг 1", 
      desc: "Приготовим панна котту: Зальем желатин молоком и поставим на 30 минут для набухания. В сливки добавим сахар и ванильный сахар. Доводим до кипения (не кипятим!)."
    },
  ]

}
