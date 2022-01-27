using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatVibezPOS
{
    internal class Customer
    {
        private int customerID;
        private string customerName, customerPhone, customerAddress;
        private decimal buyPrice, sellPrice, sellPriceTax, customerPrice;

        internal Customer()
        { }

        internal Customer(string customerName, int customerID, string customerPhone, string customerAddress)
        {
            CustomerName = customerName;
            CustomerID = customerID;
            CustomerPhone = customerPhone;
            CustomerAddress = customerAddress;
        }

        internal Customer(string customerName, int customerID, decimal buyPrice, decimal sellPrice, decimal sellPriceTax, decimal customerPrice, string customerPhone, string customerAddress)
        {
            CustomerName = customerName;
            CustomerID = customerID;
            BuyPrice = buyPrice;
            SellPrice = sellPrice;
            SellPriceTax = sellPriceTax;
            CustomerPrice = customerPrice;
            CustomerPhone = customerPhone;
            CustomerAddress = customerAddress;
        }

        internal string CustomerName { get => customerName; set => customerName = value; }
        internal string CustomerPhone { get => customerPhone; set => customerPhone = value; }
        internal string CustomerAddress { get => customerAddress; set => customerAddress = value; }
        internal int CustomerID { get => customerID; set => customerID = value; }
        internal decimal BuyPrice { get => buyPrice; set => buyPrice = value; }
        internal decimal SellPrice { get => sellPrice; set => sellPrice = value; }
        internal decimal SellPriceTax { get => sellPriceTax; set => sellPriceTax = value; }
        internal decimal CustomerPrice { get => customerPrice; set => customerPrice = value; }
    }
}
