import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Moment } from 'moment';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from '../../../environments/environment';
import { OfficeAvailabilityOverTime } from '../models/office-availability-over-time.model';
import { OfficeDetailModel } from '../models/office-detail.model';
import { SampleOfficeDetail } from './sample-data';
import { OfficeMetadata } from '../models/office-metadata.model';
import { SectionMetadata } from '../models/section-metadata.model';
import { OfficeCounts } from '../models/office-counts.model';

const OFFICE_AVAILABILITY_OVER_TIME = (start, end, officeId) => `/api/offices/by-id/${officeId}/${start}/${end}`;
const OFFICE_ODATA = '/api/offices';
const SECTION_ODATA = '/api/offices/sections';
const OFFICE_AVAILABILITY_BY_DATE = (start) => `/api/offices/${start}`;
const OFFICE_DETAIL_BY_DATE = (start, officeId) => `/api/offices/by-id/${officeId}/${start}`;

@Injectable({
    providedIn: 'root'
})
export class OfficesService {

    baseUrl: string;
    constructor(private httpClient: HttpClient) {
        this.baseUrl = environment.apiUrl;
    }

    getOffices() {
        const url = this.baseUrl + OFFICE_ODATA;
        return this.httpClient.get<OfficeMetadata[]>(url);
    }

    getOfficesOdata(odata) {
        const url = this.baseUrl + OFFICE_ODATA + odata;
        return this.httpClient.get<OfficeMetadata[]>(url);
    }

    getSections(officeId) {
        const url = this.baseUrl + SECTION_ODATA + '?$filter=officeId eq ' + officeId;
        return this.httpClient.get<SectionMetadata[]>(url);
    }

    getOfficeDetails() {
        return of(SampleOfficeDetail).pipe(map(x => [x, x, x, x, x, x, x, x, x, x, x]));
    }

    getOfficeDetailsByDate(date: Moment) {
        return this.httpClient.get<OfficeDetailModel[]>(this.baseUrl + OFFICE_AVAILABILITY_BY_DATE(date.toISOString()));
    }

    getOfficeAvailabilityOverTime(startDate: Moment, endDate: Moment, officeId) {
        const url = this.baseUrl + OFFICE_AVAILABILITY_OVER_TIME(
            startDate.toISOString(),
            endDate.toISOString(),
            officeId
        );
        return this.httpClient.get<OfficeCounts[]>(url).pipe(
            map((x: OfficeCounts[]): OfficeAvailabilityOverTime => {
                return {
                    startDate,
                    endDate,
                    days: x.map(y => ({
                       date: y.startTime,
                       count: y.approvedCount
                    }))
                };
            })
        );
    }

    fetchOfficeDetailsForDay(momentDate: Moment, officeId: string) {
        return this.httpClient.get<OfficeDetailModel>(this.baseUrl + OFFICE_DETAIL_BY_DATE(momentDate.toISOString(), officeId));
    }

    saveOffice(office: OfficeMetadata) {
        const url = this.baseUrl + OFFICE_ODATA;
        return this.httpClient.post<OfficeMetadata>(url, office);
    }

    saveSection(section: SectionMetadata) {
        const url = this.baseUrl + SECTION_ODATA;
        return this.httpClient.post<SectionMetadata>(url, section);
    }
}
