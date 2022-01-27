using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatVibezPOS
{
    internal class Category
    {
        internal string Name;
        internal int ID;

        internal Category(int iD)
        {
            ID = iD;
        }

        internal Category(int iD, string name)
        {
            Name = name;
            ID = iD;
        }
    }
}
