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
        public string myEmail = "veterinariaelcorralsv@gmail.com";
        public string MyPassword = "oiwp vhjv azqt sshq";
        public string MyAlias = "Veterinaria El Corral";
        public string[] myAdjuntos;
        public MailMessage mCorreo;
       public EnvioCorreo(string correo, string dueño, string paciente, int diasRestante, string encabezado, string nombreVacuna)
{
    try
    {
        using (MailMessage mCorreo = new MailMessage())
        {
			string diasRestantes;
            if (diasRestante == 0)
            {
				diasRestantes = "le corresponde <strong>hoy</strong>";         
            }
            else
            {
				diasRestantes = $"le faltan <strong>{diasRestante} dias</strong> para";
            }
            mCorreo.From = new MailAddress(myEmail, MyAlias, System.Text.Encoding.UTF8);
            mCorreo.To.Add(correo);
            mCorreo.Subject = encabezado;
            mCorreo.Body = @$"
							<!DOCTYPE html>
							<html xmlns:v=""urn:schemas-microsoft-com:vml"" xmlns:o=""urn:schemas-microsoft-com:office:office"" lang=""en"">

							<head>
								<title></title>
								<meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"">
								<meta name=""viewport"" content=""width=device-width, initial-scale=1.0""><!--[if mso]><xml><o:OfficeDocumentSettings><o:PixelsPerInch>96</o:PixelsPerInch><o:AllowPNG/></o:OfficeDocumentSettings></xml><![endif]--><!--[if !mso]><!-->
								<link href=""https://fonts.googleapis.com/css?family=Merriweather"" rel=""stylesheet"" type=""text/css""><!--<![endif]-->
								<style>
									* {{
										box-sizing: border-box;
									}}

									body {{
										margin: 0;
										padding: 0;
									}}

									a[x-apple-data-detectors] {{
										color: inherit !important;
										text-decoration: inherit !important;
									}}

									#MessageViewBody a {{
										color: inherit;
										text-decoration: none;
									}}

									p {{
										line-height: inherit
									}}

									.desktop_hide,
									.desktop_hide table {{
										mso-hide: all;
										display: none;
										max-height: 0px;
										overflow: hidden;
									}}

									.image_block img+div {{
										display: none;
									}}

									@media (max-width:700px) {{
										.desktop_hide table.icons-inner {{
											display: inline-block !important;
										}}

										.icons-inner {{
											text-align: center;
										}}

										.icons-inner td {{
											margin: 0 auto;
										}}

										.image_block div.fullWidth {{
											max-width: 100% !important;
										}}

										.mobile_hide {{
											display: none;
										}}

										.row-content {{
											width: 100% !important;
										}}

										.stack .column {{
											width: 100%;
											display: block;
										}}

										.mobile_hide {{
											min-height: 0;
											max-height: 0;
											max-width: 0;
											overflow: hidden;
											font-size: 0px;
										}}

										.desktop_hide,
										.desktop_hide table {{
											display: table !important;
											max-height: none !important;
										}}
									}}
								</style>
							</head>

							<body class=""body"" style=""background-color: #ece6d3; margin: 0; padding: 0; -webkit-text-size-adjust: none; text-size-adjust: none;"">
								<table class=""nl-container"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ece6d3;"">
									<tbody>
										<tr>
											<td>
												<table class=""row row-1"" align=""center"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
													<tbody>
														<tr>
															<td>
																<table class=""row-content stack"" align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 680px; margin: 0 auto;"" width=""680"">
																	<tbody>
																		<tr>
																			<td class=""column column-1"" width=""100%"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; padding-bottom: 5px; padding-top: 5px; vertical-align: top; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;"">
																				<div class=""spacer_block block-1"" style=""height:30px;line-height:30px;font-size:1px;"">&#8202;</div>
																			</td>
																		</tr>
																	</tbody>
																</table>
															</td>
														</tr>
													</tbody>
												</table>
												<table class=""row row-2"" align=""center"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
													<tbody>
														<tr>
															<td>
																<table class=""row-content stack"" align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 680px; margin: 0 auto;"" width=""680"">
																	<tbody>
																		<tr>
																			<td class=""column column-1"" width=""100%"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;"">
																				<table class=""image_block block-1"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
																					<tr>
																						<td class=""pad"" style=""padding-bottom:5px;padding-left:15px;padding-top:15px;width:100%;padding-right:0px;"">
																							<div class=""alignment"" align=""center"" style=""line-height:10px"">
																								<div style=""max-width: 272px;""><img src=""https://isaac684.github.io/MKLibrary.github.io/img/asds.png"" style=""display: block; height: auto; border: 0; width: 100%;"" width=""272"" alt=""Luxury Pets Logo"" title=""Luxury Pets Logo"" height=""auto""></div>
																							</div>
																						</td>
																					</tr>
																				</table>
																			</td>
																		</tr>
																	</tbody>
																</table>
															</td>
														</tr>
													</tbody>
												</table>
												<table class=""row row-3"" align=""center"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
													<tbody>
														<tr>
															<td>
																<table class=""row-content stack"" align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 680px; margin: 0 auto;"" width=""680"">
																	<tbody>
																		<tr>
																			<td class=""column column-1"" width=""100%"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;"">
																				<table class=""image_block block-1"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
																					<tr>
																						<td class=""pad"" style=""padding-bottom:40px;padding-top:25px;width:100%;padding-right:0px;padding-left:0px;"">
																							<div class=""alignment"" align=""center"" style=""line-height:10px"">
																								<div class=""fullWidth"" style=""max-width: 680px;""><img src=""https://isaac684.github.io/MKLibrary.github.io/img/332-3329966_the-woofin-paws-pet-fashion-show-starts-at.jpg"" style=""display: block; height: auto; border: 0; width: 100%;"" width=""680"" alt=""Fashion Pets"" title=""Fashion Pets"" height=""auto""></div>
																							</div>
																						</td>
																					</tr>
																				</table>
																				<table class=""paragraph_block block-2"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;"">
																					<tr>
																						<td class=""pad"" style=""padding-bottom:10px;padding-left:10px;padding-right:10px;padding-top:5px;"">
																							<div style=""color:#000000;font-family:'Merriwheater','Georgia',serif;font-size:42px;line-height:120%;text-align:center;mso-line-height-alt:50.4px;"">
																								<p style=""margin: 0; word-break: break-word;"">&nbsp;¡Hola estimado {dueño}!</p>
																							</div>
																						</td>
																					</tr>
																				</table>
																				<table class=""paragraph_block block-3"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;"">
																					<tr>
																						<td class=""pad"" style=""padding-bottom:20px;padding-left:20px;padding-right:30px;"">
																							<div style=""color:#79766d;font-family:Merriwheater, Georgia, serif;font-size:18px;line-height:150%;text-align:center;mso-line-height-alt:27px;"">
																								<p style=""margin: 0; word-break: break-word;"">El presente correo es para recordarle que a su mascota <strong>{paciente}</strong> {diasRestantes} la aplicación del control de su dosis de <strong>{nombreVacuna}</strong>.</p>
																								<p style=""margin: 0; word-break: break-word;"">&nbsp;De antemano, le solicitamos que visite nuestra veterinaria el dia correspondiente.</p>
																							</div>
																						</td>
																					</tr>
																				</table>
																				<table class=""paragraph_block block-4"" width=""100%"" border=""0"" cellpadding=""10"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;"">
																					<tr>
																						<td class=""pad"">
																							<div style=""color:#393d47;font-family:Merriwheater, Georgia, serif;font-size:18px;line-height:120%;text-align:center;mso-line-height-alt:21.599999999999998px;"">
																								<p style=""margin: 0; word-break: break-word;""><span style=""background-color: #000000; color: #ffffff;"">Este correo es generado de manera automática, no lo responda.</span></p>
																							</div>
																						</td>
																					</tr>
																				</table>
																			</td>
																		</tr>
																	</tbody>
																</table>
															</td>
														</tr>
													</tbody>
												</table>
												<table class=""row row-4"" align=""center"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #f0ede4;"">
													<tbody>
														<tr>
															<td>
																<table class=""row-content stack"" align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 680px; margin: 0 auto;"" width=""680"">
																	<tbody>
																		<tr>
																			<td class=""column column-1"" width=""100%"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; padding-bottom: 5px; padding-top: 5px; vertical-align: top; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;"">
																				<div class=""spacer_block block-1"" style=""height:25px;line-height:25px;font-size:1px;"">&#8202;</div>
																			</td>
																		</tr>
																	</tbody>
																</table>
															</td>
														</tr>
													</tbody>
												</table>
												<table class=""row row-5"" align=""center"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #f0ede4;"">
													<tbody>
														<tr>
															<td>
																<table class=""row-content stack"" align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 680px; margin: 0 auto;"" width=""680"">
																	<tbody>
																		<tr>
																			<td class=""column column-1"" width=""100%"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; padding-bottom: 5px; padding-top: 5px; vertical-align: top; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;"">
																				<div class=""spacer_block block-1"" style=""height:25px;line-height:25px;font-size:1px;"">&#8202;</div>
																			</td>
																		</tr>
																	</tbody>
																</table>
															</td>
														</tr>
													</tbody>
												</table>
												<table class=""row row-6"" align=""center"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #bfb9a2;"">
													<tbody>
														<tr>
															<td>
																<table class=""row-content stack"" align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 680px; margin: 0 auto;"" width=""680"">
																	<tbody>
																		<tr>
																			<td class=""column column-1"" width=""100%"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; padding-bottom: 20px; padding-top: 10px; vertical-align: top; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;"">
																				<table class=""paragraph_block block-1"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;"">
																					<tr>
																						<td class=""pad"" style=""padding-bottom:5px;padding-left:10px;padding-right:10px;"">
																							<div style=""color:#ffffff;font-family:Merriwheater, Georgia, serif;font-size:42px;line-height:120%;text-align:center;mso-line-height-alt:50.4px;"">
																								<p style=""margin: 0; word-break: break-word;""><span>Clinica Veterinaria El Corral</span></p>
																							</div>
																						</td>
																					</tr>
																				</table>
																				<table class=""paragraph_block block-2"" width=""100%"" border=""0"" cellpadding=""10"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;"">
																					<tr>
																						<td class=""pad"">
																							<div style=""color:#ffffff;font-family:Merriwheater, Georgia, serif;font-size:14px;line-height:180%;text-align:center;mso-line-height-alt:25.2px;"">
																								<p style=""margin: 0; word-break: break-word;""><a style=""text-decoration: none; color: #ffffff;"" title=""tel:+12025550109"" href=""tel:+12025550109"">+503 6041-0455</a></p>
																								<p style=""margin: 0; word-break: break-word;"">Final 4° calle oriente y, 18 Avenida Nte., Usulután.</p>
																							</div>
																						</td>
																					</tr>
																				</table>
																				<table class=""divider_block block-3"" width=""100%"" border=""0"" cellpadding=""10"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
																					<tr>
																						<td class=""pad"">
																							<div class=""alignment"" align=""center"">
																								<table border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" width=""100%"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
																									<tr>
																										<td class=""divider_inner"" style=""font-size: 1px; line-height: 1px; border-top: 1px solid #FFFFFF;""><span>&#8202;</span></td>
																									</tr>
																								</table>
																							</div>
																						</td>
																					</tr>
																				</table>
																			</td>
																		</tr>
																	</tbody>
																</table>
															</td>
														</tr>
													</tbody>
												</table>
												<table class=""row row-7"" align=""center"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffffff;"">
													<tbody>
														<tr>
															<td>
																<table class=""row-content stack"" align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; background-color: #ffffff; width: 680px; margin: 0 auto;"" width=""680"">
																	<tbody>
																		<tr>
																			<td class=""column column-1"" width=""100%"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; padding-bottom: 5px; padding-top: 5px; vertical-align: top; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;"">
																				<table class=""icons_block block-1"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; text-align: center;"">
																					<tr>
																						<td class=""pad"" style=""vertical-align: middle; color: #1e0e4b; font-family: 'Inter', sans-serif; font-size: 15px; padding-bottom: 5px; padding-top: 5px; text-align: center;"">
																							<table width=""100%"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">

																							</table>
																						</td>
																					</tr>
																				</table>
																			</td>
																		</tr>
																	</tbody>
																</table>
															</td>
														</tr>
													</tbody>
												</table>
											</td>
										</tr>
									</tbody>
								</table><!-- End -->
							</body>

							</html>
										
            ";
            mCorreo.IsBodyHtml = true;
            mCorreo.Priority = MailPriority.High;

            using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(myEmail, MyPassword);

                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) { return true; };

                smtp.Send(mCorreo);
            }
        }
        
    }
    catch (SmtpException smtpEx)
    {
        MessageBox.Show($"SMTP Error: {smtpEx.Message}");
    }
    catch (Exception ex)
    {
        MessageBox.Show($"General Error: {ex.Message}");
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
