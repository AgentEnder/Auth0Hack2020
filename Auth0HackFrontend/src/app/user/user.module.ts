import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatTable, MatTableModule } from '@angular/material/table';
import { MatTabsModule } from '@angular/material/tabs';

import { SharedModule } from '../shared/shared.module';
import { PendingRequestsComponent } from './pending-requests/pending-requests.component';
import {
    UserSectionAvailabilityPageComponent
} from './section-availability/section-availability.component';
import { FormsModule } from '@angular/forms';
import { MatDialogModule } from '@angular/material/dialog';
import { MatCardModule } from '@angular/material/card';

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
        FormsModule,
        SharedModule,
        MatTabsModule,
        MatTableModule,
        MatButtonModule,
        MatPaginatorModule,
        MatCardModule,
        MatInputModule,
        MatDialogModule,
        MatSortModule
    ],
    exports: [

    ],
    providers: [

    ],
})
export class UserPagesModule {

}
