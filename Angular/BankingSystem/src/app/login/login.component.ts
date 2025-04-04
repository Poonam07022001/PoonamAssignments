import { Component, AfterViewInit, Inject, PLATFORM_ID, OnInit } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
 import { LoginRegisterComponent } from '../login-register/login-register.component';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  standalone:true,
  imports: [ FormsModule, LoginRegisterComponent],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {


  email: string = '';
  password: string = '';

  constructor(private authService: AuthService, private router: Router) {}

  onLogin() {
    this.authService.login(this.email, this.password).subscribe(
      (response) => {
         
          alert('Login successful!');
    localStorage.setItem('token',response.token);
  this.router.navigate(['/AllAccount']); 
       
      },
      (error) => {
        alert('Invalid credentials');
        console.error('Login error:', error);
      }
    );
   }
}



