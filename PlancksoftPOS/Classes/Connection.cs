using System;
using System.Data.SqlClient;
using System.Data;
using PlancksoftPOS.Properties;
using System.Collections.Generic;
using PlancksoftPOS.PlancksoftPOS_Server;

namespace PlancksoftPOS
{
    public class Connection
    {
        public PlancksoftPOS_ServerClient server;
        public Connection()
        {
            server = new PlancksoftPOS_ServerClient("BasicHttpsBinding_IPlancksoftPOS_Server");
        }
    }
}