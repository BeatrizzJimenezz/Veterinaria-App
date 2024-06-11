using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base___V1.Models
{
    public class Vacunas
    {
        public int IdVacuna { get; set; } 
        public string Nombre { get; set; } 
        public string FechaUltAplicacion { get; set; } 
        public string FechaProxAplicacion { get; set; } 
        public string NombreDoctor { get; set; }
        public int IdMascota { get; set; }

        public Vacunas()
        {
            // Constructor por defecto
        }

        public Vacunas(int idVacuna, string nombre, string fechaUltAplicacion, string fechaProxAplicacion, string nombreDoctor, int idMascota)
        {
            IdVacuna = idVacuna;
            Nombre = nombre;
            FechaUltAplicacion = fechaUltAplicacion;
            FechaProxAplicacion = fechaProxAplicacion;
            NombreDoctor = nombreDoctor;
            IdMascota = idMascota;
        }

    }
}
