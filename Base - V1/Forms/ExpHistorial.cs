using Base___V1.Logic;
using Base___V1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Base___V1
{
    public partial class ExpHistorial : Form
    {
        private string idDueño;
        private string idMascota;
        private QuerysSQL data;
        private Mascota m;
        private ExpedienteVistaPrincipal menu;
        public ExpHistorial(string idDueño, string idMascota, ExpedienteVistaPrincipal menu)
        {
            this.idDueño = idDueño;
            this.idMascota = idMascota;
            this.menu = menu;
            InitializeComponent();
            data = new QuerysSQL();
            m = new Mascota();
            m = data.getMascota(int.Parse(idMascota));
            lblNombrePaciente.Text = m.getNombre();

            data.ListarConsultas(tblHistorialConsultas, int.Parse(idMascota));


        }

        private void tblHistorialConsultas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = tblHistorialConsultas.Rows[e.RowIndex];
                string idConsulta = filaSeleccionada.Cells["ConsultaID"].Value.ToString();


                menu.PnlFormLoader2.Controls.Clear();
                ExpNuevaConsulta abrirHistorial = new ExpNuevaConsulta(idDueño, idMascota, false, int.Parse(idConsulta),menu) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                abrirHistorial.FormBorderStyle = FormBorderStyle.None;
                menu.PnlFormLoader2.Controls.Add(abrirHistorial);
                abrirHistorial.Show();
            }
        }
    }
}
