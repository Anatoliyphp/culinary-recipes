import { Location } from '@angular/common';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { onClose } from 'src/app/core/services/logination_routing';
import { AddRecipeService } from '../../services/addRecipeService';

@Component({
  selector: 'app-add-recipe',
  templateUrl: './add-recipe.component.html',
  styleUrls: ['../../../../../styles/add-recipe.component.css']
})
export class AddRecipeComponent {

  constructor(private router: Router, public addRecipeServ: AddRecipeService, private loc: Location){}

  onClose(){
    onClose(this.loc);
  }
}
