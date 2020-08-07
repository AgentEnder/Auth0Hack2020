import { Component, Input } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';

@Component({
    selector: 'app-sidebar',
    templateUrl: './sidebar.component.html'
})
export class SidebarComponent {
    @Input() public show = true;

    mode = 'side';

    constructor(private breakpoints: BreakpointObserver){
        breakpoints.observe([Breakpoints.Handset]).subscribe( ({ matches }) => {
            this.mode = matches ? 'over' : 'side';
            console.log(matches);
        });
    }
}