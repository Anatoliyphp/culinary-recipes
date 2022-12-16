import { Router } from "@angular/router";
import { Location } from '@angular/common';

export function onClose(loc: Location): void {
    loc.back();
}

export function toRegister(router: Router): void {
    router.navigate([{ outlets: { auth: 'registration' }}]);
}

export function toLogIn(router: Router): void {
    router.navigate([{ outlets: { auth: 'login' }}]);
}

export function toAddRecipe(router: Router): void{
    router.navigate(["add"]);
}

export function toChangeRecipe(router: Router, recipeId: number): void{
    router.navigate(['recipe', recipeId]);
}

export function toEditRecipe(router: Router, recipeId: any): void{
    router.navigate(['edit', recipeId]);
}

export function toAuthorize(router: Router): void{
    router.navigate([{outlets: {auth: 'authorize'}}])
}

export function goBack(location: Location): void{
    location.back();
}

export function toProfile(router: Router, userId: number): void{
    router.navigate(['profile', userId])
}