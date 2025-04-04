import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login-register',
  imports: [FormsModule],
  templateUrl: './login-register.component.html',
  styleUrl: './login-register.component.css',
  standalone: true,
})
export class LoginRegisterComponent {
  firstName: string = '';
  lastName: string = '';
  registerEmail: string = '';
  registerPassword: string = '';
  registerConfirmPassword: string = '';

  constructor(private authService: AuthService) {}

  onRegister() {
    if (this.registerPassword !== this.registerConfirmPassword) {
      alert('Passwords do not match!');
      return;
    }

    const userData = {
      firstName: this.firstName,
      lastName: this.lastName,
      email: this.registerEmail,
      password: this.registerPassword,
    };

    this.authService.register(userData).subscribe(
      (response) => {
        console.log('User registered:', response);
        // alert('Registration successful! User ID: ' + response.userId +this.firstName + this.lastName );
        alert(this.firstName + this.lastName + 'Registration successful!');

      },
      (error) => {
        console.error('Registration failed:', error);
        alert('Registration failed. Please try again.');
      }
    );
}
}
