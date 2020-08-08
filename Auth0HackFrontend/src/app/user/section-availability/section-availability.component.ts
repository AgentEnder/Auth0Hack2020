import { Component, OnInit, ViewEncapsulation } from '@angular/core';

import { Observable } from 'rxjs';

import { OfficeDetailModel } from '../../core/models/office-detail.model';
import { OfficesService } from '../../core/services/offices.service';

@Component({
    templateUrl: './section-availability.component.html',
})
export class UserSectionAvailabilityPageComponent implements OnInit {

    constructor(
        private officesService: OfficesService
    ) { }
    offices: Observable<OfficeDetailModel[]>;


    ngOnInit() {
        this.offices = this.officesService.getOfficeDetails();
    }


}
