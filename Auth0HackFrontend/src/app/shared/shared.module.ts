import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatTooltipModule } from '@angular/material/tooltip';

import { CalendarModule, DateAdapter } from 'angular-calendar';
import { adapterFactory } from 'angular-calendar/date-adapters/moment';
import * as moment from 'moment';

import {
    BuildingAvailabilityComponent
} from './building-availabilty-card/building-availability.component';
import {
    OfficeAvailabilityCalendarComponent
} from './office-availability-calendar/office-availability-calendar.component';
import { PercentageComponent } from './percentage/percentage.component';

export function momentAdapterFactory() {
  return adapterFactory(moment);
};

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
        CalendarModule.forRoot({ provide: DateAdapter, useFactory: momentAdapterFactory })
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
