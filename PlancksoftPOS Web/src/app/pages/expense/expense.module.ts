import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExpenseComponent } from './expense.component';
import { AddExpenseComponent } from './add-expense/add-expense.component';
import { ExpenseLookupComponent } from './expense-lookup/expense-lookup.component';
import { RouterModule } from '@angular/router';
import { Ng2SmartTableModule } from 'ng2-smart-table';
import { NbActionsModule, NbButtonModule, NbCardModule, NbCheckboxModule, NbDatepickerModule, NbDialogModule, NbIconModule, NbInputModule, NbPopoverModule, NbRadioModule, NbSelectModule, NbTableModule, NbTabsetModule, NbTooltipModule, NbTreeGridModule, NbUserModule, NbWindowModule } from '@nebular/theme';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ThemeModule } from '../../@theme/theme.module';
import { FormsModule as ngFormsModule } from '@angular/forms';
import { ModalOverlaysRoutingModule } from '../modal-overlays/modal-overlays-routing.module';
import { AddExpenseModalComponent } from './add-expense-modal/add-expense-modal.component';
import { TranslateModule } from '@ngx-translate/core';



@NgModule({
  declarations: [
    ExpenseComponent,
    AddExpenseComponent,
    ExpenseLookupComponent,
    AddExpenseModalComponent
  ],
  entryComponents:[AddExpenseComponent],
  imports: [
    FormsModule,
    NbDialogModule.forChild(),
    NbWindowModule.forChild(),
    NbPopoverModule,
    NbTooltipModule,
    CommonModule,
    ThemeModule,
    NbTreeGridModule,
    NbInputModule,
    NbCardModule,
    NbTableModule,
    NbButtonModule,
    NbActionsModule,
    NbUserModule,
    NbCheckboxModule,
    NbRadioModule,
    NbDatepickerModule,
    ReactiveFormsModule,
    NbSelectModule,
    NbIconModule,
    ngFormsModule,
    NbTabsetModule,
    Ng2SmartTableModule,
    TranslateModule.forChild(),
    RouterModule.forChild([
      {
        path: '',
        component: ExpenseComponent
      },
      {
        path: 'add-expanse',
        component: AddExpenseComponent
      },
      {
        path: 'expanse-lookup',
        component: ExpenseLookupComponent
      },
    ])
  ]
})
export class ExpenseModule { }
