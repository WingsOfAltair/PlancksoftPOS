using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using Dependencies;
using Dependencies.Models;
using Newtonsoft.Json;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace DataAccessLayerJSON
{
    public class DataAccessLayerJSON
    {
        public static string ComputerName = "(local)";
        public static string DBName = "PlancksoftPOS";
        public static string DBUID = "PlancksoftPOS";
        public static string DBPWD = "PlancksoftPOS";

        public SqlConnection connection = new SqlConnection(@"Data Source=" + ComputerName + ";Initial Catalog=" + DBName + ";User ID=" + DBUID + ";Password=" + DBPWD);

        public int Status;
        public string Name;

        public string SerializeDataTableToJSON(DataTable dt)
        {
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            return JsonConvert.SerializeObject(rows);
        }

        public Response CheckConnection()
        {
            try
            {
                connection.Open();
                return new Response("Database Server is up.", true);
            }
            catch (Exception e)
            {
                return new Response("Database Server is down.", false);
            }
        }

        public Response RetrieveSaleByDate(DateTime StartDate, DateTime EndDate)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveSaleByDate", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (StartDate != null)
                {
                    cmd.Parameters.AddWithValue("@StartDate", StartDate);
                }
                if (EndDate != null)
                {
                    cmd.Parameters.AddWithValue("@EndDate", EndDate);
                }

                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "SaleByDate";
                return new Response(SerializeDataTableToJSON(dt), true);
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                dt.TableName = "SaleByDate";
                return new Response("Failed to retrieve sales by date.", false);
            }
        }  

        public Response RetrieveSystemSettings()
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveSystemSettings", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "SystemSettings";

                return new Response(Tuple.Create(SerializeDataTableToJSON(dt), (byte[])dt.Rows[0]["SystemLogo"]), true);
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                dt.TableName = "SystemSettings";
                return new Response("Failed to Retrieve system settings.", false);
            }
        }

        public Response RetrieveBillSoldBItemQuantity(int BillNumber, string itemBarcode)
        {
            try
            {
                int SoldItemQuantity = -1;
                using (SqlCommand cmd = new SqlCommand("RetrieveBillSoldBItemQuantity", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BillNumber", BillNumber);
                    cmd.Parameters.AddWithValue("@itemBarcode    ", itemBarcode);
                    cmd.Parameters.Add("@SoldItemQuantity", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    SoldItemQuantity = Convert.ToInt32(cmd.Parameters["@SoldItemQuantity"].Value);
                    connection.Close();
                }
                return new Response(SoldItemQuantity, true);
            }
            catch (Exception ex)
            {
                return new Response(-1, false);
            }
        }

        public Response UpdateSystemSettings(string SystemName, byte[] SystemLogo, string SystemPhone, string SystemAddress,
            int SystemReceiptBlankSpaces, int SystemIncludeLogoInReceipt, decimal SystemTax)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UpdateSystemSettings", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SystemName", SystemName);
                    cmd.Parameters.AddWithValue("@SystemLogo    ", SystemLogo);
                    cmd.Parameters.AddWithValue("@SystemPhone    ", SystemPhone);
                    cmd.Parameters.AddWithValue("@SystemAddress    ", SystemAddress);
                    cmd.Parameters.AddWithValue("@SystemReceiptBlankSpaces    ", SystemReceiptBlankSpaces);
                    cmd.Parameters.AddWithValue("@SystemIncludeLogoInReceipt    ", SystemIncludeLogoInReceipt);
                    cmd.Parameters.AddWithValue("@SystemTax    ", SystemTax);
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                }
                return new Response(Convert.ToBoolean(Status), true);
            }
            catch (Exception ex)
            {
                return new Response("Could not update system settings.", false);
            }
        }

        public Response RetrieveItemTypeName(int ItemTypeIndex, int locale)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveItemTypeName", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@ItemTypeIndex", ItemTypeIndex);

                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                string Name = "";

                foreach (DataRow Category in dt.Rows)
                {
                    Name = Category["ItemType Name"].ToString();
                }
                if (Name == "")
                {
                    if ((LanguageChoice.Languages)locale == LanguageChoice.Languages.Arabic)
                    {
                        Name = "غير مصنف";
                    }
                    else if ((LanguageChoice.Languages)locale == LanguageChoice.Languages.English)
                    {
                        Name = "Unclassified";
                    }
                }
                return new Response(Name, true);
            }
            catch (Exception ex)
            {
                return new Response("Could not Retrieve Item Type name.", false);
            }
        }

        public Response RetrieveWarehouseName(int WarehouseIndex, int locale)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveWarehouseName", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@WarehouseIndex", WarehouseIndex);

                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                string Name = "";

                foreach (DataRow Category in dt.Rows)
                {
                    Name = Category["Warehouse Name"].ToString();
                }
                if (Name == "")
                {
                    if ((LanguageChoice.Languages)locale == LanguageChoice.Languages.Arabic)
                    {
                        Name = "غير موجود";
                    }
                    else if ((LanguageChoice.Languages)locale == LanguageChoice.Languages.English)
                    {
                        Name = "Inexistent";
                    }
                }
                return new Response(Name, true);
            }
            catch (Exception ex)
            {
                return new Response("Could not Retrieve Warehouse name.", false);
            }
        }

        public Response RetrieveFavoriteCategoryName(int CategoryIndex, int locale)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveFavoriteCategoryName", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@CategoryIndex", CategoryIndex);

                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                string Name = "";

                foreach (DataRow Category in dt.Rows)
                {
                    Name = Category["Category Name"].ToString();
                }
                if (Name == "")
                {
                    if ((LanguageChoice.Languages)locale == LanguageChoice.Languages.Arabic)
                    {
                        Name = "غير مفضله";
                    } else if ((LanguageChoice.Languages)locale == LanguageChoice.Languages.English)
                    {
                        Name = "Not Favorited";
                    }
                }
                return new Response(Name, true);
            }
            catch (Exception ex)
            {
                return new Response("Could not Retrieve Favorite Category name.", false);
            }
        }

        public Response RetrieveCashierNames()
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveCashierNames", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                List<string> CashierNames = new List<string>();

                foreach (DataRow Cashier in dt.Rows)
                {
                    CashierNames.Add(Cashier["Cashier Name"].ToString());
                }
                return new Response(CashierNames, true);
            }
            catch (Exception ex)
            {
                List<string> CashierNames = new List<string>();
                return new Response("Could not Retrieve cashier names", false);
            }
        }

        public Response RetrieveItemTypeID(string ItemTypeName)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveItemTypeIndex", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@ItemTypeName", ItemTypeName);

                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                int Index = 0;

                foreach (DataRow ItemType in dt.Rows)
                {
                    Index = Convert.ToInt32(ItemType["ItemType ID"].ToString());
                }
                return new Response(Index, true);
            }
            catch (Exception ex)
            {
                return new Response(0, false);
            }
        }

        public Response RetrieveWarehouseID(string WarehouseName)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveWarehouseIndex", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@WarehouseName", WarehouseName);

                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                int Index = 0;

                foreach (DataRow Warehouse in dt.Rows)
                {
                    Index = Convert.ToInt32(Warehouse["Warehouse ID"].ToString());
                }
                return new Response(Index, true);
            }
            catch (Exception ex)
            {
                return new Response(0, false);
            }
        }

        public Response RetrieveFavoriteCategoryID(string CategoryName)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveFavoriteCategoryIndex", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@CategoryName", CategoryName);

                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                int Index = 0;

                foreach (DataRow Category in dt.Rows)
                {
                    Index = Convert.ToInt32(Category["Category ID"].ToString());
                }
                return new Response(Index, true);
            }
            catch (Exception ex)
            {
                return new Response(0, false);
            }
        }

        public Response RetrieveItemTypes()
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveItemTypes", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                adapter.SelectCommand = cmd;
                List<ItemType> ItemTypes = new List<ItemType>();
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                foreach (DataRow ItemType in dt.Rows)
                {
                    ItemTypes.Add(new ItemType(Convert.ToInt32(ItemType["ItemType ID"].ToString()), ItemType["ItemType Name"].ToString()));
                }
                return new Response(ItemTypes, true);
            }
            catch (Exception ex)
            {
                List<ItemType> ItemTypes = new List<ItemType>();
                return new Response("Could not Retrieve item types.", false);
            }
        }

        public Response RetrievePrinterItemTypes(int printerID)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrievePrinterItemTypes", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@printerID", printerID);
                adapter.SelectCommand = cmd;
                List<ItemType> ItemTypes = new List<ItemType>();
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                foreach (DataRow ItemType in dt.Rows)
                {
                    ItemTypes.Add(new ItemType(Convert.ToInt32(ItemType["ItemType ID"].ToString()), ItemType["ItemType Name"].ToString()));
                }
                return new Response(ItemTypes, true);
            }
            catch (Exception ex)
            {
                List<ItemType> ItemTypes = new List<ItemType>();
                return new Response("Could not Retrieve Printer Item Types.", false);
            }
        }

        public Response RetrieveWarehouses()
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveWarehouses", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                adapter.SelectCommand = cmd;
                List<Warehouse> Warehouses = new List<Warehouse>();
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                foreach (DataRow Warehouse in dt.Rows)
                {
                    Warehouses.Add(new Warehouse(Convert.ToInt32(Warehouse["Warehouse ID"].ToString()), Warehouse["Warehouse Name"].ToString()));
                }
                return new Response(Warehouses, true);
            }
            catch (Exception ex)
            {
                List<Warehouse> Warehouses = new List<Warehouse>();
                return new Response("Could not Retrieve Warehouses.", false);
            }
        }

        public Response RetrieveFavoriteCategories()
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveFavoriteCategories", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                adapter.SelectCommand = cmd;
                List<Category> Categories = new List<Category>();
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                foreach (DataRow Category in dt.Rows)
                {
                    Categories.Add(new Category(Convert.ToInt32(Category["Category ID"].ToString()), Category["Category Name"].ToString()));
                }
                return new Response(Categories, true);
            }
            catch (Exception ex)
            {
                List<Category> Categories = new List<Category>();
                return new Response("Could not Retrieve Favorite Categories.", false);
            }
        }

        public Response RetrievePrinters(string machineName)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrievePrinters", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@machineName", machineName);
                adapter.SelectCommand = cmd;
                List<Printer> Printers = new List<Printer>();
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                foreach (DataRow Printer in dt.Rows)
                {
                    Printers.Add(new Printer(Convert.ToInt32(Printer["Printer ID"].ToString()), Printer["Printer Name"].ToString()));
                }
                return new Response(Printers, true);
            }
            catch (Exception ex)
            {
                List<Printer> Printers = new List<Printer>();
                return new Response("Could not Retrieve Printers.", false);
            }
        }

        public Response RetrieveLoginLogoutInfo(DateTime Date)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveLoginLogoutInfo", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (Date != null)
                {
                    cmd.Parameters.AddWithValue("@Date1", Date);
                    cmd.Parameters.AddWithValue("@Date2", Date);
                }

                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "LoginLogoutInfo";
                return new Response(SerializeDataTableToJSON(dt), true);
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                dt.TableName = "LoginLogoutInfo";
                return new Response("Could not Retrieve Login Logout Information.", false);
            }
        }

        public Response RetrieveUsersList()
        {
            try
            {
                List<Account> Accounts = new List<Account>();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveUsersList", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "UsersList";
                foreach (DataRow Account in dt.Rows)
                {
                    Account account = new Account();
                    account.SetAccountUID(Account["User ID"].ToString());
                    account.SetAccountName(Account["User Name"].ToString());
                    Accounts.Add(account);
                }
                return new Response(Tuple.Create(Accounts, SerializeDataTableToJSON(dt)), true);
            }
            catch (Exception ex)
            {
                List<Account> Accounts = new List<Account>();
                DataTable dt = new DataTable();
                dt.TableName = "UsersList";
                return new Response("Could not Retrieve Users List.", false);
            }
        }

        public Response GetRetrieveClients()
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveClientsList", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "ClientsList";
                return new Response(SerializeDataTableToJSON(dt), true);
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                dt.TableName = "ClientsList";
                return new Response("Could not Retrieve Clients.", false);
            }
        }

        public Response GetRetrieveVendors()
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveVendorsList", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "VendorsList";
                
                return new Response(SerializeDataTableToJSON(dt), true);
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                dt.TableName = "VendorsList";
                return new Response("Could not Retrieve Vendors.", false);
            }
        }

        public Response CheckAdmin()
        {
            try
            {
                Account adminAccount = new Account();
                using (SqlCommand cmd = new SqlCommand("CheckAdmin", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", "Admin");
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();

                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                    return new Response(Convert.ToBoolean(Status), true);
                }
            }
            catch (Exception ex)
            {
                return new Response("Could not check for Administrator status.", false);
            }
        }

        public Response RegisterAdmin(Account AccountToRegister)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("RegisterAdmin", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserName", AccountToRegister.GetAccountName());
                    cmd.Parameters.AddWithValue("@UserID", AccountToRegister.GetAccountUID().ToLower());
                    cmd.Parameters.AddWithValue("@UserPWD", MD5Encryption.Encrypt(AccountToRegister.GetAccountPWD(), "PlancksoftPOS"));
                    cmd.Parameters.AddWithValue("@ClientCardEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.Client_card_edit.ToString())));
                    cmd.Parameters.AddWithValue("@discountEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.discount_edit.ToString())));
                    cmd.Parameters.AddWithValue("@priceEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.price_edit.ToString())));
                    cmd.Parameters.AddWithValue("@receiptEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.receipt_edit.ToString())));
                    cmd.Parameters.AddWithValue("@inventoryEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.inventory_edit.ToString())));
                    cmd.Parameters.AddWithValue("@expensesEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.expenses_add.ToString())));
                    cmd.Parameters.AddWithValue("@usersEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.users_edit.ToString())));
                    cmd.Parameters.AddWithValue("@settingsEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.settings_edit.ToString())));
                    cmd.Parameters.AddWithValue("@personnelEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.personnel_edit.ToString())));
                    cmd.Parameters.AddWithValue("@opencloseEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.openclose_edit.ToString())));
                    cmd.Parameters.AddWithValue("@sellEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.sell_edit.ToString())));
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                    return new Response(Convert.ToBoolean(Status), true);
                }
            }
            catch (Exception ex)
            {
                return new Response("Could not register Administrator account.", false);
            }
        }

        public void LogLogout(string cashierName, DateTime date)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("LogLogout", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@cashierName", cashierName);
                    cmd.Parameters.AddWithValue("@Date", date.ToString());

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();

                    connection.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void LogLogin(string cashierName, DateTime date)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("LogLogin", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@cashierName", cashierName);
                    cmd.Parameters.AddWithValue("@Date", date.ToString());

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    
                    connection.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public Response Login(Account AccountToLogin)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("LoginAccount", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", AccountToLogin.GetAccountUID());
                    cmd.Parameters.AddWithValue("@UserPWD", MD5Encryption.Encrypt(AccountToLogin.GetAccountPWD(), "PlancksoftPOS"));
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Authority", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters["@Name"].Size = 250;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();

                    int Authority = Convert.ToInt32(cmd.Parameters["@Authority"].Value);
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    Name = cmd.Parameters["@Name"].Value.ToString();
                    connection.Close();
                    return new Response(Tuple.Create(Convert.ToBoolean(Status), Name, Convert.ToBoolean(Authority)), true);
                }
            }
            catch (Exception ex)
            {
                return new Response("Could not Log In.", false);
            }
        }

        public Response Register(Account AccountToRegister, string UID, int AdminOrNot)
        {
            try
            {
                if (Convert.ToBoolean(AdminOrNot))
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("RegisterAdmin", connection))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@UserName", AccountToRegister.GetAccountName());
                            cmd.Parameters.AddWithValue("@UserID", AccountToRegister.GetAccountUID().ToLower());
                            cmd.Parameters.AddWithValue("@UserPWD", MD5Encryption.Encrypt(AccountToRegister.GetAccountPWD().ToString(), "PlancksoftPOS"));
                            cmd.Parameters.AddWithValue("@ClientCardEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.Client_card_edit.ToString())));
                            cmd.Parameters.AddWithValue("@discountEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.discount_edit.ToString())));
                            cmd.Parameters.AddWithValue("@priceEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.price_edit.ToString())));
                            cmd.Parameters.AddWithValue("@receiptEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.receipt_edit.ToString())));
                            cmd.Parameters.AddWithValue("@inventoryEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.inventory_edit.ToString())));
                            cmd.Parameters.AddWithValue("@expensesEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.expenses_add.ToString())));
                            cmd.Parameters.AddWithValue("@usersEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.users_edit.ToString())));
                            cmd.Parameters.AddWithValue("@settingsEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.settings_edit.ToString())));
                            cmd.Parameters.AddWithValue("@personnelEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.personnel_edit.ToString())));
                            cmd.Parameters.AddWithValue("@opencloseEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.openclose_edit.ToString())));
                            cmd.Parameters.AddWithValue("@sellEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.sell_edit.ToString())));
                            cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                            if (connection != null && connection.State == ConnectionState.Closed)
                                connection.Open();
                            cmd.ExecuteNonQuery();
                            Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                            connection.Close();
                            return new Response(Convert.ToBoolean(Status), true);
                        }
                    }
                    catch (Exception ex)
                    {
                        return new Response("Could not Register an Adminsitrator Account.", false);
                    }
                }
                using (SqlCommand cmd = new SqlCommand("RegisterAccount", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserName", AccountToRegister.GetAccountName());
                    cmd.Parameters.AddWithValue("@UserID", AccountToRegister.GetAccountUID().ToLower());
                    cmd.Parameters.AddWithValue("@UserPWD", MD5Encryption.Encrypt(AccountToRegister.GetAccountPWD().ToString(), "PlancksoftPOS"));
                    cmd.Parameters.AddWithValue("@AdminAcc", UID);
                    cmd.Parameters.AddWithValue("@ClientCardEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.Client_card_edit.ToString())));
                    cmd.Parameters.AddWithValue("@discountEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.discount_edit.ToString())));
                    cmd.Parameters.AddWithValue("@priceEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.price_edit.ToString())));
                    cmd.Parameters.AddWithValue("@receiptEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.receipt_edit.ToString())));
                    cmd.Parameters.AddWithValue("@inventoryEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.inventory_edit.ToString())));
                    cmd.Parameters.AddWithValue("@expensesEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.expenses_add.ToString())));
                    cmd.Parameters.AddWithValue("@usersEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.users_edit.ToString())));
                    cmd.Parameters.AddWithValue("@settingsEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.settings_edit.ToString())));
                    cmd.Parameters.AddWithValue("@personnelEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.personnel_edit.ToString())));
                    cmd.Parameters.AddWithValue("@opencloseEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.openclose_edit.ToString())));
                    cmd.Parameters.AddWithValue("@sellEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.sell_edit.ToString())));
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                    return new Response(Convert.ToBoolean(Status), true);
                }
            }
            catch (Exception ex)
            {
                return new Response("Could not Register an Account.", false);
            }
        }

        public Response DeleteFavoriteItem(string ItemBarCode)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("DeleteFavoriteItem", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@item_barcode", ItemBarCode);
                cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                if (connection != null && connection.State == ConnectionState.Closed)
                    connection.Open();
                cmd.ExecuteNonQuery();
                Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                connection.Close();
                return new Response(Convert.ToBoolean(Status), true);
            }
            catch (Exception ex)
            {
                return new Response("Could not Delete Favorite Item.", false);
            }
        }

        public Response AddPrinterItemType(int printerID, int itemTypeID)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("AddPrinterItemType", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@printer_id", printerID);
                cmd.Parameters.AddWithValue("@itemType_id", itemTypeID);
                cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                if (connection != null && connection.State == ConnectionState.Closed)
                    connection.Open();
                cmd.ExecuteNonQuery();
                Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                connection.Close();
                return new Response(Convert.ToBoolean(Status), true);
            }
            catch (Exception ex)
            {
                return new Response("Could not Add Printer Item Type.", false);
            }
        }

        public Response DeletePrinterItemType(int printerID, int itemTypeID)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("DeletePrinterItemType", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@printer_id", printerID);
                cmd.Parameters.AddWithValue("@itemType_id", itemTypeID);
                cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                if (connection != null && connection.State == ConnectionState.Closed)
                    connection.Open();
                cmd.ExecuteNonQuery();
                Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                connection.Close();
                return new Response(Convert.ToBoolean(Status), true);
            }
            catch (Exception ex)
            {
                return new Response("Could not Delete Printer Item Type.", false);
            }
        }

        public Response DeletePrinter(string machineName, int printerID)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("DeletePrinter", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@printer_id", printerID);
                cmd.Parameters.AddWithValue("@machine_name", machineName);
                cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                if (connection != null && connection.State == ConnectionState.Closed)
                    connection.Open();
                cmd.ExecuteNonQuery();
                Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                connection.Close();
                return new Response(Convert.ToBoolean(Status), true);
            }
            catch (Exception ex)
            {
                return new Response("Could not delete Printer.", false);
            }
        }

        public Response AddFavoriteItem(string ItemName, string ItemBarCode, int ItemQuantity, decimal ItemPrice, decimal ItemPriceTax, decimal Category, DateTime Date)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("AddFavoriteItem", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@item_name", ItemName);
                cmd.Parameters.AddWithValue("@item_barcode", ItemBarCode);
                cmd.Parameters.AddWithValue("@item_quantity", ItemQuantity);
                cmd.Parameters.AddWithValue("@item_price", ItemPrice);
                cmd.Parameters.AddWithValue("@item_price_tax", ItemPriceTax);
                cmd.Parameters.AddWithValue("@favorite", Category);
                cmd.Parameters.AddWithValue("@Date", Date);
                cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                if (connection != null && connection.State == ConnectionState.Closed)
                    connection.Open();
                cmd.ExecuteNonQuery();
                Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                connection.Close();
                return new Response(Convert.ToBoolean(Status), true);
            }
            catch (Exception ex)
            {
                return new Response("Could not Add Favorite Item.", false);
            }
        }

        public Response AddPrinter(string printerName)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("AddPrinter", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@printer_name", printerName);
                cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                if (connection != null && connection.State == ConnectionState.Closed)
                    connection.Open();
                cmd.ExecuteNonQuery();
                Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                connection.Close();
                return new Response(Convert.ToBoolean(Status), true);
            }
            catch (Exception ex)
            {
                return new Response("Could not Add Printer.", false);
            }
        }

        public Response SaveRegisterClose(string cashierName, decimal moneyInRegister)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("SaveRegisterClose", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@cashier_name", cashierName);
                cmd.Parameters.AddWithValue("@moneyInRegister", moneyInRegister);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                if (connection != null && connection.State == ConnectionState.Closed)
                    connection.Open();
                cmd.ExecuteNonQuery();
                Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                connection.Close();
                return new Response(Convert.ToBoolean(Status), true);
            }
            catch (Exception ex)
            {
                return new Response("Could not Save Register Closing.", false);
            }
        }

        public Response SaveRegisterOpen(string cashierName, decimal moneyInRegister)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("SaveRegisterOpen", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@cashier_name", cashierName);
                cmd.Parameters.AddWithValue("@moneyInRegister", moneyInRegister);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                if (connection != null && connection.State == ConnectionState.Closed)
                    connection.Open();
                cmd.ExecuteNonQuery();
                Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                connection.Close();
                return new Response(Convert.ToBoolean(Status), true);
            }
            catch (Exception ex)
            {
                return new Response("Could not Save Register Opening.", false);
            }
        }

        public Response SearchWarehouseInventoryItems(int WarehouseID)
        {
            try
            {
                List<Item> Items = new List<Item>();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("SearchWarehouseInventoryItems", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (WarehouseID != 0)
                    cmd.Parameters.AddWithValue("@WarehouseID", WarehouseID);
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "WarehouseInventoryItems";
                
                foreach (DataRow Item in dt.Rows)
                {
                    Item item = new Item();
                    item.SetName(Item["Item Name"].ToString());
                    item.SetBarCode(Item["Item BarCode"].ToString());
                    item.SetQuantity(Convert.ToInt32(Item["Item Quantity"].ToString()));
                    item.SetPrice(Convert.ToDecimal(Item["Item Price"].ToString()));
                    item.SetPriceTax(Convert.ToDecimal(Item["Item Price Tax"].ToString()));
                    Items.Add(item);
                }
                return new Response(Tuple.Create(Items, SerializeDataTableToJSON(dt)), true);
            }
            catch (Exception ex)
            {
                List<Item> Items = new List<Item>();
                DataTable dt = new DataTable();
                dt.TableName = "WarehouseInventoryItems";
                return new Response("Could not Search Warehouse Inventory Items.", false);
            }
        }

        public Response SearchInventoryItems(string ItemName = "", string ItemBarCode = "", int locale = 1)
        {
            try
            {
                List<Item> Items = new List<Item>();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("SearchInventoryItems", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                
                if (ItemName != "")
                    cmd.Parameters.AddWithValue("@ItemName", ItemName);
                if (ItemBarCode != "")
                    cmd.Parameters.AddWithValue("@ItemBarCode", ItemBarCode);
                cmd.Parameters.AddWithValue("@Locale", locale);
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "InventoryItems";
                
                foreach (DataRow Item in dt.Rows)
                {
                    Item item = new Item();
                    item.SetID(Convert.ToInt32(Item["Item ID"].ToString()));
                    item.SetName(Item["Item Name"].ToString());
                    item.SetBarCode(Item["Item BarCode"].ToString());
                    item.SetQuantity(Convert.ToInt32(Item["Item Quantity"].ToString()));
                    item.SetPrice(Convert.ToDecimal(Item["Item Price"].ToString()));
                    item.SetPriceTax(Convert.ToDecimal(Item["Item Price Tax"].ToString()));
                    Items.Add(item);
                }
                return new Response(Tuple.Create(Items, SerializeDataTableToJSON(dt)), true);
            }
            catch (Exception ex)
            {
                List<Item> Items = new List<Item>();
                DataTable dt = new DataTable();
                dt.TableName = "InventoryItems";
                return new Response("Could not Search Inventory Items", false);
            }
        }

        public Response SearchInventoryItemsWithBarCode(string ItemBarCode = "")
        {
            try
            {
                Item Item = new Item();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("SearchInventoryItemsWithBarCode", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                
                if (ItemBarCode != "")
                    cmd.Parameters.AddWithValue("@ItemBarCode", ItemBarCode);
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "InventoryItemsWithBarCode";
                
                foreach (DataRow ItemFound in dt.Rows)
                {
                    Item.SetID(Int32.Parse(ItemFound["Item ID"].ToString()));
                    Item.SetName(ItemFound["Item Name"].ToString());
                    Item.SetBarCode(ItemFound["Item BarCode"].ToString());
                    Item.SetQuantity(Convert.ToInt32(ItemFound["Item Quantity"].ToString()));
                    Item.SetPrice(Convert.ToDecimal(ItemFound["Item Price"].ToString()));
                    Item.SetPriceTax(Convert.ToDecimal(ItemFound["Item Price Tax"].ToString()));
                    return new Response(Item, true);
                }
                return null;
            }
            catch (Exception ex)
            {
                Item Item = new Item();
                return new Response("Could not find item.", false);
            }
        }

        public Response RetrieveUnPortedBills()
        {
            try
            {
                List<Bill> Bills = new List<Bill>();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveUnPortedBills", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "UnPortedBills";
                
                foreach (DataRow Bill in dt.Rows)
                {
                    Bill bill = new Bill();
                    bill.SetBillNumber(Convert.ToInt32(Bill["Bill Number"].ToString()));
                    bill.SetCashierName(Bill["Cashier Name"].ToString());
                    bill.SetTotalAmount(Convert.ToDecimal(Bill["Total Amount"].ToString()));
                    bill.SetPaidAmount(Convert.ToDecimal(Bill["Paid Amount"].ToString()));
                    bill.SetRemainderAmount(Convert.ToDecimal(Bill["Remainder Amount"].ToString()));
                    Bills.Add(bill);
                }
                return new Response(Tuple.Create(Bills, SerializeDataTableToJSON(dt)), true);
            }
            catch (Exception ex)
            {
                List<Bill> Bills = new List<Bill>();
                DataTable dt = new DataTable();
                dt.TableName = "UnPortedBills";
                return new Response("Could not Retrieve Unported Bills", false);
            }
        }

        public Response RetrievePortedBills()
        {
            try
            {
                List<Bill> Bills = new List<Bill>();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrievePortedBills", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "PortedBills";
                
                foreach (DataRow Bill in dt.Rows)
                {
                    Bill bill = new Bill();
                    bill.SetBillNumber(Convert.ToInt32(Bill["Bill Number"].ToString()));
                    bill.SetCashierName(Bill["Cashier Name"].ToString());
                    bill.SetTotalAmount(Convert.ToDecimal(Bill["Total Amount"].ToString()));
                    bill.SetPaidAmount(Convert.ToDecimal(Bill["Paid Amount"].ToString()));
                    bill.SetRemainderAmount(Convert.ToDecimal(Bill["Remainder Amount"].ToString()));
                    Bills.Add(bill);
                }
                return new Response(Tuple.Create(Bills, SerializeDataTableToJSON(dt)), true);
            }
            catch (Exception ex)
            {
                List<Bill> Bills = new List<Bill>();
                DataTable dt = new DataTable();
                dt.TableName = "PortedBills";
                return new Response("Could not Retrieve Ported Bills.", false);
            }
        }

        public Response RetrieveUnpaidBills()
        {
            try
            {
                List<Bill> Bills = new List<Bill>();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveUnpaidBills", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "UnpaidBills";
                
                foreach (DataRow Bill in dt.Rows)
                {
                    Bill bill = new Bill();
                    bill.SetBillNumber(Convert.ToInt32(Bill["Bill Number"].ToString()));
                    bill.SetCashierName(Bill["Cashier Name"].ToString());
                    bill.SetTotalAmount(Convert.ToDecimal(Bill["Total Amount"].ToString()));
                    bill.SetDate(Convert.ToDateTime(Bill["Date"].ToString()));
                    bill.Postponed = true;
                    Bills.Add(bill);
                }
                foreach(Bill bill in Bills)
                {
                    bill.ItemsBought = (List<Item>)RetrieveBillItems(bill.getBillNumber()).ResponseMessage;
                }
                return new Response(Tuple.Create(Bills, SerializeDataTableToJSON(dt)), true);
            }
            catch (Exception ex)
            {
                List<Bill> Bills = new List<Bill>();
                DataTable dt = new DataTable();
                dt.TableName = "VendorBills";
                return new Response("Could not Retrieve Unpaid Bills.", false);
            }
        }

        public Response RetrieveVendorBills()
        {
            try
            {
                List<Bill> Bills = new List<Bill>();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveVendorBills", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "VendorBills";
                
                foreach (DataRow Bill in dt.Rows)
                {
                    Bill bill = new Bill();
                    bill.SetBillNumber(Convert.ToInt32(Bill["Bill Number"].ToString()));
                    bill.ClientID = Convert.ToInt32(Bill["Vendor ID"].ToString());
                    bill.SetClientName(Bill["Vendor Name"].ToString());
                    bill.SetCashierName(Bill["Cashier Name"].ToString());
                    bill.SetTotalAmount(Convert.ToDecimal(Bill["Total Amount"].ToString()));
                    bill.SetDate(Convert.ToDateTime(Bill["Date"].ToString()));
                    Bills.Add(bill);
                }
                return new Response(Tuple.Create(Bills, SerializeDataTableToJSON(dt)), true);
            }
            catch (Exception ex)
            {
                List<Bill> Bills = new List<Bill>();
                DataTable dt = new DataTable();
                dt.TableName = "VendorBills";
                return new Response(ex.ToString(), false);
            }
        }

        public Response RetrieveTaxZReport()
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveTaxZReport", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "TaxZReport";
                return new Response(SerializeDataTableToJSON(dt), true);
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                dt.TableName = "TaxZReport";
                return new Response("Could not Retrieve Tax Z Report.", false);
            }
        }

        public Response RetrieveBills()
        {
            try
            {
                List<Bill> Bills = new List<Bill>();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveBills", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "Bills";
                
                foreach (DataRow Bill in dt.Rows)
                {
                    Bill bill = new Bill();
                    bill.SetBillNumber(Convert.ToInt32(Bill["Bill Number"].ToString()));
                    bill.SetCashierName(Bill["Cashier Name"].ToString());
                    bill.SetClientName(Bill["Client Name"].ToString());
                    bill.SetTotalAmount(Convert.ToDecimal(Bill["Total Amount"].ToString()));
                    bill.SetPaidAmount(Convert.ToDecimal(Bill["Paid Amount"].ToString()));
                    bill.SetRemainderAmount(Convert.ToDecimal(Bill["Remainder Amount"].ToString()));
                    bill.SetDate(Convert.ToDateTime(Bill["Invoice Date"].ToString()));
                    bill.SetPayByCash(Convert.ToBoolean(Convert.ToInt32(Bill["PayByCash"].ToString())));
                    Bills.Add(bill);
                }
                return new Response(Tuple.Create(Bills, SerializeDataTableToJSON(dt)), true);
            }
            catch (Exception ex)
            {
                List<Bill> Bills = new List<Bill>();
                DataTable dt = new DataTable();
                dt.TableName = "Bills";
                return new Response("Could not Retrieve Bills.", false);
            }
        }  

        public Response RetrieveBillsRefund()
        {
            try
            {
                List<Bill> Bills = new List<Bill>();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveBillsRefund", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "Bills";
                
                foreach (DataRow Bill in dt.Rows)
                {
                    Bill bill = new Bill();
                    bill.SetBillNumber(Convert.ToInt32(Bill["Bill Number"].ToString()));
                    bill.SetCashierName(Bill["Cashier Name"].ToString());
                    bill.SetClientName(Bill["Client Name"].ToString());
                    bill.SetTotalAmount(Convert.ToDecimal(Bill["Total Amount"].ToString()));
                    bill.SetPaidAmount(Convert.ToDecimal(Bill["Paid Amount"].ToString()));
                    bill.SetRemainderAmount(Convert.ToDecimal(Bill["Remainder Amount"].ToString()));
                    bill.SetDate(Convert.ToDateTime(Bill["Invoice Date"].ToString()));
                    Bills.Add(bill);
                }
                return new Response(Tuple.Create(Bills, SerializeDataTableToJSON(dt)), true);
            }
            catch (Exception ex)
            {
                List<Bill> Bills = new List<Bill>();
                DataTable dt = new DataTable();
                dt.TableName = "Bills";
                return new Response("Could not Retrieve Bills.", false);
            }
        }

        public Response RetrieveCapitalRevenue()
        {
            try
            {
                List<Item> Items = new List<Item>();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveCapitalRevenue", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "CapitalRevenue";
                
                return new Response(Tuple.Create(Items, SerializeDataTableToJSON(dt)), true);
            }
            catch (Exception ex)
            {
                List<Item> Items = new List<Item>();
                DataTable dt = new DataTable();
                dt.TableName = "CapitalRevenue";
                return new Response("Could not Retrieve Capital Revenue.", false);
            }
        }

        public Response RetrieveExports()
        {
            try
            {
                List<Item> Items = new List<Item>();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveExports", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "Exports";
                
                return new Response(Tuple.Create(Items, SerializeDataTableToJSON(dt)), true);
            }
            catch (Exception ex)
            {
                List<Item> Items = new List<Item>();
                DataTable dt = new DataTable();
                dt.TableName = "Exports";
                return new Response("Could not Retrieve Exports.", false);
            }
        }

        public Response RetrieveImports()
        {
            try
            {
                List<Item> Items = new List<Item>();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveImports", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "Imports";
                
                return new Response(Tuple.Create(Items, SerializeDataTableToJSON(dt)), true);
            }
            catch (Exception ex)
            {
                List<Item> Items = new List<Item>();
                DataTable dt = new DataTable();
                dt.TableName = "Imports";
                return new Response("Could not Retrieve Imports.", false);
            }
        }

        public Response RetrieveLeastBoughtItems()
        {
            try
            {
                List<Item> Items = new List<Item>();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveLeastBoughtItems", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "LeastBoughtItems";
                
                foreach (DataRow Item in dt.Rows)
                {
                    Item item = new Item();
                    item.SetName(Item["Item Name"].ToString());
                    item.SetBarCode(Item["Item BarCode"].ToString());
                    item.SetQuantity(Convert.ToInt32(Item["Times Sold"].ToString()));
                    item.SetPrice(Convert.ToDecimal(Item["Item Price"].ToString()));
                    item.SetPriceTax(Convert.ToDecimal(Item["Item Price Tax"].ToString()));
                    Items.Add(item);
                }
                return new Response(Tuple.Create(Items, SerializeDataTableToJSON(dt)), true);
            }
            catch (Exception ex)
            {
                List<Item> Items = new List<Item>();
                DataTable dt = new DataTable();
                dt.TableName = "LeastBoughtItems";
                return new Response("Could not Retrieve Least Bought Items.", false);
            }
        }

        public Response RetrieveMostBoughtItems()
        {
            try
            {
                List<Item> Items = new List<Item>();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveMostBoughtItems", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "MostBoughtItems";
                
                foreach (DataRow Item in dt.Rows)
                {
                    Item item = new Item();
                    item.SetName(Item["Item Name"].ToString());
                    item.SetBarCode(Item["Item BarCode"].ToString());
                    item.SetQuantity(Convert.ToInt32(Item["Times Sold"].ToString()));
                    item.SetPrice(Convert.ToDecimal(Item["Item Price"].ToString()));
                    item.SetPriceTax(Convert.ToDecimal(Item["Item Price Tax"].ToString()));
                    Items.Add(item);
                }
                return new Response(Tuple.Create(Items, SerializeDataTableToJSON(dt)), true);
            }
            catch (Exception ex)
            {
                List<Item> Items = new List<Item>();
                DataTable dt = new DataTable();
                dt.TableName = "MostBoughtItems";
                return new Response("Could not Retrieve Most Bought Items.", false);
            }
        }

        public Response RetrieveAccountAuthority(string UserID = "")
        {
            try
            {
                Account User = new Account();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveAccountAuthority", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@UserID", UserID);

                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "AccountAuthority";

                return new Response(Convert.ToInt32(dt.Rows[0]["Authority"].ToString()), true);
            }
            catch (Exception ex)
            {
                return new Response(0, false);
            }
        }

        public Response RetrieveUserPermissions(string UserID = "")
        {
            try
            {
                Account User = new Account();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveUserPermissions", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@UserID", UserID);

                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "UserPermissions";

                User.Uid = UserID;
                foreach (DataRow Permission in dt.Rows)
                {
                    User.Authority = Convert.ToInt32(Permission["Authority"].ToString());
                    User.Client_card_edit = Convert.ToBoolean(Convert.ToInt32(Permission["Client Card Permission"].ToString()));
                    User.discount_edit = Convert.ToBoolean(Convert.ToInt32(Permission["Discount Permission"].ToString()));
                    User.price_edit = Convert.ToBoolean(Convert.ToInt32(Permission["Price Edit Permission"].ToString()));
                    User.receipt_edit = Convert.ToBoolean(Convert.ToInt32(Permission["Receipt Edit Permission"].ToString()));
                    User.inventory_edit = Convert.ToBoolean(Convert.ToInt32(Permission["Inventory Edit Permission"].ToString()));
                    User.expenses_add = Convert.ToBoolean(Convert.ToInt32(Permission["Expense Add Permission"].ToString()));
                    User.users_edit = Convert.ToBoolean(Convert.ToInt32(Permission["Users Edit Permission"].ToString()));
                    User.settings_edit = Convert.ToBoolean(Convert.ToInt32(Permission["Settings Edit Permission"].ToString()));
                    User.personnel_edit = Convert.ToBoolean(Convert.ToInt32(Permission["Personnel Edit Permission"].ToString()));
                    User.openclose_edit = Convert.ToBoolean(Convert.ToInt32(Permission["Open Close Cash Permission"].ToString()));
                    User.sell_edit = Convert.ToBoolean(Convert.ToInt32(Permission["Sell Permission"].ToString()));
                }
                return new Response(User, true);
            }
            catch (Exception ex)
            {
                Account User = new Account();
                return new Response(User, false);
            }
        }

        public Response RetrieveItemPictureFromBarCode(string ItemBarCode)
        {
            try
            {
                Item Item = new Item();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveItemPictureFromBarCode", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@ItemBarCode", ItemBarCode);

                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "ItemPictureFromBarCode";
                
                foreach (DataRow ItemInfo in dt.Rows)
                {
                    if (!Convert.IsDBNull(ItemInfo["Item Picture"]))
                    {
                        Item.picture = JsonConvert.SerializeObject((Byte[])(ItemInfo["Item Picture"]));
                    }
                }
                return new Response(Item, true);
            }
            catch (Exception ex)
            {
                Item Item = new Item();
                return new Response(Item, false);
            }
        }

        public Response RetrieveItemsQuantityDates(string ItemBarCode)
        {
            try
            {
                Item Item = new Item();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveItemsQuantityDates", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@ItemBarCode", ItemBarCode);

                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "ItemsQuantityDates";
                
                foreach (DataRow ItemInfo in dt.Rows)
                {
                    Item.SetName(ItemInfo["Item Name"].ToString());
                    Item.SetBarCode(ItemInfo["Item BarCode"].ToString());
                    Item.SetQuantity(Convert.ToInt32(ItemInfo["Item Quantity"].ToString()));
                    Item.QuantityWarning = Convert.ToInt32(ItemInfo["Quantity Warning"].ToString());
                    Item.ProductionDate = Convert.ToDateTime(ItemInfo["Production Date"].ToString());
                    Item.ExpirationDate = Convert.ToDateTime(ItemInfo["Expiration Date"].ToString());
                    Item.EntryDate = Convert.ToDateTime(ItemInfo["Entry Date"].ToString());
                }
                return new Response(Item, true);
            }
            catch (Exception ex)
            {
                Item Item = new Item();
                return new Response(Item, false);
            }
        }

        public Response RetrieveItems(int locale)
        {
            try
            {
                List<Item> Items = new List<Item>();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveItems", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Locale", locale);
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "Items";
                
                foreach (DataRow Item in dt.Rows)
                {
                    Item item = new Item();
                    item.SetName(Item["Item Name"].ToString());
                    item.SetBarCode(Item["Item BarCode"].ToString());
                    item.SetQuantity(Convert.ToInt32(Item["Item Quantity"].ToString()));
                    item.SetPrice(Convert.ToDecimal(Item["Item Price"].ToString()));
                    item.SetPriceTax(Convert.ToDecimal(Item["Item Price Tax"].ToString()));
                    item.SetFavoriteCategory(Convert.ToInt32(Item["Favorite Category Number"].ToString()));
                    item.SetFavoriteCategoryName(Item["Favorite Category"].ToString());
                    item.SetWarehouseID(Convert.ToInt32(Item["Warehouse ID"].ToString()));
                    item.SetWarehouseName(Item["InventoryItemWarehouse"].ToString());
                    item.SetItemTypeID(Convert.ToInt32(Item["Item Type"].ToString()));
                    item.SetItemTypeName(Item["InventoryItemType"].ToString());
                    object pictureObj = Item["Item Picture"];
                    if (DBNull.Value.Equals(pictureObj))
                    {
                        item.Picture = null;
                    }
                    else
                    {
                        byte[] pictureBytes = (byte[])pictureObj;
                        item.Picture = JsonConvert.SerializeObject(pictureBytes);
                    }
                    Items.Add(item);
                }
                return new Response(Tuple.Create(Items, SerializeDataTableToJSON(dt)), true);
            }
            catch (Exception ex)
            {
                List<Item> Items = new List<Item>();
                DataTable dt = new DataTable();
                dt.TableName = "Items";
                return new Response("Could not Retrieve Items.", false);
            }
        }

        public Response RetrieveEmployees(DateTime DateFrom, DateTime DateTo)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveEmployees", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Date1", DateFrom);
                cmd.Parameters.AddWithValue("@Date2", DateTo);

                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "Employees";
                return new Response(SerializeDataTableToJSON(dt), true);
            }
            catch (Exception ex)
            {
                Account[] Users = new Account[0];
                DataTable dt = new DataTable();
                dt.TableName = "Employees";
                return new Response("Could not Retrieve Employees.", false);
            }
        }

        public Response RetrieveEmployeesData()
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveEmployeesData", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "EmployeesData";
                return new Response(SerializeDataTableToJSON(dt), true);
            }
            catch (Exception ex)
            {
                Account[] Users = new Account[0];
                DataTable dt = new DataTable();
                dt.TableName = "EmployeesData";
                return new Response("Could not Retrieve Employees Data.", false);
            }
        }

        public Response RetrieveUsers()
        {
            try
            {
                List<Account> Users = new List<Account>();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveUsers", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "Users";
                
                foreach (DataRow User in dt.Rows)
                {
                    Account user = new Account();
                    user.SetAccountName(User["User Name"].ToString());
                    user.SetAccountUID(User["User ID"].ToString());
                    user.SetAccountPWD(User["User Password"].ToString());
                    user.SetAccountAuthority(Convert.ToInt32(User["User Authority"].ToString()));
                    Users.Add(user);
                }
                return new Response(Tuple.Create(Users, SerializeDataTableToJSON(dt)), true);
            }
            catch (Exception ex)
            {
                List<Account> Users = new List<Account>();
                DataTable dt = new DataTable();
                dt.TableName = "Users";
                return new Response("Could not Retrieve Users.", false);
            }
        }

        public Response RetrieveVendorBillItems(int BillNumber)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveVendorBillItems", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@BillNumber", BillNumber);
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "VendorBillItems";
                return new Response(SerializeDataTableToJSON(dt), true);
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                dt.TableName = "VendorBillItems";
                return new Response("Could not Retrieve Vendor Bill Items.", false);
            }
        }

        public Response RetrieveClientBills(int ClientID)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveClientBills", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ClientID", ClientID);
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "ClientBills";
                return new Response(SerializeDataTableToJSON(dt), true);
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                dt.TableName = "ClientBills";
                return new Response("Could not Retrieve Client Bills.", false);
            }
        }

        public Response RetrieveBillItems(int BillNumber)
        {
            try
            {
                List<Item> BillItems = new List<Item>();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveBillItems", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@BillNumber", BillNumber);
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "BillItems";
                
                foreach (DataRow FavoriteItem in dt.Rows)
                {
                    Item billItems = new Item();
                    billItems.SetName(FavoriteItem["Item Name"].ToString());
                    billItems.SetBarCode(FavoriteItem["Item BarCode"].ToString());
                    billItems.SetQuantity(Convert.ToInt32(FavoriteItem["Times Sold"].ToString()));
                    billItems.SetReturnedQuantity(Convert.ToInt32(FavoriteItem["Returned Quantity"].ToString()));
                    billItems.SetPrice(Convert.ToDecimal(FavoriteItem["Item Price"].ToString()));
                    billItems.SetPriceTax(Convert.ToDecimal(FavoriteItem["Item Price Tax"].ToString()));
                    BillItems.Add(billItems);
                }
                return new Response(Tuple.Create(BillItems, SerializeDataTableToJSON(dt)), true);
            }
            catch (Exception ex)
            {
                List<Item> Items = new List<Item>();
                DataTable dt = new DataTable();
                dt.TableName = "BillItems";
                return new Response("Could not Retrieve Bill Items.", false);
            }
        }   

        public Response RetrieveBillItemsRefund(int BillNumber)
        {
            try
            {
                List<Item> BillItems = new List<Item>();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveBillItemsRefund", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@BillNumber", BillNumber);
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "BillItems";
                
                foreach (DataRow FavoriteItem in dt.Rows)
                {
                    Item billItems = new Item();
                    billItems.SetName(FavoriteItem["Item Name"].ToString());
                    billItems.SetBarCode(FavoriteItem["Item BarCode"].ToString());
                    billItems.SetQuantity(Convert.ToInt32(FavoriteItem["Times Sold"].ToString()));
                    billItems.SetPrice(Convert.ToDecimal(FavoriteItem["Item Price"].ToString()));
                    billItems.SetPriceTax(Convert.ToDecimal(FavoriteItem["Item Price Tax"].ToString()));
                    BillItems.Add(billItems);
                }
                return new Response(Tuple.Create(BillItems, SerializeDataTableToJSON(dt)), true);
            }
            catch (Exception ex)
            {
                List<Item> Items = new List<Item>();
                DataTable dt = new DataTable();
                dt.TableName = "BillItems";
                return new Response("Could not Retrieve Bill Items.", false);
            }
        }

        public Response RetrieveBillItemsProfit(string Date1, string Date2, int ItemTypeID, string CashierName)
        {
            try
            {
                Item[] BillItems = new Item[0];
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveBillItemsProfit", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Date1", Date1);
                cmd.Parameters.AddWithValue("@Date2", Date2);
                if (ItemTypeID != 0)
                    cmd.Parameters.AddWithValue("@ItemTypeID", ItemTypeID);
                if (CashierName != "")
                    cmd.Parameters.AddWithValue("@CashierName", CashierName);
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "BillItemsProfit";
                return new Response(SerializeDataTableToJSON(dt), true);
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                dt.TableName = "BillItemsProfit";
                return new Response("Could not Retrieve Bill Items Profit", false);
            }
        }

        public Response RetrieveReturnedItems()
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveReturnedItems", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "ReturnedItems";
                return new Response(SerializeDataTableToJSON(dt), true);
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                dt.TableName = "ReturnedItems";
                return new Response("Could not Retrieve Returned Items.", false);
            }
        }

        public Response RetrieveFavoriteItems(int Category)
        {
            try
            {
                List<Item> FavoriteItems = new List<Item>();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveFavoriteItems", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Category", Category);
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "FavoriteItems";
                
                foreach (DataRow FavoriteItem in dt.Rows)
                {
                    Item favoriteItem = new Item();
                    favoriteItem.SetID(Int32.Parse(FavoriteItem["Item ID"].ToString()));
                    favoriteItem.SetName(FavoriteItem["Item Name"].ToString());
                    favoriteItem.SetBarCode(FavoriteItem["Item BarCode"].ToString());
                    favoriteItem.SetQuantity(Convert.ToInt32(FavoriteItem["Item Quantity"].ToString()));
                    favoriteItem.SetPrice(Convert.ToDecimal(FavoriteItem["Item Price"].ToString()));
                    favoriteItem.SetPriceTax(Convert.ToDecimal(FavoriteItem["Item Price Tax"].ToString()));
                    favoriteItem.SetFavoriteCategory(Convert.ToInt32(FavoriteItem["Favorite Category"].ToString()));
                    FavoriteItems.Add(favoriteItem);
                }
                return new Response(Tuple.Create(FavoriteItems, SerializeDataTableToJSON(dt)), true);
            }
            catch (Exception ex)
            {
                List<Item> Items = new List<Item>();
                DataTable dt = new DataTable();
                dt.TableName = "FavoriteItems";
                return new Response("Could not Retrieve Favorite Items.", false);
            }
        }

        public Response GetCapitalAmount()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("GetCapitalAmount", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Direction = ParameterDirection.Output;
                    cmd.Parameters["@Amount"].Precision = 18;
                    cmd.Parameters["@Amount"].Scale = 2;
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                    decimal Amount = Convert.ToDecimal(cmd.Parameters["@Amount"].Value.ToString());
                    return new Response(Amount, true);
                }
            }
            catch (Exception ex)
            {
                return new Response(0, false);
            }
        }

        public Response GetOpenRegisterAmount()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("GetOpenRegisterAmount", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Direction = ParameterDirection.Output;
                    cmd.Parameters["@Amount"].Precision = 18;
                    cmd.Parameters["@Amount"].Scale = 2;
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                    decimal Amount = Convert.ToDecimal(cmd.Parameters["@Amount"].Value.ToString());
                    return new Response(Amount, true);
                }
            }
            catch (Exception ex)
            {
                return new Response(0, false);
            }
        }

        public Response GetTotalSalesAmountCloseCash()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("GetTotalSalesAmountCloseCash", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Direction = ParameterDirection.Output;
                    cmd.Parameters["@Amount"].Precision = 18;
                    cmd.Parameters["@Amount"].Scale = 2;
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    decimal Amount = Convert.ToDecimal(cmd.Parameters["@Amount"].Value.ToString());
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                    return new Response(Amount, true);
                }
            }
            catch (Exception ex)
            {
                return new Response(0, false);
            }
        }

        public Response GetTotalSalesAmount()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("GetTotalSalesAmount", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToShortDateString());
                    cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Direction = ParameterDirection.Output;
                    cmd.Parameters["@Amount"].Precision = 18;
                    cmd.Parameters["@Amount"].Scale = 2;
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    decimal Amount = Convert.ToDecimal(cmd.Parameters["@Amount"].Value.ToString());
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                    return new Response(Amount, true);
                }
            }
            catch (Exception ex)
            {
                return new Response(0, false);
            }
        }

        public Response GetLastOpenRegisterDate()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("GetLastOpenRegisterDate", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Date", SqlDbType.Date).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                    return new Response(Convert.ToDateTime(cmd.Parameters["@Date"].Value.ToString()).ToShortDateString(), true);
                }
            }
            catch (Exception ex)
            {
                return new Response("error.", false);
            }
        }

        public Response InsertExpense(string ExpenseName, decimal ExpenseCost, string EmployeeName, DateTime Date)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("InsertExpense", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ExpenseName", ExpenseName);
                    cmd.Parameters.AddWithValue("@ExpenseCost", ExpenseCost);
                    cmd.Parameters.AddWithValue("@EmployeeID", EmployeeName);
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                    return new Response(Convert.ToBoolean(Status), true);
                }
            }
            catch (Exception ex)
            {
                return new Response("Could not Insert Expense.", false);
            }
        }

        public Response InsertDeduction(int EmployeeID, DateTime Date, decimal Deduction)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("InsertDeduction", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmpID", EmployeeID);
                    cmd.Parameters.AddWithValue("@Date", Date);
                    cmd.Parameters.AddWithValue("@Deduction", Deduction);
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                    return new Response(Convert.ToBoolean(Status), true);
                }
            }
            catch (Exception ex)
            {
                return new Response("Could not Insert Deduction.", false);
            }
        }

        public Response InsertDayOff(int EmployeeID, DateTime Date)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("InsertDayOff", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmpID", EmployeeID);
                    cmd.Parameters.AddWithValue("@Date", Date);
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                    return new Response(Convert.ToBoolean(Status), true);
                }
            }
            catch (Exception ex)
            {
                return new Response("Could not Insert Day Off.", false);
            }
        }

        public Response InsertAbsence(int EmployeeID, DateTime Date, int Hours)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("InsertAbsence", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmpID", EmployeeID);
                    cmd.Parameters.AddWithValue("@Date", Date);
                    cmd.Parameters.AddWithValue("@Hours", Hours);
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                    return new Response(Convert.ToBoolean(Status), true);
                }
            }
            catch (Exception ex)
            {
                return new Response("Could not Insert Absence.", false);
            }
        }

        public Response InsertEmployee(string EmployeeName, decimal Salary, string Phone, string Address)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("InsertEmployee", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmployeeName", EmployeeName);
                    cmd.Parameters.AddWithValue("@Salary", Salary);
                    cmd.Parameters.AddWithValue("@Phone", Phone);
                    cmd.Parameters.AddWithValue("@Address", Address);
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                    return new Response(Convert.ToBoolean(Status), true);
                }
            }
            catch (Exception ex)
            {
                return new Response("Could not Insert Employee.", false);
            }
        }

        public Response InsertItem(Item ItemToInsert)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("InsertItem", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ItemName", ItemToInsert.GetName());
                    cmd.Parameters.AddWithValue("@ItemBarCode", ItemToInsert.GetItemBarCode());
                    cmd.Parameters.AddWithValue("@Quantity", ItemToInsert.GetQuantity());
                    cmd.Parameters.AddWithValue("@BuyPrice", ItemToInsert.GetBuyPrice());
                    cmd.Parameters.AddWithValue("@Price", ItemToInsert.GetPrice());
                    cmd.Parameters.AddWithValue("@PriceTax", ItemToInsert.GetPriceTax());
                    cmd.Parameters.AddWithValue("@ItemTypeID", ItemToInsert.GetItemTypeeID());
                    cmd.Parameters.AddWithValue("@WarehouseID", ItemToInsert.GetWarehouseID());
                    cmd.Parameters.AddWithValue("@Favorite", ItemToInsert.GetFavoriteCategory().ToString());
                    cmd.Parameters.AddWithValue("@Date", ItemToInsert.GetDate());
                    if (ItemToInsert.PictureUpload != null)
                        cmd.Parameters.AddWithValue("@Picture", ItemToInsert.PictureUpload);
                    cmd.Parameters.AddWithValue("WarningQuantity", ItemToInsert.QuantityWarning);
                    cmd.Parameters.AddWithValue("ProductionDate", ItemToInsert.ProductionDate);
                    cmd.Parameters.AddWithValue("ExpirationDate", ItemToInsert.ExpirationDate);
                    cmd.Parameters.AddWithValue("EntryDate", ItemToInsert.EntryDate);
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                    return new Response(Convert.ToBoolean(Status), true);
                }
            }
            catch (Exception ex)
            {
                return new Response("Could not Insert Item.", false);
            }
        }

        public Response DeleteItemType(int ItemTypeID)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DeleteItemType", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ItemTypeID", ItemTypeID);
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                }
                return new Response(Convert.ToBoolean(Status), true);
            }
            catch (Exception ex)
            {
                return new Response("Could not Delete Item Type.", false);
            }
        }

        public Response DeleteWarehouse(int WarehouseID)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DeleteWarehouse", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@WarehouseID", WarehouseID);
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                }
                return new Response(Convert.ToBoolean(Status), true);
            }
            catch (Exception ex)
            {
                return new Response("Could not Delete Warehouse.", false);
            }
        }

        public Response DeleteFavoriteCategory(int FavoriteCategoryID)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DeleteFavoriteCategory", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CategoryID", FavoriteCategoryID);
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                }
                return new Response(Convert.ToBoolean(Status), true);
            }
            catch (Exception ex)
            {
                return new Response("Could not Delete Favorite Category.", false);
            }
        }

        public Response UpdateItemTypes(int ItemTypeID, string ItemTypeName)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UpdateItemType", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ItemTypeID", ItemTypeID);
                    cmd.Parameters.AddWithValue("@ItemTypeName", ItemTypeName);
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                }
                return new Response(Convert.ToBoolean(Status), true);
            }
            catch (Exception ex)
            {
                return new Response("Could not Update Item Types.", false);
            }
        }

        public Response UpdateWarehouses(int WarehouseID, string WarehouseName)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UpdateWarehouse", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@WarehouseID", WarehouseID);
                    cmd.Parameters.AddWithValue("@WarehouseName", WarehouseName);
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                }
                return new Response(Convert.ToBoolean(Status), true);
            }
            catch (Exception ex)
            {
                return new Response("Could not Update Warehouses.", false);
            }
        }

        public Response UpdateFavoriteCategories(int FavoriteCategoryID, string FavoriteCategory)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UpdateFavoriteCategory", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CategoryID", FavoriteCategoryID);
                    cmd.Parameters.AddWithValue("@CategoryName", FavoriteCategory);
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                }
                return new Response(Convert.ToBoolean(Status), true);
            }
            catch (Exception ex)
            {
                return new Response("Could not Update Favorite Categories.", false);
            }
        }

        public Response UpdatePrinters(int printerID, string printerName)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UpdatePrinter", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PrinterID", printerID);
                    cmd.Parameters.AddWithValue("@PrinterName", printerName);
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                }
                return new Response(Convert.ToBoolean(Status), true);
            }
            catch (Exception ex)
            {
                return new Response("Could not Update Printers.", false);
            }
        }

        public Response InsertItemType(string ItemTypeName)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("InsertItemType", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ItemTypeName", ItemTypeName);
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                }
                return new Response(Convert.ToBoolean(Status), true);
            }
            catch (Exception ex)
            {
                return new Response("Could not Insert Item Type.", false);
            }
        }

        public Response InsertWarehouse(string WarehouseName)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("InsertWarehouse", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@WarehouseName", WarehouseName);
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                }
                return new Response(Convert.ToBoolean(Status), true);
            }
            catch (Exception ex)
            {
                return new Response("Could not Insert Warehouse.", false);
            }
        }

        public Response InsertFavoriteCategory(string FavoriteCategory)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("InsertFavoriteCategory", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CategoryName", FavoriteCategory);
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                }
                return new Response(Convert.ToBoolean(Status), true);
            }
            catch (Exception ex)
            {
                return new Response("Could not Insert Favoriote Category.", false);
            }
        }

        public Response InsertPrinter(string machineName, string printerName)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("InsertPrinter", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MachineName", machineName);
                    cmd.Parameters.AddWithValue("@PrinterName", printerName);
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                }
                return new Response(Convert.ToBoolean(Status), true);
            }
            catch (Exception ex)
            {
                return new Response("Could not Insert Printer.", false);
            }
        }

        public Response DeleteClient(string ClientID)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DeleteClient", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.AddWithValue("@ClientID", ClientID);
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                    return new Response(Convert.ToBoolean(Status), true);
                }
            }
            catch (Exception ex)
            {
                return new Response("Could not Delete Client.", false);
            }
        }

        public Response RegisterClient(Client ClientToInsert)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("RegisterClient", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ClientName", ClientToInsert.ClientName.ToString());
                    cmd.Parameters.AddWithValue("@ClientPhone", ClientToInsert.ClientPhone.ToString());
                    cmd.Parameters.AddWithValue("@ClientAddress", ClientToInsert.ClientAddress.ToString());
                    cmd.Parameters.AddWithValue("@ClientEmail", ClientToInsert.ClientEmail.ToString());
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                    return new Response(Convert.ToBoolean(Status), true);
                }
            }
            catch (Exception ex)
            {
                return new Response("Could not Register Client.", false);
            }
        }

        public Response RegisterVendor(Client ClientToInsert)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("RegisterVendor", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ClientName", ClientToInsert.ClientName.ToString());
                    //cmd.Parameters.AddWithValue("@ClientID", ClientToInsert.ClientID.ToString());
                    cmd.Parameters.AddWithValue("@ClientPhone", ClientToInsert.ClientPhone.ToString());
                    cmd.Parameters.AddWithValue("@ClientAddress", ClientToInsert.ClientAddress.ToString());
                    cmd.Parameters.AddWithValue("@ClientEmail", ClientToInsert.ClientEmail.ToString());
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                    return new Response(Convert.ToBoolean(Status), true);
                }
            }
            catch (Exception ex)
            {
                return new Response("Could not Register Vendor.", false);
            }
        }

        public Response DeleteAbsence(int AbsenceID)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DeleteAbsence", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AbsenceID", AbsenceID);
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                    return new Response(Convert.ToBoolean(Status), true);
                }
            }
            catch (Exception ex)
            {
                return new Response("Could not Delete Absence.", false);
            }
        }      

        public Response DeleteDeduction(int DeductionID)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DeleteDeduction", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DeductionID", DeductionID);
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                    return new Response(Convert.ToBoolean(Status), true);
                }
            }
            catch (Exception ex)
            {
                return new Response("Could not Delete Deduction.", false);
            }
        }

        public Response DeleteEmployee(int EmployeeID)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DeleteEmployee", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                    return new Response(Convert.ToBoolean(Status), true);
                }
            }
            catch (Exception ex)
            {
                return new Response("Could not Delete Employee.", false);
            }
        }

        public Response DeleteUser(Account UserToUpdate, string cashierName)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DeleteUser", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", UserToUpdate.GetAccountUID());
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                    return new Response(Convert.ToBoolean(Status), true);
                }
            }
            catch (Exception ex)
            {
                return new Response("Could not Delete User.", false);
            }
        }

        public Response AddSaleOnItems(List<Item> saleItems)
        {
            try
            {
                foreach (Item saleItem in saleItems)
                {
                    using (SqlCommand cmd = new SqlCommand("AddSaleOnItem", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ItemBarCode", saleItem.ItemBarCode);
                        cmd.Parameters.AddWithValue("@SaleRate", saleItem.saleRate);
                        cmd.Parameters.AddWithValue("@StartDate", saleItem.DateStart);
                        cmd.Parameters.AddWithValue("@EndDate", saleItem.DateEnd);
                        cmd.Parameters.AddWithValue("@QuantityEnd", saleItem.QuantityEnd);
                        cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                        if (connection != null && connection.State == ConnectionState.Closed)
                            connection.Open();
                        cmd.ExecuteNonQuery();
                        Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                        connection.Close();

                    }
                }
                return new Response(Convert.ToBoolean(Status), true);
            }
            catch (Exception ex)
            {
                return new Response("Could not Add Sale on Item.", false);
            }
        }

        public Response AddItemToClient(string ItemBarCode, int ClientID, decimal ClientPrice)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("AddItemToClient", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ClientID", ClientID);
                    cmd.Parameters.AddWithValue("@ItemBarCode", ItemBarCode);
                    cmd.Parameters.AddWithValue("@ItemPrice", ClientPrice);
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();

                    return new Response(Convert.ToBoolean(Status), true);
                }
            }
            catch (Exception ex)
            {
                return new Response("Could not Add Item to Client.", false);
            }
        }

        public Response AddVendorBill(Bill billToAdd, string cashierName)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("AddVendorBill", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@cashierName", cashierName);
                    cmd.Parameters.AddWithValue("@totalAmount", billToAdd.getTotalAmount());
                    cmd.Parameters.AddWithValue("@Date", billToAdd.getDate());
                    cmd.Parameters.AddWithValue("@IsVendor", Convert.ToInt32(billToAdd.IsVendor));
                    cmd.Parameters.AddWithValue("@vendorID", Convert.ToInt32(billToAdd.ClientID));
                    cmd.Parameters.Add("@BillID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    int BillID = Convert.ToInt32(cmd.Parameters["@BillID"].Value);
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();

                    foreach (Item itemToAdd in billToAdd.ItemsBought)
                    {
                        using (SqlCommand cmd2 = new SqlCommand("AddItemToVendorBill", connection))
                        {
                            cmd2.CommandType = CommandType.StoredProcedure;

                            cmd2.Parameters.AddWithValue("@BillID", BillID);
                            cmd2.Parameters.AddWithValue("@ItemBarCode", itemToAdd.GetItemBarCode());
                            cmd2.Parameters.AddWithValue("@ItemQuantity", itemToAdd.GetQuantity());
                            cmd2.Parameters.AddWithValue("@ItemBuyPrice", itemToAdd.ItemBuyPrice);

                            if (connection != null && connection.State == ConnectionState.Closed)
                                connection.Open();
                            cmd2.ExecuteNonQuery();
                            connection.Close();
                        }
                    }

                    return new Response(BillID, true);
                }
            }
            catch (Exception ex)
            {
                return new Response("Could not Add Vendor Bill.", false);
            }
        }

        public Response AddUnpaidBill(Bill billToAdd, string cashierName)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("AddUnpaidBill", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@cashierName", cashierName);
                    cmd.Parameters.AddWithValue("@totalAmount", billToAdd.getTotalAmount());
                    cmd.Parameters.AddWithValue("@Date", billToAdd.getDate());
                    cmd.Parameters.AddWithValue("@ClientID", billToAdd.ClientID);
                    cmd.Parameters.Add("@BillID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    int BillID = Convert.ToInt32(cmd.Parameters["@BillID"].Value);
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();

                    foreach (Item itemToAdd in billToAdd.ItemsBought)
                    {
                        using (SqlCommand cmd2 = new SqlCommand("AddItemToBill", connection))
                        {
                            cmd2.CommandType = CommandType.StoredProcedure;

                            cmd2.Parameters.AddWithValue("@BillID", BillID);
                            cmd2.Parameters.AddWithValue("@ItemBarCode", itemToAdd.GetItemBarCode());
                            cmd2.Parameters.AddWithValue("@ItemQuantity", itemToAdd.GetQuantity());

                            if (connection != null && connection.State == ConnectionState.Closed)
                                connection.Open();
                            cmd2.ExecuteNonQuery();
                            connection.Close();
                        }
                    }

                    return new Response(BillID, false);
                }
            }
            catch (Exception ex)
            {
                return new Response("Could not Add Unpaid Bill.", false);
            }
        }

        public Response PayUnpaidBill(int BillNumber, decimal paidAmount)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("PayUnpaidBill", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BillID", BillNumber);
                    cmd.Parameters.AddWithValue("@paidInstallmentAmount", paidAmount);
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();

                    return new Response(Convert.ToBoolean(Status), true);
                }
            }
            catch (Exception ex)
            {
                return new Response("Could not Pay Unpaid Bill.", false);
            }
        }

        public Response PayBill(Bill billToAdd, string cashierName)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("PayBill", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@cashierName", cashierName);
                    cmd.Parameters.AddWithValue("@totalAmount", billToAdd.getTotalAmount());
                    cmd.Parameters.AddWithValue("@paidAmount", billToAdd.getPaidAmount());
                    cmd.Parameters.AddWithValue("@remainderAmount", billToAdd.getRemainderAmount());
                    cmd.Parameters.AddWithValue("@paymentByCash", Convert.ToInt32(billToAdd.PayByCash));
                    cmd.Parameters.AddWithValue("@Date", billToAdd.getDate());
                    cmd.Parameters.AddWithValue("@ClientID", billToAdd.ClientID);
                    cmd.Parameters.Add("@BillID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    int BillID = Convert.ToInt32(cmd.Parameters["@BillID"].Value);
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                    
                    foreach(Item itemToAdd in billToAdd.ItemsBought)
                    {
                        using (SqlCommand cmd2 = new SqlCommand("AddItemToBill", connection))
                        {
                            cmd2.CommandType = CommandType.StoredProcedure;

                            cmd2.Parameters.AddWithValue("@BillID", BillID);
                            cmd2.Parameters.AddWithValue("@ItemBarCode", itemToAdd.GetItemBarCode());
                            cmd2.Parameters.AddWithValue("@ItemQuantity", itemToAdd.GetQuantity());

                            if (connection != null && connection.State == ConnectionState.Closed)
                                connection.Open();
                            cmd2.ExecuteNonQuery();
                            connection.Close();
                        }
                    }

                    return new Response(Convert.ToBoolean(Status), true);
                }
            }
            catch (Exception ex)
            {
                return new Response("Could not Pay Bill.", false);
            }
        }

        public Response UpdateEmployee(int EmployeeID, string EmployeeName, decimal Salary, string Phone, string Address)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UpdateEmployee", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                    cmd.Parameters.AddWithValue("@EmployeeName", EmployeeName);
                    cmd.Parameters.AddWithValue("@Salary", Salary);
                    cmd.Parameters.AddWithValue("@Phone", Phone);
                    cmd.Parameters.AddWithValue("@Address", Address);
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                    return new Response(Convert.ToBoolean(Status), true);
                }
            }
            catch (Exception ex)
            {
                return new Response("Could not Update Employee.", false);
            }
        }    

        public Response UpdateAbsence(int AbsenceID, int Hours)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UpdateAbsence", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AbsenceID", AbsenceID);
                    cmd.Parameters.AddWithValue("@Hours", Hours);
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                    return new Response(Convert.ToBoolean(Status), true);
                }
            }
            catch (Exception ex)
            {
                return new Response("Could not Update Absence.", false);
            }
        }   

        public Response UpdateDeduction(int DeductionID, decimal DeductionAmount)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UpdateDeduction", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DeductionID", DeductionID);
                    cmd.Parameters.AddWithValue("@DeductionAmount", DeductionAmount);
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                    return new Response(Convert.ToBoolean(Status), true);
                }
            }
            catch (Exception ex)
            {
                return new Response("Could not Update Absence.", false);
            }
        }

        public Response UpdateUser(Account UserToUpdate, string cashierName, int AdminOrNot)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UpdateUser", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserName", UserToUpdate.GetAccountName());
                    cmd.Parameters.AddWithValue("@UserID", UserToUpdate.GetAccountUID());
                    if (UserToUpdate.GetAccountPWD() != null)
                        cmd.Parameters.AddWithValue("@UserPWD", MD5Encryption.Encrypt(UserToUpdate.GetAccountPWD().ToString(), "PlancksoftPOS"));
                    cmd.Parameters.AddWithValue("@ClientCardEditPerm", Convert.ToInt32(Convert.ToBoolean(UserToUpdate.Client_card_edit.ToString())));
                    cmd.Parameters.AddWithValue("@discountEditPerm", Convert.ToInt32(Convert.ToBoolean(UserToUpdate.discount_edit.ToString())));
                    cmd.Parameters.AddWithValue("@priceEditPerm", Convert.ToInt32(Convert.ToBoolean(UserToUpdate.price_edit.ToString())));
                    cmd.Parameters.AddWithValue("@receiptEditPerm", Convert.ToInt32(Convert.ToBoolean(UserToUpdate.receipt_edit.ToString())));
                    cmd.Parameters.AddWithValue("@inventoryEditPerm", Convert.ToInt32(Convert.ToBoolean(UserToUpdate.inventory_edit.ToString())));
                    cmd.Parameters.AddWithValue("@expensesEditPerm", Convert.ToInt32(Convert.ToBoolean(UserToUpdate.expenses_add.ToString())));
                    cmd.Parameters.AddWithValue("@usersEditPerm", Convert.ToInt32(Convert.ToBoolean(UserToUpdate.users_edit.ToString())));
                    cmd.Parameters.AddWithValue("@settingsEditPerm", Convert.ToInt32(Convert.ToBoolean(UserToUpdate.settings_edit.ToString())));
                    cmd.Parameters.AddWithValue("@personnelEditPerm", Convert.ToInt32(Convert.ToBoolean(UserToUpdate.personnel_edit.ToString())));
                    cmd.Parameters.AddWithValue("@opencloseEditPerm", Convert.ToInt32(Convert.ToBoolean(UserToUpdate.openclose_edit.ToString())));
                    cmd.Parameters.AddWithValue("@sellEditPerm", Convert.ToInt32(Convert.ToBoolean(UserToUpdate.sell_edit.ToString())));
                    cmd.Parameters.AddWithValue("@UserAuthority", AdminOrNot);
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                    return new Response(Convert.ToBoolean(Status), true);
                }
            }
            catch (Exception ex)
            {
                return new Response("Could not Update User.", false);
            }
        }

        public Response UpdateBill(int BillNumber, string CashierName, decimal TotalAmount, decimal PaidAmount, decimal RemainderAmount)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UpdateBill", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BillNumber", BillNumber);
                    cmd.Parameters.AddWithValue("@CashierName", CashierName);
                    cmd.Parameters.AddWithValue("@TotalAmount", TotalAmount);
                    cmd.Parameters.AddWithValue("@PaidAmount", PaidAmount);
                    cmd.Parameters.AddWithValue("@RemainderAmount", RemainderAmount);

                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                    return new Response(Convert.ToBoolean(Status), true);
                }
            }
            catch (Exception ex)
            {
                return new Response("Could not Update Bill.", false);
            }
        }

        public Response ReturnItem(string ItemName, string ItemBarCode, int ItemQuantity, string cashierName, int BillID)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("ReturnItem", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ItemName", ItemName);
                    cmd.Parameters.AddWithValue("@ItemBarCode", ItemBarCode);
                    cmd.Parameters.AddWithValue("@ItemQuantity", ItemQuantity);
                    cmd.Parameters.AddWithValue("@cashierName", cashierName);
                    cmd.Parameters.AddWithValue("@BillID", BillID);
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                }
                return new Response(Convert.ToBoolean(Status), true);
            }
            catch (Exception ex)
            {
                return new Response("Could not Return Item.", false);
            }
        }

        public Response UpdateItemWarehouse(List<Item> ItemsToUpdate, string EmployeeName, int EntryExitType)
        {
            try
            {
                int TransactionID = 0;
                decimal Cost = 0;

                foreach (Item ItemToUpdate in ItemsToUpdate)
                {
                    Cost += Convert.ToDecimal(ItemToUpdate.GetQuantity() * ItemToUpdate.GetBuyPrice());

                }

                    using (SqlCommand cmd = new SqlCommand("CreateTransaction", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.AddWithValue("@EntryExitType", EntryExitType);
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@cashierName", EmployeeName);
                    cmd.Parameters.AddWithValue("@cost", Cost);
                    cmd.Parameters.Add("@TransactionID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    TransactionID = Convert.ToInt32(cmd.Parameters["@TransactionID"].Value);
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                }

                foreach (Item ItemToUpdate in ItemsToUpdate) {

                    using (SqlCommand cmd = new SqlCommand("UpdateItemWarehouse", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ItemName", ItemToUpdate.GetName());
                        cmd.Parameters.AddWithValue("@ItemBarCode", ItemToUpdate.GetItemBarCode());
                        cmd.Parameters.AddWithValue("@ItemQuantity", ItemToUpdate.GetQuantity());
                        cmd.Parameters.AddWithValue("@ItemBuyPrice", ItemToUpdate.GetBuyPrice());
                        cmd.Parameters.AddWithValue("@EntryExitType", EntryExitType);
                        cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                        cmd.Parameters.AddWithValue("@TransactionID", TransactionID);
                        cmd.Parameters.AddWithValue("@WarehouseID", ItemToUpdate.GetWarehouseID().ToString());
                        cmd.Parameters.AddWithValue("@WarningQuantity", ItemToUpdate.QuantityWarning);
                        cmd.Parameters.AddWithValue("@ProductionDate", ItemToUpdate.ProductionDate);
                        cmd.Parameters.AddWithValue("@ExpirationDate", ItemToUpdate.ExpirationDate);
                        cmd.Parameters.AddWithValue("@EntryDate", ItemToUpdate.EntryDate);
                        cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                        if (connection != null && connection.State == ConnectionState.Closed)
                            connection.Open();
                        cmd.ExecuteNonQuery();
                        Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                        connection.Close();
                    }
                }
                return new Response(Convert.ToBoolean(Status), true);
            }
            catch (Exception ex)
            {
                return new Response("Could not Update Item Warehouse.", false);
            }
        }

        public Response UpdateItem(Item ItemToUpdate)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UpdateItem", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ItemName", ItemToUpdate.GetName());
                    cmd.Parameters.AddWithValue("@ItemBarCode", ItemToUpdate.GetItemBarCode());
                    cmd.Parameters.AddWithValue("@ItemNewBarCode", ItemToUpdate.ItemNewBarCode);
                    cmd.Parameters.AddWithValue("@ItemQuantity", ItemToUpdate.GetQuantity().ToString());
                    cmd.Parameters.AddWithValue("@ItemBuyPrice", ItemToUpdate.GetBuyPrice());
                    cmd.Parameters.AddWithValue("@ItemPrice", ItemToUpdate.GetPrice().ToString());
                    cmd.Parameters.AddWithValue("@ItemPriceTax", ItemToUpdate.GetPriceTax().ToString());
                    cmd.Parameters.AddWithValue("@WarehouseID", ItemToUpdate.GetWarehouseID().ToString());
                    cmd.Parameters.AddWithValue("@ItemTypeID", ItemToUpdate.GetItemTypeeID().ToString());
                    cmd.Parameters.AddWithValue("@Favorite", ItemToUpdate.GetFavoriteCategory().ToString());
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                    if (ItemToUpdate.PictureUpload != null)
                        cmd.Parameters.AddWithValue("@Picture", ItemToUpdate.PictureUpload);
                    cmd.Parameters.AddWithValue("WarningQuantity", ItemToUpdate.QuantityWarning);
                    cmd.Parameters.AddWithValue("ProductionDate", ItemToUpdate.ProductionDate);
                    cmd.Parameters.AddWithValue("ExpirationDate", ItemToUpdate.ExpirationDate);
                    cmd.Parameters.AddWithValue("EntryDate", ItemToUpdate.EntryDate);
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                    return new Response(Convert.ToBoolean(Status), true);
                }
            }
            catch (Exception ex)
            {
                return new Response("Could not Update Item.", false);
            }
        }

        public Response UpdateItemQuantity(Item ItemToUpdate)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UpdateItemQuantity", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.AddWithValue("@ItemBarCode", ItemToUpdate.GetItemBarCode());
                    cmd.Parameters.AddWithValue("@ItemQuantity", ItemToUpdate.GetQuantity().ToString());
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                    return new Response(Convert.ToBoolean(Status), true);
                }
            }
            catch (Exception ex)
            {
                return new Response("Could not Update Item Quantity.", false);
            }
        }

        public Response DeleteItem(string ItemBarCode)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DeleteItem", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ItemBarCode", ItemBarCode);
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                    return new Response(Convert.ToBoolean(Status), true);
                }
            }
            catch (Exception ex)
            {
                return new Response("Could not Delete Item.", false);
            }
        }

        public Response RetrieveLastVendorBillNumberToday(DateTime Date)
        {
            try
            {
                Bill Bill = new Bill();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveLastVendorBillNumberToday", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (Date != null)
                {
                    cmd.Parameters.AddWithValue("@Date1", Date);
                    cmd.Parameters.AddWithValue("@Date2", Date);
                }
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                
                foreach (DataRow Item in dt.Rows)
                {
                    Bill.SetBillNumber(Convert.ToInt32(Item["Bill Number"].ToString()));
                }
                return new Response(Bill, true);
            }
            catch (Exception ex)
            {
                Bill Bill = new Bill();
                return new Response("Could not Retrieve Last Vendor Bill Number Today.", false);
            }
        }

        public Response RetrieveBillsCountByDate(DateTime StartDate, DateTime EndDate)
        {
            try
            {
                int BillsCount = 0;
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveBillsCountByDate", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (StartDate != null)
                {
                    cmd.Parameters.AddWithValue("@StartDate", StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", EndDate);
                }

                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                
                foreach (DataRow Item in dt.Rows)
                {
                    BillsCount = (Convert.ToInt32(Item["Bills Count"].ToString()));
                }
                return new Response(BillsCount, true);
            }
            catch (Exception ex)
            {
                return new Response("Could not Retrieve Last Bill Number Today.", false);
            }
        }  

        public Response RetrieveLastBillNumberToday()
        {
            try
            {
                Bill Bill = new Bill();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveLastBillNumber", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                
                foreach (DataRow Item in dt.Rows)
                {
                    Bill.SetBillNumber(Convert.ToInt32(Item["Bill Number"].ToString()));
                }
                return new Response(Bill, true);
            }
            catch (Exception ex)
            {
                Bill Bill = new Bill();
                return new Response("Could not Retrieve Last Bill Number Today.", false);
            }
        }

        public Response RetrieveItemsQuantity(string ItemBarCode = "")
        {
            try
            {
                List<Item> expireItems = new List<Item>();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveItemsQuantity", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (ItemBarCode != "")
                    cmd.Parameters.AddWithValue("@ItemBarCode", ItemBarCode);
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                
                foreach (DataRow Item in dt.Rows)
                {
                    Item itemexpire = new Item();
                    itemexpire.SetBarCode(Item["Item BarCode"].ToString());
                    itemexpire.ItemQuantity = Convert.ToInt32(Item["Item Quantity"].ToString());
                    expireItems.Add(itemexpire);
                }
                return new Response(expireItems, true);
            }
            catch (Exception ex)
            {
                List<Item> saleItems = new List<Item>();
                return new Response("Could not Retrieve Items Quantity.", false);
            }
        }

        public Response RetrieveSaleItemsQuantity()
        {
            try
            {
                List<Item> saleItems = new List<Item>();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveSaleItemsQuantity", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                
                foreach (DataRow Item in dt.Rows)
                {
                    Item itemsale = new Item();
                    itemsale.SetBarCode(Item["Item BarCode"].ToString());
                    itemsale.QuantityEnd = Convert.ToInt32(Item["Quantity End"].ToString());
                    saleItems.Add(itemsale);
                }
                return new Response(saleItems, true);
            }
            catch (Exception ex)
            {
                List<Item> saleItems = new List<Item>();
                return new Response("Could not Retrieve Sale Items Quantity.", false);
            }
        }

        public Response RetrieveTotalActiveItems(DateTime ExpirationDate)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveTotalActiveItems", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@ExpireDate", ExpirationDate);

                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "TotalActiveItems";
                return new Response(SerializeDataTableToJSON(dt), true);
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                dt.TableName = "TotalActiveItems";
                return new Response("Could not Retrieve Total Active Items Count.", false);
            }
        }   

        public Response RetrieveClientCount()
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveClientCount", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "ClientCount";
                return new Response(SerializeDataTableToJSON(dt), true);
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                dt.TableName = "ClientCount";
                return new Response("Could not Retrieve Client Count.", false);
            }
        }  

        public Response RetrieveExpireStockToday(DateTime Date)
        {
            try
            {
                List<Item> expireItems = new List<Item>();
                List<Item> quantity_items = (List<Item>)RetrieveItemsQuantity().ResponseMessage;

                foreach (Item expire_item in quantity_items)
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    SqlCommand cmd = new SqlCommand("RetrieveExpireStockToday", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    if (Date != null)
                    {
                        cmd.Parameters.AddWithValue("@Date1", Date);
                        cmd.Parameters.AddWithValue("@Date2", Date);
                    }

                    cmd.Parameters.AddWithValue("@ItemBarCode", expire_item.ItemBarCode);
                    cmd.Parameters.AddWithValue("@CurrentQuantity", expire_item.ItemQuantity);

                    adapter.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dt.TableName = "ExpireStockToday";
                    foreach (DataRow Item in dt.Rows)
                    {
                        Item itemexpire = new Item();
                        itemexpire.SetBarCode(Item["Item BarCode"].ToString());
                        itemexpire.SetName(Item["Item Name"].ToString());
                        itemexpire.DateStart = Convert.ToDateTime(Item["Start Date"].ToString());
                        itemexpire.DateEnd = Convert.ToDateTime(Item["End Date"].ToString());
                        itemexpire.QuantityEnd = Convert.ToInt32(Item["Quantity End"].ToString());
                        itemexpire.SetQuantity(Convert.ToInt32(Item["Current Quantity"].ToString()));
                        expireItems.Add(itemexpire);
                    }
                    return new Response(Tuple.Create(expireItems, SerializeDataTableToJSON(dt)), true);
                }
                return new Response(Tuple.Create(expireItems, SerializeDataTableToJSON(new DataTable())), true);
            }
            catch (Exception ex)
            {
                List<Item> expireItems = new List<Item>();
                DataTable dt = new DataTable();
                dt.TableName = "ExpireStockToday";
                return new Response("Could not Retrieve Expiring Stock Today.", false);
            }
        }

        public Response RetrieveSaleDateRange(DateTime StartDate, DateTime EndDate, int QuantityEnd = 0)
        {
            try
            {
                List<Item> saleItems = new List<Item>();
                List<Item> quantity_items = (List<Item>)RetrieveSaleItemsQuantity().ResponseMessage;

                foreach (Item sale_item in quantity_items)
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    SqlCommand cmd = new SqlCommand("RetrieveSaleDateRange", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    if (StartDate != null)
                    {
                        cmd.Parameters.AddWithValue("@StartDate", StartDate);
                        cmd.Parameters.AddWithValue("@EndDate", EndDate);
                    }

                    cmd.Parameters.AddWithValue("@QuantityEnd", sale_item.QuantityEnd);

                    adapter.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dt.TableName = "SaleDateRange";
                    foreach (DataRow Item in dt.Rows)
                    {
                        Item itemsale = new Item();
                        itemsale.SetBarCode(Item["Item BarCode"].ToString());
                        itemsale.SetSaleRate(Convert.ToInt32(Item["Sale Rate"].ToString()));
                        itemsale.DateStart = Convert.ToDateTime(Item["Start Date"].ToString());
                        itemsale.DateEnd = Convert.ToDateTime(Item["End Date"].ToString());
                        itemsale.QuantityEnd = Convert.ToInt32(Item["Quantity End"].ToString());
                        saleItems.Add(itemsale);
                    }
                }
                return new Response(saleItems, true);
            }
            catch (Exception ex)
            {
                List<Item> saleItems = new List<Item>();
                return new Response("Could not Retrieve Sale using Date Range.", false);
            }
        }  

        public Response RetrieveSaleToday(DateTime Date, int QuantityEnd = 0)
        {
            try
            {
                List<Item> saleItems = new List<Item>();
                List<Item> quantity_items = (List<Item>)RetrieveSaleItemsQuantity().ResponseMessage;

                foreach (Item sale_item in quantity_items)
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    SqlCommand cmd = new SqlCommand("RetrieveSale", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    if (Date != null)
                    {
                        cmd.Parameters.AddWithValue("@Date1", Date);
                        cmd.Parameters.AddWithValue("@Date2", Date);
                    }

                    cmd.Parameters.AddWithValue("@QuantityEnd", sale_item.QuantityEnd);

                    adapter.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dt.TableName = "SaleToday";
                    foreach (DataRow Item in dt.Rows)
                    {
                        Item itemsale = new Item();
                        itemsale.SetBarCode(Item["Item BarCode"].ToString());
                        itemsale.SetSaleRate(Convert.ToInt32(Item["Sale Rate"].ToString()));
                        itemsale.DateStart = Convert.ToDateTime(Item["Start Date"].ToString());
                        itemsale.DateEnd = Convert.ToDateTime(Item["End Date"].ToString());
                        itemsale.QuantityEnd = Convert.ToInt32(Item["Quantity End"].ToString());
                        saleItems.Add(itemsale);
                    }
                }
                return new Response(saleItems, true);
            }
            catch (Exception ex)
            {
                List<Item> saleItems = new List<Item>();
                return new Response("Could not Retrieve Sale Today.", false);
            }
        }

        public Response SearchTodayBills(DateTime Date)
        {
            try
            {
                List<Bill> Bills = new List<Bill>();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("SearchTodayBills", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (Date != null)
                {
                    cmd.Parameters.AddWithValue("@Date1", Date);
                    cmd.Parameters.AddWithValue("@Date2", Date);
                }
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "TodayBills";
                foreach (DataRow Item in dt.Rows)
                {
                    Bill bill = new Bill();
                    bill.SetBillNumber(Convert.ToInt32(Item["Bill Number"].ToString()));
                    bill.SetCashierName(Item["Cashier Name"].ToString());
                    bill.SetTotalAmount(Convert.ToDecimal(Item["Total Amount"].ToString()));
                    bill.SetPaidAmount(Convert.ToDecimal(Item["Paid Amount"].ToString()));
                    bill.SetRemainderAmount(Convert.ToDecimal(Item["Remainder Amount"].ToString()));
                    bill.SetDate(Convert.ToDateTime(Item["Date"].ToString()));
                    Bills.Add(bill);
                }
                return new Response(Tuple.Create(Bills, SerializeDataTableToJSON(dt)), true);
            }
            catch (Exception ex)
            {
                List<Bill> Bills = new List<Bill>();
                DataTable dt = new DataTable();
                dt.TableName = "TodayBills";
                return new Response("Could not Search Today Bills.", false);
            }
        }

        public Response SearchBills(string dateFrom, string dateTo, int BillNumber = 0)
        {
            try
            {
                List<Bill> Bills = new List<Bill>();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("SearchBills", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (BillNumber != 0)
                    cmd.Parameters.AddWithValue("@BillNumber", BillNumber);
                if (dateFrom != "")
                    cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                if (dateTo != "")
                    cmd.Parameters.AddWithValue("@DateTo", dateTo);
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dt.TableName = "Bills";
                foreach (DataRow Bill in dt.Rows)
                {
                    Bill newBill = new Bill();
                    newBill.SetBillNumber(Convert.ToInt32(Bill["Bill Number"].ToString()));
                    newBill.SetCashierName(Bill["Cashier Name"].ToString());
                    newBill.SetTotalAmount(Convert.ToDecimal(Bill["Total Amount"].ToString()));
                    newBill.SetPaidAmount(Convert.ToDecimal(Bill["Paid Amount"].ToString()));
                    newBill.SetRemainderAmount(Convert.ToDecimal(Bill["Remainder Amount"].ToString()));
                    newBill.SetDate(Convert.ToDateTime(Bill["Invoice Date"].ToString()));
                    newBill.ClientName = Bill["Client Name"].ToString();
                    newBill.ClientPhone = Bill["Client Phone"].ToString();
                    newBill.ClientAddress = Bill["Client Address"].ToString();
                    newBill.SetPayByCash(Convert.ToBoolean(Convert.ToInt32(Bill["PayByCash"].ToString())));
                    Bills.Add(newBill);
                }
                return new Response(Tuple.Create(Bills, SerializeDataTableToJSON(dt)), true);
            }
            catch (Exception ex)
            {
                List<Bill> Bills = new List<Bill>();
                DataTable dt = new DataTable();
                dt.TableName = "Bills";
                return new Response("Could not Search Bills.", false);
            }
        }

        public Response GetItemQuantity(string ItemBarCode = "")
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("SearchItemsQuantity", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (ItemBarCode != "")
                    cmd.Parameters.AddWithValue("@ItemBarCode", ItemBarCode);
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "ItemBarCode";
                int Quantity = 0;
                foreach (DataRow Item in dt.Rows)
                {
                    Quantity = Convert.ToInt32(Item["Item Quantity"].ToString());
                }
                return new Response(Quantity, true);
            }
            catch (Exception ex)
            {
                return new Response(0, false);
            }
        }

        public Response RetrieveAbsence(DateTime Date1, DateTime Date2)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveAbsence", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                
                cmd.Parameters.AddWithValue("@Date1", Date1);
                cmd.Parameters.AddWithValue("@Date2", Date2);

                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "Absence";
                return new Response(SerializeDataTableToJSON(dt), true);
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                dt.TableName = "Absence";
                return new Response("Could not Retrieve Absence.", false);
            }
        }

        public Response SearchExpenses(string Date1, string Date2, string ExpenseName = "", string EmployeeID = "")
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("SearchExpenses", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (ExpenseName != "")
                    cmd.Parameters.AddWithValue("@ExpenseName", ExpenseName);
                if (EmployeeID != "")
                    cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                cmd.Parameters.AddWithValue("@Date1", Date1);
                cmd.Parameters.AddWithValue("@Date2", Date2);

                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "Expenses";
                return new Response(SerializeDataTableToJSON(dt), true);
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                dt.TableName = "Expenses";
                return new Response("Could not Search Expenses.", false);
            }
        }

        public Response SearchItems(string ItemName = "", string ItemBarCode = "", int ItemType = 0)
        {
            try
            {
                List<Item> Items = new List<Item>();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("SearchItems", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (ItemName != "")
                    cmd.Parameters.AddWithValue("@ItemName", ItemName);
                if (ItemBarCode != "")
                    cmd.Parameters.AddWithValue("@ItemBarCode", ItemBarCode);
                if (ItemType != 0)
                    cmd.Parameters.AddWithValue("@ItemType", ItemType);
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "Items";

                foreach (DataRow Item in dt.Rows)
                {
                    Item item = new Item();
                    item.SetName(Item["Item Name"].ToString());
                    item.SetBarCode(Item["Item BarCode"].ToString());
                    item.SetQuantity(Convert.ToInt32(Item["Item Quantity"].ToString()));
                    item.SetBuyPrice(Convert.ToDecimal(Item["Item Buy Price"].ToString()));
                    item.SetPrice(Convert.ToDecimal(Item["Item Price"].ToString()));
                    item.SetPriceTax(Convert.ToDecimal(Item["Item Price Tax"].ToString()));
                    item.SetFavoriteCategory(Convert.ToInt32(Item["Favorite Category Number"].ToString()));
                    item.SetFavoriteCategoryName(Item["Favorite Category"].ToString());
                    item.SetWarehouseID(Convert.ToInt32(Item["Warehouse ID"].ToString()));
                    item.SetWarehouseName(Item["InventoryItemWarehouse"].ToString());
                    item.SetItemTypeID(Convert.ToInt32(Item["Item Type"].ToString()));
                    item.SetItemTypeName(Item["InventoryItemType"].ToString());
                    Items.Add(item);
                }
                return new Response(Tuple.Create(SerializeDataTableToJSON(dt), Items), true);
            }
            catch (Exception ex)
            {
                List<Item> Items = new List<Item>();
                DataTable dt = new DataTable();
                dt.TableName = "Items";
                return new Response("Could not Search Items.", false);
            }
        }

        public Response SearchClients(string ClientName = "", string ClientID = "", string itemName = "")
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("SearchClients", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (ClientName != "")
                    cmd.Parameters.AddWithValue("@ClientName", ClientName);
                if (ClientID != "")
                    cmd.Parameters.AddWithValue("@ClientID", ClientID);
                if (itemName != "")
                    cmd.Parameters.AddWithValue("@itemName", itemName);
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "Clients";
                return new Response(SerializeDataTableToJSON(dt), true);
            }
            catch (Exception ex)
            {
                Item[] Items = new Item[0];
                DataTable dt = new DataTable();
                return new Response("Could not Search Clients.", false);
            }
        }

        public Response SearchClientsInfo(string ClientName = "", string ClientID = "")
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("SearchClientsInfo", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (ClientName != "")
                    cmd.Parameters.AddWithValue("@ClientName", ClientName);
                if (ClientID != "")
                    cmd.Parameters.AddWithValue("@ClientID", ClientID);
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "ClientsInfo";

                return new Response(SerializeDataTableToJSON(dt), true);
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                dt.TableName = "ClientsInfo";
                return new Response("Could not Search Clients Information.", false);
            }
        }
    }
}