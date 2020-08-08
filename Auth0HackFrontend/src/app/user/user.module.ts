import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { MatTabsModule } from '@angular/material/tabs';

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
    ],
    exports: [

    ],
    providers: [

    ],
})
export class UserPagesModule {

}
