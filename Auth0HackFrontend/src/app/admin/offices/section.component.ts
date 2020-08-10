import { Component, OnInit, Input } from '@angular/core';
import { OfficeMetadata } from 'src/app/core/models/office-metadata.model';
import { OfficesService } from 'src/app/core/services/offices.service';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { SectionMetadata } from 'src/app/core/models/section-metadata.model';

@Component({
    selector: 'app-section',
    templateUrl: './section.component.html'
})
export class SectionComponent implements OnInit{

    loading = 0;
    data: SectionMetadata[];
    mobile = false;
    @Input() public sections: SectionMetadata[];
    @Input() public officeId: string;
    selectedSection: SectionMetadata;

    ngOnInit() {        
        
    }

    constructor(
        private officesService: OfficesService,
        private breakpoints: BreakpointObserver,
    ) {
        this.breakpoints.observe(Breakpoints.Handset).subscribe(x => {
            this.mobile = x.matches;
        });
    }

    editSection(event) {
        this.selectedSection = event;        
    }

    saveChanges(event) {
        this.loading++;
        this.officesService.saveSection(this.selectedSection).subscribe(x => {
            this.loading--;
            this.selectedSection = x as SectionMetadata;
            this.fetchSections();
        });
    }

    fetchSections() {
        this.loading++;
        this.officesService.getSections(this.selectedSection.officeId).subscribe(x => {
            this.sections = x;
            this.loading--;
            console.log(this.sections);
        });
    }

    newSection() {
        this.selectedSection = {} as SectionMetadata;
        this.selectedSection.officeId = this.officeId;
        this.selectedSection.sectionId = '{00000000-0000-0000-0000-000000000000}';
    }
}
