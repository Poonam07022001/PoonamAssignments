import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddAccountComponent } from '../add-account/add-account.component';
import { AccountService } from '../services/account.service';
import { Router, RouterModule } from '@angular/router';
import { AddTransactionComponent } from '../add-transaction/add-transaction.component';
import { TransferComponent } from '../transfer/transfer.component';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-get-all-account',
  standalone: true,
  imports: [CommonModule, AddAccountComponent, AddTransactionComponent,TransferComponent,FormsModule],
  templateUrl: './get-all-account.component.html',
  styleUrls: ['./get-all-account.component.css'],

})
export class GetAllAccountComponent implements OnInit {
  accounts: any[] = [];
  transactions: any[] = [];
  constructor(private accountService: AccountService, private router: Router) { }

  ngOnInit() {
    this.loadAccounts();

  }

  loadAccounts() {
    this.accountService.getAllAccounts().subscribe((data) => {
      this.accounts = data.map(acc => ({
        id: acc.id,
        name: `User ${acc.userId}`,
        accountnumber: acc.accountNumber,
        type: acc.accountType === 1 ? 'Savings' : 'Checking',
        balance: acc.balance
      }));
    });
  }

  deleteAccount(id: number) {
    if (confirm('Are you sure you want to delete this account?')) {
      this.accountService.deleteAccount(id).subscribe(() => {
        this.accounts = this.accounts.filter(account => account.id !== id);
      });
    }
  }


  fetchtransaction(id: number) {
    this.accountService.getId(id);
    this.router.navigate(['GetTransaction']);
  }

  addTransaction(id: number) {
    this.accountService.sharedData = id; 
  }
  
  transferTransaction(id:number){
    this.accountService.getId(id);
  }

}
