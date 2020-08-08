import { HttpClient } from '@angular/common/http';
import { Component, ViewChild, OnInit } from '@angular/core';

import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';

import { ODataDataSource } from '@agentender/odata-data-source';

import { environment } from '../../../environments/environment';

@Component({
    templateUrl: './pending-requests.component.html'
})
export class PendingRequestsComponent implements OnInit {

    @ViewChild(MatSort) sort: MatSort;
    @ViewChild(MatPaginator) paginator: MatPaginator;

    dataSource;

    constructor(
        private httpClient: HttpClient
    ) { }

    ngOnInit() {
        const resourcePath = environment.apiUrl + '/api/workrequests';
        this.dataSource = new ODataDataSource(this.httpClient, resourcePath);
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
    }
}