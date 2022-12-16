import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { toProfile } from 'src/app/core/services/logination_routing';
import { RecipeService } from 'src/app/core/services/recipe_service';
import { Stat } from 'src/app/features/profile/models/stat';
import { User } from 'src/app/features/profile/models/user';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['../../../../../styles/user.component.css']
})
export class UserComponent implements OnInit {

  constructor(private recipeService: RecipeService, private router: Router) { }

  ngOnInit(): void {
    this.recipeService.getUserRecipesStats(this.user.id)
    .subscribe(value => {
      this.stats[0].number = value.recipes;
      this.stats[1].number = value.likes;
      this.stats[2].number = value.favourites;
      this.stats[3].number = value.comments;
    })
  }

  @Input()
  user!: User;

  stats: Stat[] = [
    {title: "Всего рецептов", number: 0},
    {title: "Всего лайков", number: 0},
    {title: "В избранных", number: 0},
    {title: "Всего комментариев", number: 0}
  ]

  onProfile(){
    toProfile(this.router, this.user.id);
  }
}
