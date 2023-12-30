import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { MainWindowComponent } from './main-window.component';
import { Ng2SmartTableModule } from 'ng2-smart-table';
import { NbActionsModule, NbAutocompleteModule, NbButtonModule, NbCardModule, NbCheckboxModule, NbDatepickerModule, NbDialogModule, NbIconModule, NbInputModule, NbPopoverModule, NbRadioModule, NbSelectModule, NbTableModule, NbTabsetModule, NbTreeGridModule, NbUserModule, NbWindowModule } from '@nebular/theme';
import { ThemeModule } from '../../@theme/theme.module';
import { ReactiveFormsModule, FormsModule as ngFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { CashComponent } from './cash/cash.component';
import { CloseModelRegisterComponent } from './close-model-register/close-model-register.component';
import { AddItemTypeComponent } from './add-item-type/add-item-type.component';
import { FavroiteCategoryComponent } from './favroite-category/favroite-category.component';
import { AddWearhouseComponent } from './add-wearhouse/add-wearhouse.component';
import { InventoryComponent } from './inventory/inventory.component';
import { AddItemModalComponent } from './add-item-modal/add-item-modal.component';
import { WearhouseQuantificationComponent } from './wearhouse-quantification/wearhouse-quantification.component';
import { ImportExportFormComponent } from './import-export-form/import-export-form.component';
import { PickItemModalComponent } from './pick-item-modal/pick-item-modal.component';
import { PickClientComponent } from './pick-client/pick-client.component';
import { OpenRegisterModalComponent } from './open-register-modal/open-register-modal.component';
import { TranslateModule } from '@ngx-translate/core';
import { UpdateQuantityComponent } from './update-quantity/update-quantity.component';
import { BillReciptComponent } from './bill-recipt/bill-recipt.component';
import { PerivousBillComponent } from './perivous-bill/perivous-bill.component';
import { RefundItemModalComponent } from './refund-item-modal/refund-item-modal.component';


@NgModule({
  declarations: [
    MainWindowComponent,
    CashComponent,
    CloseModelRegisterComponent,
    AddItemTypeComponent,
    FavroiteCategoryComponent,
    AddWearhouseComponent,
    InventoryComponent,
    AddItemModalComponent,
    WearhouseQuantificationComponent,
    ImportExportFormComponent,
    PickItemModalComponent,
    PickClientComponent,
    OpenRegisterModalComponent,
    UpdateQuantityComponent,
    BillReciptComponent,
    PerivousBillComponent,
    RefundItemModalComponent
  ],
  exports:[OpenRegisterModalComponent,CloseModelRegisterComponent],
  imports: [
    CommonModule,
    ThemeModule,
    NbAutocompleteModule,
    NbInputModule,
    NbCardModule,
    NbTableModule,
    NbTreeGridModule,
    NbButtonModule,
    NbPopoverModule,
    NbActionsModule,
    NbUserModule,
    NbDialogModule.forChild(),
    NbWindowModule.forChild(),
    TranslateModule.forChild(),
    NbCheckboxModule,
    NbRadioModule,
    NbDatepickerModule,
    ReactiveFormsModule,
    NbSelectModule,
    NbIconModule,
    ngFormsModule,
    NbTabsetModule,
    Ng2SmartTableModule,
    RouterModule.forChild([
      {
        path: '',
        component: MainWindowComponent
      },
      {
        path: 'cash',
        component: CashComponent
      },
      {
        path: 'add-type',
        component: AddItemTypeComponent
      },
      {
        path: 'faveroite-category',
        component: FavroiteCategoryComponent
      },
      {
        path: 'add-item',
        component: AddItemModalComponent
      },
      {
        path: 'inventory',
        component: InventoryComponent
      },
      {
        path: 'add-wearhouse',
        component: AddWearhouseComponent
      },
      {
        path: 'wearhouse-quantification',
        component: WearhouseQuantificationComponent
      },
      {
        path: 'import-export',
        component: ImportExportFormComponent
      },
    ]),
  ]
})
export class MainWindowModule { }
