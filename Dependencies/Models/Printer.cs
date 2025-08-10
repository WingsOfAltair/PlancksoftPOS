﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dependencies
{
    [DataContract]
    public class Printer
    {
        [DataMember]
        public string MachineName;
        [DataMember]
        public string Name;
        [DataMember]
        public int ID;

        public Printer(int iD)
        {
            ID = iD;
        }

        public Printer(int iD, string name, string machineName)
        {
            Name = name;
            ID = iD;
            MachineName = machineName;
        }
    }
}
