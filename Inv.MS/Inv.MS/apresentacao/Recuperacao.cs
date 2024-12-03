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
    public partial class frmRecuperacao : Form
    {
        public string key;
        public string email;
        public frmRecuperacao()
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
            DAOUser RecoveryDao = new DAOUser();
            KeyGen KeyG = new KeyGen();

            email = txtEmail.Text;
            key = KeyG.Generate();

            RecoveryDao.AccessDBRecovery(email);
            if(RecoveryDao.recovery)
            {
                EMailSender.Send(email, key);
            }
            else
            {
                MessageBox.Show("Email invalido no sistema");
            }
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            DAOUser RecoveryDao = new DAOUser();

            string CODE = txtCodigo.Text;

            if(CODE == key)
            {
                var recoveryValues = RecoveryDao.RecoveryData(email);
                lblLoginRec.Text = recoveryValues[0].ToString();
                lblSenhaRec.Text = recoveryValues[1].ToString();
            }
        }
    }
}
