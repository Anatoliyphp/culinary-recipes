import { Location } from '@angular/common';
import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/services/auth_service';
import { onClose, toLogIn } from '../../../../core/services/logination_routing';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['../../../../../styles/registration.component.css']
})
export class RegistrationComponent {

  constructor(private router: Router, private auth: AuthService, private loc: Location){}

  onClose():void{
    onClose(this.loc);
  }

  toLogIn(): void{
    toLogIn(this.router);
  }

  Error: boolean = false;
  ConfirmPasswordsError: boolean = false;

  registration(form: NgForm)
  {
    if (form.value.password == form.value.passwordCheck)
    {
      if (!form.invalid){
        this.ConfirmPasswordsError = false;
        this.auth.register(form.value.login, form.value.name, form.value.password)
        .subscribe(res => {
          this.loc.go("/");
          location.reload();
          this.Error = false;
        }, error => {
          this.Error = true;
          this.ConfirmPasswordsError = false;
        })
      } else {
        this.Error = true;
        this.ConfirmPasswordsError = false;
      }
    }
    else {
      this.ConfirmPasswordsError = true;
      this.Error = false;
    }
  }

}
