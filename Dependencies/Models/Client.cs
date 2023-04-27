using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dependencies
{
    [DataContract]
    public class Client
    {
        [DataMember]
        public int clientID;
        [DataMember]
        public string clientName, clientPhone, clientAddress;
        [DataMember]
        public decimal buyPrice, sellPrice, sellPriceTax, clientPrice;

        public Client()
        { }

        public Client(string ClientName, int ClientID, string ClientPhone, string ClientAddress)
        {
            this.ClientName = ClientName;
            this.ClientID = ClientID;
            this.ClientPhone = ClientPhone;
            this.ClientAddress = ClientAddress;
        }

        public Client(string ClientName, int ClientID, decimal buyPrice, decimal sellPrice, decimal sellPriceTax, decimal ClientPrice, string ClientPhone, string ClientAddress)
        {
            this.ClientName = ClientName;
            this.ClientID = ClientID;
            BuyPrice = buyPrice;
            SellPrice = sellPrice;
            SellPriceTax = sellPriceTax;
            this.ClientPrice = ClientPrice;
            this.ClientPhone = ClientPhone;
            this.ClientAddress = ClientAddress;
        }

        public string ClientName { get => clientName; set => clientName = value; }
        public string ClientPhone { get => clientPhone; set => clientPhone = value; }
        public string ClientAddress { get => clientAddress; set => clientAddress = value; }
        public int ClientID { get => clientID; set => clientID = value; }
        public decimal BuyPrice { get => buyPrice; set => buyPrice = value; }
        public decimal SellPrice { get => sellPrice; set => sellPrice = value; }
        public decimal SellPriceTax { get => sellPriceTax; set => sellPriceTax = value; }
        public decimal ClientPrice { get => clientPrice; set => clientPrice = value; }
    }
}
