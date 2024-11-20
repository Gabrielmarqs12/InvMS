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
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            DAOUser user = new DAOUser();


            WindowState = FormWindowState.Maximized;

            lblNome.Text = user.getName();

            chtResumo.Series.Add("vendas");
            chtResumo.Series["vendas"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chtResumo.Series["vendas"].BorderWidth = 4;
            
            chtResumo.Series["vendas"].Points.AddXY("Janeiro", 300);
            chtResumo.Series["vendas"].Points.AddXY("Fevereiro", 500);
            chtResumo.Series["vendas"].Points.AddXY("Março", 450);
            chtResumo.Series["vendas"].Points.AddXY("Abril", 600);
            chtResumo.Series["vendas"].Points.AddXY("Maio", 500);
            chtResumo.Series["vendas"].Points.AddXY("Junho", 900);
            chtResumo.Series["vendas"].Points.AddXY("Julho", 850);
            chtResumo.Series["vendas"].Points.AddXY("Agosto", 0);
            chtResumo.Series["vendas"].Points.AddXY("Setembro", 0);
            chtResumo.Series["vendas"].Points.AddXY("Outrubro", 0);
            chtResumo.Series["vendas"].Points.AddXY("Novembro", 0);
            chtResumo.Series["vendas"].Points.AddXY("Dezembro", 0);



        }
    }
}
