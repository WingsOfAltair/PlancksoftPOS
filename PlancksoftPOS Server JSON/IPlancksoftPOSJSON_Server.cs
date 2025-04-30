using System;
using System.ServiceModel;
using System.Collections.Generic;
using System.Data;
using Dependencies;
using System.ServiceModel.Web;
using System.Web.Script.Services;

namespace PlancksoftPOSJSON_Server
{
    [ServiceContract]
    public interface IPlancksoftPOSJSON_Server
    {
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "CheckConnection",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string CheckConnection();
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveSaleByDate",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]

        string RetrieveSaleByDate(DateTime StartDate, DateTime EndDate);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveSystemSettings",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveSystemSettings();
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "UpdateSystemSettings",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string UpdateSystemSettings(string SystemName, byte[] SystemLogo, string SystemPhone,
            string SystemAddress, int SystemReceiptBlankSpaces, int SystemIncludeLogoInReceipt, decimal SystemTax);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveBillSoldBItemQuantity",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveBillSoldBItemQuantity(int BillNumber, string itemBarcode);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveItemTypeName",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveItemTypeName(int ItemTypeIndex, int locale);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveWarehouseName",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveWarehouseName(int WarehouseIndex, int locale);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveFavoriteCategoryName",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveFavoriteCategoryName(int CategoryIndex, int locale);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveCashierNames",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveCashierNames();
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveItemTypeID",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveItemTypeID(string ItemTypeName);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveWarehouseID",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveWarehouseID(string WarehouseName);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveFavoriteCategoryID",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveFavoriteCategoryID(string CategoryName);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrievePrinterItemTypes",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrievePrinterItemTypes(int printerID);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveItemTypes",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveItemTypes();
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveWarehouses",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveWarehouses();
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveFavoriteCategories",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveFavoriteCategories();
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrievePrinters",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrievePrinters(string machineName);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveLoginLogoutInfo",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveLoginLogoutInfo(DateTime Date);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveUsersList",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveUsersList();
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "GetRetrieveClients",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string GetRetrieveClients();
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "GetRetrieveVendors",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string GetRetrieveVendors();
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "CheckAdmin",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string CheckAdmin();
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RegisterAdmin",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RegisterAdmin(Account AccountToRegister);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "LogLogout",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        void LogLogout(string cashierName, DateTime date);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "LogLogin",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        void LogLogin(string cashierName, DateTime date);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "Login",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string Login(Account AccountToLogin);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "Register",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string Register(Account AccountToRegister, string UID, int AdminOrNot);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "AddPrinterItemType",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string AddPrinterItemType(int printerID, int itemTypeID);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "DeletePrinterItemType",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string DeletePrinterItemType(int printerID, int itemTypeID);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "DeletePrinter",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string DeletePrinter(string machineName, int printerID);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "DeleteFavoriteItem",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string DeleteFavoriteItem(string ItemBarCode);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "AddFavoriteItem",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string AddFavoriteItem(string ItemName, string ItemBarCode, int ItemQuantity, decimal ItemPrice, decimal ItemPriceTax, decimal Category, DateTime Date);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "SaveRegisterClose",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string SaveRegisterClose(string cashierName, decimal moneyInRegister);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "SaveRegisterOpen",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string SaveRegisterOpen(string cashierName, decimal moneyInRegister);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "SearchWarehouseInventoryItems",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string SearchWarehouseInventoryItems(int WarehouseID);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "SearchInventoryItems",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string SearchInventoryItems(string ItemName = "", string ItemBarCode = "", int locale = 1);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "SearchInventoryItemsWithBarCode",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string SearchInventoryItemsWithBarCode(string ItemBarCode = "");
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveUnPortedBills",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveUnPortedBills();
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrievePortedBills",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrievePortedBills();
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveUnpaidBills",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveUnpaidBills();
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveVendorBills",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveVendorBills(int ClientID);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveTaxZReport",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveTaxZReport();
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveBillsRefund",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveBillsRefund();    
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveBills",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveBills();
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveCapitalRevenue",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveCapitalRevenue();
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveExports",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveExports();
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveImports",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveImports();
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveLeastBoughtItems",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveLeastBoughtItems();
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveMostBoughtItems",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveMostBoughtItems();
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveAccountAuthority",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveAccountAuthority(string UserID = "");
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveUserPermissions",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveUserPermissions(string UserID = "");
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveItemPictureFromBarCode",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveItemPictureFromBarCode(string ItemBarCode);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveItemsQuantityDates",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveItemsQuantityDates(string ItemBarCode);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveItems",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveItems(int locale);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveEmployees",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveEmployees(DateTime DateFrom, DateTime DateTo);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveEmployeesData",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveEmployeesData();
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveUsers",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveUsers();
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveClientBills",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveClientBills(int ClientID);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveVendorBillItems",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveVendorBillItems(int BillNumber);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveBillItems",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveBillItems(int BillNumber);  
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveBillItemsRefund",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveBillItemsRefund(int BillNumber);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveBillItemsProfit",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveBillItemsProfit(string Date1, string Date2, int ItemTypeID, string CashierName);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveReturnedItems",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveReturnedItems();
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveFavoriteItems",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveFavoriteItems(int Category);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "GetCapitalAmount",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string GetCapitalAmount();
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "GetOpenRegisterAmount",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string GetOpenRegisterAmount();
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "GetTotalSalesAmountCloseCash",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string GetTotalSalesAmountCloseCash();
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "GetTotalSalesAmount",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string GetTotalSalesAmount();
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "GetLastOpenRegisterDate",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string GetLastOpenRegisterDate();
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "InsertExpense",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string InsertExpense(string ExpenseName, decimal ExpenseCost, string EmployeeName, DateTime Date);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "InsertDeduction",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string InsertDeduction(int EmployeeID, DateTime Date, decimal Deduction);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "InsertDayOff",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string InsertDayOff(int EmployeeID, DateTime Date);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "InsertAbsence",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string InsertAbsence(int EmployeeID, DateTime Date, int Hours);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "InsertEmployee",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string InsertEmployee(string EmployeeName, decimal Salary, string Phone, string Address);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "InsertItem",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string InsertItem(Item ItemToInsert);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "DeleteItemType",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string DeleteItemType(int ItemTypeID);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "DeleteWarehouse",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string DeleteWarehouse(int WarehouseID);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "DeleteFavoriteCategory",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string DeleteFavoriteCategory(int FavoriteCategoryID);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "UpdateItemTypes",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string UpdateItemTypes(int ItemTypeID, string ItemTypeName);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "UpdateWarehouses",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string UpdateWarehouses(int WarehouseID, string WarehouseName);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "UpdateFavoriteCategories",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string UpdateFavoriteCategories(int FavoriteCategoryID, string FavoriteCategory);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "UpdatePrinters",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string UpdatePrinters(int printerID, string printerName);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "InsertItemType",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string InsertItemType(string ItemTypeName);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "InsertWarehouse",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string InsertWarehouse(string WarehouseName);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "InsertFavoriteCategory",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string InsertFavoriteCategory(string FavoriteCategory);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "InsertPrinter",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string InsertPrinter(string machineName, string printerName);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "DeleteClient",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string DeleteClient(string ClientID);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RegisterClient",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RegisterClient(Client ClientToInsert);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RegisterVendor",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RegisterVendor(Client ClientToInsert);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "DeleteAbsence",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string DeleteAbsence(int AbsenceID);   
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "DeleteDeduction",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string DeleteDeduction(int DeductionID);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "DeleteEmployee",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string DeleteEmployee(int EmployeeID);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "DeleteUser",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string DeleteUser(Account UserToUpdate, string cashierName);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "AddSaleOnItems",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string AddSaleOnItems(List<Item> saleItems);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "AddItemToClient",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string AddItemToClient(string ItemBarCode, int ClientID, decimal ClientPrice);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "AddUnpaidBill",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string AddUnpaidBill(Bill billToAdd, string cashierName);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "AddVendorBill",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string AddVendorBill(Bill billToAdd, string cashierName);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "PayUnpaidBill",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string PayUnpaidBill(int BillNumber, decimal paidAmount);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "PayBill",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string PayBill(Bill billToAdd, string cashierName);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "UpdateEmployee",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string UpdateEmployee(int EmployeeID, string EmployeeName, decimal Salary, string Phone, string Address);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "UpdateAbsence",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string UpdateAbsence(int AbsenceID, int Hours);  
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "UpdateDeduction",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string UpdateDeduction(int DeductionID, int DeductionAmount);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "UpdateUser",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string UpdateUser(Account UserToUpdate, string cashierName, int AdminOrNot);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "UpdateBill",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string UpdateBill(int BillNumber, string CashierName, decimal TotalAmount, decimal PaidAmount, decimal RemainderAmount);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "ReturnItem",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string ReturnItem(string ItemName, string ItemBarCode, int ItemQuantity, string cashierName, int BillID);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "UpdateItemWarehouse",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string UpdateItemWarehouse(List<Item> ItemsToUpdate, string EmployeeName, int EntryExitType);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "UpdateItem",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string UpdateItem(Item ItemToUpdate);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "UpdateItemQuantity",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string UpdateItemQuantity(Item ItemToUpdate);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "DeleteItem",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string DeleteItem(string ItemBarCode);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveLastVendorBillNumberToday",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveLastVendorBillNumberToday(DateTime Date);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveTotalActiveItems",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveTotalActiveItems(DateTime ExpirationDate);  
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveClientCount",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveClientCount();       
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveBillsCountByDate",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveBillsCountByDate(DateTime StartDate, DateTime EndDate);    
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveLastBillNumberToday",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveLastBillNumberToday();
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveItemsQuantity",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveItemsQuantity(string ItemBarCode = "");
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveSaleItemsQuantity",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveSaleItemsQuantity();
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveExpireStockToday",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveExpireStockToday(DateTime Date);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveSaleToday",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveSaleToday(DateTime Date, int QuantityEnd = 0);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "SearchTodayBills",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveSaleDateRange(DateTime StartDate, DateTime EndDate, int QuantityEnd = 0);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveSaleDateRange",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string SearchTodayBills(DateTime Date);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "SearchBills",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string SearchBills(string dateFrom, string dateTo, int BillNumber = 0);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "GetItemQuantity",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string GetItemQuantity(string ItemBarCode = "");
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "RetrieveAbsence",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string RetrieveAbsence(DateTime Date1, DateTime Date2);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "SearchExpenses",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string SearchExpenses(string Date1, string Date2, string ExpenseName = "", string EmployeeID = "");
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "SearchItems",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string SearchItems(string ItemName = "", string ItemBarCode = "", int ItemType = 0);
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "SearchClients",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string SearchClients(string ClientName = "", string ClientID = "", string itemName = "");
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "SearchClientsInfo",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string SearchClientsInfo(string ClientName = "", string ClientID = "");
    }
}
