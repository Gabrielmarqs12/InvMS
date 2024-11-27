using Cellar_Managment_System.Apresentacao;
using Inv.MS.DAO;
using Inv.MS.modulo;
using System;
using System.Windows.Forms;

namespace Cellar_Managment_System
{
    public partial class frmLogin : Form
    {
        public bool LoginComplete { get; private set; } = false;
        public string firstName { get; private set; }
        public frmLogin()
        {
            InitializeComponent();
        }

        public string getName()
        {
            DAOUser DAO = new DAOUser();
            return DAO.getName(txtLogin.Text);

        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtLogin.Select();
        }

        private void lnkCadastro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cadastro cadastro = new Cadastro();
            cadastro.ShowDialog();
        }

        private void lnkSenha_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Recuperacao recuperacao = new Recuperacao();
            recuperacao.ShowDialog();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Controle ctrl = new Controle();

            ctrl.Access(txtLogin.Text, txtSenha.Text);
            if (ctrl.message.Equals(""))
            {
                if (ctrl.result)
                {
                    LoginComplete = true;
                    firstName = getName();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Acesso Negado. Por favor verifique login e senha !");
                }
            }
            else
            {
                MessageBox.Show(ctrl.message);
            }
        }
    }
}