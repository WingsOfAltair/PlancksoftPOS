import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthComponent } from './auth.component';
import { LoginComponent } from './login/login.component';
import { RouterModule } from '@angular/router';
// import { NgModule } from '@angular/core';
import {
  NbActionsModule,
  NbButtonModule,
  NbCardModule,
  NbCheckboxModule,
  NbDatepickerModule, NbIconModule,
  NbInputModule,
  NbRadioModule,
  NbSelectModule,
  NbUserModule,
} from '@nebular/theme';

import { ThemeModule } from '../../@theme/theme.module';
// import { FormsRoutingModule } from './forms-routing.module';
// import { FormsComponent } from './forms.component';
// import { FormInputsComponent } from './form-inputs/form-inputs.component';
// import { FormLayoutsComponent } from './form-layouts/form-layouts.component';
// import { DatepickerComponent } from './datepicker/datepicker.component';
// import { ButtonsComponent } from './buttons/buttons.component';
import { FormsModule as ngFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AuthComponent,
    LoginComponent
  ],
  imports: [
    CommonModule,
    ThemeModule,
    NbInputModule,
    NbCardModule,
    NbButtonModule,
    NbActionsModule,
    NbUserModule,
    NbCheckboxModule,
    NbRadioModule,
    NbDatepickerModule,
    NbSelectModule,
    NbIconModule,
    ngFormsModule,
    RouterModule.forChild([
      {
        path: '',
        component: AuthComponent
      },
      {
        path: 'login',
        component: LoginComponent
      },
    ])
  ]
})
export class AuthModule { }
