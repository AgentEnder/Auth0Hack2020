import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { MatTabsModule } from '@angular/material/tabs';

import { ScheduleModule } from '@syncfusion/ej2-angular-schedule';

import { SharedModule } from '../shared/shared.module';
import {
    UserSectionAvailabilityPageComponent
} from './section-availability/section-availability.component';

const routes: Routes = [
    {
        path: 'available-space',
        component: UserSectionAvailabilityPageComponent
    }
];

@NgModule({
    declarations: [
        UserSectionAvailabilityPageComponent
    ],
    imports: [
        CommonModule,
        RouterModule.forChild(routes),
        SharedModule,
        MatTabsModule,
        ScheduleModule
    ],
    exports: [

    ],
    providers: [

    ],
})
export class UserPagesModule {

}
