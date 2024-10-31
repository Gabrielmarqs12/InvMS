using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inv.MS.DAO
{
    class LoginDaoComandos
    {
        public bool access = false;                         //Acesso negado por padrão
        public string message = "";                         //Sem mensagem tudo OK
        SqlCommand cmd = new SqlCommand();
        Conexao con = new Conexao();
        SqlDataReader dr;

        public bool AccessDB(string login, string senha)    //Comandos SQL para acesso aos dados
        {
            cmd.CommandText = "SELECT * FROM vendedor WHERE login = @login and senha = @senha";
            cmd.Parameters.AddWithValue("@login",login);
            cmd.Parameters.AddWithValue("@senha", senha);

            try
            {
                cmd.Connection = con.connect();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    access = true; 
                }
                
            }
            catch (SqlException ex)
            {
                this.message = "Erro com o Banco de dados! erro" + ex;
            }
            return access;
        }

        public string Register(string nome, string login, string senha, string confSenha, string email, string perfil) //Comandos SQL para registro dos dados
        {

            return message;
        }
    }
}
