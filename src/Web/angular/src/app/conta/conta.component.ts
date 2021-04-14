import { Component, Inject, OnDestroy } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatSnackBar, MAT_SNACK_BAR_DATA } from '@angular/material/snack-bar';
import { Subscription } from 'rxjs';
import { NewSbpEventRequest, SbpService } from '../services';

@Component({
  selector: 'app-conta',
  templateUrl: './conta.component.html',
  styleUrls: ['./conta.component.scss'],
})
export class ContaComponent implements OnDestroy {
  formulario = this.fb.group({
    conta: ['', Validators.required],
    valor: ['', Validators.required],
    cpf: ['', Validators.required],
  });

  subscriptions: Subscription[] = [];

  constructor(
    private fb: FormBuilder,
    private sbpService: SbpService,
    private _snackBar: MatSnackBar
  ) {}

  ngOnDestroy() {
    this.subscriptions.forEach(s => s.unsubscribe());
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
        cpf: this.formulario.value.cpf,
      },
      amount: this.formulario.value.valor,
    };

    this.subscriptions.push(
      this.sbpService.post(request).subscribe((result) => {
        this.apresentarNotificacaoDeDeposito(result.value?.balance);
      })
    );
  }

  private apresentarNotificacaoDeDeposito(saldo: number | undefined) {
    this._snackBar.openFromComponent(SnackComponent, {
      duration: 5000,
      data: {
        mensagem: `Operacao realizada com sucesso! Seu saldo é R$ ${saldo}`,
      },
    });
  }
}

@Component({
  selector: 'app-bar-component-snack',
  template: '{{ data.mensagem }}',
})
export class SnackComponent {
  constructor(
    @Inject(MAT_SNACK_BAR_DATA) public data: { mensagem: string },
    public snackBar: MatSnackBar
  ) {}
}
