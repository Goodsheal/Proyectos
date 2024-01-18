using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public abstract class DbConnection
    {
        public static string cn = "Server=DESKTOP-Q3EDHRN; DataBase=dbventas; Integrated Security=true";
        private readonly string connectionString;


        public DbConnection()

        {
            connectionString = cn;
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

    }
}
