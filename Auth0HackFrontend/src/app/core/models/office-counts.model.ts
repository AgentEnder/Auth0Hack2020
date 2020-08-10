import { Moment } from 'moment';

export interface OfficeCounts {
    officeId: string;
    startTime: Moment;
    approvedCount: number;
}