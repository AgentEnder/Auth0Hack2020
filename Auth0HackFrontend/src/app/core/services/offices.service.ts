import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Moment } from 'moment';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from '../../../environments/environment';
import { OfficeAvailabilityOverTime } from '../models/office-availability-over-time.model';
import { OfficeDetailModel } from '../models/office-detail.model';
import { SampleOfficeDetail } from './sample-data';

const OFFICE_AVAILABILITY_OVER_TIME = (start, end, officeId) => `/api/offices/by-id/${officeId}/${start}/${end}`;

@Injectable({
    providedIn: 'root'
})
export class OfficesService {
    baseUrl: string;
    constructor(private httpClient: HttpClient) {
        this.baseUrl = environment.apiUrl;
    }

    getOfficeDetails() {
        return of(SampleOfficeDetail).pipe(map(x => [x, x, x, x, x, x, x, x, x, x, x]));
    }

    getOfficeAvailabilityOverTime(startDate: Moment, endDate: Moment, officeId) {
        const url = this.baseUrl + OFFICE_AVAILABILITY_OVER_TIME(
            startDate.toISOString(),
            endDate.toISOString(),
            officeId
        );
        return this.httpClient.get<OfficeDetailModel[]>(url).pipe(
            map((x: OfficeDetailModel[]): OfficeAvailabilityOverTime => {
                return {
                    startDate,
                    endDate,
                    days: x.map(y => ({
                       date: y.snapshotDate,
                       offices: [y]
                    }))
                };
            })
        );
    }
}
