import { Component, OnInit } from "@angular/core";
import { EmployeeMetadata } from 'src/app/core/models/employee-metadata.model';
import { EmployeesService } from 'src/app/core/services/employee.service';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { map, startWith} from 'rxjs/operators';
import { EmployeeContactTrace } from 'src/app/core/models/employee-contact-trace.model';

@Component({
    templateUrl: './contact-tracing.component.html'
})
export class ContactTracingComponent implements OnInit {
    loading = 0;
    employeeList: EmployeeMetadata[];
    mobile = false;
    selectedEmployee: EmployeeMetadata;

    filteredOptions: EmployeeMetadata[];
    startDate: Date;
    endDate: Date;
    contractTraceList: EmployeeContactTrace[];

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
        if (typeof(event) === 'string') {
            this.filteredOptions = this._filter(event || '');
        }
    }

    performContactTrace() {
        this.loading++;
        this.employeeService.getContactTraceEmployeeList(this.selectedEmployee.employeeId,
                        this.startDate.toISOString(), this.endDate.toISOString()).subscribe(x => {
            this.contractTraceList = x;
            this.loading--;
            console.log(this.contractTraceList);
        })
    }

    private _filter(value: string): EmployeeMetadata[] {
        console.log(value);
        const filterValue = value != null ? value.toLowerCase() : '';
        console.log(this.filteredOptions);
        console.log(filterValue);
        console.log(this.employeeList);
        return this.employeeList.filter(x => x.lastName.toLowerCase().indexOf(filterValue) >= 0
               || x.firstName.toLowerCase().indexOf(filterValue) >= 0);
      }

      firstLastName = (emp: EmployeeMetadata) => emp && `${emp.lastName}, ${emp.firstName}`;
}