import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { BestRecipe } from "src/app/features/home/models/best-recipe";
import { idGetter } from "../app.module";
import { Recipe } from "../models/recipe";

@Injectable({
    providedIn: 'root'
})

export class RecipeService{

    constructor(private http: HttpClient){}

    getBestRecipe(): Observable<BestRecipe>{
        return this.http.post<BestRecipe>("api/recipes/bestRecipe", {});
    }

    getAllRecipes(): Observable<Recipe[]>{
        return this.http.get<Recipe[]>("api/recipes/allRecipes/" + idGetter());
    }

    getFavourites(): Observable<Recipe[]>{
        return this.http.get<Recipe[]>("api/recipes/favourites/" + idGetter());
    }

    getUserRecipes(): Observable<Recipe[]>{
        return this.http.get<Recipe[]>("api/recipes/userRecipes/" + idGetter());
    }

}