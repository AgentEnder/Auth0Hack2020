import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatTooltipModule } from '@angular/material/tooltip';

import { CalendarModule, DateAdapter } from 'angular-calendar';
import { adapterFactory } from 'angular-calendar/date-adapters/moment';
import * as moment from 'moment';

import {
    BuildingAvailabilityComponent
} from './building-availabilty-card/building-availability.component';
import { DragDropDirective } from './directives/drag-drop.directive';
import {
    OfficeAvailabilityCalendarComponent
} from './office-availability-calendar/office-availability-calendar.component';
import { PercentageComponent } from './percentage/percentage.component';

export function momentAdapterFactory() {
  return adapterFactory(moment);
}

@NgModule({
    declarations: [
        BuildingAvailabilityComponent,
        PercentageComponent,
        OfficeAvailabilityCalendarComponent,
        DragDropDirective
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
        MatAutocompleteModule,
        CalendarModule.forRoot({ provide: DateAdapter, useFactory: momentAdapterFactory })
    ],
    exports: [
        BuildingAvailabilityComponent,
        PercentageComponent,
        OfficeAvailabilityCalendarComponent,
        DragDropDirective
    ],
    providers: [
    ]
})
export class SharedModule {

}
