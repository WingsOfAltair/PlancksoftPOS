using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using PlancksoftPOS_Receipt_Print_Server.PlancksoftPOS_Server;

namespace PlancksoftPOS_Receipt_Print_Server
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