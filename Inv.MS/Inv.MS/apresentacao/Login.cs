using Cellar_Managment_System.Apresentacao;
using Inv.MS.modulo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cellar_Managment_System
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            txtLogin.Focus();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            
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
                    MenuPrincipal MP = new MenuPrincipal();
                    MP.ShowDialog();
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