using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Inv.MS.DAO
{
    class DAOUser
    {
        public bool recovery = false;                       //Nenhum email pesquisado por padrão
        public bool access = false;                         //Acesso negado por padrão
        public string message = "";                         //Sem mensagem tudo OK
        SqlCommand cmd = new SqlCommand();
        Connection con = new Connection();
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
            cmd.CommandText = "SELECT * FROM vendedor WHERE email = @email";
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

        public object[] RecoveryData(string email)    //Comandos SQL, retornando login e senha via objeto
        {

            cmd.CommandText = "SELECT * FROM vendedor WHERE email = @email";
            cmd.Parameters.AddWithValue("@email", email);

            try
            {
                cmd.Connection = con.connect();
                dr = cmd.ExecuteReader();
                dr.Read();

                var result = new object[] {dr.GetString(2), dr.GetString(3)};

                con.disconnnect();
                dr.Close();

                return result;    
            }
            catch (SqlException ex)
            {
                this.message = "Erro com o Banco de dados! erro" + ex;
            }
            return null;
        }

        public string getName(string user)
        {
            cmd.CommandText = "SELECT * FROM vendedor WHERE login = @login";
            cmd.Parameters.AddWithValue("@login", user);

            try
            {
                cmd.Connection = con.connect();
                dr = cmd.ExecuteReader();
                dr.Read();

                string name = dr.GetString(1);

                con.disconnnect();
                dr.Close();

                return name;
            }
            catch (SqlException ex)
            {
                this.message = "Erro com o Banco de dados! erro" + ex;
            }

            return "Username ERROR";
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
