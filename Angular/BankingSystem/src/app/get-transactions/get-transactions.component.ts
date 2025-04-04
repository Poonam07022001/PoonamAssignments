import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddTransactionComponent } from '../add-transaction/add-transaction.component';
import { TransactionService } from '../services/transaction.service';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-get-transactions',
  templateUrl: './get-transactions.component.html',
  styleUrls: ['./get-transactions.component.css'],
  standalone: true,
  imports: [CommonModule, AddTransactionComponent]
})
export class GetTransactionsComponent implements OnInit {
  transactions: any[] = [];

  constructor(private accountService: AccountService) {}

  ngOnInit() {
   this.gettransaction()
  }

gettransaction(){
  this.accountService.getTransactions().subscribe((data) => {
    console.log({ data });
    this.transactions = data;
    console.log(this.transactions);
  });
}
}


