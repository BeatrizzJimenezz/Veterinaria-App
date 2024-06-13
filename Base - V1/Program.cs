
using Base___V1.Logic;
using Base___V1.Models;
using System;
using System.Globalization;
using System.IO;
using System.Web;
namespace Base___V1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Inicio main = new Inicio();
            enviarCorreosADiario();
            main.Show();
            Application.Run();
        }
        private static readonly string AppDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Veterinaria");
        private static readonly string FilePath = Path.Combine(AppDataFolder, "ultimaFechaEnvioCorreos.txt");

        public static void enviarCorreosADiario()
        {

            QuerysSQL data = new QuerysSQL();
            DateTime hoy = DateTime.Now.Date; // Solo la parte de la fecha
            DateTime ultimaVezEnviado = ReadLastGreetingDate();
            WriteLastGreetingDate(hoy);
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