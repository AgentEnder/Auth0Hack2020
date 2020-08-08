import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { OfficeDetailModel } from 'src/app/core/models/office-detail.model';
import { OfficesService } from 'src/app/core/services/offices.service';

@Component({
    templateUrl: './section-availability.component.html'
})
export class UserSectionAvailabilityPageComponent implements OnInit{
    offices: Observable<OfficeDetailModel[]>;

    constructor(
        private officesService: OfficesService
    ) {}

    ngOnInit() {
        this.offices = this.officesService.getOfficeDetails();
    }
}
