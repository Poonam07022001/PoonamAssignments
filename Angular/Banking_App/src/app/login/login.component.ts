import { Component, AfterViewInit, Inject, PLATFORM_ID } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
 import { LoginRegisterComponent } from '../login-register/login-register.component';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ FormsModule, LoginRegisterComponent],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent{
  email: string = '';
  password: string = '';

  constructor(@Inject(PLATFORM_ID) private platformId: object, private router: Router) {}

 

  onLogin() {
    if (this.email === 'admin@example.com' && this.password === 'admin123') {
      alert('Login successful!');
      this.router.navigate(['/AllAccount']); 
    } else {
      alert('Invalid credentials');
    }
  }
}



