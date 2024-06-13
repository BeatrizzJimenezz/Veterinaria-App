using Base___V1.Logic;
using Base___V1.Models;
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
    public partial class Inicio : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
            (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );

        public Inicio()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += enviarCorreosADiario;
            backgroundWorker.RunWorkerCompleted += envioTerminado;
            backgroundWorker.RunWorkerAsync();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Menu menu_vrb = new Menu();
            menu_vrb.Show();
            this.Close();
        }
        public void envioTerminado(object o, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Se han enviado todos los recordatorios", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private static readonly string AppDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Veterinaria");
        private static readonly string FilePath = Path.Combine(AppDataFolder, "ultimaFechaEnvioCorreos.txt");
        public void enviarCorreosADiario(object o, DoWorkEventArgs e)
        {

            QuerysSQL data = new QuerysSQL();
            DateTime hoy = DateTime.Now.Date; // Solo la parte de la fecha
            DateTime ultimaVezEnviado = ReadLastGreetingDate();
            WriteLastGreetingDate(hoy);
            //MessageBox.Show($"Fecha de hoy: {hoy.ToString("dd/MM/yyyy HH:mm")} Fecha de comparacion: {ultimaVezEnviado.ToString("dd/MM/yyyy HH:mm")}");
            if (ultimaVezEnviado != hoy)
            {
                List<ids> ids = data.obtenerMascotas();
                
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
