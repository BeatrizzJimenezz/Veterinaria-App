using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;


namespace Base___V1.Logic
{
    
    class ConexionBase
    {
        static private string CadenaConexion = $"server=localhost;user=root;database=db_veterinaria;port=3306;password=";
        private MySqlConnection Conexion = new MySqlConnection(CadenaConexion);

        public MySqlConnection abrirConexion()
        {
            try
            {
                if (Conexion.State == System.Data.ConnectionState.Closed)
                {
                    Conexion.Open();
                }
                return Conexion;
            }
            catch (Exception ex)
            {
                {
                    MessageBox.Show("Error al conectar a la base de datos, por favor verifique la conexión del servidor",
                        "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    abrirConexion();
                }
                return Conexion;

            }
        }
        public MySqlConnection cerrarConexion()
        {
            if(Conexion.State == System.Data.ConnectionState.Open)
            {
                Conexion.Close();
            }
            return Conexion;
        }
        public MySqlConnection getConexion() { return this.Conexion; }
    }
}
