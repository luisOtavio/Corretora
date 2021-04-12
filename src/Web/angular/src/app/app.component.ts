import { Component } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NewSbpEventRequest, SbpService } from './services';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'corretora';

  /**
   *
   */
  constructor(private sbpService: SbpService) {
    const request: NewSbpEventRequest = {
      event: 'TRANSFER',
      target: {
        bank: '352',
        branch: '0001',
        account: '300123',
      },
      origin: {
        bank: '033',
        branch: '03312',
        cpf: '92414263067',
      },
      amount: -80.45,
    };

    this.sbpService.post(request).subscribe();
  }
}
