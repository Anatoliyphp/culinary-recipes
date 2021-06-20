import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { BestRecipe } from "src/app/features/home/models/best-recipe";
import { UserStats } from "src/app/features/profile/models/stat";
import { idGetter } from "../app.module";
import { RIngridient } from "../models/ingridient";
import { Recipe } from "../models/recipe";
import { RStep } from "../models/step";

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

    addToFavourites(recipeId: number): Observable<any>{
        return this.http.get("api/recipes/addFavourites/" + idGetter() + "/" + recipeId);
    }

    removeFromRavourites(recipeId: number): Observable<any>{
        return this.http.get("api/recipes/deleteFavourites/" + idGetter() + "/" + recipeId);
    }

    addLike(recipeId: number): Observable<any>{
        return this.http.get("api/recipes/addLike/" + idGetter() + "/" + recipeId);
    }

    removeLike(recipeId: number): Observable<any>{
        return this.http.get("api/recipes/removeLike/" + idGetter() + "/" + recipeId);
    }

    getFullRecipe(recipeId: any): Observable<any>{
        return this.http.get<any>("api/recipes/fullrecipe/" + idGetter() + "/" + recipeId);
    }

    deleteRecipe(recipeId: any): Observable<any>{
        return this.http.get("api/recipes/delete/" + recipeId);
    }

    getUserRecipesStats(): Observable<UserStats>{
        return this.http.get<UserStats>("api/recipes/stats/" + idGetter());
    }

    editRecipe(
        img: File,
        name: string,
	    description: string,
		time: number,
		persons: number,
	    likes: number,
		isLike: boolean,
		favourites: number,
		isFavourite: boolean,
		userId: number,
		tags: string[],
		ingridients: RIngridient[],
		steps: RStep[]
    ): Observable<Recipe>
    {
        return this.http.post<Recipe>("api/recipes/edit", {
            img,
            name,
	        description,
		    time,
		    persons,
	        likes,
		    isLike,
		    favourites,
		    isFavourite,
		    userId,
		    tags,
		    ingridients,
		    steps
        })
    }

}