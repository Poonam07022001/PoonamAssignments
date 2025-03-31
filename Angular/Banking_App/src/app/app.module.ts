import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { routes } from './app.routes';

// Import standalone components properly
import { AppComponent } from './app.component';
import { LoginRegisterComponent } from './login-register/login-register.component';
import { GetAllAccountComponent } from './get-all-account/get-all-account.component';
import { AddAccountComponent } from './add-account/add-account.component'; // ✅ Import this

@NgModule({
  declarations: [
    AppComponent,
    GetAllAccountComponent,
    AddAccountComponent, // ✅ Add this component here
    LoginRegisterComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule.forRoot(routes),
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }
