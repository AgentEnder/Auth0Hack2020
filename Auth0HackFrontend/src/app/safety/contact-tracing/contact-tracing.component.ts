import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';

import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';

import { EmployeeMetadata } from '../../core/models/employee-metadata.model';
import { EmployeesService } from '../../core/services/employee.service';

@Component({
    templateUrl: './contact-tracing.component.html'
})
export class ContactTracingComponent implements OnInit {
    loading = 0;
    employeeList: EmployeeMetadata[];
    mobile = false;
    selectedEmployee: EmployeeMetadata;

    filteredOptions: EmployeeMetadata[];

    constructor(
        private employeeService: EmployeesService,
        private breakpoints: BreakpointObserver
    ) {
        this.breakpoints.observe(Breakpoints.Handset).subscribe(x => {
            this.mobile = x.matches;
        });
    }

    ngOnInit() {
        this.fetchEmployees();
    }

    fetchEmployees() {
        this.loading++;
        this.employeeService.getEmployeeList('?$orderby=LastName,FirstName').subscribe(x => {
            this.employeeList = x;
            this.loading--;
            this.filteredOptions = [...this.employeeList]
        });
    }

    filterComplete(event) {
        this.filteredOptions = this._filter(event || '');
    }

    private _filter(value: string): EmployeeMetadata[] {
        const filterValue = value.toLowerCase();
        console.log(this.filteredOptions);
        console.log(filterValue);
        console.log(this.employeeList);
        return this.employeeList.filter(x => x.lastName.toLowerCase().indexOf(filterValue) >= 0
               || x.firstName.toLowerCase().indexOf(filterValue) >= 0);
      }

      firstLastName = (emp: EmployeeMetadata) => `${emp.lastName}, ${emp.firstName}`

}