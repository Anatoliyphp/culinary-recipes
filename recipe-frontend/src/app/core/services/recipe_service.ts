import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { from, Observable } from "rxjs";
import { BestRecipe } from "src/app/features/home/models/best-recipe";
import { UserStats } from "src/app/features/profile/models/stat";
import { idGetter } from "../app.module";
import { RecipeFormDataBuilder } from "../builders/RecipeFormDataBuilder";
import { FullRecipe } from "../models/fullrecipe";
import { RIngridient } from "../models/ingridient";
import { Recipe } from "../models/recipe";
import { RStep } from "../models/step";
import { Tag } from "../models/tag";

@Injectable({
    providedIn: 'root'
})

export class RecipeService{

    constructor(private http: HttpClient){}

    recipes!: Recipe[];

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

    getFullRecipe(recipeId: any): Observable<FullRecipe>{
        return this.http.get<FullRecipe>("api/recipes/fullrecipe/" + idGetter() + "/" + recipeId);
    }

    deleteRecipe(recipeId: any): Observable<any>{
        return this.http.get("api/recipes/delete/" + recipeId);
    }

    getUserRecipesStats(): Observable<UserStats>{
        return this.http.get<UserStats>("api/recipes/stats/" + idGetter());
    }

    editRecipe(
        id: number,
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
        JSON.stringify(ingridients.forEach(element => {
            element.list = element.list.split("\n").join("\\n");
        }));

        var formData: FormData = RecipeFormDataBuilder(
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
        );
        return this.http.post<Recipe>("api/recipes/edit/" + id, formData);
    }

    addRecipe(
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
    ): Observable<any>
    {
        JSON.stringify(ingridients.forEach(element => {
            element.list = element.list.split("\n").join("\\n");
        }));

        var formData: FormData = RecipeFormDataBuilder(
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
        );
        return this.http.post<any>("api/recipes/add", formData);
    }

    getAllTags(): Observable<Tag[]>{
        return this.http.get<Tag[]>("api/recipes/allTags");
    }

    getSearchingRecipes(tagIds: number[], name: string): Observable<Recipe[]>{
        return this.http.post<Recipe[]>("api/recipes/search/" + idGetter(), {tagIds, name})
    }

}