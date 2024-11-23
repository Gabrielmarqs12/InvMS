using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inv.MS.DAO
{
    class DAOProduct
    {
        public decimal valor;                               //Retorna null por padrão
        SqlCommand cmd = new SqlCommand();
        Connection con = new Connection();
        SqlDataReader dr;

        public decimal getDataSum(string selectDate)              //Soma os valores da tabela venda de acordo com a data selecionada
        {
            cmd.CommandText = "SELECT SUM([valor]) FROM venda WHERE data_venda = @selectDate;";
            cmd.Parameters.AddWithValue("@selectDate", selectDate);

            try
            {
                cmd.Connection = con.connect();
                dr = cmd.ExecuteReader();
                dr.Read();

                valor = dr.GetDecimal(0);

                con.disconnnect();
                dr.Close();

                return valor;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro com o Banco de dados " + ex);
            }
            return valor;
        }

        public int listCounter(string DB)
        {
            return 2;
        }
    }
}
