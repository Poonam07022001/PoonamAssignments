import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { GetAllAccountComponent } from './get-all-account/get-all-account.component';
import { GetTransactionsComponent } from './get-transactions/get-transactions.component';

export const routes: Routes = [

    { path: '', redirectTo: 'login', pathMatch: 'full' }, 
    { path: 'login', component: LoginComponent },
    { path: 'AllAccount', component: GetAllAccountComponent },
    { path: 'GetTransaction', component: GetTransactionsComponent },

    { path: '**', redirectTo: 'login' } 
];


