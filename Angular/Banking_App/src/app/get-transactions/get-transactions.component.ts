import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddTransactionComponent } from '../add-transaction/add-transaction.component';

@Component({
  selector: 'app-get-transactions',
  templateUrl: './get-transactions.component.html',
  styleUrls: ['./get-transactions.component.css'],
  standalone: true,  // Ensure it's standalone
  imports: [CommonModule,AddTransactionComponent], // Import CommonModule for pipes
})
export class GetTransactionsComponent {
  transactions = [
    { id: 1, date: '2024-03-01', type: 'Deposit', amount: 5000, status: 'Completed' },
    { id: 2, date: '2024-03-05', type: 'Withdrawal', amount: 1500, status: 'Pending' },
    { id: 3, date: '2024-03-10', type: 'Transfer', amount: 2000, status: 'Completed' },
    { id: 4, date: '2024-03-15', type: 'Deposit', amount: 3000, status: 'Failed' }
  ];

  getStatusClass(status: string): string {
    switch (status.toLowerCase()) {
      case 'completed': return 'completed';
      case 'pending': return 'pending';
      case 'failed': return 'failed';
      default: return '';
    }
  }
  
}
