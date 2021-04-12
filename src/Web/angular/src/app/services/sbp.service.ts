import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiHttpClient } from './api-http-client';
import { NewSbpEventRequest } from './new-sbp-event.request';

@Injectable({providedIn: 'root'})
export class SbpService {
  constructor(private http: ApiHttpClient) {}

  post(request: NewSbpEventRequest): Observable<any> {
    return this.http.post('sbp/events', request);
  }
}
