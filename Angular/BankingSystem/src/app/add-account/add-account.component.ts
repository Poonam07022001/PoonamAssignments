import { Component, EventEmitter, Output } from '@angular/core';
import { AccountService } from '../services/account.service';
import { FormsModule } from '@angular/forms'; 

@Component({
  selector: 'app-add-account',
  templateUrl: './add-account.component.html',
  styleUrls: ['./add-account.component.css'],
  imports:[FormsModule]
})
export class AddAccountComponent {
  @Output() accountAdded = new EventEmitter<any>();

  newAccount: {
  
    accountNumber: number | null;
    balance: number | null;
    accountTypes: number | null;
  } = {
    accountNumber: null,
    balance: null,
    accountTypes: null
  };
  
  constructor(private accountService: AccountService) {}

  addAccount() {
    // Ensure accountTypes is a number
    this.newAccount.accountTypes = Number(this.newAccount.accountTypes);

    this.accountService.addAccount(this.newAccount).subscribe(
      (response) => {
        console.log('Account added successfully', response);
        alert('Account added successfully!');
        this.accountAdded.emit(response); 
        this.resetForm();
      },
      (error) => {
        console.error('Error adding account', error);
        alert('Failed to add account. Please try again.');
      }
    );
  }

  resetForm() {
    this.newAccount = {accountNumber: null, balance: null, accountTypes: null };
  }
}
