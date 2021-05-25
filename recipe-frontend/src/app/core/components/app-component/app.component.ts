import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['../../../../styles/app.component.css']
})
export class AppComponent {

  onFavourites = false;

  onActivate($event: any): void
  {
    window.scroll(0,0);
  }

}
