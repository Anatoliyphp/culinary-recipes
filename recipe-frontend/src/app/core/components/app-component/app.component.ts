import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['../../../../styles/app.component.css']
})
export class AppComponent {

  logged = true;

  onFavourites = false;

  onActivate($event: any): void
  {
    window.scroll(0,0);
  }

}
