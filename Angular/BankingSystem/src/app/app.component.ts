import { Component ,OnInit} from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { NavbarComponent } from './navbar/navbar.component';
import { CommonModule } from '@angular/common';
import * as AOS from 'aos';
@Component({
  selector: 'app-root',
  imports: [RouterOutlet,NavbarComponent,CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit{
  title = 'BankingSystem';
  constructor(private router: Router) {}
  shouldShowNavbar(): boolean {
    return this.router.url !== '/login'; // Hide navbar on login page
  }
  ngOnInit() {
    AOS.init();
  }
}
