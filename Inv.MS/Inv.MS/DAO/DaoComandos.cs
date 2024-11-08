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
                con.disconnnect();
                dr.Close(); 
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
                con.disconnnect();
                dr.Close();
            }
            catch (SqlException ex)
            {
                this.message = "Erro com o Banco de dados! erro" + ex;
            }
            return recovery;
        }

        public bool RecoveryData(string email)    //Comandos SQL, retornando login e senha
        {
            cmd.CommandText = "SELECT * FROM vendedor WHERE emal = @email";
            cmd.Parameters.AddWithValue("@email", email);

            try
            {
                cmd.Connection = con.connect();
                dr = cmd.ExecuteReader();
                dr.Read();
                
                con.disconnnect();
                dr.Close();
                
                return true;    //Necessita alteração de valor no codigo, não esquecer
            }
            catch (SqlException ex)
            {
                this.message = "Erro com o Banco de dados! erro" + ex;
            }
            return true;        //Necessita alteração de valor no codigo, não esquecer
        }

        public string Register(string nome, string login, string senha, string confSenha, string email, string perfil) //Comandos SQL para registro dos dados
        {
            access = false;
            if (senha.Equals(confSenha))
            {
                cmd.CommandText = "INSERT INTO vendedor VALUES (@n, @l, @s, @e, @p);";
                cmd.Parameters.AddWithValue("@n", nome);
                cmd.Parameters.AddWithValue("@l", login);
                cmd.Parameters.AddWithValue("@s", senha);
                cmd.Parameters.AddWithValue("@e", email);
                cmd.Parameters.AddWithValue("@p", perfil);

                try
                {
                    cmd.Connection = con.connect();
                    cmd.ExecuteNonQuery();

                    con.disconnnect();
                    this.message = "Cadastro criado com sucesso";
                    access = true;
                }
                catch (SqlException ex)
                {
                    this.message = "Erro com o Banco de dados! erro" + ex;
                }
            }
            else
            {
                this.message = "Senhas não correspondem";
            }

            return message;
        }
    }
}
