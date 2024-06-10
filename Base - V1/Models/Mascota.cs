using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base___V1.Models
{
    public class Mascota
    {
        private int idMascota;
        private string nombre;
        private string especie;
        private string raza;
        private int edad;
        private string sexo;
        private string color;
        private string senias;
        private int idDuenio;
        private string fechaIngreso;

        public Mascota(int idMascota, string nombre, string especie, string raza, int edad, string sexo, string color, string senias, int idDueño, string fechaIngreso)
        {
            this.idMascota = idMascota;
            this.nombre = nombre;
            this.especie = especie;
            this.raza = raza;
            this.edad = edad;
            this.sexo = sexo;
            this.color = color;
            this.senias = senias;
            this.idDuenio = idDueño;
            this.fechaIngreso = fechaIngreso;
        }
        public Mascota() { }
        public int getIdMascota() {return this.idMascota;}
        public string getNombre() {return this.nombre;}
        public string getEspecie() {return this.especie;}
        public string getRaza() { return this.raza;}
        public string getSenias() {return this.senias;}
        public int getEdad() { return this.edad; }
        public string getSexo() { return this.sexo;}
        public string getColor() {return this.color;}
        public int getIdDuenio() { return this.idDuenio; }
        public string getFechaIngreso() {return this.fechaIngreso;}
        public void setIdMascota(int id) { this.idMascota = id;}
        public void setNombre(string nombre) { this.nombre = nombre;}
        public void setEspecie(string especie) { this.especie = especie;}
        public void setRaza(string raza) { this.raza = raza;}
        public void setSenias(string senias) { this.senias = senias;}
        public void setEdad(int edad) {  this.edad = edad;}
        public void setSexo(string sexo) { this.sexo = sexo;}
        public void setColor(string color) { this.color = color;}
        public void setIdDuenio(int id) {this.idDuenio = id;}
        public void setFechaIngreso(string fecha) { this.fechaIngreso = fecha;}


    }
}
