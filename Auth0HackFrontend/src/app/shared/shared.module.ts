import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatTooltipModule } from '@angular/material/tooltip';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';

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
import { FormsModule } from '@angular/forms';

export function momentAdapterFactory() {
  return adapterFactory(moment);
}

@NgModule({
    declarations: [
        BuildingAvailabilityComponent,
        PercentageComponent,
        OfficeAvailabilityCalendarComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        MatCardModule,
        MatListModule,
        MatIconModule,
        MatButtonModule,
        MatTooltipModule,
        MatProgressSpinnerModule,
        MatDialogModule,
        MatInputModule,
        MatFormFieldModule,
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
