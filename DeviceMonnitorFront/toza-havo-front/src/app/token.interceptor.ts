import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpHeaders
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserService } from 'src/services/user.service';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {

  constructor() {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {

    const header = new HttpHeaders({ 'Content-Type': 'application/JSON', 'Authorization': 'Bearer ' + UserService.getToken() });

    const newRequest = request.clone({
      headers: header,
      params: request.params,
    })
    
    return next.handle(newRequest);
  }
}
