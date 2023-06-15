using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Context
{
    public class TesteConn
    {
        
        private static string _connString = "Server=192.168.146.42 ;Userid=pgsql;Password=magic55;Pooling=false;MinPoolSize=1;MaxPoolSize=20;Timeout=1000;SslMode=Disable;Database=siclonet";
        
        public static string ConnStringa
        {
            get
            {
                return _connString;
            }
        }
    }
}
