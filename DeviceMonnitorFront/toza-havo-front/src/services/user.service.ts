import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor() { }

  static getToken() {
    return localStorage.getItem('saltekToken') || "{}";
  }

  static setToken(token: string) {
    localStorage.setItem('saltekToken', token);
  }

  static removeToken() {
    localStorage.removeItem('userName');
    return localStorage.removeItem('saltekToken');
  }

  static getUsername() {
    return localStorage.getItem('userName');
  }

  static setUsername(username: string) {
    localStorage.setItem('userName', username);
  }
}
