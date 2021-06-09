import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { Recipe } from 'src/app/core/models/recipe';
import { AuthService } from 'src/app/core/services/auth_service';
import { toAddRecipe, toRegister } from 'src/app/core/services/logination_routing';
import { SortCategories } from 'src/app/features/home/constants/categouries';

@Component({
  selector: 'app-recipes',
  templateUrl: './recipes.component.html',
  styleUrls: ['../../../../../styles/recipes.component.css']
})
export class RecipesComponent {

  constructor(private router: Router, private auth: AuthService){}
  
  @Input()
  categories = SortCategories;

  currNumberOfItems = 4;

  allRecipes: Recipe[] = [
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
    {img: "/assets/images/panna.png", tags: ["десерты", "клубника", "сливки"], 
      likes: 8, favourites: 10, name: "Клубничная панна-котта",
      desc: "Десерт, который невероятно легко и быстро готовится. Советую подавать его порционно в красивых бокалах,украсив взбитыми сливками, свежими ягодами и мятой.", 
      time: 35, persons: 5
    },
  ]

  recipes: Recipe[] = [this.allRecipes[0], this.allRecipes[1], this.allRecipes[2], this.allRecipes[3]];

  pushRecipes(start: number, end: number): void
  {
    if (this.allRecipes.length < end)
    {
      end = this.allRecipes.length - 1;
    }
    for (let i = start; i <= end; i++)
    {
      this.recipes.push(this.allRecipes[i]);
    }
  }

  onLoadMore(): void
  {
    let currIndex = this.currNumberOfItems;
    this.pushRecipes(currIndex, currIndex + 3);
    this.currNumberOfItems += 4;
  }

  onAddRecipe()
  {
    if (this.auth.isAuthenticated())
    {
      toAddRecipe(this.router);
    }
    else
    {
      toRegister(this.router);
    }
  }

}
