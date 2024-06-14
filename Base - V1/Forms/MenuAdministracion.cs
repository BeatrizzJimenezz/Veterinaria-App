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
using Base___V1.Models;


namespace Base___V1
{

    public partial class MenuAdministracion : Form
    {
        public Button prueba;
        private QuerysSQL datos = new QuerysSQL();
        private Menu menu;

        public MenuAdministracion(Menu menu)
        {
            this.menu = menu;
            InitializeComponent();
            datos.ListarInformacion(tblPacientes);
            menu.textBox1.TextChanged += txtBusquedaPaciente;
            enviarCorreosADiario();
        }

        private void tblPacientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = tblPacientes.Rows[e.RowIndex];
                string idDueño = filaSeleccionada.Cells["DueñoID"].Value.ToString();
                string idMascota = filaSeleccionada.Cells["MascotaID"].Value.ToString();
                
                if (idDueño != "")
                {                    
                    menu.PnlFormLoader.Controls.Clear();
                    menu.textBox1.TextChanged -= txtBusquedaPaciente;
                    menu.textBox1.Text = "";
                    menu.SetPlaceholder(menu.textBox1, "Busca algo...");
                    ExpedienteVistaPrincipal pantalla2_vrb = new ExpedienteVistaPrincipal(idMascota, idDueño, menu) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    pantalla2_vrb.FormBorderStyle = FormBorderStyle.None;
                    menu.PnlFormLoader.Controls.Add(pantalla2_vrb);
                    pantalla2_vrb.Show();
                }
                else
                {
                    MessageBox.Show("Seleccione un campo que no este vacio!");
                }
            }
        }

        private void txtBusquedaPaciente(object sender, EventArgs e)
        {

            if (menu.textBox1.Text != "" || menu.textBox1.Text != "Busca algo...")
            {
                datos.ListarBusquedaPaciente(tblPacientes, menu.textBox1.Text);
            }
            else
            {
                datos.ListarInformacion(tblPacientes);
            }

        }
        private static readonly string AppDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Veterinaria");
        private static readonly string FilePath = Path.Combine(AppDataFolder, "ultimaFechaEnvioCorreos.txt");
        public  void enviarCorreosADiario()
        {

            QuerysSQL data = new QuerysSQL();
            DateTime hoy = DateTime.Now.Date; // Solo la parte de la fecha
            DateTime ultimaVezEnviado = ReadLastGreetingDate();
            //WriteLastGreetingDate(hoy);
            MessageBox.Show($"Fecha de hoy: {hoy.ToString("dd/MM/yyyy HH:mm")} Fecha de comparacion: {ultimaVezEnviado.ToString("dd/MM/yyyy HH:mm")}");
            if (ultimaVezEnviado != hoy)
            {
                List<ids> ids = data.obtenerMascotas();
                MessageBox.Show("Hola");
                for (int i = 0; i < ids.Count; i++)
                {
                    Mascota m = data.getMascota(ids[i].idMascota);
                    Dueño d = data.getDueño(ids[i].idDueño);
                    List<Vacunas> v = data.obtenerVacunas(ids[i].idMascota);
                    DateTime fourDaysAfter = hoy.AddDays(4);

                    foreach (Vacunas itemVacuna in v)
                    {
                        DateTime proxDate;
                        if (DateTime.TryParse(itemVacuna.FechaProxAplicacion, out proxDate) && IsWithinRange(proxDate, hoy, fourDaysAfter))
                        {
                            TimeSpan diferencia = proxDate - hoy;

                            EnvioCorreo envio = new EnvioCorreo(d.getCorreo(), d.getNombre(), m.getNombre(), diferencia.Days,
                                "Recordatorio de vacuna para tu mascota " + m.getNombre(), itemVacuna.Nombre);
                        }
                    }
                }

                // Escribir la fecha actual después de enviar los correos

            }
        }


        static bool IsWithinRange(DateTime targetDate, DateTime startDate, DateTime endDate)
        {
            return targetDate >= startDate && targetDate <= endDate;
        }

        private static DateTime ReadLastGreetingDate()
        {
            if (File.Exists(FilePath))
            {
                string lastDateString = File.ReadAllText(FilePath);
                if (DateTime.TryParse(lastDateString, out DateTime lastDate))
                {
                    return lastDate.Date; // Solo la parte de la fecha
                }
            }

            return DateTime.MinValue;
        }

        private static void WriteLastGreetingDate(DateTime date)
        {
            // Crear el directorio si no existe
            if (!Directory.Exists(AppDataFolder))
            {
                Directory.CreateDirectory(AppDataFolder);
            }

            File.WriteAllText(FilePath, date.ToString("yyyy-MM-dd"));
        }
    }
}
