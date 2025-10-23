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
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.CheckConnection());
        }
        public string RetrieveSaleByDate(DateTime StartDate, DateTime EndDate)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveSaleByDate(StartDate, EndDate));
        }
        public string RetrieveSystemSettings()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveSystemSettings());
        }
        public string UpdateSystemSettings(string SystemName, byte[] SystemLogo, string SystemPhone,
            string SystemAddress, int SystemReceiptBlankSpaces, int SystemIncludeLogoInReceipt, decimal SystemTax)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.UpdateSystemSettings(SystemName, SystemLogo, SystemPhone, SystemAddress, SystemReceiptBlankSpaces, SystemIncludeLogoInReceipt, SystemTax));
        }   
        public string ReprintBill(int BillNumber)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.ReprintBill(BillNumber));
        }  
        public string UpdateClientVendor(Client ClientToUpdate)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.UpdateClientVendor(ClientToUpdate));
        }
        public string RetrieveBillSoldBItemQuantity(int BillNumber, string itemBarcode)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveBillSoldBItemQuantity(BillNumber, itemBarcode));
        }
        public string RetrieveItemTypeName(int ItemTypeIndex, int locale)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveItemTypeName(ItemTypeIndex, locale));
        }
        public string RetrieveWarehouseName(int WarehouseIndex, int locale)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveWarehouseName(WarehouseIndex, locale));
        }
        public string RetrieveFavoriteCategoryName(int CategoryIndex, int locale)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveFavoriteCategoryName(CategoryIndex, locale));
        }
        public string RetrieveCashierNames()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveCashierNames());
        }
        public string RetrieveItemTypeID(string ItemTypeName)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveItemTypeID(ItemTypeName));
        }
        public string RetrieveWarehouseID(string WarehouseName)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveWarehouseID(WarehouseName));
        }
        public string RetrieveFavoriteCategoryID(string CategoryName)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveFavoriteCategoryID(CategoryName));
        }
        public string RetrieveItemTypes()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveItemTypes());
        }
        public string RetrievePrinterItemTypes(int printerID)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrievePrinterItemTypes(printerID));
        }
        public string RetrieveWarehouses()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveWarehouses());
        }
        public string RetrieveFavoriteCategories()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveFavoriteCategories());
        }
        public string RetrievePrinters(string machineName)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrievePrinters(machineName));
        }
        public string RetrieveLoginLogoutInfo(DateTime Date)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveLoginLogoutInfo(Date));
        }
        public string RetrieveUsersList()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveUsersList()); 
        }
        public string GetRetrieveClients()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.GetRetrieveClients());
        }
        public string GetRetrieveVendors()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.GetRetrieveVendors());
        }
        public string CheckAdmin()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.CheckAdmin());
        }
        public string RegisterAdmin(Account AccountToRegister)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RegisterAdmin(AccountToRegister));
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
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.Login(AccountToLogin));
        }
        public string Register(Account AccountToRegister, string UID, int AdminOrNot)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.Register(AccountToRegister, UID, AdminOrNot));
        }
        public string DeleteFavoriteItem(string ItemBarCode)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.DeleteFavoriteItem(ItemBarCode));
        }
        public string AddPrinterItemType(int printerID, int itemTypeID)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.AddPrinterItemType(printerID, itemTypeID));
        }
        public string DeletePrinterItemType(int printerID, int itemTypeID)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.DeletePrinterItemType(printerID, itemTypeID));
        }
        public string DeletePrinter(string machineName, int printerID)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.DeletePrinter(machineName, printerID));
        }
        public string AddFavoriteItem(string ItemName, string ItemBarCode, int ItemQuantity, decimal ItemPrice, decimal ItemPriceTax, decimal Category, DateTime Date)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.AddFavoriteItem(ItemName, ItemBarCode, ItemQuantity, ItemPrice, ItemPriceTax, Category, Date));
        }
        public string SaveRegisterClose(string cashierName, string cashName, decimal moneyInRegister)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.SaveRegisterClose(cashierName, cashName, moneyInRegister));
        }
        public string SaveRegisterOpen(string cashierName, string cashName, decimal moneyInRegister)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.SaveRegisterOpen(cashierName, cashName, moneyInRegister));
        }
        public string SearchWarehouseInventoryItems(int WarehouseID)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.SearchWarehouseInventoryItems(WarehouseID));
        }
        public string SearchInventoryItems(string ItemName = "", string ItemBarCode = "", int locale = 1)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.SearchInventoryItems(ItemName, ItemBarCode, locale));
        }
        public string SearchInventoryItemsWithBarCode(string ItemBarCode = "")
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.SearchInventoryItemsWithBarCode(ItemBarCode));
        }
        public string RetrieveUnPortedBills(string Date1, string Date2)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveUnPortedBills(Date1, Date2)); 
        }
        public string RetrievePortedBills(string Date1, string Date2)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrievePortedBills(Date1, Date2));
        }
        public string RetrieveUnpaidBills()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveUnpaidBills());
        }
        public string RetrieveClientBills(int ClientID)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveClientBills(ClientID));
        }
        public string RetrieveVendorBills(int ClientID)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveVendorBills(ClientID));
        }
        public string RetrieveTaxZReport(string StartDate, string EndDate)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveTaxZReport(StartDate, EndDate));
        }
        public string RetrieveBillsRefund(string customerName)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveBillsRefund(customerName));
        }
        public string RetrieveBills()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveBills());
        }  
        public string RetrieveCapitalRevenue()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveCapitalRevenue());
        }
        public string RetrieveExports()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveExports());
        }
        public string RetrieveImports()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveImports());
        }
        public string RetrieveLeastBoughtItems()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveLeastBoughtItems());
        }
        public string RetrieveMostBoughtItems()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveMostBoughtItems());
        }
        public string RetrieveAccountAuthority(string UserID = "")
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveAccountAuthority(UserID));
        }
        public string RetrieveUserPermissions(string UserID = "")
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveUserPermissions(UserID));
        }
        public string RetrieveItemPictureFromBarCode(string ItemBarCode)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveItemPictureFromBarCode(ItemBarCode));
        }
        public string RetrieveItemsQuantityDates(string ItemBarCode)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveItemsQuantityDates(ItemBarCode));
        }
        public string RetrieveItems(int locale)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer(); 
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveItems(locale));
        }
        public string RetrieveEmployees(DateTime DateFrom, DateTime DateTo)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveEmployees(DateFrom, DateTo));
        }
        public string RetrieveEmployeesData()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveEmployeesData());
        }
        public string RetrieveUsers()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveUsers());
        }
        public string RetrieveVendorBillItems(int BillNumber)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveVendorBillItems(BillNumber));
        }
        public string RetrieveBillItems(int BillNumber)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveBillItems(BillNumber));
        }  
        public string RetrieveBillItemsRefund(int BillNumber)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveBillItemsRefund(BillNumber));
        }
        public string RetrieveBillItemsProfit(string Date1, string Date2, int ItemTypeID, string CashierName)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveBillItemsProfit(Date1, Date2, ItemTypeID, CashierName));
        }
        public string RetrieveReturnedItems()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveReturnedItems());
        }
        public string RetrieveFavoriteItems(int Category)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveFavoriteItems(Category));
        }
        public string GetCapitalAmount()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.GetCapitalAmount());
        }
        public string GetOpenRegisterAmount()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.GetOpenRegisterAmount());
        }
        public string GetTotalSalesAmountCloseCash()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.GetTotalSalesAmountCloseCash());
        }
        public string GetTotalSalesAmount()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.GetTotalSalesAmount());
        }
        public string GetLastOpenRegisterDate()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.GetLastOpenRegisterDate());
        }
        public string InsertExpense(string ExpenseName, decimal ExpenseCost, string EmployeeName, DateTime Date)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.InsertExpense(ExpenseName, ExpenseCost, EmployeeName, Date));
        }
        public string InsertDeduction(int EmployeeID, DateTime Date, decimal Deduction)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.InsertDeduction(EmployeeID, Date, Deduction));
        }
        public string InsertDayOff(int EmployeeID, DateTime Date)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.InsertDayOff(EmployeeID, Date));
        }
        public string InsertAbsence(int EmployeeID, DateTime Date, int Hours)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.InsertAbsence(EmployeeID, Date, Hours));
        }
        public string InsertEmployee(string EmployeeName, decimal Salary, string Phone, string Address)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.InsertEmployee(EmployeeName, Salary, Phone, Address));
        }
        public string InsertItem(Item ItemToInsert)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.InsertItem(ItemToInsert));
        }
        public string DeleteItemType(int ItemTypeID)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.DeleteItemType(ItemTypeID));
        }
        public string DeleteWarehouse(int WarehouseID)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.DeleteWarehouse(WarehouseID));
        }
        public string DeleteFavoriteCategory(int FavoriteCategoryID)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.DeleteFavoriteCategory(FavoriteCategoryID));
        }
        public string UpdateItemTypes(int ItemTypeID, string ItemTypeName)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.UpdateItemTypes(ItemTypeID, ItemTypeName));
        }
        public string UpdateWarehouses(int WarehouseID, string WarehouseName)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.UpdateWarehouses(WarehouseID, WarehouseName));
        }
        public string UpdateFavoriteCategories(int FavoriteCategoryID, string FavoriteCategory)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.UpdateFavoriteCategories(FavoriteCategoryID, FavoriteCategory));
        }
        public string UpdatePrinters(int printerID, string printerName, string machineName, int isMainPrinter)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.UpdatePrinters(printerID, printerName, machineName, isMainPrinter));
        }
        public string InsertItemType(string ItemTypeName)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.InsertItemType(ItemTypeName));
        }
        public string InsertWarehouse(string WarehouseName)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.InsertWarehouse(WarehouseName));
        }
        public string InsertFavoriteCategory(string FavoriteCategory)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.InsertFavoriteCategory(FavoriteCategory));
        }
        public string InsertPrinter(string machineName, string printerName)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.InsertPrinter(machineName, printerName));
        }
        public string DeleteClient(string ClientID)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.DeleteClient(ClientID));
        }
        public string RegisterClient(Client ClientToInsert)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RegisterClient(ClientToInsert));
        }
        public string RegisterVendor(Client ClientToInsert)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RegisterVendor(ClientToInsert));
        }
        public string DeleteAbsence(int AbsenceID)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.DeleteAbsence(AbsenceID));
        }   
        public string DeleteDeduction(int DeductionID)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.DeleteDeduction(DeductionID));
        }
        public string DeleteEmployee(int EmployeeID)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.DeleteEmployee(EmployeeID));
        }
        public string DeleteUser(Account UserToUpdate, string cashierName)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.DeleteUser(UserToUpdate, cashierName));
        }
        public string AddSaleOnItems(List<Item> saleItems)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.AddSaleOnItems(saleItems));
        }
        public string AddItemToClient(string ItemBarCode, int ClientID, decimal ClientPrice)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.AddItemToClient(ItemBarCode, ClientID, ClientPrice));
        }
        public string AddUnpaidBill(Bill billToAdd, string cashierName)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.AddUnpaidBill(billToAdd, cashierName));
        }
        public string AddVendorBill(Bill billToAdd, string cashierName)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.AddVendorBill(billToAdd, cashierName));
        }
        public string PayUnpaidBill(int BillNumber, decimal paidAmount)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.PayUnpaidBill(BillNumber, paidAmount));
        }
        public string PayBill(Bill billToAdd, string cashierName)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.PayBill(billToAdd, cashierName));
        }
        public string UpdateEmployee(int EmployeeID, string EmployeeName, decimal Salary, string Phone, string Address)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.UpdateEmployee(EmployeeID, EmployeeName, Salary, Phone, Address));
        } 
        public string UpdateAbsence(int AbsenceID, int Hours)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.UpdateAbsence(AbsenceID, Hours));
        }  
        public string UpdateDeduction(int DeductionID, int DeductionAmount)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.UpdateDeduction(DeductionID, DeductionAmount));
        }
        public string UpdateUser(Account UserToUpdate, string cashierName, int AdminOrNot)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.UpdateUser(UserToUpdate, cashierName, AdminOrNot));
        }
        public string UpdateBill(int BillNumber, string CashierName, decimal TotalAmount, decimal PaidAmount, decimal RemainderAmount)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.UpdateBill(BillNumber, CashierName, TotalAmount, PaidAmount, RemainderAmount));
        }
        public string ReturnItem(string ItemName, string ItemBarCode, int ItemQuantity, string cashierName, int BillID)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.ReturnItem(ItemName, ItemBarCode, ItemQuantity, cashierName, BillID));
        }
        public string UpdateItemWarehouse(List<Item> ItemsToUpdate, string EmployeeName, int EntryExitType)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.UpdateItemWarehouse(ItemsToUpdate, EmployeeName, EntryExitType));
        }
        public string UpdateItem(Item ItemToUpdate)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.UpdateItem(ItemToUpdate));
        }
        public string UpdateItemQuantity(Item ItemToUpdate)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.UpdateItemQuantity(ItemToUpdate));
        }
        public string DeleteItem(string ItemBarCode)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.DeleteItem(ItemBarCode));
        }
        public string RetrieveLastVendorBillNumberToday(DateTime Date)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveLastVendorBillNumberToday(Date));
        }
        public string RetrieveTotalActiveItems(DateTime ExpirationDate)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveTotalActiveItems(ExpirationDate));
        } 
        public string RetrieveClientCount()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveClientCount());
        }   
        public string RetrieveBillsCountByDate(DateTime StartDate, DateTime EndDate)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveBillsCountByDate(StartDate, EndDate));
        }  
        public string RetrieveLastBillNumberToday()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveLastBillNumberToday());
        }
        public string RetrieveItemsQuantity(string ItemBarCode = "")
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveItemsQuantity(ItemBarCode));
        }
        public string RetrieveSaleItemsQuantity()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveSaleItemsQuantity());
        }
        public string RetrieveExpireStockToday(DateTime Date)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveExpireStockToday(Date));
        }
        public string RetrieveSaleDateRange(DateTime StartDate, DateTime EndDate, int QuantityEnd = 0)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveSaleDateRange(StartDate, EndDate, QuantityEnd));
        }  
        public string RetrieveSaleToday(DateTime Date, int QuantityEnd = 0)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveSaleToday(Date, QuantityEnd));
        }
        public string SearchTodayBills(DateTime Date)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.SearchTodayBills(Date));
        }
        public string SearchBills(string dateFrom, string dateTo, int BillNumber = 0)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.SearchBills(dateFrom, dateTo, BillNumber));
        }
        public string GetItemQuantity(string ItemBarCode = "")
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.GetItemQuantity(ItemBarCode));
        }
        public string RetrieveAbsence(DateTime Date1, DateTime Date2)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.RetrieveAbsence(Date1, Date2));
        }
        public string SearchExpenses(string Date1, string Date2, string ExpenseName = "", string EmployeeID = "")
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.SearchExpenses(Date1, Date2, ExpenseName, EmployeeID));
        }
        public string SearchItems(string ItemName = "", string ItemBarCode = "", int ItemType = 0)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.SearchItems(ItemName, ItemBarCode, ItemType));
        }
        public string SearchClients(string ClientName = "", string ClientID = "", string itemName = "")
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.SearchClients(ClientName, ClientID, itemName));
        }
        public string SearchClientsInfo(string ClientName = "", string ClientID = "")
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(DAL.SearchClientsInfo(ClientName, ClientID));
        }
    }
}
