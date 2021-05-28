import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { onClose, toRegister } from '../../services/logination_routing';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['../../../../../styles/login.component.css']
})
export class LoginComponent {

  constructor(private router: Router){}

  onClose(): void{
    onClose(this.router);
  }

  toRegister(): void{
    toRegister(this.router);
  }


}
