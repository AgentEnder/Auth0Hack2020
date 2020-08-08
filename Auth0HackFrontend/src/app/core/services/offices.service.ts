import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { of } from 'rxjs';
import { map } from 'rxjs/operators';

import { SampleOfficeDetail } from './sample-data';

@Injectable({
    providedIn: 'root'
})
export class OfficesService {
    constructor(private httpClient: HttpClient) {}

    getOfficeDetails() {
        return of(SampleOfficeDetail).pipe(map(x => [x, x, x, x, x, x, x, x, x, x, x]));
    }
}
