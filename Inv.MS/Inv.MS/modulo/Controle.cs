using Inv.MS.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inv.MS.modulo
{
    public class Controle
    {
        public bool result;
        public string message = "";

        public bool Access(string login, string senha) //Verificação de acesso do servidor
        {
            LoginDaoComandos LoginDao = new LoginDaoComandos();
            result = LoginDao.AccessDB(login, senha);
            if (!LoginDao.message.Equals(""))
            {
                this.result = LoginDao.access;
            }
            return result;
        }

        public string Register(string nome, string login, string senha, string confSenha, string email, string perfil) 
        {

            return message;
        }
    }
}
