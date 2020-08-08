import { Moment } from 'moment';
import { OfficeMetadata } from './office-metadata.model';
import { OfficeDetailModel } from './office-detail.model';

export interface OfficeAvailabilityOverTime {
    startDate: Moment;
    endDate: Moment;
    days: [{
        date: Moment
        offices: OfficeDetailModel[]
    }];
}
