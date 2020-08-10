import { Component, OnInit } from "@angular/core";
import { OfficeMetadata } from 'src/app/core/models/office-metadata.model';
import { OfficesService } from 'src/app/core/services/offices.service';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { SectionMetadata } from 'src/app/core/models/section-metadata.model';

@Component({
    templateUrl: './offices.component.html'
})
export class AdminOfficesPagesComponent implements OnInit{

    loading = 0;
    data: OfficeMetadata[];
    sections: SectionMetadata[];
    mobile = false;
    selectedOffice: OfficeMetadata;

    ngOnInit() {
        this.fetchOffices();
    }

    constructor(
        private officesService: OfficesService,
        private breakpoints: BreakpointObserver,
    ) {
        this.breakpoints.observe(Breakpoints.Handset).subscribe(x => {
            this.mobile = x.matches;
        });
    }

    fetchOffices() {
        this.loading++;
        this.officesService.getOfficesOdata('?$orderby=OfficeName').subscribe(x => {
            this.data = x;
            this.loading--;
            console.log(this.data);
        });
    }

    fetchSections() {
        this.loading++;
        this.officesService.getSections(this.selectedOffice.officeId).subscribe(x => {
            this.sections = x;
            this.loading--;
            console.log(this.sections);
        });
    }

    editOffice(event) {
        this.selectedOffice = event;
        this.fetchSections();
    }

    newOffice() {        
        this.selectedOffice = {} as OfficeMetadata;
        this.selectedOffice.officeId = '{00000000-0000-0000-0000-000000000000}';
    }

    saveChanges(event) {
        this.loading++;
        this.officesService.saveOffice(this.selectedOffice).subscribe(x => {
            this.loading--;
            this.selectedOffice = x as OfficeMetadata;
            this.fetchOffices();
        });
    }
}