import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';

import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';

import { AdminOfficesPagesComponent } from './offices/offices.component';
import { AdminUsersPageComponent } from './users/users.component';
import { SectionComponent } from './offices/section.component';

const routes: Routes = [
    {
        path: 'users',
        component: AdminUsersPageComponent
    },
    {
        path: 'offices',
        component: AdminOfficesPagesComponent
    }
];

@NgModule({
    declarations: [
        AdminUsersPageComponent,
        AdminOfficesPagesComponent,
        SectionComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        MatButtonModule,
        MatCheckboxModule,
        MatInputModule,
        RouterModule.forChild(routes),
        MatFormFieldModule,
        MatIconModule,
        MatListModule
    ],
    exports: [

    ],
    providers: [

    ],
})
export class AdminModule{

}
