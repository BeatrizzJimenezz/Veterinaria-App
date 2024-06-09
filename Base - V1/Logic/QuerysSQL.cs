using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base___V1.Models;
using System.Data;

namespace Base___V1.Logic
{
    public class QuerysSQL
    {
        private ConexionBase Conexion = new ConexionBase();
        private MySqlCommand Comando = new MySqlCommand();
        //private MySqlDataReader leerFilas;


        public void InsertarDueno(Dueño duenio)
        {
            Comando.Connection = Conexion.abrirConexion();
            Comando.CommandText = "INSERT INTO tb_dueño (nombre, direccion, correo, telefono) VALUES (@Nombre, @Direccion,@Correo, @Telefono)";
            Comando.Parameters.AddWithValue("@Nombre", duenio.getNombre());
            Comando.Parameters.AddWithValue("@Direccion", duenio.getDireccion());
            Comando.Parameters.AddWithValue("@Correo", duenio.getCorreo());
            Comando.Parameters.AddWithValue("@Telefono", duenio.getTelefono());

            try
            {
                Comando.ExecuteNonQuery();
                MessageBox.Show("Dueño ingresado de manera exitosa","Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar al dueño "+ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                Conexion.cerrarConexion();
            }
        }
        public void InsertarMascota(Mascota mascota)
        {
            Comando.Connection = Conexion.abrirConexion();
            Comando.CommandText = "INSERT INTO tb_mascota (nombre, especie, raza, edad, sexo, color, señas, idDueño, fecha_ingreso) VALUES (@NombreMascota, @Especie,@Raza, @Edad, @Sexo, @Color, @Señas, @idDueño, @FechaIngreso)";
            Comando.Parameters.AddWithValue("@NombreMascota", mascota.getNombre());
            Comando.Parameters.AddWithValue("@Especie", mascota.getEspecie());
            Comando.Parameters.AddWithValue("@Raza", mascota.getRaza());
            Comando.Parameters.AddWithValue("@Edad", mascota.getEdad());
            Comando.Parameters.AddWithValue("@Sexo", mascota.getSexo());
            Comando.Parameters.AddWithValue("@Color", mascota.getColor());
            Comando.Parameters.AddWithValue("@Señas", mascota.getSenias());
            Comando.Parameters.AddWithValue("@idDueño", mascota.getIdDuenio());
            DateTime fechaHoraActual = DateTime.Now;
            Comando.Parameters.AddWithValue("FechaIngreso", fechaHoraActual.ToString("dd/MM/yyyy HH:mm"));

            try
            {
                Comando.ExecuteNonQuery();
                MessageBox.Show("Mascota ingresada de manera exitosa", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar la mascota " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Conexion.cerrarConexion();
            }

        }
        public int ObtenerUltimoIDDuenio()
        {
            string consulta = "SELECT MAX(idDueño) AS ultID FROM tb_dueño";
            Comando.Connection = Conexion.abrirConexion();
            Comando.CommandText = consulta;
            Object resultado = Comando.ExecuteScalar();
            if (resultado != null)
            {
                return Convert.ToInt32(resultado);
            }
            else
            {
                return 0;
            }
        }
        /*public DataGridView ListarAdmin(DataGridView dgAdmin)
        {
            string consulta = "SELECT * FROM tb_dueño";
            
            DataTable dtAdmin = new DataTable();
            try
            {
                MySqlCommand infoDuenio = new MySqlCommand(consulta, Conexion.getConexion());


                Conexion.abrirConexion();
                MySqlDataAdapter adapter1 = new MySqlDataAdapter(infoDuenio);
                DataTable tbDueño = new DataTable();
                adapter1.Fill(tbDueño);


                if (tbDueño.Rows.Count > 0)
                {
                    string idsDueño = string.Join(",", tbDueño.AsEnumerable().Select(row => row.Field<int>("idDueño")));
                    string consulta2 = $"SELECT * FROM tb_mascota WHERE idDueño IN({idsDueño})";
                    MySqlCommand infoMascota = new MySqlCommand(consulta2, Conexion.getConexion());

                    MySqlDataAdapter adapter2 = new MySqlDataAdapter(infoMascota);
                    adapter1.Fill(dtAdmin);
                    adapter2.Fill(dtAdmin);
                    
                }

                dgAdmin.DataSource = dtAdmin;

            }
            catch (Exception ex)
            {

            }
            return dgAdmin;
        }*/
        public DataGridView ListarInformacion(DataGridView dataGridView)
        {
            // Consulta SQL para obtener los datos requeridos de ambas tablas
            string consulta = @"SELECT d.idDueño AS DueñoID, d.nombre AS Responsable,
                                  m.idMascota AS MascotaID, m.nombre AS Paciente,
                                  m.fecha_ingreso AS Fecha_Ingreso
                            FROM tb_dueño d
                            INNER JOIN tb_mascota m ON d.idDueño = m.idDueño";

            // Crear un objeto DataTable para almacenar los datos
            DataTable dtDatos = new DataTable();

            // Establecer una conexión y ejecutar la consulta
            using (Conexion.getConexion())
            {
                using (MySqlCommand comando = new MySqlCommand(consulta, Conexion.getConexion()))
                {
                    Conexion.abrirConexion();

                    // Crear un SqlDataAdapter para ejecutar la consulta y llenar el DataTable con los resultados
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    adapter.Fill(dtDatos);
                }
            }

            

            // Llenar el DataGridView con los datos del DataTable
            dataGridView.DataSource = dtDatos;
            dataGridView.Columns["DueñoID"].Visible = false;
            dataGridView.Columns["MascotaID"].Visible = false;

            // Devolver el DataGridView actualizado
            return dataGridView;
        }
    }
}
