import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { GetAllAccountComponent } from './get-all-account/get-all-account.component';
import { GetTransactionsComponent } from './get-transactions/get-transactions.component';
import { LoginRegisterComponent } from './login-register/login-register.component';
import { AddTransactionComponent } from './add-transaction/add-transaction.component';
import { AllAccountComponent } from './all-account/all-account.component';

export const routes: Routes = [  { path: '', redirectTo: 'login', pathMatch: 'full' }, 
    { path: 'login', component: LoginComponent },
    { path: 'AllAccount', component: GetAllAccountComponent },
    {path:'LoginRegister' , component:LoginRegisterComponent},
    { path: 'GetTransaction', component: GetTransactionsComponent },
    {path:'addTransaction', component:AddTransactionComponent},
{path:'account', component:AllAccountComponent}
];
