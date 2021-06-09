import { Component, Input, OnInit } from '@angular/core';
import { Stat } from '../../models/stat';

@Component({
  selector: 'app-stat',
  templateUrl: './stat.component.html',
  styleUrls: ['../../../../../styles/stat.component.css']
})
export class StatComponent {

  @Input()
  stat!: Stat;

}
