import { Component, Input } from '@angular/core';
import { RStep } from '../../models/step';

@Component({
  selector: 'app-change-step',
  templateUrl: './full-step.component.html',
  styleUrls: ['../../../../styles/full-step.component.css']
})
export class FullStepComponent {

  @Input()
  step!: RStep;

}
