import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { onClose, toRegister } from '../../../../core/services/logination_routing';
import { NgForm} from '@angular/forms';
import { AuthService } from '../../../../core/services/auth_service';
import {Location} from '@angular/common';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['../../../../../styles/login.component.css']
})
export class LoginComponent {

  constructor(private router: Router, private auth: AuthService, private loc: Location){}

  onClose(): void{
    this.loc.back();
  }

  toRegister(): void{
    toRegister(this.router);
  }

  Error: boolean = false;

  login(form: NgForm)
  {
    this.auth.login(form.value.login, form.value.password)
    .subscribe(res => {
      this.loc.go("/");
      location.reload();
      this.Error = false;
    }, error => {
      this.Error = true;
    })
  }
}
