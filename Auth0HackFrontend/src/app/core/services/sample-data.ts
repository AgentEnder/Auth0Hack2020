import { OfficeDetailModel } from '../models/office-detail.model';

export const SampleOfficeDetail: OfficeDetailModel = {
    officeAddress: '2617 Bissonnet St # 200, Houston, TX 77005',
    officeStreet: '2617 Bissonnet St # 200',
    officeCity: ' Houston',
    officeZip: '77005',
    officeId: '000-...',
    officeMaxCapacity: 50,
    officeSafeCapacity: 13,
    officeName: 'Local Office',
    officeState: 'TX',
    officeUsedCapacity: 4,
    sections: [
        {
            sectionDescription: 'Offices to the left of reception',
            sectionId: '000-...-001',
            sectionMaxCapacity: 4,
            sectionSafeCapacity: 1,
            sectionName: 'Left Side',
            sectionUsedCapacity: 1
        },
        {
            sectionDescription: 'Offices between reception and break room',
            sectionId: '000-...-002',
            sectionMaxCapacity: 4,
            sectionSafeCapacity: 2,
            sectionName: 'Middle Offices',
            sectionUsedCapacity: 1
        },
        {
            sectionDescription: 'Offices to the right of break room',
            sectionId: '000-...-003',
            sectionMaxCapacity: 4,
            sectionSafeCapacity: 1,
            sectionName: 'Right Side',
            sectionUsedCapacity: 0
        },
        {
            sectionDescription: 'Offices behind labs',
            sectionId: '000-...-004',
            sectionMaxCapacity: 4,
            sectionSafeCapacity: 1,
            sectionName: 'Back Offices',
            sectionUsedCapacity: 0
        }
    ]
}