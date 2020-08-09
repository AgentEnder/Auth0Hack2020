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
        MatFormFieldModule,
        MatInputModule,
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
