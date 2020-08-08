import { Component, Input, OnInit } from '@angular/core';
import { OfficeDetailModel } from '../../core/models/office-detail.model';

@Component({
    selector: 'app-building-availability',
    templateUrl: './building-availability.component.html'
})
export class BuildingAvailabilityComponent implements OnInit{
    @Input() public office: OfficeDetailModel;
    @Input() public showRequestBtn = true;
    @Input() public showCloseBtn = true;

    imgSeed: number;
    submitMode: false | 'closure' | 'request' = false;
    submitItem: any = null;
    submitReason: string;

    ngOnInit() {
        this.imgSeed = Math.random();
    }

    getRandomImgSrc(){
        return `https://picsum.photos/200/300?${this.imgSeed}`;
    }
}