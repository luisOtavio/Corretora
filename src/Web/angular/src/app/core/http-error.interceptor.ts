import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse,
  HttpResponse,
} from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { Result } from '../services/result';
@Injectable()
export class HttpErrorInterceptor implements HttpInterceptor {
  constructor() {}

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      tap((httpResponse) => {}),

      catchError((response) => {
        const httpErroResponse: HttpErrorResponse = response;
        console.log(httpErroResponse.error);
        switch (httpErroResponse.status) {
          case 400:
          case 409:
            break;
          case 500:
            // this.toast.error('Ocorreu um erro inesperado.');
            break;
          case 401:
            // this.authService.logout();
            break;
          default:
            // this.toast.error('Ocorreu um erro no sistema.');
            break;
        }

        return of(response);
      })
    );
  }
}
