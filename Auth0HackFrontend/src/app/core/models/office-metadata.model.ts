import { Point } from './point.model';

export interface OfficeMetadata {
    officeId: string;
    officeName: string;
    officeAddress: string;
    officeStreet: string;
    officeCity: string;
    officeState: string;
    officeZip: string;
    officeMaxCapacity: number;
    officeSafeCapacity: number;
    officeLocation: Point;
}