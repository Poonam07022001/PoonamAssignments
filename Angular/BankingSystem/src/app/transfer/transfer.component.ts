import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { TransferModel } from '../Models/Transaction';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-transfer',
  imports: [CommonModule, FormsModule, RouterModule],
  standalone: true,
  templateUrl: './transfer.component.html',
  styleUrls: ['./transfer.component.css']
})

export class TransferComponent {
  transferModel: TransferModel = new TransferModel(0, 0);
  errorMessage = '';

  constructor(private router: Router, private accountService: AccountService) {}
  ngonInit() {}

  transfertoanotheruser(transactionForm: NgForm) {
    if (!this.accountService.sharedData) {
      alert("🚨 No Account Selected for Transfer!");
      return;
    }
  
    console.log("✅ Transfer Button Clicked");
    this.transferModel = transactionForm.value;
  
    this.accountService.transferAmount(this.transferModel).subscribe({
      next: (res: TransferModel) => {
        console.log('✅ Transaction Completed:', res);
        alert('Transaction Completed');
        transactionForm.reset();
        this.router.navigate(['myAccounts']);
      },
      error: (error) => {
        console.error('❌ Transfer Failed:', error);
        alert(error.error?.message || "Transaction Failed");
      },
    });
  }
  
}

