using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base___V1.Models
{
    public class ExamenFisico
    {
        public int IdExamenPrimaria { get; set; }
        public string Fc { get; set; }
        public string Temp { get; set; }
        public string SonidoCardiaco { get; set; }
        public string ReflejoPupilar { get; set; }
        public string Fr { get; set; }
        public string Pulso { get; set; }
        public string Anisocoria { get; set; }
        public string Dentadura { get; set; }
        public string Mucosas { get; set; }
        public string Tonsi { get; set; }
        public string ReflTusigeno { get; set; }
        public string Tllc { get; set; }
        public string PlpAbdominal { get; set; }
        public string Deshidratado { get; set; }
        public string Palmopercusion { get; set; }
        public string Rinon { get; set; }
        public string Vejiga { get; set; }
        public string Dedos { get; set; }
        public string Higado { get; set; }
        public string Prepucio { get; set; }
        public string Intestino { get; set; }
        public string TestiVulva { get; set; }
        public string CondiCorporal { get; set; }
        public string OtrasObservaciones { get; set; }
        public string DxPresuntivo { get; set; }
        public string DxDiferencial { get; set; }
        public string ExamenesLab { get; set; }
        public int IdMascota { get; set; }
        public int? IdConsulta { get; set; } // IdConsulta puede ser nulo
    }
}
