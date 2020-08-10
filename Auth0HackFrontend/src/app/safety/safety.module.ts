import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { SharedModule } from '../shared/shared.module';
import { ContactTracingComponent } from './contact-tracing/contact-tracing.component';
import { OfficeClosuresComponent } from './office-closures/office-closures.component';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';

const routes: Routes = [
    {
        component: ContactTracingComponent,
        path: 'contact-tracing'
    },
    {
        component: OfficeClosuresComponent,
        path: 'office-closures'
    }
];

@NgModule({
    declarations: [
        ContactTracingComponent,
        OfficeClosuresComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        MatAutocompleteModule,
        MatButtonModule,
        MatCheckboxModule,
        MatInputModule,
        MatFormFieldModule,
        MatIconModule,
        MatListModule,
        MatDatepickerModule,
        SharedModule,
        RouterModule.forChild(routes)
    ],
    exports: [

    ],
    providers: [

    ]
})
export class SafetyModule {
}
