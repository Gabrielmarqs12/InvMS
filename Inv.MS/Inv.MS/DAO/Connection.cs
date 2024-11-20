using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Inv.MS.DAO
{
    public class Connection
    {

        SqlConnection con = new SqlConnection();

        public Connection()
        {
            con.ConnectionString = @"Data Source=GABRIEL;Initial Catalog=invms;Integrated Security=True;";
        }

        public SqlConnection connect()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        public void disconnnect()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            
        }
    }
}
