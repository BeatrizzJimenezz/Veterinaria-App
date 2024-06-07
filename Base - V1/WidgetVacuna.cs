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
    public partial class WidgetVacuna : UserControl
    {
        public WidgetVacuna()
        {
            InitializeComponent();
        }

        #region Getter And Setter por labels and txtBox

        private string _fecha;
        private string _vacuna;
        private string _doctor;
        private string _revacunacion;

        [Category("Custom Props")]

        public string Fecha
        {
            get { return _fecha; }
            set { _fecha = value; lblFecha.Text = value; }
        }

        [Category("Custom Props")]

        public string Vacuna
        {
            get { return _vacuna; }
            set { _vacuna = value; lblNombreVacuna.Text = value; }
        }

        [Category("Custom Props")]

        public string Doctor
        {
            get { return _doctor; }
            set { _doctor = value; lblDoctor.Text = value; }
        }

        [Category("Custom Props")]

        public string Revacunacion
        {
            get { return _revacunacion; }
            set { _revacunacion = value; lblRevacunacion.Text = value; }
        }

        #endregion

        #region Hover Effect

        private void ucRequest_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(217, 229, 242);
        }

        private void ucRequest_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(255, 255, 255);
        }

        #endregion


    }
}
