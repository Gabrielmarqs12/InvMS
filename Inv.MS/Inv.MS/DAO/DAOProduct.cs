using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inv.MS.DAO
{
    class DAOProduct
    {
        public decimal valor = 0;                               //Retorna null por padrão
        SqlCommand cmd;
        Connection con = new Connection();
        SqlDataReader dr;

        public decimal getDataSum(string selectDate)            //Soma os valores da tabela venda de acordo com a data selecionada
        {

            cmd = new SqlCommand();

            cmd.CommandText = "SELECT SUM([valor]) FROM venda WHERE data_venda = @selectDate";
            cmd.Parameters.AddWithValue("@selectDate", selectDate);

            try
            {
                cmd.Connection = con.connect();
                dr = cmd.ExecuteReader();

                if (dr.Read()) 
                {
                    if (!dr.IsDBNull(0))
                    {
                        valor = dr.GetDecimal(0);
                    }
                }

                con.disconnnect();
                dr.Close();
                return valor;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de dados " + ex);
                con.disconnnect();
                dr.Close();
            }

            return valor;
        }

        public int listCounter(string DB)
        {
            return 2;
        }
    }
}
