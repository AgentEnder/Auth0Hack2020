import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import * as moment from 'moment';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

import { WorkRequestMetadataDTO } from '../models/work-request.model';

const CREATE_REQUEST = '/api/workrequests/';
const DETAILS = '/api/workrequests/details';

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

    public getAllRequests() {
        return this.httpClient.get<any[]>(this.baseUrl + DETAILS).pipe(
            map(
                x => x.map(y => {
                    y.startTime = moment(y.startTime)
                    return y;
                })
            )
        );
    }
}
