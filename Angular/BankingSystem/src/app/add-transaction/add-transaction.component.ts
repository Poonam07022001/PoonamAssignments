import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { TransactionAddModel } from '../Models/Transaction';
import { AccountService } from '../services/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-transaction',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './add-transaction.component.html',
  styleUrls: ['./add-transaction.component.css']
})
export class AddTransactionComponent implements OnInit {
  transactionForm!: FormGroup;
  errorMessage = "";
  accountId?: number; 

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private accountService: AccountService
  ) {}

  ngOnInit() {
    this.accountId = this.accountService.sharedData;
    console.log("💾 Received Account ID for transaction:", this.accountId);

    this.transactionForm = this.fb.group({
      type: ['', Validators.required],  // Credit or Debit
      amount: [0, [Validators.required, Validators.min(1)]], 
      description: ['', Validators.required]
    });
  }

  transactionUser() {
    console.log("🔄 Form submitted...");
    
    if (!this.accountId) {
      console.error("❌ No account selected!");
      alert("Please select an account before adding a transaction.");
      return;
    }

    if (this.transactionForm.invalid) {
      console.error("⚠️ Form is invalid!", this.transactionForm.errors);
      alert("Please fill all required fields correctly.");
      return;
    }


    const transactionData: TransactionAddModel = {
      amount: this.transactionForm.value.amount,
      description: this.transactionForm.value.description
    };

    console.log("📤 Sending Transaction Data:", transactionData);

    this.accountService.addTransaction(transactionData).subscribe({
      next: (res) => {
        console.log("✅ Transaction successful!", res);
        alert("Transaction Added!");
        this.transactionForm.reset();
        this.router.navigate(['AllAccount']);
      },
      error: (error) => {
        console.error("🚨 API Error:", error);
        alert("Error: " + JSON.stringify(error.error));
      }
    });
  }
}
