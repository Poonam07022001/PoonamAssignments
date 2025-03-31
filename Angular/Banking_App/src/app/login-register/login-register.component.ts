import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login-register',
  imports: [FormsModule],
  templateUrl: './login-register.component.html',
  styleUrl: './login-register.component.css',
  standalone: true,
})
export class LoginRegisterComponent {
  registerEmail: string = '';
  registerPassword: string = '';
  registerConfirmPassword:string=''

  onRegister() {
    console.log('Register:', this.registerEmail, this.registerPassword,this.registerConfirmPassword);
  }
}
