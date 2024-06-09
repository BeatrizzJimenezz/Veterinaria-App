using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Base___V1.Logic;
using Base___V1.Models;

namespace Base___V1
{
    public partial class MenuAddPaciente : Form
    {
        private QuerysSQL data = new QuerysSQL();
        public MenuAddPaciente()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(txboxPropietario.Text != "" && txboxDireccion.Text != "" && txboxCorreo.Text != "" 
                && txboxTelefono.Text != "" && txboxColor.Text != "" && txboxPaciente.Text != "" &&
                txboxEspecie.Text != "" && txboxRaza.Text != "" && txboxEdad.Text != "" && txboxSenias.Text != "")
            {
                Dueño dueno = new Dueño();

                dueno.setNombre(txboxPropietario.Text);
                dueno.setCorreo(txboxCorreo.Text);
                dueno.setDireccion(txboxDireccion.Text);
                dueno.setTelefono(txboxTelefono.Text);

                data.InsertarDueno(dueno);

                Mascota mascota = new Mascota();
                mascota.setNombre(txboxPaciente.Text);
                mascota.setEspecie(txboxEspecie.Text);
                mascota.setRaza(txboxRaza.Text);
                mascota.setEdad(Convert.ToInt32(txboxEdad.Text));
                mascota.setSexo(comboBoxSexo.Text);
                mascota.setColor(txboxColor.Text);
                mascota.setSenias(txboxSenias.Text);
                mascota.setIdDuenio(data.ObtenerUltimoIDDuenio());

                data.InsertarMascota(mascota);

                LimpiarTextBox();


            }
            else
            {
                MessageBox.Show("Por favor rellene todos los campos");
            }

        }

        private void LimpiarTextBox()
        {
            txboxColor.Text = "";
            txboxCorreo.Text = "";
            txboxDireccion.Text = "";
            txboxPropietario.Text = "";
            txboxTelefono.Text = "";
            txboxPaciente.Text = "";
            txboxEspecie.Text = "";
            txboxRaza.Text = "";
            txboxEdad.Text = "";
            txboxSenias.Text = "";
        }
    }
}
