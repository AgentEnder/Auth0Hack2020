import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserSectionAvailabilityPageComponent } from './section-availability/section-availability.component';
import { SharedModule } from '../shared/shared.module';
import { CommonModule } from '@angular/common';

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
        SharedModule
    ],
    exports: [

    ],
    providers: [

    ],
})
export class UserPagesModule {

}
