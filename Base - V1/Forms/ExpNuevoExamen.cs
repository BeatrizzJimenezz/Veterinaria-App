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
    public partial class ExpNuevoExamen : Form
    {
        private int idDueño, idMascota, idConsulta;
        private QuerysSQL data;
        private bool enable;
        public ExpNuevoExamen(int idDueño, int idMascota, int idConsulta, bool enable)
        {
            this.idMascota = idMascota;
            this.idDueño = idDueño;
            this.idConsulta = idConsulta;
            this.enable = enable;
            InitializeComponent();
            SetControlsEnabled(enable);
            data = new QuerysSQL();
            Mascota m = new Mascota();
            m = data.getMascota(idMascota);
            lblNombrePaciente.Text = m.getNombre();
            btnNewExamen.Enabled = enable;
            if (!enable)
            {
                cargarDatos(idConsulta);
            }
        }

        private void btnNewExamen_Click(object sender, EventArgs e)
        {
            ExamenFisico exam = obtenerDatos();
            exam.IdMascota = idMascota;
            exam.IdConsulta = data.getUltimaConsulta();
            data.insertarExamenFisico(exam);

        }

        private ExamenFisico obtenerDatos()
        {
            ExamenFisico exp = new ExamenFisico();
            exp.Fc = txtBoxTenencia.Text;
            exp.Temp = textBox8.Text;
            exp.SonidoCardiaco = textBox1.Text;
            exp.ReflejoPupilar = textBox7.Text;
            exp.Fr = textBox2.Text;
            exp.Pulso = textBox5.Text;
            exp.Anisocoria = txtboxAspecto.Text;
            exp.Dentadura = textBox11.Text;
            exp.Mucosas = txtBoxLesiones.Text;
            exp.Tonsi = textBox9.Text;
            exp.ReflTusigeno = textBox3.Text;
            exp.Tllc = textBox12.Text;
            exp.PlpAbdominal = textBox6.Text;
            exp.Deshidratado = textBox10.Text;
            exp.Palmopercusion = textBox4.Text;
            exp.Rinon = textBox15.Text;
            exp.Vejiga = textBox18.Text;
            exp.Dedos = textBox20.Text;
            exp.Higado = textBox14.Text;
            exp.Prepucio = textBox17.Text;
            exp.Intestino = textBox13.Text;
            exp.TestiVulva = textBox16.Text;
            exp.CondiCorporal = textBox19.Text;
            exp.OtrasObservaciones = textBox25.Text;
            exp.DxPresuntivo = textBox22.Text;
            exp.DxDiferencial = textBox24.Text;
            exp.ExamenesLab = textBox21.Text;
            exp.IdMascota = idMascota;
            exp.IdConsulta = idConsulta;
            return exp;
        }

        public void SetControlsEnabled(bool enabled)
        {
            // Iterar a través de todos los controles en el formulario
            foreach (Control control in this.Controls)
            {
                // Si el control es un TextBox o CheckBox, cambiar su propiedad Enabled
                if (control is System.Windows.Forms.TextBox || control is CheckBox)
                {
                    control.Enabled = enabled;
                }

                // Si el control es un contenedor de controles (como un Panel o GroupBox),
                // iterar a través de sus controles hijos
                if (control.HasChildren)
                {
                    foreach (Control childControl in control.Controls)
                    {
                        if (childControl is System.Windows.Forms.TextBox || childControl is CheckBox)
                        {
                            childControl.Enabled = enabled;
                        }
                    }
                }
            }
            cbEditar.Enabled = !enable;
        }
        public void cargarDatos(int id)
        {
            ExamenFisico exam = data.GetExamenFisico(id);

            if (exam != null)
            {
                txtBoxTenencia.Text = exam.Fc;
                textBox8.Text = exam.Temp;
                textBox1.Text = exam.SonidoCardiaco;
                textBox7.Text = exam.ReflejoPupilar;
                textBox2.Text = exam.Fr;
                textBox5.Text = exam.Pulso;
                txtboxAspecto.Text = exam.Anisocoria;
                textBox11.Text = exam.Dentadura;
                txtBoxLesiones.Text = exam.Mucosas;
                textBox9.Text = exam.Tonsi;
                textBox3.Text = exam.ReflTusigeno;
                textBox12.Text = exam.Tllc;
                textBox6.Text = exam.PlpAbdominal;
                textBox10.Text = exam.Deshidratado;
                textBox4.Text = exam.Palmopercusion;
                textBox15.Text = exam.Rinon;
                textBox18.Text = exam.Vejiga;
                textBox20.Text = exam.Dedos;
                textBox14.Text = exam.Higado;
                textBox17.Text = exam.Prepucio;
                textBox13.Text = exam.Intestino;
                textBox16.Text = exam.TestiVulva;
                textBox19.Text = exam.CondiCorporal;
                textBox25.Text = exam.OtrasObservaciones;
                textBox22.Text = exam.DxPresuntivo;
                textBox24.Text = exam.DxDiferencial;
                textBox21.Text = exam.ExamenesLab;

            }
        }

        private void cbEditar_CheckedChanged(object sender, EventArgs e)
        {
            SetControlsEnabled(cbEditar.Checked);
            if (!cbEditar.Checked)
            {
                ExamenFisico exam = obtenerDatos();
                exam.IdConsulta = idConsulta;
                data.editarExamenFisico(exam);
            }
        }


    }
}
