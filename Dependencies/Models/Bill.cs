﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dependencies
{
    [DataContract]
    public class Bill
    {
        [DataMember]
        public bool isVendor;
        [DataMember]
        private bool postponed;
        [DataMember]
        private int clientID;
        [DataMember]
        public int billNumber;
        [DataMember]
        public decimal remainderAmount, totalAmount, paidAmount, discountAmount;
        [DataMember]
        public List<Item> itemsBought;
        [DataMember]
        public DateTime date;
        [DataMember]
        private string cashierName;   
        [DataMember]
        private string cashName;
        [DataMember]
        public bool paybycash;
        [DataMember]
        private string clientName;
        [DataMember]
        private string clientPhone;
        [DataMember]
        private string clientAddress;   
        [DataMember]
        private string clientEmail;
        [DataMember]
        private string taxID;

        [DataMember]
        public int BillNumber { get => billNumber; set => billNumber = value; }
        [DataMember]
        public string TaxID { get => taxID; set => taxID = value; }
        [DataMember]
        public decimal TotalAmount { get => totalAmount; set => totalAmount = value; }
        [DataMember]
        public decimal DiscountAmount { get => discountAmount; set => discountAmount = value; }
        [DataMember]
        public decimal PaidAmount { get => paidAmount; set => paidAmount = value; }
        [DataMember]
        public decimal RemainderAmount { get => remainderAmount; set => remainderAmount = value; }
        [DataMember]
        public List<Item> ItemsBought { get => itemsBought; set => itemsBought = value; }
        [DataMember]
        public DateTime Date { get => date; set => date = value; }
        [DataMember]
        public bool PayByCash { get => paybycash; set => paybycash = value; }
        [DataMember]
        public bool Postponed { get => postponed; set => postponed = value; }
        [DataMember]
        public int ClientID { get => clientID; set => clientID = value; }
        public string ClientName { get => clientName; set => clientName = value; }
        public string ClientPhone { get => clientPhone; set => clientPhone = value; }
        public string ClientAddress { get => clientAddress; set => clientAddress = value; }
        public string ClientEmail { get => clientEmail; set => clientEmail = value; }
        public string CashierName { get => cashierName; set => cashierName = value; }
        public string CashName { get => cashName; set => cashName = value; }
        public bool IsVendor { get => isVendor; set => isVendor = value; }

        public Bill()
        {

        }

        public Bill(int billNumber, decimal totalAmount, List<Item> itemsBought, DateTime date)
        {
            if (BillNumber > -1)
            {
                BillNumber = billNumber;
            }
            TotalAmount = totalAmount;
            PaidAmount = paidAmount;
            RemainderAmount = remainderAmount;
            ItemsBought = itemsBought;
            PayByCash = paybycash;
            Date = date;
        }

        public Bill(int billNumber, decimal totalAmount, decimal paidAmount, decimal remainderAmount, decimal discounedAmount, string taxID, List<Item> itemsBought, bool paybycash, DateTime date, string cashierName, string cashName)
        {
            if (BillNumber > -1)
            {
                BillNumber = billNumber;
            }
            TotalAmount = totalAmount;
            PaidAmount = paidAmount;
            RemainderAmount = remainderAmount;
            ItemsBought = itemsBought;
            PayByCash = paybycash;
            Date = date;
            CashierName = cashierName;
            TaxID = taxID;
            DiscountAmount = discounedAmount;
            CashName = cashName;
        }

        public Bill(int billNumber, decimal totalAmount, decimal paidAmount, decimal remainderAmount, decimal discountedAmount, string taxID, List<Item> itemsBought, DateTime date, string cashName)
        {
            if (BillNumber > -1)
            {
                BillNumber = billNumber;
            }
            TotalAmount = totalAmount;
            PaidAmount = paidAmount;
            RemainderAmount = remainderAmount;
            ItemsBought = itemsBought;
            Date = date;
            TaxID = taxID;
            DiscountAmount = discountedAmount;
            CashName = cashName;
        }

        public Bill(int billNumber, decimal totalAmount, decimal paidAmount, decimal remainderAmount, List<Item> itemsBought, DateTime date, string cashName)
        {
            if (BillNumber > -1)
            {
                BillNumber = billNumber;
            }
            TotalAmount = totalAmount;
            PaidAmount = paidAmount;
            RemainderAmount = remainderAmount;
            ItemsBought = itemsBought;
            Date = date;
            CashName = cashName;
        }

        public string getCashierName()
        {
            return this.CashierName;
        }          

        public string getClientName()
        {
            return this.ClientName;
        }

        public int getBillNumber()
        {
            return this.BillNumber;
        }
        
        public decimal getTotalAmount()
        {
            return this.TotalAmount;
        }

        public decimal getPaidAmount()
        {
            return this.PaidAmount;
        }

        public decimal getRemainderAmount()
        {
            return this.RemainderAmount;
        }

        public List<Item> getItemsList()
        {
            return this.ItemsBought;
        }

        public DateTime getDate()
        {
            return this.Date;
        }

        public Boolean getPayByCash()
        {
            return this.PayByCash;
        }

        public void SetCashierName(string cashierName)
        {
            this.CashierName = cashierName;
        } 

        public void SetClientName(string clientName)
        {
            this.ClientName = clientName;
        }

        public void SetBillNumber(int BillNumber)
        {
            this.BillNumber = BillNumber;
        }

        public void SetTotalAmount(decimal TotalAmount)
        {
            this.TotalAmount = TotalAmount;
        }

        public void SetPaidAmount(decimal PaidAmount)
        {
            this.PaidAmount = PaidAmount;
        }

        public void SetRemainderAmount(decimal RemainderAmount)
        {
            this.RemainderAmount = RemainderAmount;
        }

        public void SetItemsList(List<Item> ItemsList)
        {
            this.ItemsBought = ItemsList;
        }

        public void SetDate(DateTime Date)
        {
            this.Date = Date;
        }

        public void SetPayByCash(bool PayByCash)
        {
            this.PayByCash = PayByCash;
        }
    }
}
