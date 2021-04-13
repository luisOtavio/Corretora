import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ContaComponent } from './conta/conta.component';

const routes: Routes = [
  {
    path: 'conta',
    component: ContaComponent
  },
  {
    path: '**', redirectTo: 'conta'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
