using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Base___V1
{
    public partial class ExpedienteVistaPrincipal : Form
    {
        public ExpedienteVistaPrincipal()
        {
            InitializeComponent();

            this.PnlFormLoader2.Controls.Clear();
            ExpInfo infoGeneral = new ExpInfo() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            infoGeneral.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader2.Controls.Add(infoGeneral);
            infoGeneral.Show();
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            this.PnlFormLoader2.Controls.Clear();
            ExpHistorial abrirHistorial = new ExpHistorial() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            abrirHistorial.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader2.Controls.Add(abrirHistorial);
            abrirHistorial.Show();
        }

        private void btnNewConsulta_Click(object sender, EventArgs e)
        {
            this.PnlFormLoader2.Controls.Clear();
            ExpNuevaConsulta agregarConsulta = new ExpNuevaConsulta() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            agregarConsulta.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader2.Controls.Add(agregarConsulta);
            agregarConsulta.Show();
        }

        private void btnNewExamen_Click(object sender, EventArgs e)
        {
            this.PnlFormLoader2.Controls.Clear();
            ExpNuevoExamen agregarExamen = new ExpNuevoExamen() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            agregarExamen.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader2.Controls.Add(agregarExamen);
            agregarExamen.Show();
        }

        private void btnVacunas_Click(object sender, EventArgs e)
        {
            this.PnlFormLoader2.Controls.Clear();
            ExpVacunas controlarVacunas = new ExpVacunas() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            controlarVacunas.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader2.Controls.Add(controlarVacunas);
            controlarVacunas.Show();
        }
    }
}
