import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { from } from 'rxjs';
import { Recipe } from 'src/app/core/models/recipe';
import { AuthService, USER_NAME } from 'src/app/core/services/auth_service';
import { onClose } from 'src/app/core/services/logination_routing';
import { RecipeService } from 'src/app/core/services/recipe_service';
import { Stat } from '../../models/stat';
import { User } from '../../models/user';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['../../../../../styles/profile.component.css']
})
export class ProfileComponent implements OnInit {

  constructor(private auth: AuthService, private rec: RecipeService, private loc: Location){}

  user!: User;

  onClose(){
    onClose(this.loc);
  }

  hasRecipes: boolean = false;

  ngOnInit(): void {
    this.auth.getUser()
      .subscribe( value => {this.user= value}, error => {
      })

    this.rec.getUserRecipes()
      .subscribe(value => {
        this.recipes = value
        if (this.recipes.length < 1){
          this.hasRecipes = false;
        }
        else{
          this.hasRecipes = true;
        }
      });

    this.rec.getUserRecipesStats()
      .subscribe(value => {
        this.stats[0].number = value.recipes;
        this.stats[1].number = value.likes;
        this.stats[2].number = value.favourites;
      })
  }

  type = "password";

  onShowPass()
  {
    this.type = this.type == "password" ? "text" : "password";
  }

  onEdit(form: NgForm): void{
    var editUser: User =
      {
        id: this.user.id,
        login: form.value.login,
        password: form.value.password,
        name: form.value.name,
        about: form.value.about
      }
    this.auth.editUser(
      this.user.id,
      form.value.login,
      form.value.password,
      form.value.name,
      form.value.about
      )
      .subscribe(value => {
        this.Error = false
        localStorage.removeItem(USER_NAME);
        localStorage.setItem(USER_NAME, form.value.name);
        location.reload();
      }, error => {
        this.Error = true;
      });
  }

  stats: Stat[] = [
    {title: "Всего рецептов", number: 0},
    {title: "Всего лайков", number: 0},
    {title: "В избранных", number: 0}
  ]

  Error: boolean = false;

  recipes!: Recipe[];

}
