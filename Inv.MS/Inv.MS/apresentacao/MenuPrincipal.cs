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

        DAOProduct user = new DAOProduct();

        public frmMenuPrincipal(string username)
        {
            InitializeComponent();
            this.lblNome.Text = username;
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
