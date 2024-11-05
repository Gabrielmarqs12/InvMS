using Inv.MS.DAO;
using Inv.MS.function;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cellar_Managment_System.Apresentacao
{
    public partial class Recuperacao : Form
    {
        public int key;
        public Recuperacao()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Recuperacao_Load(object sender, EventArgs e)
        {
            
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            DaoComandos RecoveryDao = new DaoComandos();
            KeyGen KeyG = new KeyGen();

            RecoveryDao.AccessDBRecovery(email);
            if(RecoveryDao.recovery)
            {
                key = KeyG.Generate();
                EMailSender.Send(email, key);
            }
            else
            {
                MessageBox.Show("Email invalido no sistema");
            }
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            string CODE = txtCodigo.Text;
            if(CODE == key) 
            {
                
            }
        }
    }
}
