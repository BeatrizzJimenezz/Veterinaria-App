using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Base___V1.Logic;


namespace Base___V1
{

    public partial class MenuAdministracion : Form
    {
        public Button prueba;
        private QuerysSQL datos = new QuerysSQL();

        public MenuAdministracion()
        {
            InitializeComponent();
            datos.ListarInformacion(tblPacientes);
        }

        private void btnAgregarPaciente_Click(object sender, EventArgs e)
        {

        }

        private void btnVerPaciente_Click(object sender, EventArgs e)
        {
            ExpedienteVistaPrincipal ver = new ExpedienteVistaPrincipal();
            ver.Show();
        }
    }
}
