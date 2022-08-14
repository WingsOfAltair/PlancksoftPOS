using System;
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
        public int billNumber;
        [DataMember]
        public decimal remainderAmount, totalAmount, paidAmount;
        [DataMember]
        public Item[] itemsBought;
        [DataMember]
        public DateTime date;
        [DataMember]
        public string cashierName;
        [DataMember]
        public bool paybycash;

        [DataMember]
        public int BillNumber { get => billNumber; set => billNumber = value; }
        [DataMember]
        public decimal TotalAmount { get => totalAmount; set => totalAmount = value; }
        [DataMember]
        public decimal PaidAmount { get => paidAmount; set => paidAmount = value; }
        [DataMember]
        public decimal RemainderAmount { get => remainderAmount; set => remainderAmount = value; }
        [DataMember]
        public Item[] ItemsBought { get => itemsBought; set => itemsBought = value; }
        [DataMember]
        public DateTime Date { get => date; set => date = value; }
        [DataMember]
        public bool PayByCash { get => paybycash; set => paybycash = value; }

        public Bill()
        {

        }

        public Bill(int billNumber, decimal totalAmount, Item[] itemsBought, DateTime date)
        {
            BillNumber = billNumber;
            TotalAmount = totalAmount;
            PaidAmount = paidAmount;
            RemainderAmount = remainderAmount;
            ItemsBought = itemsBought;
            PayByCash = paybycash;
            Date = date;
        }

        public Bill(int billNumber, decimal totalAmount, decimal paidAmount, decimal remainderAmount, Item[] itemsBought, bool paybycash, DateTime date)
        {
            BillNumber = billNumber;
            TotalAmount = totalAmount;
            PaidAmount = paidAmount;
            RemainderAmount = remainderAmount;
            ItemsBought = itemsBought;
            PayByCash = paybycash;
            Date = date;
        }

        public Bill(int billNumber, decimal totalAmount, decimal paidAmount, decimal remainderAmount, Item[] itemsBought, DateTime date)
        {
            BillNumber = billNumber;
            TotalAmount = totalAmount;
            PaidAmount = paidAmount;
            RemainderAmount = remainderAmount;
            ItemsBought = itemsBought;
            Date = date;
        }

        public string getCashierName()
        {
            return this.cashierName;
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

        public Item[] getItemsList()
        {
            return this.ItemsBought;
        }

        public DateTime getDate()
        {
            return this.Date;
        }

        public void SetCashierName(string cashierName)
        {
            this.cashierName = cashierName;
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

        public void SetItemsList(Item[] ItemsList)
        {
            this.ItemsBought = ItemsList;
        }

        public void SetDate(DateTime Date)
        {
            this.Date = Date;
        }
    }
}
