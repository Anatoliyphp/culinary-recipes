import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { JwtHelperService } from "@auth0/angular-jwt";
import { Observable } from "rxjs";
import { Token } from "src/app/core/models/token";
import { tap } from 'rxjs/operators';
import { User } from "src/app/features/profile/models/user";

export const ACCESS_TOKEN_KEY = "recipe_access_token";
export const USER_NAME = "user_name";
export const USER_ID = "userId";

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
                localStorage.setItem(USER_ID, token.id.toString());
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
                localStorage.setItem(USER_ID, token.id.toString());
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
        localStorage.removeItem(USER_ID);
        this.router.navigate(['']);
    }

    getUser(id: number): Observable<User> {
        return this.http.get<User>('api/account/getUser/' + id);
      }

    getAllUsers(): Observable<User[]>{
        return this.http.get<User[]>('api/account/getAllUsers');
    }

    searchUsers(filter: number, name: string): Observable<User[]>{
        return this.http.post<User[]>('api/account/searchUsers/' + filter, {name});
    }

    editUser(id: number, login: string, password: string, name: string, about: string): Observable<User>{
        return this.http.post<User>("api/account/editUser", {
            id, login, password, name, about
        });
    }
}