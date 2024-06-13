using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Base___V1.Logic
{
    internal class EnvioCorreo
    {
        public string myEmail = "josueisaac684@gmail.com";
        public string MyPassword = "cwwt quuj pxtk syoq";
        public string MyAlias = "Veterinaria El Corral";
        public string[] myAdjuntos;
        public MailMessage mCorreo;
        public EnvioCorreo(string correo, string dueño, string paciente, int diasRestantes,string encabezado, string nombreVacuna)
        {
            try
              {
                    mCorreo =  new MailMessage();
                mCorreo.From = new MailAddress(myEmail, MyAlias, System.Text.Encoding.UTF8);
                mCorreo.To.Add(correo);
                mCorreo.Subject = encabezado;
                mCorreo.Body = @$"
                      Hola estimado {dueño}, el presente correo es para recordarle que a su mascota {paciente}
                      le faltan {diasRestantes} para la aplicacion de {nombreVacuna}, de ante mano le solicitamos que 
                      asista al control de su vacuna.

Este correo es generado de manera automatica no lo responda
                      ";
                mCorreo.IsBodyHtml = true;
                mCorreo.Priority = MailPriority.High;

                SmtpClient smtp = new SmtpClient();
                smtp.UseDefaultCredentials = false;
                smtp.Port = 25;
                smtp.Host = "smtp.gmail.com";
                smtp.Credentials = new System.Net.NetworkCredential(myEmail, MyPassword);
                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) { return true; };
                smtp.EnableSsl = true;
                smtp.Send(mCorreo);
                MessageBox.Show("Enviado");
                
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }   
        }

        

        /* codigo de envio de correos
          private static readonly string AppDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Veterinaria");
        private static readonly string FilePath = Path.Combine(AppDataFolder, "ultimaFechaEnvioCorreos.txt");

        public void enviarCorreosADiario()
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
         
         
         */

    }

}
