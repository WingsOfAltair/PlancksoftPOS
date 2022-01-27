using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatVibezPOS
{
    internal class Bill
    {
        private int billNumber;
        private decimal remainderAmount, totalAmount, paidAmount;
        private Item[] itemsBought;
        private DateTime date;
        private string cashierName;
        private bool paybycash;

        internal int BillNumber { get => billNumber; set => billNumber = value; }
        internal decimal TotalAmount { get => totalAmount; set => totalAmount = value; }
        internal decimal PaidAmount { get => paidAmount; set => paidAmount = value; }
        internal decimal RemainderAmount { get => remainderAmount; set => remainderAmount = value; }
        internal Item[] ItemsBought { get => itemsBought; set => itemsBought = value; }
        internal DateTime Date { get => date; set => date = value; }
        internal bool PayByCash { get => paybycash; set => paybycash = value; }

        internal Bill()
        {

        }

        internal Bill(int billNumber, decimal totalAmount, Item[] itemsBought, DateTime date)
        {
            BillNumber = billNumber;
            TotalAmount = totalAmount;
            PaidAmount = paidAmount;
            RemainderAmount = remainderAmount;
            ItemsBought = itemsBought;
            PayByCash = paybycash;
            Date = date;
        }

        internal Bill(int billNumber, decimal totalAmount, decimal paidAmount, decimal remainderAmount, Item[] itemsBought, bool paybycash, DateTime date)
        {
            BillNumber = billNumber;
            TotalAmount = totalAmount;
            PaidAmount = paidAmount;
            RemainderAmount = remainderAmount;
            ItemsBought = itemsBought;
            PayByCash = paybycash;
            Date = date;
        }

        internal Bill(int billNumber, decimal totalAmount, decimal paidAmount, decimal remainderAmount, Item[] itemsBought, DateTime date)
        {
            BillNumber = billNumber;
            TotalAmount = totalAmount;
            PaidAmount = paidAmount;
            RemainderAmount = remainderAmount;
            ItemsBought = itemsBought;
            Date = date;
        }

        internal string getCashierName()
        {
            return this.cashierName;
        }

        internal int getBillNumber()
        {
            return this.BillNumber;
        }
        
        internal decimal getTotalAmount()
        {
            return this.TotalAmount;
        }

        internal decimal getPaidAmount()
        {
            return this.PaidAmount;
        }

        internal decimal getRemainderAmount()
        {
            return this.RemainderAmount;
        }

        internal Item[] getItemsList()
        {
            return this.ItemsBought;
        }

        internal DateTime getDate()
        {
            return this.Date;
        }

        internal void SetCashierName(string cashierName)
        {
            this.cashierName = cashierName;
        }

        internal void SetBillNumber(int BillNumber)
        {
            this.BillNumber = BillNumber;
        }

        internal void SetTotalAmount(decimal TotalAmount)
        {
            this.TotalAmount = TotalAmount;
        }

        internal void SetPaidAmount(decimal PaidAmount)
        {
            this.PaidAmount = PaidAmount;
        }

        internal void SetRemainderAmount(decimal RemainderAmount)
        {
            this.RemainderAmount = RemainderAmount;
        }

        internal void SetItemsList(Item[] ItemsList)
        {
            this.ItemsBought = ItemsList;
        }

        internal void SetDate(DateTime Date)
        {
            this.Date = Date;
        }
    }
}
