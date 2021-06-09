import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RStep } from '../../models/step';
import { toAddRecipe } from '../../services/logination_routing';

@Component({
  selector: 'app-change-step',
  templateUrl: './change-step.component.html',
  styleUrls: ['../../../../styles/change-step.component.css']
})
export class ChangeStepComponent {

  @Input()
  step!: RStep;

}
