import { Router } from "@angular/router";
import { Location } from '@angular/common';

export function onClose(router: Router): void {
    router.navigate([{ outlets: { auth: null }}]);
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

export function toChangeRecipe(router: Router): void{
    router.navigate(["recipe/:id"]);
}

export function toEditRecipe(router: Router): void{
    router.navigate(["edit/:id"]);
}

export function toAuthorize(router: Router): void{
    router.navigate([{outlets: {auth: 'authorize'}}])
}

export function goBack(location: Location): void{
    location.back();
}