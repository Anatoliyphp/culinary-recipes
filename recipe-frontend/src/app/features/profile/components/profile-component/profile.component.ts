import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { idGetter } from 'src/app/core/app.module';
import { Recipe } from 'src/app/core/models/recipe';
import { AuthService } from 'src/app/core/services/auth_service';
import { RecipeService } from 'src/app/core/services/recipe_service';
import { Stat } from '../../models/stat';
import { User } from '../../models/user';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['../../../../../styles/profile.component.css']
})
export class ProfileComponent implements OnInit {

  constructor(private auth: AuthService, private rec: RecipeService){}

  user!: User;

  ngOnInit(): void {
    this.auth.getUser()
      .subscribe( value => { this.user = value}, error => {
      })

    this.rec.getUserRecipes()
      .subscribe(value => {this.recipes = value});
  }

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

  recipes!: Recipe[];

}
