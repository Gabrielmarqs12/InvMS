using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inv.MS.DAO
{
    class DAOFinancial
    {
        SqlCommand cmd = new SqlCommand();
        Connection con = new Connection();
        SqlDataReader dr;

        public int getFinancialReport(string month)
        {

            //cmd.CommandText = "SELECT SUM ([valor_total]) FROM vendas WHERE data_venda = @month";
            //
            //
            //cmd.Parameters.AddWithValue("@month", month);
            return 2; 
        }
    }
}