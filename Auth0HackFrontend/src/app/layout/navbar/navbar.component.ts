import { Component, Output, EventEmitter } from '@angular/core';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
    selector: 'app-navbar',
    templateUrl: './navbar.component.html'
})
export class NavbarComponent {
    @Output() public navToggle = new EventEmitter<void>();

    constructor(public auth: AuthService) {}
}
