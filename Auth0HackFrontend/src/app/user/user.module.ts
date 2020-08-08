import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { MatTabsModule } from '@angular/material/tabs';
import { MatTableModule, MatTable } from '@angular/material/table';

import { SharedModule } from '../shared/shared.module';
import {
    UserSectionAvailabilityPageComponent
} from './section-availability/section-availability.component';
import { PendingRequestsComponent } from './pending-requests/pending-requests.component';

const routes: Routes = [
    {
        path: 'available-space',
        component: UserSectionAvailabilityPageComponent
    },
    {
        path: 'pending-requests',
        component: PendingRequestsComponent
    }
];

@NgModule({
    declarations: [
        UserSectionAvailabilityPageComponent,
        PendingRequestsComponent
    ],
    imports: [
        CommonModule,
        RouterModule.forChild(routes),
        SharedModule,
        MatTabsModule,
        MatTableModule
    ],
    exports: [

    ],
    providers: [

    ],
})
export class UserPagesModule {

}
