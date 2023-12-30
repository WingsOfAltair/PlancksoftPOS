import { CommonModule } from '@angular/common';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { NgxAuthRoutingModule } from './auth-routing.module';
import { NbAuthModule } from '@nebular/auth';
import { NbAlertModule, NbButtonModule, NbCardModule, NbCheckboxModule, NbIconComponent, NbIconModule, NbInputModule } from '@nebular/theme';


import { NgxLoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { CheckConnectionComponent } from './check-connection/check-connection.component';
import { ActivationKeyComponent } from './activation-key/activation-key.component';


@NgModule({
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  imports: [
    CommonModule,
    FormsModule,
    NbCardModule,
    RouterModule,
    NbAlertModule,
    NbInputModule,
    NbButtonModule, 
    NgxAuthRoutingModule,
    NbIconModule,
    NbAuthModule,
    ReactiveFormsModule,
    NbCheckboxModule
    
  ],
  declarations: [
    NgxLoginComponent,
    RegisterComponent,
    CheckConnectionComponent,
    ActivationKeyComponent,
 
  ],
})
export class NgxAuthModule {
}