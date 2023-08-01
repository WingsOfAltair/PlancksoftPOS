using System;
using System.ServiceModel;
using System.Collections.Generic;
using System.Data;
using Dependencies;

namespace PlancksoftPOS_Server
{
    [ServiceContract]
    public interface IPlancksoftPOS_Server
    {
        [OperationContract]
        bool CheckConnection();
        [OperationContract]
        DataTable RetrieveSaleByDate(DateTime StartDate, DateTime EndDate);
        [OperationContract]
        DataTable RetrieveSystemSettings();
        [OperationContract]
        bool UpdateSystemSettings(string SystemName, byte[] SystemLogo, string SystemPhone,
            string SystemAddress, int SystemReceiptBlankSpaces, int SystemIncludeLogoInReceipt, decimal SystemTax);
        [OperationContract]
        int RetrieveBillSoldBItemQuantity(int BillNumber, string itemBarcode);
        [OperationContract]
        string RetrieveItemTypeName(int ItemTypeIndex, int locale);
        [OperationContract]
        string RetrieveWarehouseName(int WarehouseIndex, int locale);
        [OperationContract]
        string RetrieveFavoriteCategoryName(int CategoryIndex, int locale);
        [OperationContract]
        List<string> RetrieveCashierNames();
        [OperationContract]
        int RetrieveItemTypeID(string ItemTypeName);
        [OperationContract]
        int RetrieveWarehouseID(string WarehouseName);
        [OperationContract]
        int RetrieveFavoriteCategoryID(string CategoryName);
        [OperationContract]
        List<ItemType> RetrievePrinterItemTypes(int printerID);
        [OperationContract]
        List<ItemType> RetrieveItemTypes();
        [OperationContract]
        List<Warehouse> RetrieveWarehouses();
        [OperationContract]
        List<Category> RetrieveFavoriteCategories();
        [OperationContract]
        List<Printer> RetrievePrinters(string machineName);
        [OperationContract]
        DataTable RetrieveLoginLogoutInfo(DateTime Date);
        [OperationContract]
        Tuple<List<Account>, DataTable> RetrieveUsersList();
        [OperationContract]
        DataTable GetRetrieveClients();
        [OperationContract]
        DataTable GetRetrieveVendors();
        [OperationContract]
        bool CheckAdmin();
        [OperationContract]
        bool RegisterAdmin(Account AccountToRegister);
        [OperationContract]
        void LogLogout(string cashierName, DateTime date);
        [OperationContract]
        void LogLogin(string cashierName, DateTime date);
        [OperationContract]
        Tuple<bool, string, bool> Login(Account AccountToLogin);
        [OperationContract]
        bool Register(Account AccountToRegister, string UID, int AdminOrNot);
        [OperationContract]
        bool AddPrinterItemType(int printerID, int itemTypeID);
        [OperationContract]
        bool DeletePrinterItemType(int printerID, int itemTypeID);
        [OperationContract]
        bool DeletePrinter(string machineName, int printerID);
        [OperationContract]
        bool DeleteFavoriteItem(string ItemBarCode);
        [OperationContract]
        bool AddFavoriteItem(string ItemName, string ItemBarCode, int ItemQuantity, decimal ItemPrice, decimal ItemPriceTax, decimal Category, DateTime Date);
        [OperationContract]
        bool SaveRegisterClose(string cashierName, decimal moneyInRegister);
        [OperationContract]
        bool SaveRegisterOpen(string cashierName, decimal moneyInRegister);
        [OperationContract]
        Tuple<List<Item>, DataTable> SearchWarehouseInventoryItems(int WarehouseID);
        [OperationContract]
        Tuple<List<Item>, DataTable> SearchInventoryItems(string ItemName = "", string ItemBarCode = "", int locale = 1);
        [OperationContract]
        Item SearchInventoryItemsWithBarCode(string ItemBarCode = "");
        [OperationContract]
        Tuple<List<Bill>, DataTable> RetrieveUnPortedBills();
        [OperationContract]
        Tuple<List<Bill>, DataTable> RetrievePortedBills();
        [OperationContract]
        Tuple<List<Bill>, DataTable> RetrieveUnpaidBills();
        [OperationContract]
        Tuple<List<Bill>, DataTable> RetrieveVendorBills();
        [OperationContract]
        DataTable RetrieveTaxZReport();
        [OperationContract]
        Tuple<List<Bill>, DataTable> RetrieveBills();
        [OperationContract]
        Tuple<List<Item>, DataTable> RetrieveCapitalRevenue();
        [OperationContract]
        Tuple<List<Item>, DataTable> RetrieveExports();
        [OperationContract]
        Tuple<List<Item>, DataTable> RetrieveImports();
        [OperationContract]
        Tuple<List<Item>, DataTable> RetrieveLeastBoughtItems();
        [OperationContract]
        Tuple<List<Item>, DataTable> RetrieveMostBoughtItems();
        [OperationContract]
        int RetrieveAccountAuthority(string UserID = "");
        [OperationContract]
        Account RetrieveUserPermissions(string UserID = "");
        [OperationContract]
        Item RetrieveItemPictureFromBarCode(string ItemBarCode);
        [OperationContract]
        Item RetrieveItemsQuantityDates(string ItemBarCode);
        [OperationContract]
        Tuple<List<Item>, DataTable> RetrieveItems(int locale);
        [OperationContract]
        DataTable RetrieveEmployees();
        [OperationContract]
        Tuple<List<Account>, DataTable> RetrieveUsers();
        [OperationContract]
        DataTable RetrieveClientBills(int ClientID);
        [OperationContract]
        DataTable RetrieveVendorBillItems(int BillNumber);
        [OperationContract]
        Tuple<List<Item>, DataTable> RetrieveBillItems(int BillNumber);
        [OperationContract]
        DataTable RetrieveBillItemsProfit(string Date1, string Date2, int ItemTypeID, string CashierName);
        [OperationContract]
        DataTable RetrieveReturnedItems();
        [OperationContract]
        Tuple<List<Item>, DataTable> RetrieveFavoriteItems(int Category);
        [OperationContract]
        decimal GetCapitalAmount();
        [OperationContract]
        decimal GetOpenRegisterAmount();
        [OperationContract]
        decimal GetTotalSalesAmountCloseCash();
        [OperationContract]
        decimal GetTotalSalesAmount();
        [OperationContract]
        string GetLastOpenRegisterDate();
        [OperationContract]
        bool InsertExpense(string ExpenseName, decimal ExpenseCost, string EmployeeName, DateTime Date);
        [OperationContract]
        bool InsertDeduction(int EmployeeID, DateTime Date, decimal Deduction);
        [OperationContract]
        bool InsertDayOff(int EmployeeID, DateTime Date);
        [OperationContract]
        bool InsertAbsence(int EmployeeID, DateTime Date, int Hours);
        [OperationContract]
        bool InsertEmployee(string EmployeeName, decimal Salary, string Phone, string Address);
        [OperationContract]
        bool InsertItem(Item ItemToInsert);
        [OperationContract]
        bool DeleteItemType(int ItemTypeID);
        [OperationContract]
        bool DeleteWarehouse(int WarehouseID);
        [OperationContract]
        bool DeleteFavoriteCategory(int FavoriteCategoryID);
        [OperationContract]
        bool UpdateItemTypes(int ItemTypeID, string ItemTypeName);
        [OperationContract]
        bool UpdateWarehouses(int WarehouseID, string WarehouseName);
        [OperationContract]
        bool UpdateFavoriteCategories(int FavoriteCategoryID, string FavoriteCategory);
        [OperationContract]
        bool UpdatePrinters(int printerID, string printerName);
        [OperationContract]
        bool InsertItemType(string ItemTypeName);
        [OperationContract]
        bool InsertWarehouse(string WarehouseName);
        [OperationContract]
        bool InsertFavoriteCategory(string FavoriteCategory);
        [OperationContract]
        bool InsertPrinter(string machineName, string printerName);
        [OperationContract]
        bool DeleteClient(string ClientID);
        [OperationContract]
        bool RegisterClient(Client ClientToInsert);
        [OperationContract]
        bool RegisterVendor(Client ClientToInsert);
        [OperationContract]
        bool DeleteAbsence(int AbsenceID);
        [OperationContract]
        bool DeleteEmployee(int EmployeeID);
        [OperationContract]
        bool DeleteUser(Account UserToUpdate, string cashierName);
        [OperationContract]
        bool AddSaleOnItems(List<Item> saleItems);
        [OperationContract]
        bool AddItemToClient(string ItemBarCode, int ClientID, decimal ClientPrice);
        [OperationContract]
        int AddUnpaidBill(Bill billToAdd, string cashierName);
        [OperationContract]
        int AddVendorBill(Bill billToAdd, string cashierName);
        [OperationContract]
        bool PayUnpaidBill(int BillNumber, decimal paidAmount);
        [OperationContract]
        bool PayBill(Bill billToAdd, string cashierName);
        [OperationContract]
        bool UpdateEmployee(int EmployeeID, string EmployeeName, decimal Salary, string Phone, string Address);
        [OperationContract]
        bool UpdateUser(Account UserToUpdate, string cashierName, int AdminOrNot);
        [OperationContract]
        bool UpdateBill(int BillNumber, string CashierName, decimal TotalAmount, decimal PaidAmount, decimal RemainderAmount);
        [OperationContract]
        bool ReturnItem(string ItemName, string ItemBarCode, int ItemQuantity, string cashierName);
        [OperationContract]
        bool UpdateItemWarehouse(List<Item> ItemsToUpdate, string EmployeeName, int EntryExitType);
        [OperationContract]
        bool UpdateItem(Item ItemToUpdate);
        [OperationContract]
        bool UpdateItemQuantity(Item ItemToUpdate);
        [OperationContract]
        bool DeleteItem(string ItemBarCode);
        [OperationContract]
        Bill RetrieveLastVendorBillNumberToday(DateTime Date);
        [OperationContract]
        int RetrieveBillsCountByDate(DateTime StartDate, DateTime EndDate);   
        [OperationContract]
        Bill RetrieveLastBillNumberToday();
        [OperationContract]
        List<Item> RetrieveItemsQuantity(string ItemBarCode = "");
        [OperationContract]
        List<Item> RetrieveSaleItemsQuantity();
        [OperationContract]
        Tuple<List<Item>, DataTable> RetrieveExpireStockToday(DateTime Date);
        [OperationContract]
        List<Item> RetrieveSaleDateRange(DateTime StartDate, DateTime EndDate, int QuantityEnd = 0);     
        [OperationContract]
        List<Item> RetrieveSaleToday(DateTime Date, int QuantityEnd = 0);
        [OperationContract]
        Tuple<List<Bill>, DataTable> SearchTodayBills(DateTime Date);
        [OperationContract]
        Tuple<List<Bill>, DataTable> SearchBills(string dateFrom, string dateTo, int BillNumber = 0);
        [OperationContract]
        int GetItemQuantity(string ItemBarCode = "");
        [OperationContract]
        DataTable RetrieveAbsence(DateTime Date1, DateTime Date2);
        [OperationContract]
        DataTable SearchExpenses(string Date1, string Date2, string ExpenseName = "", string EmployeeID = "");
        [OperationContract]
        Tuple<List<Item>, DataTable> SearchItems(string ItemName = "", string ItemBarCode = "", int ItemType = 0);
        [OperationContract]
        DataTable SearchClients(string ClientName = "", string ClientID = "", string itemName = "");
        [OperationContract]
        DataTable SearchClientsInfo(string ClientName = "", string ClientID = "");
    }
}
