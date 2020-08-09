import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { SharedModule } from '../shared/shared.module';
import { ContactTracingComponent } from './contact-tracing/contact-tracing.component';

const routes: Routes = [
    {
        component: ContactTracingComponent,
        path: 'contact-tracing'
    }
];

@NgModule({
    declarations: [
        ContactTracingComponent
    ],
    imports: [
        CommonModule,
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
