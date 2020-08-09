import { Component, Input } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { tap, take } from 'rxjs/operators';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-sidebar',
    templateUrl: './sidebar.component.html'
})
export class SidebarComponent {
    public show;

    mode = 'side';

    topGap = 64;

    public routes: MenuItem[] = [
        {
            path: '/',
            icon: 'home',
            label: 'Home'
        },
        {
            path: '/user/available-space',
            icon: 'business_center',
            label: 'Availability'
        },
        {
            path: '/user/pending-requests',
            icon: 'pending_actions',
            label: 'Pending Requests'
        },
        {
            path: '/admin',
            icon: 'admin_panel_settings',
            label: 'Admin',
            children: [
                {
                    path: '/admin/users',
                    icon: 'face',
                    label: 'Users'
                },
                {
                    path: '/admin/offices',
                    icon: 'apartment',
                    label: 'Offices'
                }
            ]
        },
        {
            path: '/safety',
            icon: 'warning',
            label: 'Safety',
            children: [
                {
                    path: '/safety/contact-tracing',
                    icon: 'business',
                    label: 'Contact Tracing'
                },
                {
                    path: '/safety/office-closures',
                    icon: 'location_disabled',
                    label: 'Closures'
                }
            ]
        }
    ];

    public toggleSidenav(){
        this.show = !this.show;
    }

    constructor(private breakpoints: BreakpointObserver, public activatedRoute: ActivatedRoute){
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

export interface MenuItem{
    icon: string;
    label: string;
    path?: string;
    children?: MenuItem[];
}
