import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { Menu } from 'primeng/menu';
import { MenuItem } from "primeng/primeng";
import { Router } from "@angular/router";

declare var jQuery: any;

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit, AfterViewInit {

    menuItems: MenuItem[];
    miniMenuItems: MenuItem[];

    @ViewChild('bigMenu') bigMenu: Menu;
    @ViewChild('smallMenu') smallMenu: Menu;

    constructor(private router: Router) {
    }

    ngOnInit() {

        const handleSelected = event => {

            const allMenus = jQuery(event.originalEvent.target).closest('ul');
            const allLinks = allMenus.find('.menu-selected');
            const selected = jQuery(event.originalEvent.target).closest('a');

            allLinks.removeClass("menu-selected");
            selected.addClass('menu-selected');

        };

        this.menuItems = [
            {
                label: 'Dashboard',
                icon: 'fa fa-home',
                routerLink: ['/dashboard'],
                command: (event) => handleSelected(event)
            }
        ];
        this.miniMenuItems = [];
        this.menuItems.forEach((item: MenuItem) => {

            const miniItem = { icon: item.icon, routerLink: item.routerLink };

            this.miniMenuItems.push(miniItem);

        });
    }

    selectInitialMenuItemBasedOnUrl() {

        const path = document.location.pathname;
        const menuItem = this.menuItems.find((item) => { return item.routerLink[0] == path });

        if (menuItem) {

            const selectedIcon = this.bigMenu.containerViewChild.nativeElement.querySelector(`.${menuItem.icon}`);

            jQuery(selectedIcon).closest('li').addClass('menu-selected');
        }
    }

    ngAfterViewInit() {
        this.selectInitialMenuItemBasedOnUrl();
    }
}
