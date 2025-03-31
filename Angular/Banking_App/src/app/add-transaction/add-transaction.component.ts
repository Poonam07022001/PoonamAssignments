import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-add-transaction',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './add-transaction.component.html',
  styleUrls: ['./add-transaction.component.css']
})
export class AddTransactionComponent {
  transactionForm: FormGroup;

  constructor(private fb: FormBuilder) {
    this.transactionForm = this.fb.group({
      date: ['', Validators.required],
      type: ['', Validators.required],
      amount: ['', [Validators.required, Validators.min(1)]],
      status: ['', Validators.required]
    });
  }

  submitTransaction() {
    if (this.transactionForm.valid) {
      console.log('Transaction Submitted:', this.transactionForm.value);
      // Handle transaction submission logic
    }
  }
}
