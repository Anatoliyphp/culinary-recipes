import { Component, Input, OnInit } from '@angular/core';
import { Step } from '../../models/step';
import { AddRecipeService } from '../../services/addRecipeService';

@Component({
  selector: 'app-step',
  templateUrl: './step.component.html',
  styleUrls: ['../../../../../styles/step.component.css']
})
export class StepComponent {

  constructor(public addRecipeServ: AddRecipeService){}

  @Input()
  step!: Step;

  

}
