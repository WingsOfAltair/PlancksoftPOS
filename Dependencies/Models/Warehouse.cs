using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dependencies
{
    [DataContract]
    public class Warehouse
    {
        [DataMember]
        public string Name;
        [DataMember]
        public int ID;

        public Warehouse(int iD)
        {
            ID = iD;
        }

        public Warehouse(int iD, string name)
        {
            Name = name;
            ID = iD;
        }
    }
}
