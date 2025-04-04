import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { TransactionAddModel, Transactions, TransferModel } from '../Models/Transaction';

@Injectable({
  providedIn: 'root'  // This makes the service available throughout the app
})
export class AccountService {
  private allaccountUrl = 'https://localhost:7257/api/Account/GetAllAccount';
 private myAccount='https://localhost:7257/api/Account/MyAccounts' ;

  private deleteaccountUrl = 'https://localhost:7257/api/Account'; 
  private addaccountUrl = 'https://localhost:7257/api/Account/AddAccount';

  private getMyTransaction = 'https://localhost:7257/api/Transaction/GetByAccountId';

  private uid=localStorage.getItem('UserId');
  sharedData?: number;
  constructor(private http: HttpClient) {}

  // Method to fetch all accounts from API
  getAllAccounts(): Observable<any[]> {
    return this.http.get<any[]>(this.myAccount);
  }

  AllAccounts(): Observable<any[]> {
    return this.http.get<any[]>(this.allaccountUrl);
  }
  

  deleteAccount(id: number): Observable<any> {
    return this.http.delete(`${this.deleteaccountUrl}/${id}`);
  }
  
  addAccount(accountData: any): Observable<any> {
    return this.http.post(`${this.addaccountUrl}`, accountData);
  }


  getTransactions():Observable<Transactions[]>{
    return this.http.get<Transactions[]>(`https://localhost:7257/api/Transaction/GetByAccountId?accountId=${this.sharedData}`)
  }

  addTransaction(transactionData: TransactionAddModel): Observable<TransactionAddModel> {
    if (!this.sharedData) {
      console.error("🚨 Missing Account ID!");
      return throwError(() => new Error("Account ID is required."));
    }
  
    const apiUrl = `https://localhost:7257/api/Transaction/AddTransaction?id=${this.sharedData}`;
    console.log("🌐 Calling API:", apiUrl);
    console.log("📤 Transaction Payload:", transactionData);
  
    return this.http.post<TransactionAddModel>(apiUrl, transactionData);
  }
  
  transferAmount(transactionData:TransferModel):Observable<TransferModel>{
    const apiUrl = `https://localhost:7257/api/Transaction/Transfer?id=${this.sharedData || ''}`;
    console.log("📡 API Call:", apiUrl);
    return this.http.post<TransferModel>(apiUrl, transactionData);
    }

  getId(id: number) {
    console.log("Setting sharedData with Account ID:", id);
    this.sharedData = id;
  }
}
