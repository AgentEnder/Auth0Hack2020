import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatTooltipModule } from '@angular/material/tooltip';

import { ScheduleModule } from '@syncfusion/ej2-angular-schedule';

import {
    BuildingAvailabilityComponent
} from './building-availabilty-card/building-availability.component';
import {
    OfficeAvailabilityCalendarComponent
} from './office-availability-calendar/office-availability-calendar.component';
import { PercentageComponent } from './percentage/percentage.component';

@NgModule({
    declarations: [
        BuildingAvailabilityComponent,
        PercentageComponent,
        OfficeAvailabilityCalendarComponent
    ],
    imports: [
        CommonModule,
        MatCardModule,
        MatListModule,
        MatIconModule,
        MatButtonModule,
        MatTooltipModule,
        ScheduleModule
    ],
    exports: [
        BuildingAvailabilityComponent,
        PercentageComponent,
        OfficeAvailabilityCalendarComponent
    ],
    providers: [
    ]
})
export class SharedModule {

}
