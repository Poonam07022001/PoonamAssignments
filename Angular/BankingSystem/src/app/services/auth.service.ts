import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'https://localhost:7257/api/Auth/login'; 
  private registerUrl = 'https://localhost:7257/api/Auth/register';
  constructor(private http: HttpClient) {
    
  }

  // Method to login the user
  login(email: string, password: string): Observable<any> {
    const body = { email, password }; 
    
    return this.http.post<any>(this.apiUrl, body);
  }

  // Retrieve stored token
  getToken(): string | null {
    return localStorage.getItem('token');
  }

  // Check if user is logged in
  isAuthenticated(): boolean {
    return this.getToken() !== null;
  }

  // Logout user (remove token)
  logout() {
    localStorage.removeItem('token');
  }

  register(userData: any): Observable<any> {
    return this.http.post<any>(this.registerUrl, userData);
  }

  isLoggedIn():boolean{
    return !!localStorage.getItem('token')
  }
}
