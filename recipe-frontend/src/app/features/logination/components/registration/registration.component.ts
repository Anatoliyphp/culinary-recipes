import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { onClose, toLogIn } from '../../services/logination_routing';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['../../../../../styles/registration.component.css']
})
export class RegistrationComponent {

  constructor(private router: Router){}

  onClose():void{
    onClose(this.router);
  }

  toLogIn(): void{
    toLogIn(this.router);
  }

}
