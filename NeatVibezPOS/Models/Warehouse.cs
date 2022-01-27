using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatVibezPOS
{
    internal class Warehouse
    {
        internal string Name;
        internal int ID;

        internal Warehouse(int iD)
        {
            ID = iD;
        }

        internal Warehouse(int iD, string name)
        {
            Name = name;
            ID = iD;
        }
    }
}
