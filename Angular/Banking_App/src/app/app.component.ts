import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Router } from '@angular/router';
import { NavbarComponent } from './navbar/navbar.component';  // ✅ Import NavbarComponent
import { CommonModule } from '@angular/common';  // ✅ Import CommonModule

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,NavbarComponent,CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  standalone: true,
})
export class AppComponent {
  title = 'Banking_App';
  constructor(private router: Router) {}
  shouldShowNavbar(): boolean {
    return this.router.url !== '/login'; // Hide navbar on login page
  }
}
