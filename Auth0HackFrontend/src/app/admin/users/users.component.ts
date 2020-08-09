import { Component, OnInit } from '@angular/core';
import { EmployeesService } from 'src/app/core/services/employee.service';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { EmployeeMetadata } from 'src/app/core/models/employee-metadata.model';
import { FormGroup } from '@angular/forms';
import { DomSanitizer } from '@angular/platform-browser';

interface ImageInfo {
    width: number;
    height: number;
}
@Component({
    templateUrl: './users.component.html'
})
export class AdminUsersPageComponent implements OnInit{
    editEmployeeFormGroup: FormGroup;
    mobile = false;
    loading = 0;    
    data: EmployeeMetadata[];
    selectedEmployee: EmployeeMetadata;
    imageDims: ImageInfo = { } as ImageInfo;
    constructor(
        private employeeService: EmployeesService,
        private breakpoints: BreakpointObserver,
        public sanitizer: DomSanitizer
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
            this.data = x;
            this.loading--;
            console.log(this.data);
        });
    }

    editEmployee(event) {
        this.selectedEmployee = event;
        console.log(this.selectedEmployee);
    }
    
    setPreviewUrl = (url) => {
        this.selectedEmployee.avatar = url;        
    }

    public uploadFile = (files, callback: (dataUrl: string) => void) => {
        if (files.length === 0) {
          return;
        }
    
        let fileToUpload = <File>files[0];
        
        const reader: FileReader = new FileReader();
        reader.readAsDataURL(fileToUpload);
        reader.onload = () => {
            let encoded = reader.result.toString().replace(/^data:(.*,)?/, '');
            if (encoded.length % 4 > 0) {
                encoded += '='.repeat(4 - (encoded.length % 4));
            }
            encoded = `data:${fileToUpload.type};base64, ${encoded}`;
            const i = new Image();
            i.src = encoded;
            i.onload = (e: any) => {
                this.imageDims.width = e.path[0].width;
                this.imageDims.height = e.path[0].height;
            }
            callback(encoded);
        };
    }

    saveChanges(event) {
        this.loading++;
        console.log(this.selectedEmployee.avatar);
        this.employeeService.saveEmployee(this.selectedEmployee).subscribe(x => {
            this.loading--;
        });
    }
}
