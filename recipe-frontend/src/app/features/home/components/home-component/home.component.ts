import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/services/auth_service';
import { onClose, toRegister } from 'src/app/core/services/logination_routing';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['../../../../../styles/home.component.css']
})
export class HomeComponent {

  constructor(private router: Router, private auth: AuthService){}

  onAddRecipe()
  {
    if (this.auth.isAuthenticated())
    {
      onClose(this.router);
    }
    else
    {
      toRegister(this.router);
    }
  }

}
