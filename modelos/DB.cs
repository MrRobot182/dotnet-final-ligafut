using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LigaFutbol
{
    public class DB
    {
        private string cstr;
        private SqlConnection conn;
        public DB()
        {
            this.cstr = "Data Source=localhost;Initial Catalog=liga_futbol;Integrated Security=True";
            this.conn = new SqlConnection(this.cstr);
        }

        public SqlConnection Conn
        {
            get { return conn; }
        }
        
    }
}