import { Component, OnInit, Input } from '@angular/core';
import { HorseStat } from 'src/app/modules/dto/horse-stat';

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.css']
})
export class StatisticsComponent implements OnInit {
  @Input() icon: string;
  @Input() label: string;
  @Input() value: string;
  @Input() colour: string;
  @Input() titleStyle: string;
  @Input() horseStats: HorseStat[] = [];
  constructor() { }

  ngOnInit() {
  }
}
