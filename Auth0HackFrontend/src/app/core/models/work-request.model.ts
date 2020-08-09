import { EmployeeMetadata } from './employee-metadata.model';
import { OfficeMetadata } from './office-metadata.model';
import { SectionMetadata } from './section-metadata.model';
import { ApprovalStatusMetadata } from './approval-status-metadata.model';

export interface WorkRequestMetadataDTO {
    workRequestId?: string;
    requestor: EmployeeMetadata;
    approver: EmployeeMetadata;
    person: EmployeeMetadata;
    office: OfficeMetadata;
    section: SectionMetadata;
    approvalStatus: ApprovalStatusMetadata;
    startTime?: string;
    endTime?: string;
    requestorNotes?: string;
    approverNotes?: string;
}
