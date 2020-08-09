import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';

import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatDialogModule } from '@angular/material/dialog';
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
        MatDatepickerModule,
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
