using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatVibezPOS
{
    internal class Item
    {
        internal int ItemID, Warehouse_ID, ItemTypeID, QuantityEnd, QuantityWarning, vendorQuantity;
        internal string ItemName, ItemBarCode, itemNewBarCode;
        internal int ItemQuantity, FavoriteCategory, saleRate;
        internal decimal ItemBuyPrice, ItemPrice, ItemPriceTax, customerPrice;
        internal DateTime Date, DateStart, DateEnd, ProductionDate, ExpirationDate, EntryDate;
        internal byte[] Picture;

        internal Item()
        {
            saleRate = 0;
        }

        internal Item(string itemName1, string itemBarCode1, int itemQuantity1, decimal itemPrice1, decimal itemPriceTax1, DateTime Date)
        {
            ItemName1 = itemName1;
            ItemBarCode1 = itemBarCode1;
            ItemQuantity1 = itemQuantity1;
            ItemPrice1 = itemPrice1;
            ItemPriceTax1 = itemPriceTax1;
            saleRate = 0;
            this.Date = Date;
        }

        internal Item(string itemName1, string itemBarCode1, int itemQuantity1, decimal itemBuyPrice1, decimal itemPrice1, decimal itemPriceTax1, int WarehouseID, int ItemTypeID, DateTime Date)
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

        internal int ItemID1 { get => ItemID; set => ItemID = value; }
        internal string ItemName1 { get => ItemName; set => ItemName = value; }
        internal string ItemBarCode1 { get => ItemBarCode; set => ItemBarCode = value; }
        internal int ItemQuantity1 { get => ItemQuantity; set => ItemQuantity = value; }
        internal decimal ItemBuyPrice1 { get => ItemBuyPrice; set => ItemBuyPrice = value; }
        internal decimal ItemPrice1 { get => ItemPrice; set => ItemPrice = value; }
        internal decimal ItemPriceTax1 { get => ItemPriceTax; set => ItemPriceTax = value; }
        internal int ItemTypeID1 { get => ItemTypeID; set => ItemTypeID = value; }
        internal int WarehouseID1 { get => Warehouse_ID; set => Warehouse_ID = value; }
        internal int FavoriteCategory1 { get => FavoriteCategory; set => FavoriteCategory = value; }
        internal DateTime Date1 { get => Date; set => Date = value; }
        internal byte[] picture { get => Picture; set => Picture = value; }
        internal string ItemNewBarCode { get => itemNewBarCode; set => itemNewBarCode = value; }

        internal int GetID()
        {
            return this.ItemID1;
        }

        internal string GetName()
        {
            return this.ItemName1;
        }

        internal string GetItemBarCode()
        {
            return this.ItemBarCode1;
        }

        internal int GetQuantity()
        {
            return this.ItemQuantity1;
        }

        internal decimal GetBuyPrice()
        {
            return this.ItemBuyPrice1;
        }

        internal decimal GetPrice()
        {
            return this.ItemPrice1;
        }

        internal decimal GetPriceTax()
        {
            return this.ItemPriceTax1;
        }

        internal int GetItemTypeeID()
        {
            return this.ItemTypeID1;
        }

        internal int GetWarehouseID()
        {
            return this.WarehouseID1;
        }

        internal decimal GetFavoriteCategory()
        {
            return this.FavoriteCategory1;
        }

        internal DateTime GetDate()
        {
            return this.Date1;
        }

        internal byte[] GetPicture()
        {
            return picture;
        }

        internal void SetID(int id)
        {
            this.ItemID1 = id;
        }

        internal void SetName(string name)
        {
            this.ItemName1 = name;
        }

        internal void SetBarCode(string barcode)
        {
            this.ItemBarCode1 = barcode;
        }

        internal void SetNewBarCode(string barcode)
        {
            this.ItemNewBarCode = barcode;
        }

        internal void SetQuantity(int quantity)
        {
            this.ItemQuantity1 = quantity;
        }

        internal void SetBuyPrice(decimal price)
        {
            this.ItemBuyPrice1 = price;
        }

        internal void SetPrice(decimal price)
        {
            this.ItemPrice1 = price;
        }

        internal void SetPriceTax(decimal price)
        {
            this.ItemPriceTax1 = price;
        }

        internal void SetItemTypeID(int ID)
        {
            this.ItemTypeID1 = ID;
        }

        internal void SetWarehouseID(int ID)
        {
            this.WarehouseID1 = ID;
        }

        internal void SetFavoriteCategory(int Category)
        {
            this.FavoriteCategory1 = Category;
        }
        
        internal void SetDate(DateTime Date)
        {
            this.Date = Date;
        }

        internal void SetSaleRate(int Rate)
        {
            this.saleRate = Rate;
        }

        internal void SetPicture(byte[] picture)
        {
            this.picture = picture;
        }
    }
}
