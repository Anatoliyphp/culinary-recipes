import { Router } from "@angular/router";

export function onClose(router: Router): void {
    router.navigate([{ outlets: { auth: null }}]);
}

export function toRegister(router: Router): void {
    router.navigate([{ outlets: { auth: 'registration' }}]);
}

export function toLogIn(router: Router): void {
    router.navigate([{ outlets: { auth: 'login' }}]);
}