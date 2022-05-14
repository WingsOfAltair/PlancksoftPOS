using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dependencies
{
    [DataContract]
    public class Account
    {
        [DataMember]
        public string uid, pwd, name;
        [DataMember]
        public int authority;
        [DataMember]
        public bool customer_card_edit, discount_edit, price_edit, receipt_edit, inventory_edit, expenses_add, users_edit, settings_edit, personnel_edit, openclose_edit;
        [DataMember]
        public string Uid { get => uid; set => uid = value; }
        [DataMember]
        public string Pwd { get => pwd; set => pwd = value; }
        [DataMember]
        public string Name { get => name; set => name = value; }
        [DataMember]
        public int Authority { get => authority; set => authority = value; }

        public void SetAccountUID(string uid)
        {
            this.Uid = uid;
        }

        public void SetAccountPWD(string pwd)
        {
            this.Pwd = DataAccessLayer.MD5Encryption.Encrypt(pwd, "NeatVibezPOS");
        }

        public void SetAccountName(string name)
        {
            this.Name = name;
        }

        public void SetAccountAuthority(int authority)
        {
            this.Authority = authority;
        }

        public string GetAccountUID()
        {
            return this.Uid;
        }

        public string GetAccountPWD()
        {
            return this.Pwd;
        }

        public string GetAccountName()
        {
            return this.Name;
        }

        public int GetAccountAuthority()
        {
            return this.Authority;
        }
    }
}
