import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NbAuthComponent } from '@nebular/auth';
// import { NbAuthService } from '../.././'
import { NgxLoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { CheckConnectionComponent } from './check-connection/check-connection.component';
import { ActivationKeyComponent } from './activation-key/activation-key.component';


export const routes: Routes = [
  {
    path: '',
    component: NbAuthComponent,
    children: [
      {
        path: 'login',
        component: NgxLoginComponent, // <---
      },
      {
        path: 'register',
        component: RegisterComponent, // <---
      },
      {
        path: 'check-connection',
        component: CheckConnectionComponent, // <---
      },
      {
        path: 'activation-key',
        component: ActivationKeyComponent, // <---
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class NgxAuthRoutingModule {
}