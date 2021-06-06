import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { onClose, toRegister } from '../../../../core/services/logination_routing';
import { NgForm} from '@angular/forms';
import { AuthService } from '../../../../core/services/auth_service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['../../../../../styles/login.component.css']
})
export class LoginComponent {

  constructor(private router: Router, private auth: AuthService){}

  onClose(): void{
    onClose(this.router);
  }

  toRegister(): void{
    toRegister(this.router);
  }

  login(form: NgForm)
  {
    this.auth.login(form.value.login, form.value.password)
    .subscribe(res => {
      this.onClose()
      location.reload()
    }, error => {
      alert("Wrong login or password")
    })
  }
}
