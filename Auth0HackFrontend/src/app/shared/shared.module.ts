import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatTooltipModule } from '@angular/material/tooltip';

import {
    BuildingAvailabilityComponent
} from './building-availabilty/building-availability.component';
import { PercentageComponent } from './percentage/percentage.component';
import { MatButtonModule } from '@angular/material/button';

@NgModule({
    declarations: [
        BuildingAvailabilityComponent,
        PercentageComponent
    ],
    imports: [
        CommonModule,
        MatCardModule,
        MatListModule,
        MatIconModule,
        MatButtonModule,
        MatTooltipModule
    ],
    exports: [
        BuildingAvailabilityComponent,
        PercentageComponent
    ],
    providers: [
    ]
})
export class SharedModule {

}
