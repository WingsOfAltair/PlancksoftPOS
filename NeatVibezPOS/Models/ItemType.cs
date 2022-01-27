using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatVibezPOS
{
    internal class ItemType
    {
        internal string Name;
        internal int ID;

        internal ItemType(int iD)
        {
            ID = iD;
        }

        internal ItemType(int iD, string name)
        {
            Name = name;
            ID = iD;
        }
    }
}
