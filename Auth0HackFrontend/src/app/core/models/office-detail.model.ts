import { Moment } from 'moment';

import { SectionDetailModel } from './section-detail.model';

export interface OfficeDetailModel {
    officeId: string;
    officeName: string;
    officeAddress: string;
    officeStreet: string;
    officeCity: string;
    officeState: string;
    officeZip: string;
    officeMaxCapacity: number;
    officeSafeCapacity: number;
    officeUsedCapacity: number;
    snapshotDate?: Moment;
    sections: SectionDetailModel[];
}