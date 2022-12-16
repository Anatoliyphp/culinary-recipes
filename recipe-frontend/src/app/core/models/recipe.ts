import { Tag } from "./tag";

export interface Recipe{
  id: number,
  img: string,
  name: string,
  description: string,
  time: number,
  persons: number,
  likes: number,
  comments: number,
  isLike: boolean,
  favourites: number,
  isFavourite: boolean,
  userId: number,
  tags: Tag[]
  }