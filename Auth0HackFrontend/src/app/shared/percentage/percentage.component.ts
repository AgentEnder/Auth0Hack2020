import { Component, Input, OnChanges, ChangeDetectorRef } from '@angular/core';

@Component({
    selector: 'app-percentage',
    templateUrl: './percentage.component.html'
})
export class PercentageComponent implements OnChanges{
    @Input() numerator: number;
    @Input() numeratorLabel: string;
    @Input() denominator: number;
    @Input() denominatorLabel: string;
    @Input() warnThreshold = 0.5;
    @Input() dangerThreshold = 0.75;
    @Input() customClass: string;
    @Input() clamp = false;
    percentage = 0;
    textClass = '';

    constructor(private cdr: ChangeDetectorRef) {}

    ngOnChanges() {
        const old = this.percentage;
        this.percentage = this.denominator
                          ? this.numerator / this.denominator
                          : 1;
        if (this.clamp) {
            if (this.percentage > 1) { this.percentage = 1; }
            if (this.percentage < 0) { this.percentage = 0; }
        }
        if (this.percentage !== old) {
            this.calculateTextClass();
        }
    }

    calculateTextClass() {
        if (this.percentage >= this.dangerThreshold) {
            this.textClass = 'text-danger';
        } else if (this.percentage >= this.warnThreshold) {
            this.textClass = 'text-warning';
        } else {
            this.textClass = '';
        }
        this.cdr.detectChanges();
    }
}
