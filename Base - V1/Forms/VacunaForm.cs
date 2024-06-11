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

namespace Base___V1.Forms
{
    public partial class VacunaForm : Form
    {
        private int idMascota;
        private QuerysSQL data;
        private ExpVacunas expVacunas;
        public VacunaForm(int idMascota, ExpVacunas expVacunas)
        {
            InitializeComponent();
            this.idMascota = idMascota;
            data = new QuerysSQL();
            this.expVacunas = expVacunas;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(txtNombreVacuna.Text != "" && txtDr.Text != "")
            {
                Vacunas vac = new Vacunas();
                vac.Nombre = txtNombreVacuna.Text;
                vac.NombreDoctor = txtDr.Text;
                vac.FechaUltAplicacion = dateAplicacion.Value.ToString("dd/MM/yyyy");
                vac.FechaProxAplicacion = dateProxima.Value.ToString("dd/MM/yyyy");
                vac.IdMascota = idMascota;

                if (data.ingresarVacuna(vac))
                {
                    expVacunas.GenerateDynamicWidget();
                    this.Close();
                }
                

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
           DialogResult result = MessageBox.Show("¿Seguro quiere cancelar el ingreso de la vacuna?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
