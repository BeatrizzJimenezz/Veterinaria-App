using Base___V1.Forms;
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

namespace Base___V1
{
    public partial class ExpVacunas : Form
    {
        private int idMascota;
        private QuerysSQL data;
        public ExpVacunas(int idMascota)
        {
            this.idMascota = idMascota;
            data = new QuerysSQL();
            InitializeComponent();

            Mascota m = data.getMascota(idMascota);
            lblNombrePaciente.Text = m.getNombre();
        }

        #region Generar los widgets

        public void GenerateDynamicWidget()
        {
            List<Vacunas> dataVacunas = data.obtenerVacunas(idMascota);
            flowLayoutPanel1.Controls.Clear();

            WidgetVacuna[] listItems = new WidgetVacuna[dataVacunas.Count];

            /*string[] fecha = new string[4] { "16 de mayo de 2024", "23 de agosto de 2024", "4 de septiembre de 2024", "15 de mayo de 2024" };

            string[] revacunacion = new string[4] { "16 de agosto de 2025", "23 de julio de 2025", "4 de diciembre de 2026", "15 de agosto de 2025" };

            string[] vacuna = new string[4] { "Rabia", "Leucemia", "Vitaminas", "Rabiaza" };

            string[] doctor = new string[4] { "Sancho Panza", "Beatriz Jimenez", "Juanito Alvarez", "Sanchos Panzas" };

            for (int i = 0; i < listItems.Length; i++)
            {
                listItems[i] = new WidgetVacuna();

                listItems[i].Fecha = fecha[i];
                listItems[i].Doctor = doctor[i];
                listItems[i].Vacuna = vacuna[i];
                listItems[i].Revacunacion = revacunacion[i];

                flowLayoutPanel1.Controls.Add(listItems[i]);

            }*/
            int i = 0;
            foreach (Vacunas itemVacuna in dataVacunas)
            {
                listItems[i] = new WidgetVacuna();

                listItems[i].Fecha = itemVacuna.FechaUltAplicacion;
                listItems[i].Doctor = itemVacuna.NombreDoctor;
                listItems[i].Vacuna = itemVacuna.Nombre;
                listItems[i].Revacunacion = itemVacuna.FechaProxAplicacion;

                flowLayoutPanel1.Controls.Add(listItems[i]);
                i++;
            }



        }

        private void ExpVacunas_Load(object sender, EventArgs e)
        {
            GenerateDynamicWidget();
        }
        #endregion





        private void ExpVacunas_Activated(object sender, EventArgs e)
        {
            GenerateDynamicWidget();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            VacunaForm vacunaForm = new VacunaForm(idMascota, this);
            vacunaForm.ShowDialog();
        }

        private void ExpVacunas_Enter(object sender, EventArgs e)
        {
            GenerateDynamicWidget();
        }
    }
}
