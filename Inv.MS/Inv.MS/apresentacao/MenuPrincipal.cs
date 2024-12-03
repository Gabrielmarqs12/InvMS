using Inv.MS.apresentacao;
using Inv.MS.DAO;
using Inv.MS.function;
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
    public partial class frmMenuPrincipal : Form
    {
        private Form frmAtivo;
        DAOProduct user = new DAOProduct();

        public frmMenuPrincipal(string username)
        {
            InitializeComponent();
            this.lblNome.Text = username;
        }

        private void FormShow(Form frm)
        {
            ActiveFormClose();
            frmAtivo = frm;
            frm.TopLevel = false;
            panelHome.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void ActiveFormClose()
        {
            if (frmAtivo != null) frmAtivo.Close();

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ActiveFormClose();
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            FormShow(new frmPedidos());
        }

        private void btnEstoque_Click(object sender, EventArgs e)
        {
            FormShow(new frmEstoque());
        }

        private void btnFinanceiro_Click(object sender, EventArgs e)
        {
            frmFinanceiro financeiro = new frmFinanceiro();
            financeiro.Show();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            lblVendas.Text = user.getDataSum(DateTime.Today.ToString("d")).ToString();
        }

        private void tmrRelogio_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            lblVendas.Text = user.getDataSum(DateTime.Today.ToString("d")).ToString();
        }
    }
}
