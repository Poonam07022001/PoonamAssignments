import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddAccountComponent } from '../add-account/add-account.component'; // ✅ Import it

@Component({
  selector: 'app-get-all-account',
  standalone: true,
  imports: [CommonModule, AddAccountComponent], // ✅ Add it here
  templateUrl: './get-all-account.component.html',
  styleUrls: ['./get-all-account.component.css'],
})
export class GetAllAccountComponent {
  accounts = [
    { id: 101, name: 'John Doe', type: 'Savings', balance: 5000 },
    { id: 102, name: 'Jane Smith', type: 'Checking', balance: 12000 },
    { id: 103, name: 'Mark Johnson', type: 'Business', balance: 75000 },
    { id: 104, name: 'Emily Davis', type: 'Savings', balance: 10000 },
    { id: 105, name: 'Michael Brown', type: 'Checking', balance: 2200 }
  ];

  handleAccountAdded(newAccount: any) {
    const newId = this.accounts.length + 1;
    this.accounts.push({ id: newId, ...newAccount });
  }
}
