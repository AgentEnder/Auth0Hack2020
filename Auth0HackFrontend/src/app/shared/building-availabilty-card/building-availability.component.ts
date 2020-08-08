import { Component, Input, OnInit } from '@angular/core';
import { OfficeDetailModel } from '../../core/models/office-detail.model';
import { RequestsService } from 'src/app/core/services/requests.service';
import { Moment } from 'moment';

@Component({
    selector: 'app-building-availability',
    templateUrl: './building-availability.component.html'
})
export class BuildingAvailabilityComponent implements OnInit{
    @Input() public office: OfficeDetailModel;
    @Input() public showRequestBtn = true;
    @Input() public showCloseBtn = true;
    @Input() public day: Moment;

    imgSeed: number;
    submitMode: false | 'closure' | 'request' = false;
    submitItem: any = null;
    submitReason: string;

    constructor(
        private requestsService: RequestsService
    ) {}

    ngOnInit() {
        this.imgSeed = Math.random();
    }

    getRandomImgSrc(){
        return `https://picsum.photos/200/300?${this.imgSeed}`;
    }

    submit() {
        if (this.submitMode === 'closure') {
            this.submitClosure();
        } else if (this.submitMode === 'request') {
            this.submitRequest();
        }
    }

    submitClosure() {
        this.submitItem = null;
        this.submitMode = false;
    }

    submitRequest() {
        this.requestsService.submitRequest(
            'BC238306-9CB5-4731-A117-EC1A926E2659',
            '293E75E0-20CD-4855-B951-57067E26FA84',
            '293E75E0-20CD-4855-B951-57067E26FA84',
            this.day,
            this.day.add(1, 'day'),
            this.office.officeId,
            this.submitItem.sectionId,
            this.submitReason
        ).subscribe(x => {
            this.submitMode = false;
        });
    }
}