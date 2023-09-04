import { Injectable } from '@angular/core';
import { CanActivate, CanActivateChild, CanDeactivate, CanLoad, Route, UrlSegment, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';
import { UserService } from './user.service';
import jwt_decode from "jwt-decode";

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private authService: AuthService, private router: Router, private userService: UserService) { }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    try {
      var token = UserService.getToken();
      var decoded = jwt_decode(token) as any;

      if (token != null && (Number(decoded['exp'] + '000') > Date.now())) {
        return true;
      }
      else {
        this.router.navigateByUrl('/login');
        return false;
      }

    }
    catch (error) {
      this.router.navigateByUrl('/login');
      return false;
    }
  }
}
