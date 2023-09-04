import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthService } from 'src/services/auth.service';
import { UserService } from 'src/services/user.service';
import jwt_decode from "jwt-decode";
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-screen',
  templateUrl: './login-screen.component.html',
  styleUrls: [
    './login-screen.component.css'
  ]
})
export class LoginScreenComponent implements OnInit {

  constructor(public authService: AuthService, private router: Router) { }

  ngOnInit(): void {
    console.log('boom');
    var token = UserService.getToken();
    var decoded = jwt_decode(token);
    if (token != null && (Number((decoded as any)['exp'] + '000') > Date.now())) {
      this.router.navigateByUrl('/main');
    }
  }

  onSubmit(form: NgForm) {
    var res = this.authService.login(form.value)
  }

}
