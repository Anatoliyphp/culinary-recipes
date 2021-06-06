import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { JwtHelperService } from "@auth0/angular-jwt";
import { Observable } from "rxjs";
import { Token } from "src/app/core/models/token";
import { tap } from 'rxjs/operators';

export const ACCESS_TOKEN_KEY = "recipe_access_token";
export const USER_NAME = "user_name";

@Injectable({
    providedIn: 'root'
})
export class AuthService {

    constructor(
        private http: HttpClient,
        private jwtHelper: JwtHelperService,
        private router: Router
    ){}

    login(login: string, password: string): Observable<Token>
    {
        return this.http.post<Token>("/api/account/login",{
            login, password
        }).pipe(
            tap(token => {
                localStorage.setItem(ACCESS_TOKEN_KEY, token.access_token);
                localStorage.setItem(USER_NAME, token.name);
            })
        )
    }

    register(login: string, name: string, password: string): Observable<Token>
    {
        return this.http.post<Token>("/api/account/register",{
            login, name, password
        }).pipe(
            tap(token => {
                localStorage.setItem(ACCESS_TOKEN_KEY, token.access_token);
                localStorage.setItem(USER_NAME, token.name);
            })
        )
    }

    isAuthenticated(): any
    {
        var token = localStorage.getItem(ACCESS_TOKEN_KEY);
        return token && !this.jwtHelper.isTokenExpired(token);
    }

    logout(): void
    {
        localStorage.removeItem(ACCESS_TOKEN_KEY);
        localStorage.removeItem(USER_NAME);
        this.router.navigate(['']);
    }
}