using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using Dependencies;

namespace DataAccessLayer
{
    public class DataAccessLayer
    {
        public static string ComputerName = "(local)";
        public static string DBName = "PlancksoftPOS";
        public static string DBUID = "PlancksoftPOS";
        public static string DBPWD = "PlancksoftPOS";

        public SqlConnection connection = new SqlConnection(@"Data Source=" + ComputerName + ";Initial Catalog=" + DBName + ";User ID=" + DBUID + ";Password=" + DBPWD);

        public int Status;
        public string Name;

        public bool CheckConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public DataTable RetrieveSystemSettings()
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
                return dt;
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                dt.TableName = "SystemSettings";
                return dt;
            }
        }

        public bool UpdateSystemSettings(string SystemName, byte[] SystemLogo, string SystemPhone, int SystemReceiptBlankSpaces, int SystemIncludeLogoInReceipt, decimal SystemTax)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UpdateSystemSettings", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SystemName", SystemName);
                    cmd.Parameters.AddWithValue("@SystemLogo    ", SystemLogo);
                    cmd.Parameters.AddWithValue("@SystemPhone    ", SystemPhone);
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
                return Convert.ToBoolean(Status);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string RetrieveItemTypeName(int ItemTypeIndex, int locale)
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
                return Name;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public string RetrieveWarehouseName(int WarehouseIndex, int locale)
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
                return Name;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public string RetrieveFavoriteCategoryName(int CategoryIndex, int locale)
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
                return Name;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public List<string> RetrieveCashierNames()
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
                return CashierNames;
            }
            catch (Exception ex)
            {
                List<string> CashierNames = new List<string>();
                return CashierNames;
            }
        }

        public int RetrieveItemTypeID(string ItemTypeName)
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
                return Index;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int RetrieveWarehouseID(string WarehouseName)
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
                return Index;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int RetrieveFavoriteCategoryID(string CategoryName)
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
                return Index;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public List<ItemType> RetrieveItemTypes()
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
                return ItemTypes;
            }
            catch (Exception ex)
            {
                List<ItemType> ItemTypes = new List<ItemType>();
                return ItemTypes;
            }
        }

        public List<Warehouse> RetrieveWarehouses()
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
                return Warehouses;
            }
            catch (Exception ex)
            {
                List<Warehouse> Warehouses = new List<Warehouse>();
                return Warehouses;
            }
        }

        public List<Category> RetrieveFavoriteCategories()
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
                return Categories;
            }
            catch (Exception ex)
            {
                List<Category> Categories = new List<Category>();
                return Categories;
            }
        }

        public List<Printer> RetrievePrinters()
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrievePrinters", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                adapter.SelectCommand = cmd;
                List<Printer> Printers = new List<Printer>();
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                foreach (DataRow Printer in dt.Rows)
                {
                    Printers.Add(new Printer(Convert.ToInt32(Printer["Printer ID"].ToString()), Printer["Printer Name"].ToString()));
                }
                return Printers;
            }
            catch (Exception ex)
            {
                List<Printer> Printers = new List<Printer>();
                return Printers;
            }
        }

        public DataTable RetrieveLoginLogoutInfo(DateTime Date)
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
                return dt;
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                dt.TableName = "LoginLogoutInfo";
                return dt;
            }
        }

        public Tuple<List<Account>, DataTable> RetrieveUsersList()
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
                return Tuple.Create(Accounts, dt);
            }
            catch (Exception ex)
            {
                List<Account> Accounts = new List<Account>();
                DataTable dt = new DataTable();
                dt.TableName = "UsersList";
                return Tuple.Create(Accounts, dt);
            }
        }

        public Tuple<List<Customer>, DataTable> GetRetrieveCustomers()
        {
            try
            {
                List<Customer> Customers = new List<Customer>();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveCustomersList", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "CustomersList";
                
                foreach (DataRow Customer in dt.Rows)
                {
                    Customer customer = new Customer();
                    customer.CustomerName = Customer["Customer Name"].ToString();
                    Customers.Add(customer);
                }
                return Tuple.Create(Customers, dt);
            }
            catch (Exception ex)
            {
                List<Customer> Customers = new List<Customer>();
                DataTable dt = new DataTable();
                dt.TableName = "CustomersList";
                return Tuple.Create(Customers, dt);
            }
        }

        public Tuple<List<Customer>, DataTable> GetRetrieveVendors()
        {
            try
            {
                List<Customer> Customers = new List<Customer>();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveVendorsList", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "VendorsList";
                
                foreach (DataRow Customer in dt.Rows)
                {
                    Customer customer = new Customer();
                    customer.CustomerName = Customer["Customer Name"].ToString();
                    Customers.Add(customer);
                }
                return Tuple.Create(Customers, dt);
            }
            catch (Exception ex)
            {
                List<Customer> Customers = new List<Customer>();
                DataTable dt = new DataTable();
                dt.TableName = "VendorsList";
                return Tuple.Create(Customers, dt);
            }
        }

        public bool CheckAdmin()
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
                    return Convert.ToBoolean(Status);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool RegisterAdmin(Account AccountToRegister)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("RegisterAdmin", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserName", AccountToRegister.GetAccountName());
                    cmd.Parameters.AddWithValue("@UserID", AccountToRegister.GetAccountUID().ToLower());
                    cmd.Parameters.AddWithValue("@UserPWD", MD5Encryption.Encrypt(AccountToRegister.GetAccountPWD(), "PlancksoftPOS"));
                    cmd.Parameters.AddWithValue("@customerCardEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.customer_card_edit.ToString())));
                    cmd.Parameters.AddWithValue("@discountEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.discount_edit.ToString())));
                    cmd.Parameters.AddWithValue("@priceEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.price_edit.ToString())));
                    cmd.Parameters.AddWithValue("@receiptEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.receipt_edit.ToString())));
                    cmd.Parameters.AddWithValue("@inventoryEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.inventory_edit.ToString())));
                    cmd.Parameters.AddWithValue("@expensesEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.expenses_add.ToString())));
                    cmd.Parameters.AddWithValue("@usersEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.users_edit.ToString())));
                    cmd.Parameters.AddWithValue("@settingsEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.settings_edit.ToString())));
                    cmd.Parameters.AddWithValue("@personnelEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.personnel_edit.ToString())));
                    cmd.Parameters.AddWithValue("@opencloseEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.openclose_edit.ToString())));
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                    return Convert.ToBoolean(Status);
                }
            }
            catch (Exception ex)
            {
                return false;
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

        public Tuple<bool, string, bool> Login(Account AccountToLogin)
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
                    return Tuple.Create(Convert.ToBoolean(Status), Name, Convert.ToBoolean(Authority));
                }
            }
            catch (Exception ex)
            {
                return Tuple.Create(false, "", false);
            }
        }

        public bool Register(Account AccountToRegister, string UID, int AdminOrNot)
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
                            cmd.Parameters.AddWithValue("@customerCardEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.customer_card_edit.ToString())));
                            cmd.Parameters.AddWithValue("@discountEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.discount_edit.ToString())));
                            cmd.Parameters.AddWithValue("@priceEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.price_edit.ToString())));
                            cmd.Parameters.AddWithValue("@receiptEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.receipt_edit.ToString())));
                            cmd.Parameters.AddWithValue("@inventoryEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.inventory_edit.ToString())));
                            cmd.Parameters.AddWithValue("@expensesEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.expenses_add.ToString())));
                            cmd.Parameters.AddWithValue("@usersEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.users_edit.ToString())));
                            cmd.Parameters.AddWithValue("@settingsEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.settings_edit.ToString())));
                            cmd.Parameters.AddWithValue("@personnelEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.personnel_edit.ToString())));
                            cmd.Parameters.AddWithValue("@opencloseEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.openclose_edit.ToString())));
                            cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                            if (connection != null && connection.State == ConnectionState.Closed)
                                connection.Open();
                            cmd.ExecuteNonQuery();
                            Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                            connection.Close();
                            return Convert.ToBoolean(Status);
                        }
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
                using (SqlCommand cmd = new SqlCommand("RegisterAccount", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserName", AccountToRegister.GetAccountName());
                    cmd.Parameters.AddWithValue("@UserID", AccountToRegister.GetAccountUID().ToLower());
                    cmd.Parameters.AddWithValue("@UserPWD", MD5Encryption.Encrypt(AccountToRegister.GetAccountPWD().ToString(), "PlancksoftPOS"));
                    cmd.Parameters.AddWithValue("@AdminAcc", UID);
                    cmd.Parameters.AddWithValue("@customerCardEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.customer_card_edit.ToString())));
                    cmd.Parameters.AddWithValue("@discountEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.discount_edit.ToString())));
                    cmd.Parameters.AddWithValue("@priceEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.price_edit.ToString())));
                    cmd.Parameters.AddWithValue("@receiptEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.receipt_edit.ToString())));
                    cmd.Parameters.AddWithValue("@inventoryEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.inventory_edit.ToString())));
                    cmd.Parameters.AddWithValue("@expensesEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.expenses_add.ToString())));
                    cmd.Parameters.AddWithValue("@usersEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.users_edit.ToString())));
                    cmd.Parameters.AddWithValue("@settingsEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.settings_edit.ToString())));
                    cmd.Parameters.AddWithValue("@personnelEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.personnel_edit.ToString())));
                    cmd.Parameters.AddWithValue("@opencloseEditPerm", Convert.ToInt32(Convert.ToBoolean(AccountToRegister.openclose_edit.ToString())));
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                    return Convert.ToBoolean(Status);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteFavoriteItem(string ItemBarCode)
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
                return Convert.ToBoolean(Status);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeletePrinter(int printerID)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("DeletePrinter", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@printer_id", printerID);
                cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                if (connection != null && connection.State == ConnectionState.Closed)
                    connection.Open();
                cmd.ExecuteNonQuery();
                Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                connection.Close();
                return Convert.ToBoolean(Status);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddFavoriteItem(string ItemName, string ItemBarCode, int ItemQuantity, decimal ItemPrice, decimal ItemPriceTax, decimal Category, DateTime Date)
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
                return Convert.ToBoolean(Status);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddPrinter(string printerName)
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
                return Convert.ToBoolean(Status);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool SaveRegisterClose(string cashierName, decimal moneyInRegister)
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
                return Convert.ToBoolean(Status);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool SaveRegisterOpen(string cashierName, decimal moneyInRegister)
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
                return Convert.ToBoolean(Status);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Tuple<List<Item>, DataTable> SearchWarehouseInventoryItems(int WarehouseID)
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
                return Tuple.Create(Items, dt);
            }
            catch (Exception ex)
            {
                List<Item> Items = new List<Item>();
                DataTable dt = new DataTable();
                dt.TableName = "WarehouseInventoryItems";
                return Tuple.Create(Items, dt);
            }
        }

        public Tuple<List<Item>, DataTable> SearchInventoryItems(string ItemName = "", string ItemBarCode = "", int locale = 1)
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
                return Tuple.Create(Items, dt);
            }
            catch (Exception ex)
            {
                List<Item> Items = new List<Item>();
                DataTable dt = new DataTable();
                dt.TableName = "InventoryItems";
                return Tuple.Create(Items, dt);
            }
        }

        public Item SearchInventoryItemsWithBarCode(string ItemBarCode = "")
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
                    return Item;
                }
                return null;
            }
            catch (Exception ex)
            {
                Item Item = new Item();
                return Item;
            }
        }

        public Tuple<List<Bill>, DataTable> RetrieveUnPortedBills()
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
                return Tuple.Create(Bills, dt);
            }
            catch (Exception ex)
            {
                List<Bill> Bills = new List<Bill>();
                DataTable dt = new DataTable();
                dt.TableName = "UnPortedBills";
                return Tuple.Create(Bills, dt);
            }
        }

        public Tuple<List<Bill>, DataTable> RetrievePortedBills()
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
                return Tuple.Create(Bills, dt);
            }
            catch (Exception ex)
            {
                List<Bill> Bills = new List<Bill>();
                DataTable dt = new DataTable();
                dt.TableName = "PortedBills";
                return Tuple.Create(Bills, dt);
            }
        }

        public Tuple<List<Bill>, DataTable> RetrieveVendorBills()
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
                    bill.SetCashierName(Bill["Cashier Name"].ToString());
                    bill.SetTotalAmount(Convert.ToDecimal(Bill["Total Amount"].ToString()));
                    bill.SetDate(Convert.ToDateTime(Bill["Date"].ToString()));
                    Bills.Add(bill);
                }
                return Tuple.Create(Bills, dt);
            }
            catch (Exception ex)
            {
                List<Bill> Bills = new List<Bill>();
                DataTable dt = new DataTable();
                dt.TableName = "VendorBills";
                return Tuple.Create(Bills, dt);
            }
        }

        public DataTable RetrieveTaxZReport()
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
                return dt;
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                dt.TableName = "TaxZReport";
                return dt;
            }
        }

        public Tuple<List<Bill>, DataTable> RetrieveBills()
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
                    bill.SetTotalAmount(Convert.ToDecimal(Bill["Total Amount"].ToString()));
                    bill.SetPaidAmount(Convert.ToDecimal(Bill["Paid Amount"].ToString()));
                    bill.SetRemainderAmount(Convert.ToDecimal(Bill["Remainder Amount"].ToString()));
                    bill.SetDate(Convert.ToDateTime(Bill["Invoice Date"].ToString()));
                    Bills.Add(bill);
                }
                return Tuple.Create(Bills, dt);
            }
            catch (Exception ex)
            {
                List<Bill> Bills = new List<Bill>();
                DataTable dt = new DataTable();
                dt.TableName = "Bills";
                return Tuple.Create(Bills, dt);
            }
        }

        public Tuple<List<Item>, DataTable> RetrieveCapitalRevenue()
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
                
                return Tuple.Create(Items, dt);
            }
            catch (Exception ex)
            {
                List<Item> Items = new List<Item>();
                DataTable dt = new DataTable();
                dt.TableName = "CapitalRevenue";
                return Tuple.Create(Items, dt);
            }
        }

        public Tuple<List<Item>, DataTable> RetrieveExports()
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
                
                return Tuple.Create(Items, dt);
            }
            catch (Exception ex)
            {
                List<Item> Items = new List<Item>();
                DataTable dt = new DataTable();
                dt.TableName = "Exports";
                return Tuple.Create(Items, dt);
            }
        }

        public Tuple<List<Item>, DataTable> RetrieveImports()
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
                
                return Tuple.Create(Items, dt);
            }
            catch (Exception ex)
            {
                List<Item> Items = new List<Item>();
                DataTable dt = new DataTable();
                dt.TableName = "Imports";
                return Tuple.Create(Items, dt);
            }
        }

        public Tuple<List<Item>, DataTable> RetrieveLeastBoughtItems()
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
                return Tuple.Create(Items, dt);
            }
            catch (Exception ex)
            {
                List<Item> Items = new List<Item>();
                DataTable dt = new DataTable();
                dt.TableName = "LeastBoughtItems";
                return Tuple.Create(Items, dt);
            }
        }

        public Tuple<List<Item>, DataTable> RetrieveMostBoughtItems()
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
                return Tuple.Create(Items, dt);
            }
            catch (Exception ex)
            {
                List<Item> Items = new List<Item>();
                DataTable dt = new DataTable();
                dt.TableName = "MostBoughtItems";
                return Tuple.Create(Items, dt);
            }
        }

        public int RetrieveAccountAuthority(string UserID = "")
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

                return Convert.ToInt32(dt.Rows[0]["Authority"].ToString());
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public Account RetrieveUserPermissions(string UserID = "")
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
                
                foreach (DataRow Permission in dt.Rows)
                {
                    User.customer_card_edit = Convert.ToBoolean(Convert.ToInt32(Permission["Customer Card Permission"].ToString()));
                    User.discount_edit = Convert.ToBoolean(Convert.ToInt32(Permission["Discount Permission"].ToString()));
                    User.price_edit = Convert.ToBoolean(Convert.ToInt32(Permission["Price Edit Permission"].ToString()));
                    User.receipt_edit = Convert.ToBoolean(Convert.ToInt32(Permission["Receipt Edit Permission"].ToString()));
                    User.inventory_edit = Convert.ToBoolean(Convert.ToInt32(Permission["Inventory Edit Permission"].ToString()));
                    User.expenses_add = Convert.ToBoolean(Convert.ToInt32(Permission["Expense Add Permission"].ToString()));
                    User.users_edit = Convert.ToBoolean(Convert.ToInt32(Permission["Users Edit Permission"].ToString()));
                    User.settings_edit = Convert.ToBoolean(Convert.ToInt32(Permission["Settings Edit Permission"].ToString()));
                    User.personnel_edit = Convert.ToBoolean(Convert.ToInt32(Permission["Personnel Edit Permission"].ToString()));
                    User.openclose_edit = Convert.ToBoolean(Convert.ToInt32(Permission["Open Close Cash Permission"].ToString()));
                }
                return User;
            }
            catch (Exception ex)
            {
                Account User = new Account();
                return User;
            }
        }

        public Item RetrieveItemPictureFromBarCode(string ItemBarCode)
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
                        Item.picture = (Byte[])(ItemInfo["Item Picture"]);
                    }
                }
                return Item;
            }
            catch (Exception ex)
            {
                Item Item = new Item();
                return Item;
            }
        }

        public Item RetrieveItemsQuantityDates(string ItemBarCode)
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
                return Item;
            }
            catch (Exception ex)
            {
                Item Item = new Item();
                return Item;
            }
        }

        public Tuple<List<Item>, DataTable> RetrieveItems(int locale)
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
                    Items.Add(item);
                }
                return Tuple.Create(Items, dt);
            }
            catch (Exception ex)
            {
                List<Item> Items = new List<Item>();
                DataTable dt = new DataTable();
                dt.TableName = "Items";
                return Tuple.Create(Items, dt);
            }
        }

        public DataTable RetrieveEmployees()
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("RetrieveEmployees", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "Employees";
                return dt;
            }
            catch (Exception ex)
            {
                Account[] Users = new Account[0];
                DataTable dt = new DataTable();
                dt.TableName = "Employees";
                return dt;
            }
        }

        public Tuple<List<Account>, DataTable> RetrieveUsers()
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
                return Tuple.Create(Users, dt);
            }
            catch (Exception ex)
            {
                List<Account> Users = new List<Account>();
                DataTable dt = new DataTable();
                dt.TableName = "Users";
                return Tuple.Create(Users, dt);
            }
        }

        public Tuple<List<Item>, DataTable> RetrieveVendorBillItems(int BillNumber)
        {
            try
            {
                List<Item> BillItems = new List<Item>();
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
                
                foreach (DataRow FavoriteItem in dt.Rows)
                {
                    Item billItem = new Item();
                    billItem.SetName(FavoriteItem["Item Name"].ToString());
                    billItem.SetBarCode(FavoriteItem["Item BarCode"].ToString());
                    billItem.vendorQuantity = Convert.ToInt32(FavoriteItem["Item Buy Quantity"].ToString());
                    billItem.SetBuyPrice(Convert.ToDecimal(FavoriteItem["Item Buy Price"].ToString()));
                    BillItems.Add(billItem);
                }
                return Tuple.Create(BillItems, dt);
            }
            catch (Exception ex)
            {
                List<Item> Items = new List<Item>();
                DataTable dt = new DataTable();
                dt.TableName = "VendorBillItems";
                return Tuple.Create(Items, dt);
            }
        }

        public Tuple<List<Item>, DataTable> RetrieveBillItems(int BillNumber)
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
                    billItems.SetPrice(Convert.ToDecimal(FavoriteItem["Item Price"].ToString()));
                    billItems.SetPriceTax(Convert.ToDecimal(FavoriteItem["Item Price Tax"].ToString()));
                    BillItems.Add(billItems);
                }
                return Tuple.Create(BillItems, dt);
            }
            catch (Exception ex)
            {
                List<Item> Items = new List<Item>();
                DataTable dt = new DataTable();
                dt.TableName = "BillItems";
                return Tuple.Create(Items, dt);
            }
        }

        public DataTable RetrieveBillItemsProfit(DateTime Date1, DateTime Date2, int ItemTypeID, string CashierName)
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
                return dt;
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                dt.TableName = "BillItemsProfit";
                return dt;
            }
        }

        public DataTable RetrieveReturnedItems()
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
                return dt;
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                dt.TableName = "ReturnedItems";
                return dt;
            }
        }

        public Tuple<List<Item>, DataTable> RetrieveFavoriteItems(int Category)
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
                return Tuple.Create(FavoriteItems, dt);
            }
            catch (Exception ex)
            {
                List<Item> Items = new List<Item>();
                DataTable dt = new DataTable();
                dt.TableName = "FavoriteItems";
                return Tuple.Create(Items, dt);
            }
        }

        public decimal GetCapitalAmount()
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
                    return Amount;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public decimal GetOpenRegisterAmount()
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
                    return Amount;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public decimal GetTotalSalesAmountCloseCash()
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
                    return Amount;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public decimal GetTotalSalesAmount()
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
                    return Amount;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public string GetLastOpenRegisterDate()
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
                    return Convert.ToDateTime(cmd.Parameters["@Date"].Value.ToString()).ToShortDateString();
                }
            }
            catch (Exception ex)
            {
                return "error.";
            }
        }

        public bool InsertExpense(string ExpenseName, decimal ExpenseCost, string EmployeeName, DateTime Date)
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
                    return Convert.ToBoolean(Status);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool InsertDeduction(int EmployeeID, DateTime Date, decimal Deduction)
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
                    return Convert.ToBoolean(Status);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool InsertDayOff(int EmployeeID, DateTime Date)
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
                    return Convert.ToBoolean(Status);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool InsertAbsence(int EmployeeID, DateTime Date, int Hours)
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
                    return Convert.ToBoolean(Status);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool InsertEmployee(string EmployeeName, decimal Salary, string Phone, string Address)
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
                    return Convert.ToBoolean(Status);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool InsertItem(Item ItemToInsert)
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
                    if (ItemToInsert.GetPicture() != null)
                        cmd.Parameters.AddWithValue("@Picture", ItemToInsert.GetPicture());
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
                    return Convert.ToBoolean(Status);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteItemType(int ItemTypeID)
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
                return Convert.ToBoolean(Status);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteWarehouse(int WarehouseID)
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
                return Convert.ToBoolean(Status);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteFavoriteCategory(int FavoriteCategoryID)
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
                return Convert.ToBoolean(Status);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateItemTypes(int ItemTypeID, string ItemTypeName)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UpdateItemType", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@WarehouseID", ItemTypeID);
                    cmd.Parameters.AddWithValue("@WarehouseName", ItemTypeName);
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                }
                return Convert.ToBoolean(Status);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateWarehouses(int WarehouseID, string WarehouseName)
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
                return Convert.ToBoolean(Status);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateFavoriteCategories(int FavoriteCategoryID, string FavoriteCategory)
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
                return Convert.ToBoolean(Status);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdatePrinters(int printerID, string printerName)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UpdatePrinters", connection))
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
                return Convert.ToBoolean(Status);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool InsertItemType(string ItemTypeName)
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
                return Convert.ToBoolean(Status);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool InsertWarehouse(string WarehouseName)
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
                return Convert.ToBoolean(Status);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool InsertFavoriteCategory(string FavoriteCategory)
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
                return Convert.ToBoolean(Status);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool InsertPrinter(string printerName)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("InsertPrinter", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PrinterName", printerName);
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                }
                return Convert.ToBoolean(Status);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeletesCustomer(string CustomerID)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DeleteCustomer", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                    return Convert.ToBoolean(Status);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool RegisterCustomer(Customer CustomerToInsert)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("RegisterCustomer", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CustomerName", CustomerToInsert.CustomerName.ToString());
                    cmd.Parameters.AddWithValue("@CustomerID", CustomerToInsert.CustomerID.ToString());
                    cmd.Parameters.AddWithValue("@CustomerPhone", CustomerToInsert.CustomerPhone.ToString());
                    cmd.Parameters.AddWithValue("@CustomerAddress", CustomerToInsert.CustomerAddress.ToString());
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                    return Convert.ToBoolean(Status);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool RegisterVendor(Customer CustomerToInsert)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("RegisterVendor", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CustomerName", CustomerToInsert.CustomerName.ToString());
                    cmd.Parameters.AddWithValue("@CustomerID", CustomerToInsert.CustomerID.ToString());
                    cmd.Parameters.AddWithValue("@CustomerPhone", CustomerToInsert.CustomerPhone.ToString());
                    cmd.Parameters.AddWithValue("@CustomerAddress", CustomerToInsert.CustomerAddress.ToString());
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                    return Convert.ToBoolean(Status);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteAbsence(int AbsenceID)
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
                    return Convert.ToBoolean(Status);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteEmployee(int EmployeeID)
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
                    return Convert.ToBoolean(Status);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteUser(Account UserToUpdate, string cashierName)
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
                    return Convert.ToBoolean(Status);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddSaleOnItems(List<Item> saleItems)
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
                return Convert.ToBoolean(Status);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddItemToCustomer(string ItemBarCode, int CustomerID, decimal CustomerPrice)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("AddItemToCustomer", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                    cmd.Parameters.AddWithValue("@ItemBarCode", ItemBarCode);
                    cmd.Parameters.AddWithValue("@ItemPrice", CustomerPrice);
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();

                    return Convert.ToBoolean(Status);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddVendorBill(Bill billToAdd, string cashierName)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("AddVendorBill", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@cashierName", cashierName);
                    cmd.Parameters.AddWithValue("@totalAmount", billToAdd.getTotalAmount());
                    cmd.Parameters.AddWithValue("@Date", billToAdd.getDate());
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

                            if (connection != null && connection.State == ConnectionState.Closed)
                                connection.Open();
                            cmd2.ExecuteNonQuery();
                            connection.Close();
                        }
                    }

                    return Convert.ToBoolean(Status);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool PayBill(Bill billToAdd, string cashierName)
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

                    return Convert.ToBoolean(Status);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateEmployee(int EmployeeID, string EmployeeName, decimal Salary, string Phone, string Address)
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
                    return Convert.ToBoolean(Status);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateUser(Account UserToUpdate, string cashierName, int AdminOrNot)
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
                    cmd.Parameters.AddWithValue("@customerCardEditPerm", Convert.ToInt32(Convert.ToBoolean(UserToUpdate.customer_card_edit.ToString())));
                    cmd.Parameters.AddWithValue("@discountEditPerm", Convert.ToInt32(Convert.ToBoolean(UserToUpdate.discount_edit.ToString())));
                    cmd.Parameters.AddWithValue("@priceEditPerm", Convert.ToInt32(Convert.ToBoolean(UserToUpdate.price_edit.ToString())));
                    cmd.Parameters.AddWithValue("@receiptEditPerm", Convert.ToInt32(Convert.ToBoolean(UserToUpdate.receipt_edit.ToString())));
                    cmd.Parameters.AddWithValue("@inventoryEditPerm", Convert.ToInt32(Convert.ToBoolean(UserToUpdate.inventory_edit.ToString())));
                    cmd.Parameters.AddWithValue("@expensesEditPerm", Convert.ToInt32(Convert.ToBoolean(UserToUpdate.expenses_add.ToString())));
                    cmd.Parameters.AddWithValue("@usersEditPerm", Convert.ToInt32(Convert.ToBoolean(UserToUpdate.users_edit.ToString())));
                    cmd.Parameters.AddWithValue("@settingsEditPerm", Convert.ToInt32(Convert.ToBoolean(UserToUpdate.settings_edit.ToString())));
                    cmd.Parameters.AddWithValue("@personnelEditPerm", Convert.ToInt32(Convert.ToBoolean(UserToUpdate.personnel_edit.ToString())));
                    cmd.Parameters.AddWithValue("@opencloseEditPerm", Convert.ToInt32(Convert.ToBoolean(UserToUpdate.openclose_edit.ToString())));
                    cmd.Parameters.AddWithValue("@UserAuthority", AdminOrNot);
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                    return Convert.ToBoolean(Status);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateBill(int BillNumber, string CashierName, decimal TotalAmount, decimal PaidAmount, decimal RemainderAmount)
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
                    return Convert.ToBoolean(Status);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ReturnItem(string ItemName, string ItemBarCode, int ItemQuantity, string cashierName)
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
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (connection != null && connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.ExecuteNonQuery();
                    Status = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    connection.Close();
                }
                return Convert.ToBoolean(Status);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateItemWarehouse(List<Item> ItemsToUpdate, string EmployeeName, int EntryExitType)
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
                return Convert.ToBoolean(Status);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateItem(Item ItemToUpdate)
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
                    if (ItemToUpdate.GetPicture() != null)
                        cmd.Parameters.AddWithValue("@Picture", ItemToUpdate.GetPicture());
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
                    return Convert.ToBoolean(Status);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateItemQuantity(Item ItemToUpdate)
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
                    return Convert.ToBoolean(Status);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteItem(string ItemBarCode)
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
                    return Convert.ToBoolean(Status);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Bill RetrieveLastVendorBillNumberToday(DateTime Date)
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
                return Bill;
            }
            catch (Exception ex)
            {
                Bill Bill = new Bill();
                return Bill;
            }
        }

        public Bill RetrieveLastBillNumberToday()
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
                return Bill;
            }
            catch (Exception ex)
            {
                Bill Bill = new Bill();
                return Bill;
            }
        }

        public List<Item> RetrieveItemsQuantity(string ItemBarCode = "")
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
                return expireItems;
            }
            catch (Exception ex)
            {
                List<Item> saleItems = new List<Item>();
                return saleItems;
            }
        }

        public List<Item> RetrieveSaleItemsQuantity()
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
                return saleItems;
            }
            catch (Exception ex)
            {
                List<Item> saleItems = new List<Item>();
                return saleItems;
            }
        }

        public Tuple<List<Item>, DataTable> RetrieveExpireStockToday(DateTime Date)
        {
            try
            {
                List<Item> expireItems = new List<Item>();
                List<Item> quantity_items = RetrieveItemsQuantity();

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
                    return Tuple.Create(expireItems, dt);
                }
                return Tuple.Create(expireItems, new DataTable());
            }
            catch (Exception ex)
            {
                List<Item> expireItems = new List<Item>();
                DataTable dt = new DataTable();
                dt.TableName = "ExpireStockToday";
                return Tuple.Create(expireItems, dt);
            }
        }

        public List<Item> RetrieveSaleToday(DateTime Date, int QuantityEnd = 0)
        {
            try
            {
                List<Item> saleItems = new List<Item>();
                List<Item> quantity_items = RetrieveSaleItemsQuantity();

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
                return saleItems;
            }
            catch (Exception ex)
            {
                List<Item> saleItems = new List<Item>();
                return saleItems;
            }
        }

        public Tuple<List<Bill>, DataTable> SearchTodayBills(DateTime Date)
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
                return Tuple.Create(Bills, dt);
            }
            catch (Exception ex)
            {
                List<Bill> Bills = new List<Bill>();
                DataTable dt = new DataTable();
                dt.TableName = "TodayBills";
                return Tuple.Create(Bills, dt);
            }
        }

        public Tuple<List<Bill>, DataTable> SearchBills(int BillNumber = 0)
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
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dt.TableName = "Bills";
                foreach (DataRow Item in dt.Rows)
                {
                    Bill bill = new Bill();
                    bill.SetBillNumber(Convert.ToInt32(Item["Bill Number"].ToString()));
                    bill.SetCashierName(Item["Cashier Name"].ToString());
                    bill.SetTotalAmount(Convert.ToDecimal(Item["Total Amount"].ToString()));
                    bill.SetPaidAmount(Convert.ToDecimal(Item["Paid Amount"].ToString()));
                    bill.SetRemainderAmount(Convert.ToDecimal(Item["Remainder Amount"].ToString()));
                    Bills.Add(bill);
                }
                return Tuple.Create(Bills, dt);
            }
            catch (Exception ex)
            {
                List<Bill> Bills = new List<Bill>();
                DataTable dt = new DataTable();
                dt.TableName = "Bills";
                return Tuple.Create(Bills, dt);
            }
        }

        public int GetItemQuantity(string ItemBarCode = "")
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
                return Quantity;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public DataTable RetrieveAbsence(DateTime Date1, DateTime Date2)
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
                return dt;
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                dt.TableName = "Absence";
                return dt;
            }
        }

        public DataTable SearchExpenses(string Date1, string Date2, string ExpenseName = "", string EmployeeID = "")
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
                return dt;
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                dt.TableName = "Expenses";
                return dt;
            }
        }

        public Tuple<List<Item>, DataTable> SearchItems(string ItemName = "", string ItemBarCode = "", int ItemType = 0)
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
                    Items.Add(item);
                }
                return Tuple.Create(Items, dt);
            }
            catch (Exception ex)
            {
                List<Item> Items = new List<Item>();
                DataTable dt = new DataTable();
                dt.TableName = "Items";
                return Tuple.Create(Items, dt);
            }
        }

        public DataTable SearchCustomers(string customerName = "", string customerID = "", string itemName = "")
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("SearchCustomers", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (customerName != "")
                    cmd.Parameters.AddWithValue("@customerName", customerName);
                if (customerID != "")
                    cmd.Parameters.AddWithValue("@customerID", customerID);
                if (itemName != "")
                    cmd.Parameters.AddWithValue("@itemName", itemName);
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "Customers";
                return dt;
            }
            catch (Exception ex)
            {
                Item[] Items = new Item[0];
                DataTable dt = new DataTable();
                return dt;
            }
        }

        public Tuple<Customer, DataTable> SearchCustomersInfo(string customerName = "", string customerID = "")
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("SearchCustomersInfo", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (customerName != "")
                    cmd.Parameters.AddWithValue("@customerName", customerName);
                if (customerID != "")
                    cmd.Parameters.AddWithValue("@customerID", customerID);
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.TableName = "CustomersInfo";

                Customer searchedCustomer = new Customer();

                foreach(DataRow customer in dt.Rows)
                {
                    searchedCustomer.CustomerID = Convert.ToInt32(customer["Customer ID"].ToString());
                    searchedCustomer.CustomerName = customer["Customer Name"].ToString();
                }

                return Tuple.Create(searchedCustomer, dt);
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                dt.TableName = "CustomersInfo";
                Customer Customer = new Customer();
                return Tuple.Create(Customer, dt);
            }
        }
    }
}