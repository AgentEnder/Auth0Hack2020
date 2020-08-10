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

    _selectedOffice: OfficeMetadata;
    set selectedOffice(v: OfficeMetadata){
        this._selectedOffice = v;
        if ('officeId' in v) {
            this.fetchMonthlyAvailability();
        }
    };

    get selectedOffice() {
        return this._selectedOffice;
    }
    
    @ViewChild('modalTemplate') template: TemplateRef<any>;
    
    public selectedDate: moment.Moment = moment();
    month: moment.Moment = moment(this.selectedDate);
    public dateData: OfficeDetailModel;
    public dateDataLoading = false;
    
    data: OfficeAvailabilityOverTime;
    loading = 0;
    officeList: OfficeMetadata[];
    filteredOffices: OfficeMetadata[];

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
        // this.fetchMonthlyAvailability();
        this.fetchOffices();
    }

    closeOpenMonthViewDay() {
        this.activeDayIsOpen = false;
    }

    fetchMonthlyAvailability() {
        const start = moment(this.selectedDate).startOf('month');
        this.month = start;
        const end = moment(this.selectedDate).endOf('month');
        this.data = null;
        this.loading++;
        this.officeService.getOfficeAvailabilityOverTime(
            start,
            end,
            this.selectedOffice.officeId
        ).subscribe(x => {
            this.data = x;
            this.loading--;
        });
    }

    shouldShow(day) {
        return moment(day.date).month() === this.month.month();
    }

    getOfficeUsedForDay(day): number {
        if (!this.data || !this.data.days) {
            return null;
        }
        const o = this.data.days.find(x => {
            // debugger;
            const dataDay = moment(x.date).startOf('day');
            const searchDay = moment(day.date).startOf('day');
            return dataDay.isSame(searchDay, 'day');
        });
        return o && o.count;
    }

    showDialogDay( day ) {
        const momentDate = moment(day.date);
        this.dateDataLoading = true;
        this.officeService.fetchOfficeDetailsForDay(momentDate, this.selectedOffice.officeId).subscribe(x => {
            this.dateData = x;
            this.dateDataLoading = false;
        });

        this.dialogService.open(this.template, {
            data: {
                day: momentDate
            },
            height: this.mobile ? '100%' : undefined,
            width: this.mobile ? '100%' : '50%'
        });
    }

    fetchOffices() {
        this.officeService.getOfficesOdata('?$orderby=officeName').subscribe(x => {
            this.officeList = x;
            this.filteredOffices = [...this.officeList];
        });
    }

    filterComplete(event) {
        if (typeof(event) === 'string'){
            this.filteredOffices = this._filter(event || '');
        }
    }

    private _filter(value: string): OfficeMetadata[] {
        const filterValue = value.toLowerCase();
        return this.officeList.filter(x => x.officeName.toLowerCase().indexOf(filterValue) >= 0);
    }

    getOfficeName = (office: OfficeMetadata) => office && `${office.officeName}`;
}
