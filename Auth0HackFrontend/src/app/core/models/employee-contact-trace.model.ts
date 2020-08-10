import { EmployeeMetadata } from './employee-metadata.model';

export interface EmployeeContactTrace {
    employeeData: EmployeeMetadata;
    dateOfContact: Date;
    officeId: string;
    officeName: string;
    sectionId: string;
    sectionName: string;
}