using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    [DataContract]
    public class ItemType
    {
        [DataMember]
        public string Name;
        [DataMember]
        public int ID;

        public ItemType(int iD)
        {
            ID = iD;
        }

        public ItemType(int iD, string name)
        {
            Name = name;
            ID = iD;
        }
    }
}
