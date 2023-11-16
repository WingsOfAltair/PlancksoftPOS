using Dependencies;
using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel.Activation;
using System.ServiceModel;
using Dependencies.Models;
using System.Web.Script.Serialization;
using System.Globalization;
using System.ServiceModel.Web;
using System.Web.Script.Services;
using System.Runtime.InteropServices.ComTypes;

namespace PlancksoftPOSJSON_Server
{
    [ServiceBehavior(MaxItemsInObjectGraph = int.MaxValue)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class PlancksoftPOSJSON_Server : IPlancksoftPOSJSON_Server
    {
        DataAccessLayerJSON.DataAccessLayerJSON DAL = new DataAccessLayerJSON.DataAccessLayerJSON();

        public string CheckConnection()
        {
            return new JavaScriptSerializer().Serialize(DAL.CheckConnection());
        }
        public string RetrieveSaleByDate(DateTime StartDate, DateTime EndDate)
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveSaleByDate(StartDate, EndDate));
        }
        public string RetrieveSystemSettings()
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveSystemSettings());
        }
        public string UpdateSystemSettings(string SystemName, byte[] SystemLogo, string SystemPhone,
            string SystemAddress, int SystemReceiptBlankSpaces, int SystemIncludeLogoInReceipt, decimal SystemTax)
        {
            return new JavaScriptSerializer().Serialize(DAL.UpdateSystemSettings(SystemName, SystemLogo, SystemPhone, SystemAddress, SystemReceiptBlankSpaces, SystemIncludeLogoInReceipt, SystemTax));
        }
        public string RetrieveBillSoldBItemQuantity(int BillNumber, string itemBarcode)
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveBillSoldBItemQuantity(BillNumber, itemBarcode));
        }
        public string RetrieveItemTypeName(int ItemTypeIndex, int locale)
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveItemTypeName(ItemTypeIndex, locale));
        }
        public string RetrieveWarehouseName(int WarehouseIndex, int locale)
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveWarehouseName(WarehouseIndex, locale));
        }
        public string RetrieveFavoriteCategoryName(int CategoryIndex, int locale)
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveFavoriteCategoryName(CategoryIndex, locale));
        }
        public string RetrieveCashierNames()
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveCashierNames());
        }
        public string RetrieveItemTypeID(string ItemTypeName)
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveItemTypeID(ItemTypeName));
        }
        public string RetrieveWarehouseID(string WarehouseName)
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveWarehouseID(WarehouseName));
        }
        public string RetrieveFavoriteCategoryID(string CategoryName)
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveFavoriteCategoryID(CategoryName));
        }
        public string RetrieveItemTypes()
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveItemTypes());
        }
        public string RetrievePrinterItemTypes(int printerID)
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrievePrinterItemTypes(printerID));
        }
        public string RetrieveWarehouses()
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveWarehouses());
        }
        public string RetrieveFavoriteCategories()
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveFavoriteCategories());
        }
        public string RetrievePrinters(string machineName)
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrievePrinters(machineName));
        }
        public string RetrieveLoginLogoutInfo(DateTime Date)
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveLoginLogoutInfo(Date));
        }
        public string RetrieveUsersList()
        {  
            return new JavaScriptSerializer().Serialize(DAL.RetrieveUsersList()); 
        }
        public string GetRetrieveClients()
        {
            return new JavaScriptSerializer().Serialize(DAL.GetRetrieveClients());
        }
        public string GetRetrieveVendors()
        {
            return new JavaScriptSerializer().Serialize(DAL.GetRetrieveVendors());
        }
        public string CheckAdmin()
        {
            return new JavaScriptSerializer().Serialize(DAL.CheckAdmin());
        }
        public string RegisterAdmin(Account AccountToRegister)
        {
            return new JavaScriptSerializer().Serialize(DAL.RegisterAdmin(AccountToRegister));
        }
        public void LogLogout(string cashierName, DateTime date)
        {
            DAL.LogLogout(cashierName, date);
        }
        public void LogLogin(string cashierName, DateTime date)
        {
            DAL.LogLogin(cashierName, date);
        }
        public string Login(Account AccountToLogin)
        {
            return new JavaScriptSerializer().Serialize(DAL.Login(AccountToLogin));
        }
        public string Register(Account AccountToRegister, string UID, int AdminOrNot)
        {
            return new JavaScriptSerializer().Serialize(DAL.Register(AccountToRegister, UID, AdminOrNot));
        }
        public string DeleteFavoriteItem(string ItemBarCode)
        {
            return new JavaScriptSerializer().Serialize(DAL.DeleteFavoriteItem(ItemBarCode));
        }
        public string AddPrinterItemType(int printerID, int itemTypeID)
        {
            return new JavaScriptSerializer().Serialize(DAL.AddPrinterItemType(printerID, itemTypeID));
        }
        public string DeletePrinterItemType(int printerID, int itemTypeID)
        {
            return new JavaScriptSerializer().Serialize(DAL.DeletePrinterItemType(printerID, itemTypeID));
        }
        public string DeletePrinter(string machineName, int printerID)
        {
            return new JavaScriptSerializer().Serialize(DAL.DeletePrinter(machineName, printerID));
        }
        public string AddFavoriteItem(string ItemName, string ItemBarCode, int ItemQuantity, decimal ItemPrice, decimal ItemPriceTax, decimal Category, DateTime Date)
        {
            return new JavaScriptSerializer().Serialize(DAL.AddFavoriteItem(ItemName, ItemBarCode, ItemQuantity, ItemPrice, ItemPriceTax, Category, Date));
        }
        public string SaveRegisterClose(string cashierName, decimal moneyInRegister)
        {
            return new JavaScriptSerializer().Serialize(DAL.SaveRegisterClose(cashierName, moneyInRegister));
        }
        public string SaveRegisterOpen(string cashierName, decimal moneyInRegister)
        {
            return new JavaScriptSerializer().Serialize(DAL.SaveRegisterOpen(cashierName, moneyInRegister));
        }
        public string SearchWarehouseInventoryItems(int WarehouseID) { 
            return new JavaScriptSerializer().Serialize(DAL.SearchWarehouseInventoryItems(WarehouseID));
        }
        public string SearchInventoryItems(string ItemName = "", string ItemBarCode = "", int locale = 1)
        {
            return new JavaScriptSerializer().Serialize(DAL.SearchInventoryItems(ItemName, ItemBarCode, locale));
        }
        public string SearchInventoryItemsWithBarCode(string ItemBarCode = "")
        {
            return new JavaScriptSerializer().Serialize(DAL.SearchInventoryItemsWithBarCode(ItemBarCode));
        }
        public string RetrieveUnPortedBills()
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveUnPortedBills()); 
        }
        public string RetrievePortedBills()
        { 
            return new JavaScriptSerializer().Serialize(DAL.RetrievePortedBills());
        }
        public string RetrieveUnpaidBills()
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveUnpaidBills());
        }
        public string RetrieveClientBills(int ClientID)
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveClientBills(ClientID));
        }
        public string RetrieveVendorBills()
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveVendorBills());
        }
        public string RetrieveTaxZReport()
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveTaxZReport());
        }
        public string RetrieveBills()
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveBills());
        }
        public string RetrieveCapitalRevenue()
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveCapitalRevenue());
        }
        public string RetrieveExports()
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveExports());
        }
        public string RetrieveImports()
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveImports());
        }
        public string RetrieveLeastBoughtItems()
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveLeastBoughtItems());
        }
        public string RetrieveMostBoughtItems()
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveMostBoughtItems());
        }
        public string RetrieveAccountAuthority(string UserID = "")
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveAccountAuthority(UserID));
        }
        public string RetrieveUserPermissions(string UserID = "")
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveUserPermissions(UserID));
        }
        public string RetrieveItemPictureFromBarCode(string ItemBarCode)
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveItemPictureFromBarCode(ItemBarCode));
        }
        public string RetrieveItemsQuantityDates(string ItemBarCode)
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveItemsQuantityDates(ItemBarCode));
        }
        public string RetrieveItems(int locale)
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveItems(locale));
        }
        public string RetrieveEmployees(DateTime DateFrom, DateTime DateTo)
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveEmployees(DateFrom, DateTo));
        }
        public string RetrieveUsers()
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveUsers());
        }
        public string RetrieveVendorBillItems(int BillNumber)
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveVendorBillItems(BillNumber));
        }
        public string RetrieveBillItems(int BillNumber)
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveBillItems(BillNumber));
        }
        public string RetrieveBillItemsProfit(string Date1, string Date2, int ItemTypeID, string CashierName)
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveBillItemsProfit(Date1, Date2, ItemTypeID, CashierName));
        }
        public string RetrieveReturnedItems()
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveReturnedItems());
        }
        public string RetrieveFavoriteItems(int Category)
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveFavoriteItems(Category));
        }
        public string GetCapitalAmount()
        {
            return new JavaScriptSerializer().Serialize(DAL.GetCapitalAmount());
        }
        public string GetOpenRegisterAmount()
        {
            return new JavaScriptSerializer().Serialize(DAL.GetOpenRegisterAmount());
        }
        public string GetTotalSalesAmountCloseCash()
        {
            return new JavaScriptSerializer().Serialize(DAL.GetTotalSalesAmountCloseCash());
        }
        public string GetTotalSalesAmount()
        {
            return new JavaScriptSerializer().Serialize(DAL.GetTotalSalesAmount());
        }
        public string GetLastOpenRegisterDate()
        {
            return new JavaScriptSerializer().Serialize(DAL.GetLastOpenRegisterDate());
        }
        public string InsertExpense(string ExpenseName, decimal ExpenseCost, string EmployeeName, DateTime Date)
        {
            return new JavaScriptSerializer().Serialize(DAL.InsertExpense(ExpenseName, ExpenseCost, EmployeeName, Date));
        }
        public string InsertDeduction(int EmployeeID, DateTime Date, decimal Deduction)
        {
            return new JavaScriptSerializer().Serialize(DAL.InsertDeduction(EmployeeID, Date, Deduction));
        }
        public string InsertDayOff(int EmployeeID, DateTime Date)
        {
            return new JavaScriptSerializer().Serialize(DAL.InsertDayOff(EmployeeID, Date));
        }
        public string InsertAbsence(int EmployeeID, DateTime Date, int Hours)
        {
            return new JavaScriptSerializer().Serialize(DAL.InsertAbsence(EmployeeID, Date, Hours));
        }
        public string InsertEmployee(string EmployeeName, decimal Salary, string Phone, string Address)
        {
            return new JavaScriptSerializer().Serialize(DAL.InsertEmployee(EmployeeName, Salary, Phone, Address));
        }
        public string InsertItem(Item ItemToInsert)
        {
            return new JavaScriptSerializer().Serialize(DAL.InsertItem(ItemToInsert));
        }
        public string DeleteItemType(int ItemTypeID)
        {
            return new JavaScriptSerializer().Serialize(DAL.DeleteItemType(ItemTypeID));
        }
        public string DeleteWarehouse(int WarehouseID)
        {
            return new JavaScriptSerializer().Serialize(DAL.DeleteWarehouse(WarehouseID));
        }
        public string DeleteFavoriteCategory(int FavoriteCategoryID)
        {
            return new JavaScriptSerializer().Serialize(DAL.DeleteFavoriteCategory(FavoriteCategoryID));
        }
        public string UpdateItemTypes(int ItemTypeID, string ItemTypeName)
        {
            return new JavaScriptSerializer().Serialize(DAL.UpdateItemTypes(ItemTypeID, ItemTypeName));
        }
        public string UpdateWarehouses(int WarehouseID, string WarehouseName)
        {
            return new JavaScriptSerializer().Serialize(DAL.UpdateWarehouses(WarehouseID, WarehouseName));
        }
        public string UpdateFavoriteCategories(int FavoriteCategoryID, string FavoriteCategory)
        {
            return new JavaScriptSerializer().Serialize(DAL.UpdateFavoriteCategories(FavoriteCategoryID, FavoriteCategory));
        }
        public string UpdatePrinters(int printerID, string printerName)
        {
            return new JavaScriptSerializer().Serialize(DAL.UpdatePrinters(printerID, printerName));
        }
        public string InsertItemType(string ItemTypeName)
        {
            return new JavaScriptSerializer().Serialize(DAL.InsertItemType(ItemTypeName));
        }
        public string InsertWarehouse(string WarehouseName)
        {
            return new JavaScriptSerializer().Serialize(DAL.InsertWarehouse(WarehouseName));
        }
        public string InsertFavoriteCategory(string FavoriteCategory)
        {
            return new JavaScriptSerializer().Serialize(DAL.InsertFavoriteCategory(FavoriteCategory));
        }
        public string InsertPrinter(string machineName, string printerName)
        {
            return new JavaScriptSerializer().Serialize(DAL.InsertPrinter(machineName, printerName));
        }
        public string DeleteClient(string ClientID)
        {
            return new JavaScriptSerializer().Serialize(DAL.DeleteClient(ClientID));
        }
        public string RegisterClient(Client ClientToInsert)
        {
            return new JavaScriptSerializer().Serialize(DAL.RegisterClient(ClientToInsert));
        }
        public string RegisterVendor(Client ClientToInsert)
        {
            return new JavaScriptSerializer().Serialize(DAL.RegisterVendor(ClientToInsert));
        }
        public string DeleteAbsence(int AbsenceID)
        {
            return new JavaScriptSerializer().Serialize(DAL.DeleteAbsence(AbsenceID));
        }   
        public string DeleteDeduction(int DeductionID)
        {
            return new JavaScriptSerializer().Serialize(DAL.DeleteDeduction(DeductionID));
        }
        public string DeleteEmployee(int EmployeeID)
        {
            return new JavaScriptSerializer().Serialize(DAL.DeleteEmployee(EmployeeID));
        }
        public string DeleteUser(Account UserToUpdate, string cashierName)
        {
            return new JavaScriptSerializer().Serialize(DAL.DeleteUser(UserToUpdate, cashierName));
        }
        public string AddSaleOnItems(List<Item> saleItems)
        {
            return new JavaScriptSerializer().Serialize(DAL.AddSaleOnItems(saleItems));
        }
        public string AddItemToClient(string ItemBarCode, int ClientID, decimal ClientPrice)
        {
            return new JavaScriptSerializer().Serialize(DAL.AddItemToClient(ItemBarCode, ClientID, ClientPrice));
        }
        public string AddUnpaidBill(Bill billToAdd, string cashierName)
        {
            return new JavaScriptSerializer().Serialize(DAL.AddUnpaidBill(billToAdd, cashierName));
        }
        public string AddVendorBill(Bill billToAdd, string cashierName)
        {
            return new JavaScriptSerializer().Serialize(DAL.AddVendorBill(billToAdd, cashierName));
        }
        public string PayUnpaidBill(int BillNumber, decimal paidAmount)
        {
            return new JavaScriptSerializer().Serialize(DAL.PayUnpaidBill(BillNumber, paidAmount));
        }
        public string PayBill(Bill billToAdd, string cashierName)
        {
            return new JavaScriptSerializer().Serialize(DAL.PayBill(billToAdd, cashierName));
        }
        public string UpdateEmployee(int EmployeeID, string EmployeeName, decimal Salary, string Phone, string Address)
        {
            return new JavaScriptSerializer().Serialize(DAL.UpdateEmployee(EmployeeID, EmployeeName, Salary, Phone, Address));
        } 
        public string UpdateAbsence(int AbsenceID, int Hours)
        {
            return new JavaScriptSerializer().Serialize(DAL.UpdateAbsence(AbsenceID, Hours));
        }  
        public string UpdateDeduction(int DeductionID, int DeductionAmount)
        {
            return new JavaScriptSerializer().Serialize(DAL.UpdateDeduction(DeductionID, DeductionAmount));
        }
        public string UpdateUser(Account UserToUpdate, string cashierName, int AdminOrNot)
        {
            return new JavaScriptSerializer().Serialize(DAL.UpdateUser(UserToUpdate, cashierName, AdminOrNot));
        }
        public string UpdateBill(int BillNumber, string CashierName, decimal TotalAmount, decimal PaidAmount, decimal RemainderAmount)
        {
            return new JavaScriptSerializer().Serialize(DAL.UpdateBill(BillNumber, CashierName, TotalAmount, PaidAmount, RemainderAmount));
        }
        public string ReturnItem(string ItemName, string ItemBarCode, int ItemQuantity, string cashierName)
        {
            return new JavaScriptSerializer().Serialize(DAL.ReturnItem(ItemName, ItemBarCode, ItemQuantity, cashierName));
        }
        public string UpdateItemWarehouse(List<Item> ItemsToUpdate, string EmployeeName, int EntryExitType)
        {
            return new JavaScriptSerializer().Serialize(DAL.UpdateItemWarehouse(ItemsToUpdate, EmployeeName, EntryExitType));
        }
        public string UpdateItem(Item ItemToUpdate)
        {
            return new JavaScriptSerializer().Serialize(DAL.UpdateItem(ItemToUpdate));
        }
        public string UpdateItemQuantity(Item ItemToUpdate)
        {
            return new JavaScriptSerializer().Serialize(DAL.UpdateItemQuantity(ItemToUpdate));
        }
        public string DeleteItem(string ItemBarCode)
        {
            return new JavaScriptSerializer().Serialize(DAL.DeleteItem(ItemBarCode));
        }
        public string RetrieveLastVendorBillNumberToday(DateTime Date)
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveLastVendorBillNumberToday(Date));
        }
        public string RetrieveTotalActiveItems(DateTime ExpirationDate)
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveTotalActiveItems(ExpirationDate));
        } 
        public string RetrieveClientCount()
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveClientCount());
        }   
        public string RetrieveBillsCountByDate(DateTime StartDate, DateTime EndDate)
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveBillsCountByDate(StartDate, EndDate));
        }  
        public string RetrieveLastBillNumberToday()
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveLastBillNumberToday());
        }
        public string RetrieveItemsQuantity(string ItemBarCode = "")
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveItemsQuantity(ItemBarCode));
        }
        public string RetrieveSaleItemsQuantity()
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveSaleItemsQuantity());
        }
        public string RetrieveExpireStockToday(DateTime Date)
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveExpireStockToday(Date));
        }
        public string RetrieveSaleDateRange(DateTime StartDate, DateTime EndDate, int QuantityEnd = 0)
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveSaleDateRange(StartDate, EndDate, QuantityEnd));
        }  
        public string RetrieveSaleToday(DateTime Date, int QuantityEnd = 0)
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveSaleToday(Date, QuantityEnd));
        }
        public string SearchTodayBills(DateTime Date)
        {
            return new JavaScriptSerializer().Serialize(DAL.SearchTodayBills(Date));
        }
        public string SearchBills(string dateFrom, string dateTo, int BillNumber = 0)
        {
            return new JavaScriptSerializer().Serialize(DAL.SearchBills(dateFrom, dateTo, BillNumber));
        }
        public string GetItemQuantity(string ItemBarCode = "")
        {
            return new JavaScriptSerializer().Serialize(DAL.GetItemQuantity(ItemBarCode));
        }
        public string RetrieveAbsence(DateTime Date1, DateTime Date2)
        {
            return new JavaScriptSerializer().Serialize(DAL.RetrieveAbsence(Date1, Date2));
        }
        public string SearchExpenses(string Date1, string Date2, string ExpenseName = "", string EmployeeID = "")
        {
            return new JavaScriptSerializer().Serialize(DAL.SearchExpenses(Date1, Date2, ExpenseName, EmployeeID));
        }
        public string SearchItems(string ItemName = "", string ItemBarCode = "", int ItemType = 0)
        {
            return new JavaScriptSerializer().Serialize(DAL.SearchItems(ItemName, ItemBarCode, ItemType));
        }
        public string SearchClients(string ClientName = "", string ClientID = "", string itemName = "")
        {
            return new JavaScriptSerializer().Serialize(DAL.SearchClients(ClientName, ClientID, itemName));
        }
        public string SearchClientsInfo(string ClientName = "", string ClientID = "")
        {
            return new JavaScriptSerializer().Serialize(DAL.SearchClientsInfo(ClientName, ClientID));
        }
    }
}
