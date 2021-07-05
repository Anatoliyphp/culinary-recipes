import { RIngridient } from "./ingridient";
import { RStep } from "./step";
import { Tag } from "./tag";

export interface FullRecipe{
    id: number,
    img: string,
    name: string,
    description: string,
    time: number,
    persons: number,
    likes: number,
    isLike: boolean,
    favourites: number,
    isFavourite: boolean,
    userId: number,
    tags: Tag[],
    ingridients: RIngridient[],
    steps: RStep[]
    }