import { HttpClient } from '@angular/common/http';
import { Component, ViewChild, OnInit } from '@angular/core';

import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';

import { ODataDataSource } from '@agentender/odata-data-source';

import { environment } from '../../../environments/environment';
import { MatTableDataSource } from '@angular/material/table';
import { RequestsService } from 'src/app/core/services/requests.service';
import { WorkRequestMetadataDTO, WorkRequestDetailDTO } from 'src/app/core/models/work-request.model';
import { MatDialog } from '@angular/material/dialog';
import { MatTabChangeEvent } from '@angular/material/tabs';

@Component({
    templateUrl: './pending-requests.component.html'
})
export class PendingRequestsComponent implements OnInit {

    @ViewChild(MatSort) sort: MatSort;
    @ViewChild(MatPaginator) paginator: MatPaginator;
    @ViewChild('acceptForm') modalTemplate;


    dataSource;

    selectedRow: WorkRequestDetailDTO;

    displayedColumns: string[] = ['Office', 'Section', 'StartTime', 'Employee', 'Actions'];

    constructor(
        // private httpClient: HttpClient
        private requestsService: RequestsService,
        private dialog: MatDialog
    ) { }

    ngOnInit() {
        // const resourcePath = environment.apiUrl + '/odata/workrequests?$skip=1&$count=true';
        // this.dataSource = new ODataDataSource(this.httpClient, resourcePath);
        // this.dataSource.sort = this.sort;
        // this.dataSource.paginator = this.paginator;
        this.requestsService.getAllRequests('?$filter=contains(approvalStatus/statusName, \'Submitted\')').subscribe( x => {
            this.dataSource = new MatTableDataSource(x);
            this.dataSource.sort = this.sort;
            this.dataSource.paginator = this.paginator;
        });
    }

    getAcceptColor(row) {
        const section = row.section.sectionSafeCapacity
                    ? row.sectionUsedCapacity / row.section.sectionSafeCapacity
                    : 1;
        const office = row.office.officeSafeCapacity
                    ? row.officeUsedCapacity / row.office.officeSafeCapacity
                    : 1;
        return section >= 1 || office >= 1 ? 'warn' : 'primary';
    }

    acceptRequest(row: WorkRequestMetadataDTO) {
        this.requestsService.acceptRequest({
            approverNotes: row.approverNotes,
            workRequestId: row.workRequestId
        }).subscribe(x => {

        });
    }

    rejectRequest(row: WorkRequestMetadataDTO) {
        this.requestsService.rejectRequest({
            approverNotes: row.approverNotes,
            workRequestId: row.workRequestId
        }).subscribe(x => {
        });
    }

    openDialog(row) {
        this.selectedRow = row;
        this.dialog.open(this.modalTemplate);
    }

    onTabChange(event: MatTabChangeEvent) {
        if (event.tab.textLabel === 'Pending') {
            this.requestsService.getAllRequests('?$filter=contains(approvalStatus/statusName, \'Submitted\')').subscribe( x => {
                this.dataSource = new MatTableDataSource(x);
                this.dataSource.sort = this.sort;
                this.dataSource.paginator = this.paginator;
            });
        } else if (event.tab.textLabel === 'Accepted') {
            this.requestsService.getAllRequests('?$filter=contains(approvalStatus/statusName, \'Approved\')').subscribe( x => {
                this.dataSource = new MatTableDataSource(x);
                this.dataSource.sort = this.sort;
                this.dataSource.paginator = this.paginator;
            });
        } else if (event.tab.textLabel === 'Rejected') {
            this.requestsService.getAllRequests('?$filter=contains(approvalStatus/statusName, \'Denied\')').subscribe( x => {
                this.dataSource = new MatTableDataSource(x);
                this.dataSource.sort = this.sort;
                this.dataSource.paginator = this.paginator;
            });
        }
    }
}
