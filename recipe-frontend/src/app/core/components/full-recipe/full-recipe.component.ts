import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { RIngridient } from '../../models/ingridient';
import { Recipe } from '../../models/recipe';
import { RStep } from '../../models/step';
import { toEditRecipe } from '../../services/logination_routing';

@Component({
  selector: 'app-change-recipe',
  templateUrl: './full-recipe.component.html',
  styleUrls: ['../../../../styles/full-recipe.component.css']
})
export class FullRecipeComponent {

  constructor(private router: Router) { }

  onEdit(){
    toEditRecipe(this.router);
  }

  recipe!: Recipe;

  ingrs: RIngridient[] = [
    {id: 1,  header: "Для панна котты",
      desc: "Сливки-20-30% - 500мл. Молоко - 100мл. Желатин - 2ч.л. Сахар - 3ст.л. Ванильный сахар - 2 ч.л."
    },
    {id: 2, header: "Для панна котты",
      desc: "Сливки-20-30% - 500мл. Молоко - 100мл. Желатин - 2ч.л. Сахар - 3ст.л. Ванильный сахар - 2 ч.л."
    }
  ]

  steps: RStep[] = [
    {number: 1, header: "Шаг 1", 
      desc: "Приготовим панна котту: Зальем желатин молоком и поставим на 30 минут для набухания. В сливки добавим сахар и ванильный сахар. Доводим до кипения (не кипятим!)."
    },
    {number: 1, header: "Шаг 1", 
      desc: "Приготовим панна котту: Зальем желатин молоком и поставим на 30 минут для набухания. В сливки добавим сахар и ванильный сахар. Доводим до кипения (не кипятим!)."
    },
    {number: 1, header: "Шаг 1", 
      desc: "Приготовим панна котту: Зальем желатин молоком и поставим на 30 минут для набухания. В сливки добавим сахар и ванильный сахар. Доводим до кипения (не кипятим!)."
    },
    {number: 1, header: "Шаг 1", 
      desc: "Приготовим панна котту: Зальем желатин молоком и поставим на 30 минут для набухания. В сливки добавим сахар и ванильный сахар. Доводим до кипения (не кипятим!)."
    },
  ]

}
