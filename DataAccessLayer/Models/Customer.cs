using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    [DataContract]
    public class Customer
    {
        [DataMember]
        public int customerID;
        [DataMember]
        public string customerName, customerPhone, customerAddress;
        [DataMember]
        public decimal buyPrice, sellPrice, sellPriceTax, customerPrice;

        public Customer()
        { }

        public Customer(string customerName, int customerID, string customerPhone, string customerAddress)
        {
            CustomerName = customerName;
            CustomerID = customerID;
            CustomerPhone = customerPhone;
            CustomerAddress = customerAddress;
        }

        public Customer(string customerName, int customerID, decimal buyPrice, decimal sellPrice, decimal sellPriceTax, decimal customerPrice, string customerPhone, string customerAddress)
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

        public string CustomerName { get => customerName; set => customerName = value; }
        public string CustomerPhone { get => customerPhone; set => customerPhone = value; }
        public string CustomerAddress { get => customerAddress; set => customerAddress = value; }
        public int CustomerID { get => customerID; set => customerID = value; }
        public decimal BuyPrice { get => buyPrice; set => buyPrice = value; }
        public decimal SellPrice { get => sellPrice; set => sellPrice = value; }
        public decimal SellPriceTax { get => sellPriceTax; set => sellPriceTax = value; }
        public decimal CustomerPrice { get => customerPrice; set => customerPrice = value; }
    }
}
