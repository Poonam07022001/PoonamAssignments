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
import { NavbarComponent } from './navbar/navbar.component'; // ✅ Import Navbar
import { GetTransactionsComponent } from './get-transactions/get-transactions.component';
import {AddTransactionComponent} from './add-transaction/add-transaction.component';
@NgModule({
  declarations: [
    AppComponent,
    GetAllAccountComponent,
    AddAccountComponent,
    LoginRegisterComponent,
    NavbarComponent,
    GetTransactionsComponent,
    AddTransactionComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule.forRoot(routes)
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }
