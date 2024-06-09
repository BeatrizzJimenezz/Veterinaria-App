using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base___V1.Models
{
    public class Dueño
    {
        private int idDueno;
        private string nombre;
        private string direccion;
        private string correo;
        private string telefono;

        public Dueño(int idDueno, string nombre, string direccion, string correo, string telefono)
        {
            this.idDueno = idDueno;
            this.nombre = nombre;
            this.direccion = direccion;
            this.correo = correo;
            this.telefono = telefono;
        }
        public Dueño() { }
        public int getIdDueno() { return this.idDueno; } 
        public string getNombre() { return this.nombre; }
        public string getDireccion() { return this.direccion; }
        public string getCorreo() { return this.correo; }
        public string getTelefono() { return this.telefono; }
        
        public void setIdDueno(int id)
        {
            this.idDueno = id;
        }
        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }
        public void setDireccion(string direccion) { this.direccion = direccion;}
        public void setCorreo(string correo) {  this.correo = correo; }
        public void setTelefono(string telefono) { this.telefono= telefono;}
    }
}
