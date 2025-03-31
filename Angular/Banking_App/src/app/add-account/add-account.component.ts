import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-add-account',
  templateUrl: './add-account.component.html',
  styleUrls: ['./add-account.component.css'],
})
export class AddAccountComponent {
  @Output() accountAdded = new EventEmitter<any>();

  newAccount = { name: '', type: '', balance: 0 };

  addAccount() {
    this.accountAdded.emit(this.newAccount);
    this.newAccount = { name: '', type: '', balance: 0 }; 
  }
}
