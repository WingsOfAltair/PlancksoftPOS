using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dependencies
{
    [DataContract]
    public class Item
    {
        [DataMember]
        public int ItemID, Warehouse_ID, ItemTypeID, QuantityEnd, QuantityWarning, vendorQuantity;
        [DataMember]
        public string ItemName, ItemBarCode, itemNewBarCode, favoriteCategoryName, warehouseName, itemTypeName;
        [DataMember]
        public int ItemQuantity, TimesSold, ReturnedQuantity, FavoriteCategory, saleRate;
        [DataMember]
        public decimal ItemBuyPrice, ItemPrice, ItemPriceTax, ClientPrice;
        [DataMember]
        public DateTime Date, DateStart, DateEnd, ProductionDate, ExpirationDate, EntryDate;
        [DataMember]
        public string Picture;
        [DataMember]
        public byte[] PictureUpload;

        public Item()
        {
            saleRate = 0;
        }

        public Item(string itemName1, string itemBarCode1, int itemQuantity1, decimal itemPrice1, decimal itemPriceTax1, DateTime Date)
        {
            ItemName1 = itemName1;
            ItemBarCode1 = itemBarCode1;
            ItemQuantity1 = itemQuantity1;
            ItemPrice1 = itemPrice1;
            ItemPriceTax1 = itemPriceTax1;
            saleRate = 0;
            this.Date = Date;
        }

        public Item(string itemName1, string itemBarCode1, int itemQuantity1, decimal itemBuyPrice1, decimal itemPrice1, decimal itemPriceTax1, int WarehouseID, int ItemTypeID, DateTime Date)
        {
            ItemName1 = itemName1;
            ItemBarCode1 = itemBarCode1;
            ItemQuantity1 = itemQuantity1;
            ItemBuyPrice1 = itemBuyPrice1;
            ItemPrice1 = itemPrice1;
            ItemPriceTax1 = itemPriceTax1;
            WarehouseID1 = WarehouseID;
            ItemTypeID1 = ItemTypeID;
            saleRate = 0;
            this.Date = Date;
        }

        public int ItemID1 { get => ItemID; set => ItemID = value; }
        public string ItemName1 { get => ItemName; set => ItemName = value; }
        public string ItemBarCode1 { get => ItemBarCode; set => ItemBarCode = value; }
        public string FavoriteCategoryName { get => favoriteCategoryName; set => favoriteCategoryName = value; }
        public string WarehouseName { get => warehouseName; set => warehouseName = value; }
        public string ItemTypeName { get => itemTypeName; set => itemTypeName = value; }
        public int ItemQuantity1 { get => ItemQuantity; set => ItemQuantity = value; }
        public int TimesSold1 { get => TimesSold; set => TimesSold = value; }
        public int ReturnedQuantity1 { get => ReturnedQuantity; set => ReturnedQuantity = value; }
        public decimal ItemBuyPrice1 { get => ItemBuyPrice; set => ItemBuyPrice = value; }
        public decimal ItemPrice1 { get => ItemPrice; set => ItemPrice = value; }
        public decimal ItemPriceTax1 { get => ItemPriceTax; set => ItemPriceTax = value; }
        public int ItemTypeID1 { get => ItemTypeID; set => ItemTypeID = value; }
        public int WarehouseID1 { get => Warehouse_ID; set => Warehouse_ID = value; }
        public int FavoriteCategory1 { get => FavoriteCategory; set => FavoriteCategory = value; }
        public DateTime Date1 { get => Date; set => Date = value; }
        public string picture { get => Picture; set => Picture = value; }
        public string ItemNewBarCode { get => itemNewBarCode; set => itemNewBarCode = value; }

        public int GetID()
        {
            return this.ItemID1;
        }

        public string GetName()
        {
            return this.ItemName1;
        }

        public string GetItemBarCode()
        {
            return this.ItemBarCode1;
        }

        public int GetQuantity()
        {
            return this.ItemQuantity1;
        }

        public int GetTimesSold()
        {
            return this.TimesSold1;
        }

        public decimal GetBuyPrice()
        {
            return this.ItemBuyPrice1;
        }

        public decimal GetPrice()
        {
            return this.ItemPrice1;
        }

        public decimal GetPriceTax()
        {
            return this.ItemPriceTax1;
        }

        public int GetItemTypeeID()
        {
            return this.ItemTypeID1;
        }

        public string GetItemTypeName()
        {
            return this.ItemTypeName;
        }

        public int GetWarehouseID()
        {
            return this.WarehouseID1;
        }

        public string GetWarehouseName()
        {
            return this.WarehouseName;
        }

        public decimal GetFavoriteCategory()
        {
            return this.FavoriteCategory1;
        }

        public string GetFavoriteCategoryName()
        {
            return this.FavoriteCategoryName;
        }

        public DateTime GetDate()
        {
            return this.Date1;
        }

        public string GetPicture()
        {
            return picture;
        }

        public void SetID(int id)
        {
            this.ItemID1 = id;
        }

        public void SetName(string name)
        {
            this.ItemName1 = name;
        }

        public void SetBarCode(string barcode)
        {
            this.ItemBarCode1 = barcode;
        }

        public void SetNewBarCode(string barcode)
        {
            this.ItemNewBarCode = barcode;
        }

        public void SetQuantity(int quantity)
        {
            this.ItemQuantity1 = quantity;
        } 

        public void SetTimesSold(int quantity)
        {
            this.TimesSold1 = quantity;
        }  

        public void SetReturnedQuantity(int quantity)
        {
            this.ReturnedQuantity1 = quantity;
        }

        public void SetBuyPrice(decimal price)
        {
            this.ItemBuyPrice1 = price;
        }

        public void SetPrice(decimal price)
        {
            this.ItemPrice1 = price;
        }

        public void SetPriceTax(decimal price)
        {
            this.ItemPriceTax1 = price;
        }

        public void SetItemTypeID(int ID)
        {
            this.ItemTypeID1 = ID;
        }

        public void SetItemTypeName(string ItemTypeName)
        {
            this.ItemTypeName = ItemTypeName;
        }

        public void SetWarehouseID(int ID)
        {
            this.WarehouseID1 = ID;
        }

        public void SetWarehouseName(string WarehouseName)
        {
            this.WarehouseName = WarehouseName;
        }

        public void SetFavoriteCategory(int Category)
        {
            this.FavoriteCategory1 = Category;
        }

        public void SetFavoriteCategoryName(string FavoriteCategoryName)
        {
            this.FavoriteCategoryName = FavoriteCategoryName;
        }

        public void SetDate(DateTime Date)
        {
            this.Date = Date;
        }

        public void SetSaleRate(int Rate)
        {
            this.saleRate = Rate;
        }

        public void SetPicture(string picture)
        {
            this.picture = picture;
        }
    }
}
