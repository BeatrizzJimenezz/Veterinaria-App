
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
            //enviarCorreosADiario();
            main.Show();
            Application.Run();
        }
    }
}