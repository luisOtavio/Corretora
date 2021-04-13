import { Component, Inject } from "@angular/core";
import { MatSnackBar, MAT_SNACK_BAR_DATA } from "@angular/material/snack-bar";

@Component({
  selector: 'app-snack-error-component-snack',
  template: '{{ data.mensagem }}',
})
export class SnackErrorComponent {
  constructor(
    @Inject(MAT_SNACK_BAR_DATA) public data: { mensagem: string },
    public snackBar: MatSnackBar
  ) {}
}
