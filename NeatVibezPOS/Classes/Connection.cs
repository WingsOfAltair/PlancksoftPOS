using System;
using System.Data.SqlClient;
using System.Data;
using NeatVibezPOS.Properties;
using System.Collections.Generic;
using NeatVibezPOS.NeatVibez_Server;

namespace NeatVibezPOS
{
    public class Connection
    {
        public NeatVibez_ServerClient server;
        public Connection()
        {
            server = new NeatVibez_ServerClient();
        }
    }
}