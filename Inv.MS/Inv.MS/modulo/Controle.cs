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

        public bool Access(string login, string senha) //Verificação de acesso ao aplicativo com os dados do servidor
        {
            DaoComandos LoginDao = new DaoComandos();
            result = LoginDao.AccessDBLogin(login, senha);
            if (!LoginDao.message.Equals(""))
            {
                this.result = LoginDao.access;
            }
            return result;
        }

        public string Register(string nome, string login, string senha, string confSenha, string email, string perfil) 
        {
            DaoComandos LoginDao = new DaoComandos();
            this.message = LoginDao.Register(nome, login, senha, confSenha, email, perfil);

            if (LoginDao.access)
            {
                this.result = true;
            }
            return message;
        }
    }
}
