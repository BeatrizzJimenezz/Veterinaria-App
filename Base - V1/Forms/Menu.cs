using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Base___V1
{
    public partial class Menu : Form
    {


        public Menu()
        {
            InitializeComponent();
            PanelNav.Height = Btn1.Height;
            PanelNav.Top = Btn1.Top;
            PanelNav.Left = Btn1.Left;
           

            IblTittle.Text = "Administración";
            this.PnlFormLoader.Controls.Clear();
            MenuAdministracion pantalla2_vrb = new MenuAdministracion(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            pantalla2_vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(pantalla2_vrb);
            pantalla2_vrb.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void Btn1_Click(object sender, EventArgs e)
        {
            PanelNav.Height = Btn1.Height;
            PanelNav.Top = Btn1.Top;
            PanelNav.Left = Btn1.Left;
            Btn1.BackColor = Color.FromArgb(46, 51, 73);

            IblTittle.Text = "Administración";
            this.PnlFormLoader.Controls.Clear();
            MenuAdministracion pantalla2_vrb = new MenuAdministracion(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            pantalla2_vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(pantalla2_vrb);
            pantalla2_vrb.Show();

        }

        public void Btn2_Click(object sender, EventArgs e)
        {
            PanelNav.Height = Btn2.Height;
            PanelNav.Top = Btn2.Top;
            Btn2.BackColor = Color.FromArgb(46, 51, 73);

            IblTittle.Text = "Agregar paciente";
            this.PnlFormLoader.Controls.Clear();
            MenuAddPaciente pantalla3_vrb = new MenuAddPaciente() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            pantalla3_vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(pantalla3_vrb);
            pantalla3_vrb.Show();
        }


        private void Btn6_Click(object sender, EventArgs e)
        {
            PanelNav.Height = Btn6.Height;
            PanelNav.Top = Btn6.Top;
            Btn6.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void Btn1_Leave(object sender, EventArgs e)
        {
            Btn1.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void Btn2_Leave(object sender, EventArgs e)
        {
            Btn2.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void Btn6_Leave(object sender, EventArgs e)
        {
            Btn6.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
