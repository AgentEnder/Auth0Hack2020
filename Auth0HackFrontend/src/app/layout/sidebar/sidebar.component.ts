import { Component, Input } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { tap, take } from 'rxjs/operators';

@Component({
    selector: 'app-sidebar',
    templateUrl: './sidebar.component.html'
})
export class SidebarComponent {
    public show;

    mode = 'side';

    topGap = 64;

    links: {
        path: string,
        icon: string,
        label: string
    }[] = [
        {
            path: '/',
            icon: 'home',
            label: 'Home'
        }
    ];

    public toggleSidenav(){
        this.show = !this.show;
    }

    constructor(private breakpoints: BreakpointObserver){
        breakpoints.observe([Breakpoints.Handset]).subscribe( ({ matches }) => {
            if (matches) { // Mobile
                this.mode = 'over';
                this.topGap = 56;
                this.show = false;
            } else {
                this.mode = 'side';
                this.topGap = 64;
                this.show = true;
            }
            console.log('Mobile: ', matches);
        });
    }
}