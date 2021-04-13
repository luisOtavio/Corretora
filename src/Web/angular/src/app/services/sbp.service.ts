import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiHttpClient } from './api-http-client';
import { NewSbpEventRequest } from './new-sbp-event.request';
import { Result } from './result';

@Injectable({providedIn: 'root'})
export class SbpService {
  constructor(private http: ApiHttpClient) {}

  post(request: NewSbpEventRequest): Observable<Result<{ balance: number}>> {
    return this.http.post('sbp/events', request);
  }
}
