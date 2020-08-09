import { HttpClient } from '@angular/common/http';
import { Component, ViewChild, OnInit } from '@angular/core';

import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';

import { ODataDataSource } from '@agentender/odata-data-source';

import { environment } from '../../../environments/environment';
import { MatTableDataSource } from '@angular/material/table';
import { RequestsService } from 'src/app/core/services/requests.service';

@Component({
    templateUrl: './pending-requests.component.html'
})
export class PendingRequestsComponent implements OnInit {

    @ViewChild(MatSort) sort: MatSort;
    @ViewChild(MatPaginator) paginator: MatPaginator;

    dataSource;

    displayedColumns: string[] = ['Office', 'Section', 'StartTime', 'Employee', 'Actions'];

    constructor(
        // private httpClient: HttpClient
        private requestsService: RequestsService
    ) { }

    ngOnInit() {
        // const resourcePath = environment.apiUrl + '/odata/workrequests?$skip=1&$count=true';
        // this.dataSource = new ODataDataSource(this.httpClient, resourcePath);
        // this.dataSource.sort = this.sort;
        // this.dataSource.paginator = this.paginator;
        this.requestsService.getAllRequests().subscribe( x => {
            this.dataSource = new MatTableDataSource(x);
            this.dataSource.sort = this.sort;
            this.dataSource.paginator = this.paginator;
        });
    }
}