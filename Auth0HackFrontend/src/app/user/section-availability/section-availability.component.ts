import { Component, OnInit, ViewEncapsulation } from '@angular/core';

import { Observable } from 'rxjs';

import { OfficeDetailModel } from '../../core/models/office-detail.model';
import { OfficesService } from '../../core/services/offices.service';
import { OfficeMetadata } from 'src/app/core/models/office-metadata.model';

@Component({
    templateUrl: './section-availability.component.html',
})
export class UserSectionAvailabilityPageComponent implements OnInit {

    offices: Observable<OfficeDetailModel[]>;
    o: any = {
        officeId: '240B663E-F7B7-4A3E-B234-AA5273F8CAFB'
    };

    constructor(
        private officesService: OfficesService
    ) { }

    ngOnInit() {
        this.offices = this.officesService.getOfficeDetails();
    }


}
