import { Component, Input, ViewEncapsulation, OnInit, ViewChild, TemplateRef } from '@angular/core';

import { CalendarView } from 'angular-calendar';
import * as moment from 'moment';

import { OfficeAvailabilityOverTime } from '../../core/models/office-availability-over-time.model';
import { OfficeMetadata } from '../../core/models/office-metadata.model';
import { OfficesService } from '../../core/services/offices.service';
import { OfficeDetailModel } from 'src/app/core/models/office-detail.model';
import { MatDialog } from '@angular/material/dialog';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';

@Component({
    selector: 'app-office-availability-calendar',
    templateUrl: './office-availability-calendar.component.html',
    encapsulation: ViewEncapsulation.None
})
export class OfficeAvailabilityCalendarComponent implements OnInit {

    @Input() public office: OfficeMetadata;

    @ViewChild('modalTemplate') template: TemplateRef<any>;

    public selectedDate: moment.Moment = moment();
    data: OfficeAvailabilityOverTime;
    loading = 0;

    public get viewDate() {
        return this.selectedDate.toDate();
    }

    public set viewDate(val) {
        this.selectedDate = moment(val);
        this.fetchMonthlyAvailability();
    }

    view: CalendarView = CalendarView.Month;
    activeDayIsOpen = false;
    mobile = false;

    constructor(
        private officeService: OfficesService,
        private dialogService: MatDialog,
        private breakpoints: BreakpointObserver
    ) {
        this.breakpoints.observe(Breakpoints.Handset).subscribe(x => {
            this.mobile = x.matches;
        });
    }

    ngOnInit() {
        this.fetchMonthlyAvailability();
    }

    closeOpenMonthViewDay() {
        this.activeDayIsOpen = false;
    }

    fetchMonthlyAvailability() {
        const start = moment(this.selectedDate).startOf('month');
        const end = moment(this.selectedDate).endOf('month');
        this.data = null;
        this.loading++;
        this.officeService.getOfficeAvailabilityOverTime(
            start,
            end,
            this.office.officeId
        ).subscribe(x => {
            this.data = x;
            this.loading--;
        });
    }

    getOfficeForDay(day): OfficeDetailModel {
        if (!this.data || !this.data.days) {
            return null;
        }
        const o = this.data.days.find(x => {
            // debugger;
            const dataDay = moment(x.date).startOf('day');
            const searchDay = moment(day.date).startOf('day');
            return dataDay.isSame(searchDay, 'day');
        });
        return o && o.offices && o.offices[0];
    }

    showDialogDay(office, day) {
        this.dialogService.open(this.template, {
            data: {
                office,
                day: moment(day.date)
            },
            height: this.mobile ? '100%' : undefined,
            width: this.mobile ? '100%' : '50%'
        });
    }
}
