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
        private Menu menu2;
        public ExpHistorial(string idDueño, string idMascota, ExpedienteVistaPrincipal menu, Menu menu2)
        {
            this.idDueño = idDueño;
            this.idMascota = idMascota;
            this.menu = menu;
            this.menu2 = menu2;
            InitializeComponent();
            data = new QuerysSQL();
            menu2.textBox1.TextChanged += txtbusqueda;
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

                menu2.textBox1.TextChanged -= txtbusqueda;
                menu.PnlFormLoader2.Controls.Clear();
                menu2.textBox1.Text = "";
                menu2.SetPlaceholder(menu2.textBox1, "Busca algo...");
                ExpNuevaConsulta abrirHistorial = new ExpNuevaConsulta(idDueño, idMascota, false, int.Parse(idConsulta),menu) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                abrirHistorial.FormBorderStyle = FormBorderStyle.None;
                menu.PnlFormLoader2.Controls.Add(abrirHistorial);
                abrirHistorial.Show();
            }
        }
        private void txtbusqueda(object sender, EventArgs e) {

            if(menu2.textBox1.Text != "" || menu2.textBox1.Text != "Busca algo...")
            {
                data.ListarConsultasBusqueda(tblHistorialConsultas, int.Parse(idMascota), menu2.textBox1.Text);
            }
            else
            {
                data.ListarConsultas(tblHistorialConsultas, int.Parse(idMascota));
            }
        
        }
    }
}
