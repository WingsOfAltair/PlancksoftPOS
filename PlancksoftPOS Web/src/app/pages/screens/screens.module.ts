import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ScreensComponent } from './screens.component';
import {
  NbActionsModule,
  NbButtonModule,
  
  NbCardModule,
  
  NbCheckboxModule,
  NbDatepickerModule, 
  NbIconModule,
  NbInputModule,
  NbPopoverModule,
  NbRadioModule,
  NbSelectModule,
  NbTabsetModule,
  NbTreeGridModule,
  NbUserModule,
  NbWindowModule,
} from '@nebular/theme';
import { ReactiveFormsModule, FormsModule as ngFormsModule } from '@angular/forms';


import { ThemeModule } from '../../@theme/theme.module';
import { ClintCardComponent } from '../screens/clint-card/clint-card.component';
import { Ng2SmartTableModule } from 'ng2-smart-table';
import { SalesComponent } from './sales/sales.component';
import { RouterModule } from '@angular/router';
import { PickCostumerComponent } from './pick-costumer/pick-costumer.component';
import { AboutComponent } from './about/about.component';
import { AddPrinterComponent } from './add-printer/add-printer.component';
import { EditPriceComponent } from './edit-price/edit-price.component';
import { RefundItemComponent } from './refund-item/refund-item.component';
import { PaymentComponent } from './payment/payment.component';
import { PickCostumerLookupComponent } from './pick-costumer-lookup/pick-costumer-lookup.component';
import { ItemComponent } from './item/item.component';
import { MainWindowComponent } from './main-window/main-window.component';
import { MainInventoryComponent } from './main-inventory/main-inventory.component';
import { UserComponent } from './user/user.component';
import { AlaramComponent } from './alaram/alaram.component';
import { AddEmployeeComponent } from './add-employee/add-employee.component';
import { AddEmployeeAbsenceModalComponent } from './add-employee-absence-modal/add-employee-absence-modal.component';
import { AddEmployeeSaleryDeductModalComponent } from './add-employee-salery-deduct-modal/add-employee-salery-deduct-modal.component';
import { EmployeeComponent } from './employee/employee.component';
import { AddEmployeeAbsenceComponent } from './add-employee-absence/add-employee-absence.component';
import { ImportExportCapitalComponent } from './import-export-capital/import-export-capital.component';
import { EditInvoiceComponent } from './edit-invoice/edit-invoice.component';
import { ImcomingOutgoingsaleComponent } from './imcoming-outgoingsale/imcoming-outgoingsale.component';
import { SoldItemQuantificationComponent } from './sold-item-quantification/sold-item-quantification.component';
import { ClientDefinationComponent } from './client-defination/client-defination.component';
import { ClientCheckBalanceComponent } from './client-check-balance/client-check-balance.component';
import { VendorsDefinationComponent } from './vendors-defination/vendors-defination.component';
import { VendorsCheckBalanceComponent } from './vendors-check-balance/vendors-check-balance.component';
import { ClientAddModalComponent } from './client-add-modal/client-add-modal.component';
import { VendorAddModalComponent } from './vendor-add-modal/vendor-add-modal.component';
import { AddSellItemComponent } from './add-sell-item/add-sell-item.component';
import { PrinterSettingComponent } from './printer-setting/printer-setting.component';
import { AddBillItemModalComponent } from './add-bill-item-modal/add-bill-item-modal.component';
import { UpdateBillComponent } from './update-bill/update-bill.component';
import { TaxReportComponent } from './tax-report/tax-report.component';
import { ReturnItemModalComponent } from './return-item-modal/return-item-modal.component';
import { PrinterModalComponent } from './printer-modal/printer-modal.component';
import { PrinterTypeModalComponent } from './printer-type-modal/printer-type-modal.component';
import { PrinterTypeComponent } from './printer-type/printer-type.component';
import { UserModalComponent } from './user-modal/user-modal.component';
import { TranslateModule } from '@ngx-translate/core';
import { PaymentModalComponent } from './payment-modal/payment-modal.component';
import { SettingComponent } from './setting/setting.component';


@NgModule({
  declarations: [
    ScreensComponent,
    ClintCardComponent,
    SalesComponent,
    PickCostumerComponent,
    AboutComponent,
    AddPrinterComponent,
    EditPriceComponent,
    RefundItemComponent,
    PaymentComponent,
    PickCostumerLookupComponent,
    ItemComponent,
    MainWindowComponent,
    MainInventoryComponent,
    UserComponent,
    AlaramComponent,
    AddEmployeeComponent,
    AddEmployeeAbsenceModalComponent,
    AddEmployeeSaleryDeductModalComponent,
    EmployeeComponent,
    AddEmployeeAbsenceComponent,
    ImportExportCapitalComponent,
    EditInvoiceComponent,
    SoldItemQuantificationComponent,
    ImcomingOutgoingsaleComponent,
    ClientDefinationComponent,
    ClientCheckBalanceComponent,
    VendorsDefinationComponent,
    VendorsCheckBalanceComponent,
    ClientAddModalComponent,
    VendorAddModalComponent,
    AddSellItemComponent,
    PrinterSettingComponent,
    AddBillItemModalComponent,
    UpdateBillComponent,
    TaxReportComponent,
    ReturnItemModalComponent,
    PrinterModalComponent,
    PrinterTypeModalComponent,
    PrinterTypeComponent,
    UserModalComponent,
    PaymentModalComponent,
    SettingComponent
  ],
  entryComponents:[AddEmployeeAbsenceModalComponent,AddEmployeeSaleryDeductModalComponent,AddEmployeeComponent],
  imports: [
    CommonModule,
    NbWindowModule.forChild(),
    ThemeModule,
    NbInputModule,
    NbTreeGridModule,
    NbCardModule,
    NbButtonModule,
    NbActionsModule,
    NbUserModule,
    NbCheckboxModule,
    NbRadioModule,
    NbPopoverModule,
    NbDatepickerModule,
    NbSelectModule,
    NbIconModule,
    ngFormsModule,
    ReactiveFormsModule,
    NbTabsetModule,
    TranslateModule.forChild(),
    Ng2SmartTableModule,
    RouterModule.forChild([
      {
        path: '',
        component: ScreensComponent
      },
      {
        path: 'client-card',
        component: ClintCardComponent
      },
      {
        path: 'sale',
        component: SalesComponent
      },
      {
        path: 'pick-costumer',
        component: PickCostumerComponent
      },
      {
        path: 'about',
        component: AboutComponent
      },
      {
        path: 'add-printer',
        component: AddPrinterComponent
      },
      {
        path: 'edit-price',
        component: EditPriceComponent
      },
      {
        path: 'refund-item',
        component: RefundItemComponent
      },
      {
        path: 'payment',
        component: PaymentComponent
      },
      {
        path: 'pick-costumer-lookup',
        component: PickCostumerLookupComponent
      },
      {
        path: 'item',
        component: ItemComponent
      },
      {
        path: 'main-window',
        component: MainWindowComponent
      },
      {
        path: 'user',
        component: UserComponent
      },
      {
        path: 'alaram',
        component: AlaramComponent,
      },
      {
        path: 'employee',
        component: EmployeeComponent,
      },
      {
        path: 'employee-absence',
        component: AddEmployeeAbsenceComponent,
      },
      {
        path: 'import-export-capital',
        component: ImportExportCapitalComponent,
      },
      {
        path: 'edit-invoice',
        component: EditInvoiceComponent,
      },
      {
        path: 'imcomming-outgoing',
        component: ImcomingOutgoingsaleComponent,
      },
      {
        path: 'sold-item-quantification',
        component: SoldItemQuantificationComponent,
      },
      {
        path: 'client-defination',
        component: ClientDefinationComponent,
      },
      {
        path: 'client-check-balance',
        component: ClientCheckBalanceComponent,
      },
      {
        path: 'vendor-defination',
        component: VendorsDefinationComponent,
      },
      {
        path: 'vendor-check-balance',
        component: VendorsCheckBalanceComponent,
      },
      {
        path: 'sell-item/:id', 
        component: AddSellItemComponent,
      },
      {
        path: 'sell-item', 
        component: AddSellItemComponent,
      },
      {
        path: 'tax-report', 
        component: TaxReportComponent,
      },
      {
        path: 'printer', 
        component: PrinterSettingComponent,
      },
      {
        path: 'printer-type', 
        component: PrinterTypeComponent,
      },
      {
        path: 'setting', 
        component: SettingComponent,
      },
    ]),
  ]
})
export class ScreensModule { }

