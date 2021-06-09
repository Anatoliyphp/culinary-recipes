import { Component, OnInit } from '@angular/core';
import { ACCESS_TOKEN_KEY, AuthService } from '../../../core/services/auth_service';
import { nameGetter } from '../../app.module';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['../../../../styles/app.component.css']
})
export class AppComponent {

  constructor(public auth: AuthService){}

  name = nameGetter();

  logged = true;

  onFavourites = true;

  onActivate($event: any): void
  {
    window.scroll(0,0);
  }

}
