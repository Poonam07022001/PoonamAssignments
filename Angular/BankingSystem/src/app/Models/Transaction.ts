export interface Accounts {
    id: number;
    userId: string;
    accountNumber: number;
    balance: number;
    accountTypes: AccountTypes;
    createdDate: Date;
    transactions?: Transactions[];
  }

export interface Transactions {
    id: number;
    accountId: number;
    account?: Accounts;
    transactionType:TransactionTypes;
    amount:number;
    date:Date;
    description:string
  
  }
export enum AccountTypes {
  Saving_Account = 1,
  Current_Account,
  Joint_Account,
  Salary_Account
}
export enum TransactionTypes {
  credit = 1,
  Debit
}
export class TransactionAddModel{
    amount:number;
    description:string;
    
    constructor(amount:number,description:string) {
        this.amount=amount;
        this.description=description
        
    }
}

export class TransferModel{
    accountNumber:number;
    amount:number;
    
    
    constructor(amount:number,accountNumber:number) {
        this.accountNumber=accountNumber;
        this.amount=amount;
        
        
    }
}