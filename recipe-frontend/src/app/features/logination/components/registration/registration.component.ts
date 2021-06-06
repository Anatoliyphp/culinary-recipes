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

  constructor(private router: Router, private auth: AuthService){}

  onClose():void{
    onClose(this.router);
  }

  toLogIn(): void{
    toLogIn(this.router);
  }

  registration(form: NgForm)
  {
    this.auth.register(form.value.login, form.value.name, form.value.password)
    .subscribe(res => {
      location.reload()
      this.onClose()
    }, error => {
      alert("Failed")
    })
  }

}
