using Dependencies;
using System;
using System.Collections.Generic;
using System.Data;

namespace PlancksoftPOS_Server
{
    public class PlancksoftPOS_Server : IPlancksoftPOS_Server
    {
        DataAccessLayer.DataAccessLayer DAL = new DataAccessLayer.DataAccessLayer();
        public bool CheckConnection()
        {
            return DAL.CheckConnection();
        }
        public DataTable RetrieveSystemSettings()
        {
            return DAL.RetrieveSystemSettings();
        }
        public bool UpdateSystemSettings(string SystemName, byte[] SystemLogo, string SystemPhone,
            string SystemAddress, int SystemReceiptBlankSpaces, int SystemIncludeLogoInReceipt, decimal SystemTax)
        {
            return DAL.UpdateSystemSettings(SystemName, SystemLogo, SystemPhone, SystemAddress, SystemReceiptBlankSpaces, SystemIncludeLogoInReceipt, SystemTax);
        }
        public int RetrieveBillSoldBItemQuantity(int BillNumber, string itemBarcode)
        {
            return DAL.RetrieveBillSoldBItemQuantity(BillNumber, itemBarcode);
        }
        public string RetrieveItemTypeName(int ItemTypeIndex, int locale)
        {
            return DAL.RetrieveItemTypeName(ItemTypeIndex, locale);
        }
        public string RetrieveWarehouseName(int WarehouseIndex, int locale)
        {
            return DAL.RetrieveWarehouseName(WarehouseIndex, locale);
        }
        public string RetrieveFavoriteCategoryName(int CategoryIndex, int locale)
        {
            return DAL.RetrieveFavoriteCategoryName(CategoryIndex, locale);
        }
        public List<string> RetrieveCashierNames()
        {
            return DAL.RetrieveCashierNames();
        }
        public int RetrieveItemTypeID(string ItemTypeName)
        {
            return DAL.RetrieveItemTypeID(ItemTypeName);
        }
        public int RetrieveWarehouseID(string WarehouseName)
        {
            return DAL.RetrieveWarehouseID(WarehouseName);
        }
        public int RetrieveFavoriteCategoryID(string CategoryName)
        {
            return DAL.RetrieveFavoriteCategoryID(CategoryName);
        }
        public List<ItemType> RetrieveItemTypes()
        {
            return DAL.RetrieveItemTypes();
        }
        public List<ItemType> RetrievePrinterItemTypes(int printerID)
        {
            return DAL.RetrievePrinterItemTypes(printerID);
        }
        public List<Warehouse> RetrieveWarehouses()
        {
            return DAL.RetrieveWarehouses();
        }
        public List<Category> RetrieveFavoriteCategories()
        {
            return DAL.RetrieveFavoriteCategories();
        }
        public List<Printer> RetrievePrinters(string machineName)
        {
            return DAL.RetrievePrinters(machineName);
        }
        public DataTable RetrieveLoginLogoutInfo(DateTime Date)
        {
            return DAL.RetrieveLoginLogoutInfo(Date);
        }
        public Tuple<List<Account>, DataTable> RetrieveUsersList()
        { 
            return DAL.RetrieveUsersList(); 
        }
        public DataTable GetRetrieveClients()
        {
            return DAL.GetRetrieveClients();
        }
        public DataTable GetRetrieveVendors()
        {
            return DAL.GetRetrieveVendors();
        }
        public bool CheckAdmin()
        {
            return DAL.CheckAdmin();
        }
        public bool RegisterAdmin(Account AccountToRegister)
        {
            return DAL.RegisterAdmin(AccountToRegister);
        }
        public void LogLogout(string cashierName, DateTime date)
        {
            DAL.LogLogout(cashierName, date);
        }
        public void LogLogin(string cashierName, DateTime date)
        {
            DAL.LogLogin(cashierName, date);
        }
        public Tuple<bool, string, bool, bool> Login(Account AccountToLogin)
        {
            return DAL.Login(AccountToLogin);
        }
        public bool Register(Account AccountToRegister, string UID, int AdminOrNot)
        {
            return DAL.Register(AccountToRegister, UID, AdminOrNot);
        }
        public bool DeleteFavoriteItem(string ItemBarCode)
        {
            return DAL.DeleteFavoriteItem(ItemBarCode);
        }
        public bool AddPrinterItemType(int printerID, int itemTypeID)
        {
            return DAL.AddPrinterItemType(printerID, itemTypeID);
        }
        public bool DeletePrinterItemType(int printerID, int itemTypeID)
        {
            return DAL.DeletePrinterItemType(printerID, itemTypeID);
        }
        public bool DeletePrinter(string machineName, int printerID)
        {
            return DAL.DeletePrinter(machineName, printerID);
        }
        public bool AddFavoriteItem(string ItemName, string ItemBarCode, int ItemQuantity, decimal ItemPrice, decimal ItemPriceTax, decimal Category, DateTime Date)
        {
            return DAL.AddFavoriteItem(ItemName, ItemBarCode, ItemQuantity, ItemPrice, ItemPriceTax, Category, Date);
        }
        public bool SaveRegisterClose(string cashierName, decimal moneyInRegister)
        {
            return DAL.SaveRegisterClose(cashierName, moneyInRegister);
        }
        public bool SaveRegisterOpen(string cashierName, decimal moneyInRegister)
        {
            return DAL.SaveRegisterOpen(cashierName, moneyInRegister);
        }
        public Tuple<List<Item>, DataTable> SearchWarehouseInventoryItems(int WarehouseID) { 
            return DAL.SearchWarehouseInventoryItems(WarehouseID);
        }
        public Tuple<List<Item>, DataTable> SearchInventoryItems(string ItemName = "", string ItemBarCode = "", int locale = 1)
        {
            return DAL.SearchInventoryItems(ItemName, ItemBarCode, locale);
        }
        public Item SearchInventoryItemsWithBarCode(string ItemBarCode = "")
        {
            return DAL.SearchInventoryItemsWithBarCode(ItemBarCode);
        }
        public Tuple<List<Bill>, DataTable> RetrieveUnPortedBills()
        {
            return DAL.RetrieveUnPortedBills(); 
        }
        public Tuple<List<Bill>, DataTable> RetrievePortedBills()
        { 
            return DAL.RetrievePortedBills();
        }
        public Tuple<List<Bill>, DataTable> RetrieveUnpaidBills()
        {
            return DAL.RetrieveUnpaidBills();
        }
        public DataTable RetrieveClientBills(int ClientID)
        {
            return DAL.RetrieveClientBills(ClientID);
        }
        public Tuple<List<Bill>, DataTable> RetrieveVendorBills(int ClientID)
        {
            return DAL.RetrieveVendorBills(ClientID);
        }
        public DataTable RetrieveTaxZReport(string StartDate, string EndDate)
        {
            return DAL.RetrieveTaxZReport(StartDate, EndDate);
        }
        public Tuple<List<Bill>, DataTable> RetrieveBillsRefund()
        {
            return DAL.RetrieveBillsRefund();
        }
        public Tuple<List<Bill>, DataTable> RetrieveBills()
        {
            return DAL.RetrieveBills();
        } 
        public Tuple<List<Bill>, DataTable> RetrieveUnprintedBills()
        {
            return DAL.RetrieveUnprintedBills();
        } 
        public Tuple<List<Item>, DataTable> RetrieveCapitalRevenue()
        {
            return DAL.RetrieveCapitalRevenue();
        }
        public Tuple<List<Item>, DataTable> RetrieveExports()
        {
            return DAL.RetrieveExports();
        }
        public Tuple<List<Item>, DataTable> RetrieveImports()
        {
            return DAL.RetrieveImports();
        }
        public Tuple<List<Item>, DataTable> RetrieveLeastBoughtItems()
        {
            return DAL.RetrieveLeastBoughtItems();
        }
        public Tuple<List<Item>, DataTable> RetrieveMostBoughtItems()
        {
            return DAL.RetrieveMostBoughtItems();
        }
        public int RetrieveAccountAuthority(string UserID = "")
        {
            return DAL.RetrieveAccountAuthority(UserID);
        }
        public Account RetrieveUserPermissions(string UserID = "")
        {
            return DAL.RetrieveUserPermissions(UserID);
        }
        public Item RetrieveItemPictureFromBarCode(string ItemBarCode)
        {
            return DAL.RetrieveItemPictureFromBarCode(ItemBarCode);
        }
        public Item RetrieveItemsQuantityDates(string ItemBarCode)
        {
            return DAL.RetrieveItemsQuantityDates(ItemBarCode);
        }
        public Tuple<List<Item>, DataTable> RetrieveItems(int locale)
        {
            return DAL.RetrieveItems(locale);
        }
        public DataTable RetrieveEmployees(DateTime DateFrom, DateTime DateTo)
        {
            return DAL.RetrieveEmployees(DateFrom, DateTo);
        }
        public Tuple<List<Account>, DataTable> RetrieveUsers()
        {
            return DAL.RetrieveUsers();
        }
        public DataTable RetrieveVendorBillItems(int BillNumber)
        {
            return DAL.RetrieveVendorBillItems(BillNumber);
        }
        public Tuple<List<Item>, DataTable> RetrieveBillItems(int BillNumber)
        {
            return DAL.RetrieveBillItems(BillNumber);
        }      
        public Tuple<List<Item>, DataTable> RetrieveBillItemsRefund(int BillNumber)
        {
            return DAL.RetrieveBillItemsRefund(BillNumber);
        }
        public DataTable RetrieveBillItemsProfit(string Date1, string Date2, int ItemTypeID, string CashierName)
        {
            return DAL.RetrieveBillItemsProfit(Date1, Date2, ItemTypeID, CashierName);
        }
        public DataTable RetrieveReturnedItems()
        {
            return DAL.RetrieveReturnedItems();
        }
        public Tuple<List<Item>, DataTable> RetrieveFavoriteItems(int Category)
        {
            return DAL.RetrieveFavoriteItems(Category);
        }
        public decimal GetCapitalAmount()
        {
            return DAL.GetCapitalAmount();
        }
        public decimal GetOpenRegisterAmount()
        {
            return DAL.GetOpenRegisterAmount();
        }
        public decimal GetTotalSalesAmountCloseCash()
        {
            return DAL.GetTotalSalesAmountCloseCash();
        }
        public decimal GetTotalSalesAmount()
        {
            return DAL.GetTotalSalesAmount();
        }
        public string GetLastOpenRegisterDate()
        {
            return DAL.GetLastOpenRegisterDate();
        }
        public bool InsertExpense(string ExpenseName, decimal ExpenseCost, string EmployeeName, DateTime Date)
        {
            return DAL.InsertExpense(ExpenseName, ExpenseCost, EmployeeName, Date);
        }
        public bool InsertDeduction(int EmployeeID, DateTime Date, decimal Deduction)
        {
            return DAL.InsertDeduction(EmployeeID, Date, Deduction);
        }
        public bool InsertDayOff(int EmployeeID, DateTime Date)
        {
            return DAL.InsertDayOff(EmployeeID, Date);
        }
        public bool InsertAbsence(int EmployeeID, DateTime Date, int Hours)
        {
            return DAL.InsertAbsence(EmployeeID, Date, Hours);
        }
        public bool InsertEmployee(string EmployeeName, decimal Salary, string Phone, string Address)
        {
            return DAL.InsertEmployee(EmployeeName, Salary, Phone, Address);
        }
        public bool InsertItem(Item ItemToInsert)
        {
            return DAL.InsertItem(ItemToInsert);
        }
        public bool DeleteItemType(int ItemTypeID)
        {
            return DAL.DeleteItemType(ItemTypeID);
        }
        public bool DeleteWarehouse(int WarehouseID)
        {
            return DAL.DeleteWarehouse(WarehouseID);
        }
        public bool DeleteFavoriteCategory(int FavoriteCategoryID)
        {
            return DAL.DeleteFavoriteCategory(FavoriteCategoryID);
        }
        public bool UpdateItemTypes(int ItemTypeID, string ItemTypeName)
        {
            return DAL.UpdateItemTypes(ItemTypeID, ItemTypeName);
        }
        public bool UpdateWarehouses(int WarehouseID, string WarehouseName)
        {
            return DAL.UpdateWarehouses(WarehouseID, WarehouseName);
        }
        public bool UpdateFavoriteCategories(int FavoriteCategoryID, string FavoriteCategory)
        {
            return DAL.UpdateFavoriteCategories(FavoriteCategoryID, FavoriteCategory);
        }
        public bool UpdatePrinters(int printerID, string printerName)
        {
            return DAL.UpdatePrinters(printerID, printerName);
        }
        public bool InsertItemType(string ItemTypeName)
        {
            return DAL.InsertItemType(ItemTypeName);
        }
        public bool InsertWarehouse(string WarehouseName)
        {
            return DAL.InsertWarehouse(WarehouseName);
        }
        public bool InsertFavoriteCategory(string FavoriteCategory)
        {
            return DAL.InsertFavoriteCategory(FavoriteCategory);
        }
        public bool InsertPrinter(string machineName, string printerName)
        {
            return DAL.InsertPrinter(machineName, printerName);
        }
        public bool DeleteClient(string ClientID)
        {
            return DAL.DeleteClient(ClientID);
        }
        public bool RegisterClient(Client ClientToInsert)
        {
            return DAL.RegisterClient(ClientToInsert);
        }
        public bool RegisterVendor(Client ClientToInsert)
        {
            return DAL.RegisterVendor(ClientToInsert);
        }
        public bool DeleteAbsence(int AbsenceID)
        {
            return DAL.DeleteAbsence(AbsenceID);
        }
        public bool DeleteEmployee(int EmployeeID)
        {
            return DAL.DeleteEmployee(EmployeeID);
        }
        public bool DeleteUser(Account UserToUpdate, string cashierName)
        {
            return DAL.DeleteUser(UserToUpdate, cashierName);
        }
        public bool AddSaleOnItems(List<Item> saleItems)
        {
            return DAL.AddSaleOnItems(saleItems);
        }
        public bool AddItemToClient(string ItemBarCode, int ClientID, decimal ClientPrice)
        {
            return DAL.AddItemToClient(ItemBarCode, ClientID, ClientPrice);
        }
        public int AddUnpaidBill(Bill billToAdd, string cashierName)
        {
            return DAL.AddUnpaidBill(billToAdd, cashierName);
        }
        public int AddVendorBill(Bill billToAdd, string cashierName)
        {
            return DAL.AddVendorBill(billToAdd, cashierName);
        }
        public bool PayUnpaidBill(int BillNumber, decimal paidAmount)
        {
            return DAL.PayUnpaidBill(BillNumber, paidAmount);
        }
        public bool PayBill(Bill billToAdd, string cashierName)
        {
            return DAL.PayBill(billToAdd, cashierName);
        }
        public bool UpdateEmployee(int EmployeeID, string EmployeeName, decimal Salary, string Phone, string Address)
        {
            return DAL.UpdateEmployee(EmployeeID, EmployeeName, Salary, Phone, Address);
        }
        public bool UpdateUser(Account UserToUpdate, string cashierName, int AdminOrNot)
        {
            return DAL.UpdateUser(UserToUpdate, cashierName, AdminOrNot);
        }
        public bool UpdateBill(int BillNumber, string CashierName, decimal TotalAmount, decimal PaidAmount, decimal RemainderAmount)
        {
            return DAL.UpdateBill(BillNumber, CashierName, TotalAmount, PaidAmount, RemainderAmount);
        }
        public bool ReturnItem(string ItemName, string ItemBarCode, int ItemQuantity, string cashierName, int BillID)
        {
            return DAL.ReturnItem(ItemName, ItemBarCode, ItemQuantity, cashierName, BillID);
        }
        public bool UpdateItemWarehouse(List<Item> ItemsToUpdate, string EmployeeName, int EntryExitType)
        {
            return DAL.UpdateItemWarehouse(ItemsToUpdate, EmployeeName, EntryExitType);
        }
        public bool UpdateItem(Item ItemToUpdate)
        {
            return DAL.UpdateItem(ItemToUpdate);
        }
        public bool UpdateItemQuantity(Item ItemToUpdate)
        {
            return DAL.UpdateItemQuantity(ItemToUpdate);
        }
        public bool DeleteItem(string ItemBarCode)
        {
            return DAL.DeleteItem(ItemBarCode);
        }
        public Bill RetrieveLastVendorBillNumberToday(DateTime Date)
        {
            return DAL.RetrieveLastVendorBillNumberToday(Date);
        }
        public Bill RetrieveLastBillNumberToday()
        {
            return DAL.RetrieveLastBillNumberToday();
        }
        public List<Item> RetrieveItemsQuantity(string ItemBarCode = "")
        {
            return DAL.RetrieveItemsQuantity(ItemBarCode);
        }
        public List<Item> RetrieveSaleItemsQuantity()
        {
            return DAL.RetrieveSaleItemsQuantity();
        }
        public Tuple<List<Item>, DataTable> RetrieveExpireStockToday(DateTime Date)
        {
            return DAL.RetrieveExpireStockToday(Date);
        }
        public List<Item> RetrieveSaleToday(DateTime Date, int QuantityEnd = 0)
        {
            return DAL.RetrieveSaleToday(Date, QuantityEnd);
        }
        public Tuple<List<Bill>, DataTable> SearchTodayBills(DateTime Date)
        {
            return DAL.SearchTodayBills(Date);
        }
        public Tuple<List<Bill>, DataTable> SearchBills(string dateFrom, string dateTo, int BillNumber = 0)
        {
            return DAL.SearchBills(dateFrom, dateTo, BillNumber);
        }
        public int GetItemQuantity(string ItemBarCode = "")
        {
            return DAL.GetItemQuantity(ItemBarCode);
        }
        public DataTable RetrieveAbsence(DateTime Date1, DateTime Date2)
        {
            return DAL.RetrieveAbsence(Date1, Date2);
        }
        public DataTable SearchExpenses(string Date1, string Date2, string ExpenseName = "", string EmployeeID = "")
        {
            return DAL.SearchExpenses(Date1, Date2, ExpenseName, EmployeeID);
        }
        public Tuple<List<Item>, DataTable> SearchItems(string ItemName = "", string ItemBarCode = "", int ItemType = 0)
        {
            return DAL.SearchItems(ItemName, ItemBarCode, ItemType);
        }
        public DataTable SearchClients(string ClientName = "", string ClientID = "", string itemName = "")
        {
            return DAL.SearchClients(ClientName, ClientID, itemName);
        }
        public DataTable SearchClientsInfo(string ClientName = "", string ClientID = "")
        {
            return DAL.SearchClientsInfo(ClientName, ClientID);
        }
    }
}
