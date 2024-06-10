using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Base___V1.Models;
using Base___V1.Logic;
using System.Globalization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Base___V1
{
    public partial class ExpNuevaConsulta : Form
    {
        private string idDueño;
        private string idMascota;
        private QuerysSQL data;
        private bool ingreso;
        private int idConsulta;
        private ExpedienteVistaPrincipal exp;
        public ExpNuevaConsulta(string idDueño, string idMascota, bool ingreso, int idConsulta, ExpedienteVistaPrincipal exp)
        {
            this.idDueño = idDueño;
            this.idMascota = idMascota;
            this.ingreso = ingreso;
            this.idConsulta = idConsulta;
            this.exp = exp;
            InitializeComponent();
            SetControlsEnabled(ingreso);
            data = new QuerysSQL();
            Mascota mascota = data.getMascota(int.Parse(idMascota));
            lblNombrePaciente.Text = mascota.getNombre();
            cbEditar.Enabled = !ingreso;
            btnNewConsulta.Enabled = ingreso;
            if (!ingreso)
            {
                cargarDatos(idConsulta);
            }

        }

        private void btnNewConsulta_Click(object sender, EventArgs e)
        {
            Consulta consulta = obtenerDatos();

            if (data.InsertarConsulta(consulta))
            {
                DialogResult result = MessageBox.Show("¿Desea ingresar un examen fisico?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    exp.idConsulta = idConsulta;
                    exp.PnlFormLoader2.Controls.Clear();
                    ExpNuevoExamen abrirHistorial = new ExpNuevoExamen(int.Parse(idDueño), int.Parse(idMascota), idConsulta, true) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    abrirHistorial.FormBorderStyle = FormBorderStyle.None;
                    exp.PnlFormLoader2.Controls.Add(abrirHistorial);
                    abrirHistorial.Show();
                }else if(result == DialogResult.No)
                {
                    ExamenFisico exam = new ExamenFisico();
                    exam.IdMascota = int.Parse(idMascota);
                    exam.IdConsulta = data.getUltimaConsulta();
                    data.insertarExamenFisico(exam);

                    
                    exp.PnlFormLoader2.Controls.Clear();
                    ExpInfo abrirHistorial = new ExpInfo(idMascota,idDueño) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    abrirHistorial.FormBorderStyle = FormBorderStyle.None;
                    exp.PnlFormLoader2.Controls.Add(abrirHistorial);
                    abrirHistorial.Show();
                }
            }




        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }
        public void SetControlsEnabled(bool enabled)
        {
            btnNewConsulta.Enabled = enabled;
            btnNewConsulta.Visible = enabled;
            button1.Enabled = !enabled;
            button1.Visible = !enabled;
            cbEditar.Visible = !enabled;
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
        }
        public void cargarDatos(int idConsulta)
        {
            Consulta consulta = data.getConsulta(idConsulta);

            checkVacuna.Checked = consulta.InVacunas == 1;
            checkQuintuple.Checked = consulta.InQuintuple == 1;
            checkTriFelina.Checked = consulta.InTripleFelina == 1;
            checkParvovirus.Checked = consulta.InParvovirus == 1;
            checkRabia.Checked = consulta.InRabia == 1;
            checkGiardia.Checked = consulta.InGiardia == 1;
            checkBordetella.Checked = consulta.InBordetella == 1;
            checkLeucemia.Checked = consulta.InLeucemia == 1;
            textBox2.Text = consulta.InOtra;
            checkParasitos.Checked = consulta.InDesparacitacion == 1;
            dateTimePicker1.Value = DateTime.ParseExact(consulta.FechaDesparacitacion, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            txtMedicina.Text = consulta.MedicamentoDesparacitacion;
            checkGarrapatas.Checked = consulta.InControlGarrapata == 1;
            dateTimePicker2.Value = DateTime.ParseExact(consulta.FechaControlGarrapata, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            textBox1.Text = consulta.MedicamentoControlGarrapata;
            txtBoxTenencia.Text = consulta.TiempoMascota;
            txtBoxMascotas.Text = consulta.OtrasMascotas;
            txtBoxDieta.Text = consulta.DietaAlimenticia;
            checkAcceso.Checked = consulta.AccesoCalle == 1;
            checkBox1.Checked = consulta.ContactoEnfermos == 1;
            txtEnfermedades.Text = consulta.EnfermedadesAnt;
            textBox3.Text = consulta.Habitat;
            textBox6.Text = consulta.SintomasObs;
            textBox4.Text = consulta.MedAdmCasa;
            txtboxAspecto.Text = consulta.StAspecto;
            txtBoxLesiones.Text = consulta.StLesiones;
            txtBoxAlopecia.Text = consulta.StAlopecia;
            txtBoxParasitos.Text = consulta.StParasitos;
            txtBoxMovimiento.Text = consulta.SmeMovimeinto;
            textBox9.Text = consulta.SdApetito;
            textBox8.Text = consulta.SdIngestoAgua;
            checkBox2.Checked = consulta.SdVomito == 1;
            textBox5.Text = consulta.SdVomitoFrecuencia;
            textBox7.Text = consulta.SdAspecto;
            checkBox11.Checked = consulta.SdDefeca == 1;
            textBox11.Text = consulta.SdDefecaFrecuencia;
            textBox10.Text = consulta.SdColor;
            textBox12.Text = consulta.SdAspectoDefeca;
            checkBox3.Checked = consulta.SdEstreñimiento == 1;
            checkBox4.Checked = consulta.SdFlatulencia == 1;
            checkBox5.Checked = consulta.SdDeglucion == 1;
            textBox16.Text = consulta.SrTos;
            textBox15.Text = consulta.SrTipo;
            textBox17.Text = consulta.SrDisnea;
            textBox14.Text = consulta.SrEstornudos;
            textBox13.Text = consulta.SrDescargaNasal;
            textBox21.Text = consulta.ScFF;
            textBox19.Text = consulta.ScClanosis;
            textBox18.Text = consulta.ScTosNocturna;
            textBox27.Text = consulta.SuOrina;
            textBox26.Text = consulta.SuCastrado;
            checkBox7.Checked = consulta.SuCruzadoRaza == 1;
            checkBox6.Checked = consulta.SuGestante == 1;
            textBox24.Text = consulta.SuPsudociesis;
            textBox22.Text = consulta.SuUltimoCelo;
            textBox20.Text = consulta.SuUltimoParto;
            textBox23.Text = consulta.SuDescargaPreVa;
            textBox33.Text = consulta.SnComportamiento;
            textBox32.Text = consulta.SnIncoordinacion;
            textBox31.Text = consulta.SnDismetria;
            checkBox13.Checked = consulta.SnGolpePrevio == 1;
            checkBox12.Checked = consulta.SnRespondeLlamado == 1;
            textBox30.Text = consulta.SnOjos;
            textBox36.Text = consulta.SnSecrecion;
            textBox35.Text = consulta.SnCeguera;
            textBox29.Text = consulta.SnOidos;
            textBox28.Text = consulta.SnSeRasca;
            textBox25.Text = consulta.SnMalOlor;
            textBox34.Text = consulta.SnEscucha;
            textBox39.Text = consulta.SnParasitos;
            textBox38.Text = consulta.SnDescarga;
            textBox37.Text = consulta.SnAfectado;
        }

        private void cbEditar_CheckedChanged(object sender, EventArgs e)
        {
            SetControlsEnabled(cbEditar.Checked);

            if (!cbEditar.Checked)
            {
                Consulta cosulta = obtenerDatos();
                cosulta.IdConsulta = idConsulta;
                data.editarConsulta(cosulta);
            }
        }

        private Consulta obtenerDatos()
        {
            Consulta consulta = new Consulta();
            consulta.InVacunas = checkVacuna.Checked ? 1 : 0;
            consulta.InQuintuple = checkQuintuple.Checked ? 1 : 0;
            consulta.InTripleFelina = checkTriFelina.Checked ? 1 : 0;
            consulta.InParvovirus = checkParvovirus.Checked ? 1 : 0;
            consulta.InRabia = checkRabia.Checked ? 1 : 0;
            consulta.InGiardia = checkGiardia.Checked ? 1 : 0;
            consulta.InBordetella = checkBordetella.Checked ? 1 : 0;
            consulta.InLeucemia = checkLeucemia.Checked ? 1 : 0;
            consulta.InOtra = textBox2.Text;
            consulta.InDesparacitacion = checkParasitos.Checked ? 1 : 0;
            consulta.FechaDesparacitacion = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            consulta.MedicamentoDesparacitacion = txtMedicina.Text;
            consulta.InControlGarrapata = checkGarrapatas.Checked ? 1 : 0;
            consulta.FechaControlGarrapata = dateTimePicker2.Value.ToString("dd/MM/yyyy");
            consulta.MedicamentoControlGarrapata = textBox1.Text;
            consulta.TiempoMascota = txtBoxTenencia.Text;
            consulta.OtrasMascotas = txtBoxMascotas.Text;
            consulta.DietaAlimenticia = txtBoxDieta.Text;
            consulta.AccesoCalle = checkAcceso.Checked ? 1 : 0;
            consulta.ContactoEnfermos = checkBox1.Checked ? 1 : 0;
            consulta.EnfermedadesAnt = txtEnfermedades.Text;
            consulta.Habitat = textBox3.Text;
            consulta.SintomasObs = textBox6.Text;
            consulta.MedAdmCasa = textBox4.Text;
            consulta.StAspecto = txtboxAspecto.Text;
            consulta.StLesiones = txtBoxLesiones.Text;
            consulta.StAlopecia = txtBoxAlopecia.Text;
            consulta.StParasitos = txtBoxParasitos.Text;
            consulta.SmeMovimeinto = txtBoxMovimiento.Text;
            consulta.SdApetito = textBox9.Text;
            consulta.SdIngestoAgua = textBox8.Text;
            consulta.SdVomito = checkBox2.Checked ? 1 : 0;
            consulta.SdVomitoFrecuencia = textBox5.Text;
            consulta.SdAspecto = textBox7.Text;
            consulta.SdDefeca = checkBox11.Checked ? 1 : 0;
            consulta.SdDefecaFrecuencia = textBox11.Text;
            consulta.SdColor = textBox10.Text;
            consulta.SdAspectoDefeca = textBox12.Text;
            consulta.SdEstreñimiento = checkBox3.Checked ? 1 : 0;
            consulta.SdFlatulencia = checkBox4.Checked ? 1 : 0;
            consulta.SdDeglucion = checkBox5.Checked ? 1 : 0;
            consulta.SrTos = textBox16.Text;
            consulta.SrTipo = textBox15.Text;
            consulta.SrDisnea = textBox17.Text;
            consulta.SrEstornudos = textBox14.Text;
            consulta.SrDescargaNasal = textBox13.Text;
            consulta.ScFF = textBox21.Text;
            consulta.ScClanosis = textBox19.Text;
            consulta.ScTosNocturna = textBox18.Text;
            consulta.SuOrina = textBox27.Text;
            consulta.SuCastrado = textBox26.Text;
            consulta.SuCruzadoRaza = checkBox7.Checked ? 1 : 0;
            consulta.SuGestante = checkBox6.Checked ? 1 : 0;
            consulta.SuPsudociesis = textBox24.Text;
            consulta.SuUltimoCelo = textBox22.Text;
            consulta.SuUltimoParto = textBox20.Text;
            consulta.SuDescargaPreVa = textBox23.Text;
            consulta.SnComportamiento = textBox33.Text;
            consulta.SnIncoordinacion = textBox32.Text;
            consulta.SnDismetria = textBox31.Text;
            consulta.SnGolpePrevio = checkBox13.Checked ? 1 : 0;
            consulta.SnRespondeLlamado = checkBox12.Checked ? 1 : 0;
            consulta.SnOjos = textBox30.Text;
            consulta.SnSecrecion = textBox36.Text;
            consulta.SnCeguera = textBox35.Text;
            consulta.SnOidos = textBox29.Text;
            consulta.SnSeRasca = textBox28.Text;
            consulta.SnMalOlor = textBox25.Text;
            consulta.SnEscucha = textBox34.Text;
            consulta.SnParasitos = textBox39.Text;
            consulta.SnDescarga = textBox38.Text;
            consulta.SnAfectado = textBox37.Text;
            consulta.IdMascota = int.Parse(idMascota);
            DateTime fechaHoraActual = DateTime.Now;
            consulta.FechaRealizado = fechaHoraActual.ToString("dd/MM/yyyy HH:mm");
            consulta.MotivoConsulta = "Mareos";//Aqui poner el textBox para motivo de la consulta

            return consulta;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            exp.PnlFormLoader2.Controls.Clear();
            ExpNuevoExamen abrirHistorial = new ExpNuevoExamen(int.Parse(idDueño), int.Parse(idMascota), idConsulta, false) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            abrirHistorial.FormBorderStyle = FormBorderStyle.None;
            exp.PnlFormLoader2.Controls.Add(abrirHistorial);
            abrirHistorial.Show();
        }
    }
}
