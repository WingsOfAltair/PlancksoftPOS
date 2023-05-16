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
        string CheckConnection();
        [OperationContract]
        string RetrieveSystemSettings();
        [OperationContract]
        string UpdateSystemSettings(string SystemName, byte[] SystemLogo, string SystemPhone,
            string SystemAddress, int SystemReceiptBlankSpaces, int SystemIncludeLogoInReceipt, decimal SystemTax);
        [OperationContract]
        string RetrieveBillSoldBItemQuantity(int BillNumber, string itemBarcode);
        [OperationContract]
        string RetrieveItemTypeName(int ItemTypeIndex, int locale);
        [OperationContract]
        string RetrieveWarehouseName(int WarehouseIndex, int locale);
        [OperationContract]
        string RetrieveFavoriteCategoryName(int CategoryIndex, int locale);
        [OperationContract]
        string RetrieveCashierNames();
        [OperationContract]
        string RetrieveItemTypeID(string ItemTypeName);
        [OperationContract]
        string RetrieveWarehouseID(string WarehouseName);
        [OperationContract]
        string RetrieveFavoriteCategoryID(string CategoryName);
        [OperationContract]
        string RetrievePrinterItemTypes(int printerID);
        [OperationContract]
        string RetrieveItemTypes();
        [OperationContract]
        string RetrieveWarehouses();
        [OperationContract]
        string RetrieveFavoriteCategories();
        [OperationContract]
        string RetrievePrinters(string machineName);
        [OperationContract]
        string RetrieveLoginLogoutInfo(DateTime Date);
        [OperationContract]
        string RetrieveUsersList();
        [OperationContract]
        string GetRetrieveClients();
        [OperationContract]
        string GetRetrieveVendors();
        [OperationContract]
        string CheckAdmin();
        [OperationContract]
        string RegisterAdmin(Account AccountToRegister);
        [OperationContract]
        void LogLogout(string cashierName, DateTime date);
        [OperationContract]
        void LogLogin(string cashierName, DateTime date);
        [OperationContract]
        string Login(Account AccountToLogin);
        [OperationContract]
        string Register(Account AccountToRegister, string UID, int AdminOrNot);
        [OperationContract]
        string AddPrinterItemType(int printerID, int itemTypeID);
        [OperationContract]
        string DeletePrinterItemType(int printerID, int itemTypeID);
        [OperationContract]
        string DeletePrinter(string machineName, int printerID);
        [OperationContract]
        string DeleteFavoriteItem(string ItemBarCode);
        [OperationContract]
        string AddFavoriteItem(string ItemName, string ItemBarCode, int ItemQuantity, decimal ItemPrice, decimal ItemPriceTax, decimal Category, DateTime Date);
        [OperationContract]
        string SaveRegisterClose(string cashierName, decimal moneyInRegister);
        [OperationContract]
        string SaveRegisterOpen(string cashierName, decimal moneyInRegister);
        [OperationContract]
        string SearchWarehouseInventoryItems(int WarehouseID);
        [OperationContract]
        string SearchInventoryItems(string ItemName = "", string ItemBarCode = "", int locale = 1);
        [OperationContract]
        string SearchInventoryItemsWithBarCode(string ItemBarCode = "");
        [OperationContract]
        string RetrieveUnPortedBills();
        [OperationContract]
        string RetrievePortedBills();
        [OperationContract]
        string RetrieveUnpaidBills();
        [OperationContract]
        string RetrieveVendorBills();
        [OperationContract]
        string RetrieveTaxZReport();
        [OperationContract]
        string RetrieveBills();
        [OperationContract]
        string RetrieveCapitalRevenue();
        [OperationContract]
        string RetrieveExports();
        [OperationContract]
        string RetrieveImports();
        [OperationContract]
        string RetrieveLeastBoughtItems();
        [OperationContract]
        string RetrieveMostBoughtItems();
        [OperationContract]
        string RetrieveAccountAuthority(string UserID = "");
        [OperationContract]
        string RetrieveUserPermissions(string UserID = "");
        [OperationContract]
        string RetrieveItemPictureFromBarCode(string ItemBarCode);
        [OperationContract]
        string RetrieveItemsQuantityDates(string ItemBarCode);
        [OperationContract]
        string RetrieveItems(int locale);
        [OperationContract]
        string RetrieveEmployees();
        [OperationContract]
        string RetrieveUsers();
        [OperationContract]
        string RetrieveClientBills(int ClientID);
        [OperationContract]
        string RetrieveVendorBillItems(int BillNumber);
        [OperationContract]
        string RetrieveBillItems(int BillNumber);
        [OperationContract]
        string RetrieveBillItemsProfit(string Date1, string Date2, int ItemTypeID, string CashierName);
        [OperationContract]
        string RetrieveReturnedItems();
        [OperationContract]
        string RetrieveFavoriteItems(int Category);
        [OperationContract]
        string GetCapitalAmount();
        [OperationContract]
        string GetOpenRegisterAmount();
        [OperationContract]
        string GetTotalSalesAmountCloseCash();
        [OperationContract]
        string GetTotalSalesAmount();
        [OperationContract]
        string GetLastOpenRegisterDate();
        [OperationContract]
        string InsertExpense(string ExpenseName, decimal ExpenseCost, string EmployeeName, DateTime Date);
        [OperationContract]
        string InsertDeduction(int EmployeeID, DateTime Date, decimal Deduction);
        [OperationContract]
        string InsertDayOff(int EmployeeID, DateTime Date);
        [OperationContract]
        string InsertAbsence(int EmployeeID, DateTime Date, int Hours);
        [OperationContract]
        string InsertEmployee(string EmployeeName, decimal Salary, string Phone, string Address);
        [OperationContract]
        string InsertItem(Item ItemToInsert);
        [OperationContract]
        string DeleteItemType(int ItemTypeID);
        [OperationContract]
        string DeleteWarehouse(int WarehouseID);
        [OperationContract]
        string DeleteFavoriteCategory(int FavoriteCategoryID);
        [OperationContract]
        string UpdateItemTypes(int ItemTypeID, string ItemTypeName);
        [OperationContract]
        string UpdateWarehouses(int WarehouseID, string WarehouseName);
        [OperationContract]
        string UpdateFavoriteCategories(int FavoriteCategoryID, string FavoriteCategory);
        [OperationContract]
        string UpdatePrinters(int printerID, string printerName);
        [OperationContract]
        string InsertItemType(string ItemTypeName);
        [OperationContract]
        string InsertWarehouse(string WarehouseName);
        [OperationContract]
        string InsertFavoriteCategory(string FavoriteCategory);
        [OperationContract]
        string InsertPrinter(string machineName, string printerName);
        [OperationContract]
        string DeleteClient(string ClientID);
        [OperationContract]
        string RegisterClient(Client ClientToInsert);
        [OperationContract]
        string RegisterVendor(Client ClientToInsert);
        [OperationContract]
        string DeleteAbsence(int AbsenceID);
        [OperationContract]
        string DeleteEmployee(int EmployeeID);
        [OperationContract]
        string DeleteUser(Account UserToUpdate, string cashierName);
        [OperationContract]
        string AddSaleOnItems(List<Item> saleItems);
        [OperationContract]
        string AddItemToClient(string ItemBarCode, int ClientID, decimal ClientPrice);
        [OperationContract]
        string AddUnpaidBill(Bill billToAdd, string cashierName);
        [OperationContract]
        string AddVendorBill(Bill billToAdd, string cashierName);
        [OperationContract]
        string PayUnpaidBill(int BillNumber, decimal paidAmount);
        [OperationContract]
        string PayBill(Bill billToAdd, string cashierName);
        [OperationContract]
        string UpdateEmployee(int EmployeeID, string EmployeeName, decimal Salary, string Phone, string Address);
        [OperationContract]
        string UpdateUser(Account UserToUpdate, string cashierName, int AdminOrNot);
        [OperationContract]
        string UpdateBill(int BillNumber, string CashierName, decimal TotalAmount, decimal PaidAmount, decimal RemainderAmount);
        [OperationContract]
        string ReturnItem(string ItemName, string ItemBarCode, int ItemQuantity, string cashierName);
        [OperationContract]
        string UpdateItemWarehouse(List<Item> ItemsToUpdate, string EmployeeName, int EntryExitType);
        [OperationContract]
        string UpdateItem(Item ItemToUpdate);
        [OperationContract]
        string UpdateItemQuantity(Item ItemToUpdate);
        [OperationContract]
        string DeleteItem(string ItemBarCode);
        [OperationContract]
        string RetrieveLastVendorBillNumberToday(DateTime Date);
        [OperationContract]
        string RetrieveLastBillNumberToday();
        [OperationContract]
        string RetrieveItemsQuantity(string ItemBarCode = "");
        [OperationContract]
        string RetrieveSaleItemsQuantity();
        [OperationContract]
        string RetrieveExpireStockToday(DateTime Date);
        [OperationContract]
        string RetrieveSaleToday(DateTime Date, int QuantityEnd = 0);
        [OperationContract]
        string SearchTodayBills(DateTime Date);
        [OperationContract]
        string SearchBills(string dateFrom, string dateTo, int BillNumber = 0);
        [OperationContract]
        string GetItemQuantity(string ItemBarCode = "");
        [OperationContract]
        string RetrieveAbsence(DateTime Date1, DateTime Date2);
        [OperationContract]
        string SearchExpenses(string Date1, string Date2, string ExpenseName = "", string EmployeeID = "");
        [OperationContract]
        string SearchItems(string ItemName = "", string ItemBarCode = "", int ItemType = 0);
        [OperationContract]
        string SearchClients(string ClientName = "", string ClientID = "", string itemName = "");
        [OperationContract]
        string SearchClientsInfo(string ClientName = "", string ClientID = "");
    }
}
