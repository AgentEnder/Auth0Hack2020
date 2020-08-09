import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import * as moment from 'moment';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

import { WorkRequestMetadataDTO } from '../models/work-request.model';
import { WorkRequestApproval } from '../models/work-request-approval.model';

const CREATE_REQUEST = '/api/workrequests/';
const DETAILS = '/api/workrequests/details';
const ACCEPT_REQUEST = '/api/workrequests/approve';
const DENY_REQUEST = '/api/workrequests/deny';

@Injectable({
    providedIn: 'root'
})
export class RequestsService {
    baseUrl: string;

    constructor(private httpClient: HttpClient) {
        this.baseUrl = environment.apiUrl;
    }

    submitRequest(approverId, employeeId, requestorId, startTime, endTime, officeId, sectionId, notes) {
        let body: WorkRequestMetadataDTO = {
            approvalStatus: {
                approvalStatusId: 'E54C2575-E6BD-4FD7-89AC-1D5A76DA7D07',
                isFinal: false,
                statusName: 'Submitted'
            },
            approver: {
                employeeId: approverId
            },
            office: {
                officeId
            },
            person: {
                employeeId
            },
            requestor: {
                employeeId: requestorId
            },
            section: {
                sectionId
            },
            endTime,
            startTime,
            requestorNotes: notes
        };

        return this.httpClient.post(this.baseUrl + CREATE_REQUEST, body);
    }

    public getAllRequests(options = '') {
        return this.httpClient.get<any[]>(this.baseUrl + DETAILS + options).pipe(
            map(
                x => x.map(y => {
                    y.startTime = moment(y.startTime);
                    return y;
                })
            )
        );
    }

    public acceptRequest(row: WorkRequestApproval) {
        return this.httpClient.post<WorkRequestMetadataDTO>(this.baseUrl + ACCEPT_REQUEST, row);
    }

    public rejectRequest(row: WorkRequestApproval) {
        return this.httpClient.post<WorkRequestMetadataDTO>(this.baseUrl + DENY_REQUEST, row);
    }
}
