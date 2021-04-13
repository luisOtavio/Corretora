import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { NewSbpEventRequest, SbpService } from '../services';

@Component({
  selector: 'app-conta',
  templateUrl: './conta.component.html',
  styleUrls: ['./conta.component.scss']
})
export class ContaComponent implements OnInit {

  formulario = this.fb.group({
    conta: ['', Validators.required],
    valor: ['', Validators.required],
  });

  constructor(private fb: FormBuilder, private sbpService: SbpService) { }

  ngOnInit(): void {
  }

  depositar() {
    const request: NewSbpEventRequest = {
      event: 'TRANSFER',
      target: {
        bank: '352',
        branch: '0001',
        account: this.formulario.value.conta,
      },
      origin: {
        bank: '033',
        branch: '03312',
        cpf: '92414263067',
      },
      amount: this.formulario.value.valor,
    };

    this.sbpService.post(request).subscribe();
  }

}
