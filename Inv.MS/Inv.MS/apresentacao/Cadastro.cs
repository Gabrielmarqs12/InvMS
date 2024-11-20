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
    public partial class Cadastro : Form
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cadastro_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Inv.MS.modulo.Controle ctrl = new Inv.MS.modulo.Controle();
            string message = ctrl.Register(txtNome.Text, txtLogin.Text, txtSenha.Text, txtConfSenha.Text, txtEmail.Text, cmbPerfil.Text);

            if (ctrl.result)
            {
                MessageBox.Show(message, "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(ctrl.message);
            }
            this.Close();
        }
    }
}
