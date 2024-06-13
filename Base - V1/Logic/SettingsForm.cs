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
    public partial class SettingsForm : Form
    {
        private int idMascota;
        private QuerysSQL data;
        private ExpVacunas expVacunas;
        public SettingsForm()
        {
            InitializeComponent();
            data = new QuerysSQL();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if(txt1.Text != "" && txt2.Text != "")
            {
                if (data.updateClave(txt1.Text, txt2.Text))
                {
                    MessageBox.Show("Pin de acceso actualizado correctamente", "Hecho");
                    txt2.Text = "";
                    txt1.Text = "";
                    return;
                }
                else
                {
                    MessageBox.Show("Ocurrio un error, verifique los datos", "Hecho");
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
