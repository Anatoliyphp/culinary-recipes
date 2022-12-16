import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { from } from 'rxjs';
import { filter, throttleTime } from 'rxjs/operators';
import { idGetter } from 'src/app/core/app.module';
import { Filters } from 'src/app/core/constants/filters';
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

  constructor(private auth: AuthService, private rec: RecipeService, private loc: Location, private route: ActivatedRoute){}

  user!: User;

  onClose(){
    onClose(this.loc);
  }

  hasRecipes: boolean = false;
  profileHead: string = "Мой профиль";

  ngOnInit(): void {
    this.auth.getUser(this.route.snapshot.params['userId'])
      .subscribe( value => {
          this.user = value, this.canEdit = this.route.snapshot.params['userId'] == idGetter();
          this.profileHead = this.canEdit ? this.profileHead : "Профиль: " + this.user.login;
        }, error => {
      })
    this.rec.getUserRecipes(Filters.ByLikes, this.route.snapshot.params['userId'])
      .subscribe(value => {
        this.recipes = value
        if (this.recipes.length < 1){
          this.hasRecipes = false;
        }
        else{
          this.hasRecipes = true;
        }
      });

    this.rec.getUserRecipesStats(this.route.snapshot.params['userId'])
      .subscribe(value => {
        this.stats[0].number = value.recipes;
        this.stats[1].number = value.likes;
        this.stats[2].number = value.favourites;
        this.stats[3].number = value.comments;
      })
  }

  filters: string[] = ["По лайкам", "По избранному", "По комментариям"]
  canEdit: boolean = false;
  showErrorEdit: boolean = false;

  type = "password";

  onChooseFilter(event: any){
      var currentFilter: string = event.target.value;
      var currentFilterNumber: number = 0;
      switch (currentFilter){
        case this.filters[0]:
          currentFilterNumber = 1
          break;
        case this.filters[1]:
          currentFilterNumber = 2
          break;
        case this.filters[2]:
          currentFilterNumber = 3
          break;
        default:
          currentFilterNumber = 1;
      }
      this.rec.getUserRecipes(currentFilterNumber, this.route.snapshot.params['userId'])
      .subscribe(value => {
        this.recipes = value
        if (this.recipes.length < 1){
          this.hasRecipes = false;
        }
        else{
          this.hasRecipes = true;
        }
      });
  }

  onShowPass()
  {
    this.type = this.type == "password" ? "text" : "password";
  }

  onEdit(form: NgForm): void{

    if (this.canEdit){
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
    } else {
      this.showErrorEdit = true;
    }
  }

  stats: Stat[] = [
    {title: "Всего рецептов", number: 0},
    {title: "Всего лайков", number: 0},
    {title: "В избранных", number: 0},
    {title: "Всего комментариев", number: 0}
  ]

  Error: boolean = false;

  recipes!: Recipe[];

}
