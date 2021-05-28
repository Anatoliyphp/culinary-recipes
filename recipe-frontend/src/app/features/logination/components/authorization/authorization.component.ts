import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { toLogIn, toRegister } from '../../services/logination_routing';

@Component({
  selector: 'app-authorization',
  templateUrl: './authorization.component.html',
  styleUrls: ['../../../../../styles/authorization.component.css']
})
export class AuthorizationComponent {

  constructor(private router: Router){}

  toRegister(): void{
    toRegister(this.router);
  }

  toLogIn(): void{
    toLogIn(this.router);
  }

}
