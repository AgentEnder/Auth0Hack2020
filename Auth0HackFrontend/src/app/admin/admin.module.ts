import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminUsersPageComponent } from './users/users.component';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import {MatCheckboxModule} from '@angular/material/checkbox';

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
