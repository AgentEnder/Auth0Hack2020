import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Moment } from 'moment';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from '../../../environments/environment';
import { SampleOfficeDetail } from './sample-data';
import { EmployeeMetadata } from '../models/employee-metadata.model';
import { EmployeeContactTrace } from '../models/employee-contact-trace.model';

const EMPLOYEES = '/api/employees';
const CONTACT_TRACE = '/api/employees/contact-trace';

@Injectable({
    providedIn: 'root'
})
export class EmployeesService {
    baseUrl: string;
    constructor(private httpClient: HttpClient) {
        this.baseUrl = environment.apiUrl;
    }

    getEmployeeList(options) {
        const url = this.baseUrl + EMPLOYEES + options;
        return this.httpClient.get<EmployeeMetadata[]>(url);
    }

    getContactTraceEmployeeList(employeeId, startTime, endTime) {
        const url = this.baseUrl + CONTACT_TRACE + '/' + employeeId + '/' + startTime + '/' + endTime;
        return this.httpClient.get<EmployeeContactTrace[]>(url);
    }

    saveEmployee(employee: EmployeeMetadata) {
        const url = this.baseUrl + EMPLOYEES;
        return this.httpClient.post<EmployeeMetadata>(url, employee);
    }
}
