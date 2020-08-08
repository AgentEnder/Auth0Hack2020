import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { WorkRequestMetadataDTO } from '../models/work-request.model';

const SUBMIT_REQUEST = '/api/workrequests/';

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

        return this.httpClient.post(this.baseUrl + SUBMIT_REQUEST, body);
    }

}
