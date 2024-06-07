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
        public ExpVacunas()
        {
            InitializeComponent();
        }

        #region Generar los widgets

        private void GenerateDynamicWidget()
        {
            flowLayoutPanel1.Controls.Clear();

            WidgetVacuna[] listItems = new WidgetVacuna[4];

            string[] fecha = new string[4] { "16 de mayo de 2024", "23 de agosto de 2024", "4 de septiembre de 2024", "15 de mayo de 2024" };

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

            }

        }

        private void ExpVacunas_Load(object sender, EventArgs e)
        {
            GenerateDynamicWidget();
        }
        #endregion





    }
}
