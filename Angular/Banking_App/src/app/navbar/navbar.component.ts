import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  imports: [],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {
  constructor(private router: Router) {}

  logout() {
    this.router.navigate(['/login']); // Redirect to login page
  }

  navigateTo(route: string) {
    this.router.navigate([route]); // ✅ Programmatic navigation
  }
}
