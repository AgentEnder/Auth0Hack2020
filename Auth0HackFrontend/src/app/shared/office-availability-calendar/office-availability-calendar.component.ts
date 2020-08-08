import { Component, ViewEncapsulation } from '@angular/core';
import { CalendarView } from 'angular-calendar';


@Component({
    selector: 'app-office-availability-calendar',
    templateUrl: './office-availability-calendar.component.html',
    encapsulation: ViewEncapsulation.None
})
export class OfficeAvailabilityCalendarComponent {

    public selectedDate: Date = new Date();
    view: CalendarView = CalendarView.Month;
    activeDayIsOpen = true;

    closeOpenMonthViewDay() {
        this.activeDayIsOpen = false;
    }
}
