import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { MenuItem } from 'primeng/primeng';

@Component({
  selector: 'app-modules',
  templateUrl: './modules.component.html',
  styleUrls: ['./modules.component.css']
})
export class ModulesComponent implements OnInit {

  menuItems: MenuItem[];
  miniMenuItems: MenuItem[];

  ngOnInit() {

    this.menuItems = [
      { label: 'Dashboard', icon: 'fa fa-home', routerLink: [''], routerLinkActiveOptions: { exact: true } }
    ];
    this.miniMenuItems = [];
    this.menuItems.forEach((item: MenuItem) => {

      const miniItem = { icon: item.icon, routerLink: item.routerLink };

      this.miniMenuItems.push(miniItem);

    });
  }
}
