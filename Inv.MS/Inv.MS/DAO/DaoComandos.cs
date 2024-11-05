using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inv.MS.DAO
{
    class DaoComandos
    {
        public bool recovery = false;                       //Nenhum email pesquisado por padrão
        public bool access = false;                         //Acesso negado por padrão
        public string message = "";                         //Sem mensagem tudo OK
        SqlCommand cmd = new SqlCommand();
        Conexao con = new Conexao();
        SqlDataReader dr;

        public bool AccessDBLogin(string login, string senha)    //Comandos SQL, retornando verdadeiro se login e senha OK
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

        public bool AccessDBRecovery(string email)    //Comandos SQL, retornando verdadeiro se email OK
        {
            cmd.CommandText = "SELECT * FROM vendedor WHERE emal = @email";
            cmd.Parameters.AddWithValue("@email", email);

            try
            {
                cmd.Connection = con.connect();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    recovery = true;
                }

            }
            catch (SqlException ex)
            {
                this.message = "Erro com o Banco de dados! erro" + ex;
            }
            return recovery;
        }

        public bool RecoveryData(string email)    //Comandos SQL, retornandologin e senha se email OK
        {
            cmd.CommandText = "SELECT * FROM vendedor WHERE emal = @email";
            cmd.Parameters.AddWithValue("@email", email);

            try
            {
                cmd.Connection = con.connect();
                dr = cmd.ExecuteReader();
                dr.Read();

                return;
                
            }
            catch (SqlException ex)
            {
                this.message = "Erro com o Banco de dados! erro" + ex;
            }
            return;
        }

        public string Register(string nome, string login, string senha, string confSenha, string email, string perfil) //Comandos SQL para registro dos dados
        {

            return message;
        }
    }
}
