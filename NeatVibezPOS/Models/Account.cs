using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatVibezPOS
{
    internal class Account
    {
        private string uid, pwd, name;
        private int authority;
        public bool customer_card_edit, discount_edit, price_edit, receipt_edit, inventory_edit, expenses_add, users_edit, settings_edit, personnel_edit, openclose_edit;

        private string Uid { get => uid; set => uid = value; }
        private string Pwd { get => pwd; set => pwd = value; }
        private string Name { get => name; set => name = value; }
        private int Authority { get => authority; set => authority = value; }

        internal void SetAccountUID(string uid)
        {
            this.Uid = uid;
        }

        internal void SetAccountPWD(string pwd)
        {
            this.Pwd = MD5Encryption.Encrypt(pwd, "NeatVibezPOS");
        }

        internal void SetAccountName(string name)
        {
            this.Name = name;
        }

        internal void SetAccountAuthority(int authority)
        {
            this.Authority = authority;
        }

        internal string GetAccountUID()
        {
            return this.Uid;
        }

        internal string GetAccountPWD()
        {
            return this.Pwd;
        }

        internal string GetAccountName()
        {
            return this.Name;
        }

        internal int GetAccountAuthority()
        {
            return this.Authority;
        }
    }
}
