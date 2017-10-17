import { Component, OnInit, Input } from '@angular/core';
import { HorseStat } from '../../dashboard/dto/horse-stat';

@Component({
  selector: 'app-statistic',
  templateUrl: './statistic.component.html',
  styleUrls: ['./statistic.component.css']
})
export class StatisticComponent implements OnInit {
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
