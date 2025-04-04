import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TransactionService {
  private getTransaction = 'https://localhost:7257/api/Transaction/GetAllTransaction';
  private getMyTransaction = 'https://localhost:7257/api/Transaction/GetAllTransaction';

  constructor(private http: HttpClient) {}

  getTransactions(): Observable<any[]> {
    return this.http.get<any[]>(this.getMyTransaction);
  }

  // getmyTransactions(): Observable<any[]> {
  //   return this.http.get<any[]>(this.getTransaction);
  // }
}
