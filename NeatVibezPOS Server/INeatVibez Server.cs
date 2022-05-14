using System;
using System.ServiceModel;
using System.Collections.Generic;
using System.Data;
using Dependencies;

namespace NeatVibezPOS_Server
{
    [ServiceContract]
    public interface INeatVibez_Server
    {
        [OperationContract]
        bool CheckConnection();
        [OperationContract]
        DataTable RetrieveSystemSettings();
        [OperationContract]
        bool UpdateSystemSettings(string SystemName, byte[] SystemLogo, string SystemPhone, int SystemReceiptBlankSpaces, string SystemPrinterName, int SystemIncludeLogoInReceipt, decimal SystemTax);
        [OperationContract]
        string RetrieveItemTypeName(int ItemTypeIndex);
        [OperationContract]
        string RetrieveWarehouseName(int WarehouseIndex);
        [OperationContract]
        string RetrieveFavoriteCategoryName(int CategoryIndex);
        [OperationContract]
        List<string> RetrieveCashierNames();
        [OperationContract]
        int RetrieveItemTypeID(string ItemTypeName);
        [OperationContract]
        int RetrieveWarehouseID(string WarehouseName);
        [OperationContract]
        int RetrieveFavoriteCategoryID(string CategoryName);
        [OperationContract]
        List<ItemType> RetrieveItemTypes();
        [OperationContract]
        List<Warehouse> RetrieveWarehouses();
        [OperationContract]
        List<Category> RetrieveFavoriteCategories();
        [OperationContract]
        DataTable RetrieveLoginLogoutInfo(DateTime Date);
        [OperationContract]
        Tuple<List<Account>, DataTable> RetrieveUsersList();
        [OperationContract]
        Tuple<List<Customer>, DataTable> GetRetrieveCustomers();
        [OperationContract]
        Tuple<List<Customer>, DataTable> GetRetrieveVendors();
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
        Tuple<List<Item>, DataTable> SearchInventoryItems(string ItemName = "", string ItemBarCode = "");
        [OperationContract]
        Item SearchInventoryItemsWithBarCode(string ItemBarCode = "");
        [OperationContract]
        Tuple<List<Bill>, DataTable> RetrieveUnPortedBills();
        [OperationContract]
        Tuple<List<Bill>, DataTable> RetrievePortedBills();
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
        Tuple<List<Item>, DataTable> RetrieveItems();
        [OperationContract]
        DataTable RetrieveEmployees();
        [OperationContract]
        Tuple<List<Account>, DataTable> RetrieveUsers();
        [OperationContract]
        Tuple<List<Item>, DataTable> RetrieveVendorBillItems(int BillNumber);
        [OperationContract]
        Tuple<List<Item>, DataTable> RetrieveBillItems(int BillNumber);
        [OperationContract]
        DataTable RetrieveBillItemsProfit(DateTime Date1, DateTime Date2, int ItemTypeID, string CashierName);
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
        bool InsertItemType(string ItemTypeName);
        [OperationContract]
        bool InsertWarehouse(string WarehouseName);
        [OperationContract]
        bool InsertFavoriteCategory(string FavoriteCategory);
        [OperationContract]
        bool DeletesCustomer(string CustomerID);
        [OperationContract]
        bool RegisterCustomer(Customer CustomerToInsert);
        [OperationContract]
        bool RegisterVendor(Customer CustomerToInsert);
        [OperationContract]
        bool DeleteAbsence(int AbsenceID);
        [OperationContract]
        bool DeleteEmployee(int EmployeeID);
        [OperationContract]
        bool DeleteUser(Account UserToUpdate, string cashierName);
        [OperationContract]
        bool AddSaleOnItems(List<Item> saleItems);
        [OperationContract]
        bool AddItemToCustomer(string ItemBarCode, int CustomerID, decimal CustomerPrice);
        [OperationContract]
        bool AddVendorBill(Bill billToAdd, string cashierName);
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
        Bill RetrieveLastBillNumberToday();
        [OperationContract]
        List<Item> RetrieveItemsQuantity(string ItemBarCode = "");
        [OperationContract]
        List<Item> RetrieveSaleItemsQuantity();
        [OperationContract]
        Tuple<List<Item>, DataTable> RetrieveExpireStockToday(DateTime Date);
        [OperationContract]
        List<Item> RetrieveSaleToday(DateTime Date, int QuantityEnd = 0);
        [OperationContract]
        Tuple<List<Bill>, DataTable> SearchTodayBills(DateTime Date);
        [OperationContract]
        Tuple<List<Bill>, DataTable> SearchBills(int BillNumber = 0);
        [OperationContract]
        int GetItemQuantity(string ItemBarCode = "");
        [OperationContract]
        DataTable RetrieveAbsence(DateTime Date1, DateTime Date2);
        [OperationContract]
        DataTable SearchExpenses(DateTime Date1, DateTime Date2, string ExpenseName = "", string EmployeeID = "");
        [OperationContract]
        Tuple<List<Item>, DataTable> SearchItems(string ItemName = "", string ItemBarCode = "", int ItemType = 0);
        [OperationContract]
        DataTable SearchCustomers(string customerName = "", string customerID = "", string itemName = "");
        [OperationContract]
        Tuple<Customer, DataTable> SearchCustomersInfo(string customerName = "", string customerID = "");
    }
}
