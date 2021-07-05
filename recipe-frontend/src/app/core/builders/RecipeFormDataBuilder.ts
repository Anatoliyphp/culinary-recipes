import { RIngridient } from "../models/ingridient";
import { RStep } from "../models/step";

export function RecipeFormDataBuilder(
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
): FormData
{
    let formData: FormData = new FormData();
    if (img != null)
    {
     formData.append("img", img, img.name);
    }
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
         formData.append("steps[" + i + "].name", element.name);
         formData.append("steps[" + i + "].desc", element.desc);
         i++;
     })
     i = 0;
     ingridients.forEach(element => {
         formData.append("ingridients[" + i + "].name", element.name);
         formData.append("ingridients[" + i + "].list", element.list);
         i++;
     })
     return formData;
}