import { Component } from '@angular/core';
import { RIngridient } from 'src/app/core/models/ingridient';
import { Recipe } from 'src/app/core/models/recipe';
import { RStep } from 'src/app/core/models/step';

@Component({
  selector: 'app-edit-recipe',
  templateUrl: './edit-recipe.component.html',
  styleUrls: ['../../../../../styles/edit-recipe.component.css']
})

export class EditRecipeComponent {

  recipe!: Recipe;

  ingrs: RIngridient[] = [
    {id: 1, header: "Для панна котты",
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
