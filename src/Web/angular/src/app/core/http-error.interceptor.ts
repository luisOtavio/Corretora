import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse,
} from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { Result } from '../services/result';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SnackErrorComponent } from './snack-erro.component';
@Injectable()
export class HttpErrorInterceptor implements HttpInterceptor {
  constructor( private _snackBar: MatSnackBar) {}

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      tap((httpResponse) => {}),

      catchError((response) => {
        const httpErroResponse: HttpErrorResponse | any = response;
        switch (httpErroResponse.status) {
          case 400:
          case 409:
            this.apresentarNotificacao(httpErroResponse?.error?.errors[0].message);
            break;
          default:
            this.apresentarNotificacao('Ocorreu um erro no sistema.');
            break;
        }

        return of(response);
      })
    );
  }

  private apresentarNotificacao(mensagem: string) {
    this._snackBar.openFromComponent(SnackErrorComponent, {
      duration: 5000,
      data: {
        mensagem: mensagem,
      },
    });
  }
}
