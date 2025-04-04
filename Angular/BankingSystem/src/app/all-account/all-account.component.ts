import { Component,OnInit } from '@angular/core';
import { AccountService } from '../services/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-all-account',
  imports: [],
  templateUrl: './all-account.component.html',
  styleUrl: './all-account.component.css'
})
export class AllAccountComponent  implements OnInit {
  accounts: any[] = [];

  constructor(private accountService: AccountService, private router: Router) { }

  ngOnInit() {
    this.loadAccounts();

  }

  loadAccounts() {
    this.accountService.AllAccounts().subscribe((data) => {
      this.accounts = data.map(acc => ({
        id: acc.id,
        name: `User ${acc.userId}`,
        accountnumber: acc.accountNumber,
        type: acc.accountType === 1 ? 'Savings' : 'Checking',
        balance: acc.balance
      }));
    });
  }
}
