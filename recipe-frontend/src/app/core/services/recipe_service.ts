import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { from, Observable } from "rxjs";
import { BestRecipe } from "src/app/features/home/models/best-recipe";
import { UserStats } from "src/app/features/profile/models/stat";
import { idGetter } from "../app.module";
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

        let formData: FormData = new FormData();
         formData.append("img", img, img.name);
         formData.append("name", name);
         formData.append("description", description);
         formData.append("time", JSON.stringify(time));
         formData.append("persons", JSON.stringify(persons));
         formData.append("likes", JSON.stringify(likes));
         formData.append("isLike", JSON.stringify(isLike));
         formData.append("favourites", JSON.stringify(favourites));
         formData.append("isFavourite", JSON.stringify(isFavourite));
         formData.append("userId", JSON.stringify(userId));
         let i: number = 0;
         tags.forEach(element => {
             formData.append("tags[" + i + "]", element);
             i++;
         });
         i = 0;
         steps.forEach(element => {
             formData.append("steps[" + i + "].name", JSON.stringify(element.name));
             formData.append("steps[" + i + "].desc", JSON.stringify(element.desc));
             i++;
         })
         i = 0;
         ingridients.forEach(element => {
             formData.append("ingridients[" + i + "].name", JSON.stringify(element.name));
             formData.append("ingridients[" + i + "].list", JSON.stringify(element.list));
             i++;
         })
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

        let formData: FormData = new FormData();
         formData.append("img", img, img.name);
         formData.append("name", name);
         formData.append("description", description);
         formData.append("time", JSON.stringify(time));
         formData.append("persons", JSON.stringify(persons));
         formData.append("likes", JSON.stringify(likes));
         formData.append("isLike", JSON.stringify(isLike));
         formData.append("favourites", JSON.stringify(favourites));
         formData.append("isFavourite", JSON.stringify(isFavourite));
         formData.append("userId", JSON.stringify(userId));//foreach
         let i: number = 0;
         tags.forEach(element => {
             formData.append("tags[" + i + "]", element);
             i++;
         });
         i = 0;
         steps.forEach(element => {
             formData.append("steps[" + i + "].name", JSON.stringify(element.name));
             formData.append("steps[" + i + "].desc", JSON.stringify(element.desc));
             i++;
         })
         i = 0;
         ingridients.forEach(element => {
             formData.append("ingridients[" + i + "].name", JSON.stringify(element.name));
             formData.append("ingridients[" + i + "].list", JSON.stringify(element.list));
             i++;
         })
        return this.http.post<any>("api/recipes/add", formData);
    }

    getAllTags(): Observable<Tag[]>{
        return this.http.get<Tag[]>("api/recipes/allTags");
    }

    getSearchingRecipes(tagIds: number[], name: string): Observable<Recipe[]>{
        return this.http.post<Recipe[]>("api/recipes/search/" + idGetter(), {tagIds, name})
    }

}