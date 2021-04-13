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
}
