import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { RStep } from 'src/app/core/models/step';
import { Step } from '../../models/step';

@Component({
  selector: 'app-step',
  templateUrl: './step.component.html',
  styleUrls: ['../../../../../styles/step.component.css']
})
export class StepComponent {

  @Output() childComponentValue = new EventEmitter<any>();

  constructor(){}

  @Input()
  step!: RStep;
  @Input()
  index!: number;

  onDelete(){
    this.childComponentValue.emit(this.index);
  }

}
