import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminUsersPageComponent } from './users/users.component';

const routes: Routes = [
    {
        path: 'users',
        component: AdminUsersPageComponent
    }
];

@NgModule({
    declarations: [
        AdminUsersPageComponent
    ],
    imports: [
        RouterModule.forChild(routes),
    ],
    exports: [

    ],
    providers: [

    ],
})
export class AdminModule{

}
