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
                MessageBox.Show("Dueño ingresado de manera exitosa", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar al dueño " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        public bool getClave(String key)
        {
            int id = 1;
            Comando.Connection = Conexion.abrirConexion();
            Comando.CommandText = $"SELECT * FROM tb_key WHERE id = {id}";
            Comando.CommandType = CommandType.Text;
            MySqlDataReader dr = Comando.ExecuteReader();
            string clave = "";
            if (dr.Read())
            {
                clave = dr["clave"].ToString();
                Conexion.cerrarConexion();
                if(key == clave)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            else
            {
                Conexion.cerrarConexion();
                MessageBox.Show("Error al cargar la informacion de la mascota", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool updateClave(string new_key, string old_key)
        {
            if (getClave(old_key))
            {
                try
                {
                    Comando.Connection = Conexion.abrirConexion();
                    Comando.CommandText = $"UPDATE tb_key SET clave = '{new_key}' WHERE id = {1}";
                    Comando.CommandType = CommandType.Text;
                    Comando.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show("Error al editar los datos del paciente. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                finally
                {
                    Conexion.cerrarConexion();
                }

            }
            else
            {
                return false;
            }
        }
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
            using (MySqlCommand comando = new MySqlCommand(consulta, Conexion.abrirConexion()))
            {
                Conexion.abrirConexion();

                // Crear un SqlDataAdapter para ejecutar la consulta y llenar el DataTable con los resultados
                MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                adapter.Fill(dtDatos);
            }



            // Llenar el DataGridView con los datos del DataTable
            dataGridView.DataSource = dtDatos;
            dataGridView.Columns["DueñoID"].Visible = false;
            dataGridView.Columns["MascotaID"].Visible = false;
            Conexion.cerrarConexion();
            // Devolver el DataGridView actualizado
            return dataGridView;
        }
        public Mascota getMascota(int id)
        {
            Mascota m = new Mascota();

            Comando.Connection = Conexion.abrirConexion();
            Comando.CommandText = $"SELECT * FROM tb_mascota WHERE idMascota = {id}";
            Comando.CommandType = CommandType.Text;
            MySqlDataReader dr = Comando.ExecuteReader();

            if (dr.Read())
            {
                m.setIdMascota(int.Parse(dr["idMascota"].ToString()));
                m.setNombre(dr["nombre"].ToString());
                m.setEspecie(dr["especie"].ToString());
                m.setRaza(dr["raza"].ToString());
                m.setEdad(int.Parse(dr["edad"].ToString()));
                m.setSexo(dr["sexo"].ToString());
                m.setColor(dr["color"].ToString());
                m.setSenias(dr["señas"].ToString());
                m.setIdDuenio(int.Parse(dr["idDueño"].ToString()));
                m.setFechaIngreso(dr["fecha_ingreso"].ToString());
                Conexion.cerrarConexion();
                return m;
            }
            else
            {
                Conexion.cerrarConexion();
                MessageBox.Show("Error al cargar la informacion de la mascota", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return m;
            }
        }
        public Dueño getDueño(int id)
        {
            Dueño d = new Dueño();

            Comando.Connection = Conexion.abrirConexion();
            Comando.CommandText = $"SELECT * FROM tb_dueño WHERE idDueño = {id}";
            Comando.CommandType = CommandType.Text;
            MySqlDataReader dr = Comando.ExecuteReader();

            if (dr.Read()) {
                d.setIdDueno(id);
                d.setNombre(dr["nombre"].ToString());
                d.setDireccion(dr["direccion"].ToString());
                d.setCorreo(dr["correo"].ToString());
                d.setTelefono(dr["telefono"].ToString());

                Conexion.cerrarConexion();

                return d;

            }
            else
            {
                MessageBox.Show("Error al cargar la informacion del dueño", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Conexion.cerrarConexion();
                return d;
            }
        }

        public void editarDatosPaciente(Mascota m)
        {
            try
            {
                Comando.Connection = Conexion.abrirConexion();
                Comando.CommandText = $"UPDATE tb_mascota SET nombre = '{m.getNombre()}', especie = '{m.getEspecie()}'" +
                    $", raza = '{m.getRaza()}', edad = {m.getEdad()}, sexo = '{m.getSexo()}', color = '{m.getColor()}'" +
                    $", señas = '{m.getSenias()}' WHERE idMascota = {m.getIdMascota()}";

                Comando.CommandType = CommandType.Text;
                Comando.ExecuteNonQuery();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al editar los datos del paciente. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Conexion.cerrarConexion();
            }

        }
        public void editarDueño(Dueño d)
        {
            try
            {
                Comando.Connection = Conexion.abrirConexion();
                Comando.CommandText = $"UPDATE tb_dueño SET nombre = '{d.getNombre()}', direccion = '{d.getDireccion()}'" +
                    $", correo = '{d.getCorreo()}', telefono = '{d.getTelefono()}' WHERE idDueño = {d.getIdDueno()}";
                Comando.CommandType = CommandType.Text;
                Comando.ExecuteNonQuery();
                Conexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al editar los datos del dueño. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                Conexion.cerrarConexion();
            }



        }
        public bool InsertarConsulta(Consulta consulta)
        {
            Comando.Connection = Conexion.abrirConexion();
            Comando.CommandText = @"
            INSERT INTO tb_consulta (
                in_vacunas, in_quintuple, in_tripleFelina, in_parvovirus, in_rabia, in_giardia, 
                in_bordetella, in_leucemia, in_otra, in_desparacitacion, fecha_desparacitacion, 
                medicamento_desparacitacion, in_controlGarrapata, fecha_controlGarrapata, 
                medicamento_controlGarrapata, tiempo_mascota, otras_mascotas, dieta_alimenticia, 
                acceso_calle, contacto_enfermos, enfermedades_Ant, habitat, sintomas_obs, 
                med_Adm_Casa, stAspecto, stLesiones, stAlopecia, stParasitos, smeMovimeinto, 
                sdApetito, sdIngestoAgua, sdVomito, sdVomitoFrecuencia, sdAspecto, sdDefeca, 
                sdDefecaFrecuencia, sdColor,sdAspectoDefeca, sdEstreñimiento, sdFlatulencia, sdDeglucion, srTos, 
                srTipo, srDisnea, srEstornudos, srDescargaNasal, scFF, scClanosis, scTosNocturna, 
                suOrina, suCastrado, suCruzadoRaza, suGestante, suPsudociesis, suUltimoCelo, 
                suUltimo_parto, suDescarga_PreVa, snComportamiento, snIncoordinacion, snDismetria, 
                snGolpe_Previo, snResponde_llamado, snOjos, snSecrecion, snCeguera, snOidos, 
                snSeRasca, snMalOlor, snEscucha, snParasitos, snDescarga, snAfectado, idMascota, 
                fecha_realizado, motivo_consulta
            ) VALUES (
                @in_vacunas, @in_quintuple, @in_tripleFelina, @in_parvovirus, @in_rabia, @in_giardia, 
                @in_bordetella, @in_leucemia, @in_otra, @in_desparacitacion, @fecha_desparacitacion, 
                @medicamento_desparacitacion, @in_controlGarrapata, @fecha_controlGarrapata, 
                @medicamento_controlGarrapata, @tiempo_mascota, @otras_mascotas, @dieta_alimenticia, 
                @acceso_calle, @contacto_enfermos, @enfermedades_Ant, @habitat, @sintomas_obs, 
                @med_Adm_Casa, @stAspecto, @stLesiones, @stAlopecia, @stParasitos, @smeMovimeinto, 
                @sdApetito, @sdIngestoAgua, @sdVomito, @sdVomitoFrecuencia, @sdAspecto, @sdDefeca, 
                @sdDefecaFrecuencia, @sdColor,@sdAspectoDefeca, @sdEstreñimiento, @sdFlatulencia, @sdDeglucion, @srTos, 
                @srTipo, @srDisnea, @srEstornudos, @srDescargaNasal, @scFF, @scClanosis, @scTosNocturna, 
                @suOrina, @suCastrado, @suCruzadoRaza, @suGestante, @suPsudociesis, @suUltimoCelo, 
                @suUltimo_parto, @suDescarga_PreVa, @snComportamiento, @snIncoordinacion, @snDismetria, 
                @snGolpe_Previo, @snResponde_llamado, @snOjos, @snSecrecion, @snCeguera, @snOidos, 
                @snSeRasca, @snMalOlor, @snEscucha, @snParasitos, @snDescarga, @snAfectado, @idMascota, 
                @fecha_realizado, @motivo_consulta
            );
        ";
            Comando.Parameters.AddWithValue("@in_vacunas", (object)consulta.InVacunas ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@in_quintuple", (object)consulta.InQuintuple ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@in_tripleFelina", (object)consulta.InTripleFelina ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@in_parvovirus", (object)consulta.InParvovirus ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@in_rabia", (object)consulta.InRabia ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@in_giardia", (object)consulta.InGiardia ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@in_bordetella", (object)consulta.InBordetella ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@in_leucemia", (object)consulta.InLeucemia ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@in_otra", (object)consulta.InOtra ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@in_desparacitacion", (object)consulta.InDesparacitacion ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@fecha_desparacitacion", (object)consulta.FechaDesparacitacion ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@medicamento_desparacitacion", (object)consulta.MedicamentoDesparacitacion ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@in_controlGarrapata", (object)consulta.InControlGarrapata ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@fecha_controlGarrapata", (object)consulta.FechaControlGarrapata ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@medicamento_controlGarrapata", (object)consulta.MedicamentoControlGarrapata ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@tiempo_mascota", (object)consulta.TiempoMascota ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@otras_mascotas", (object)consulta.OtrasMascotas ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@dieta_alimenticia", (object)consulta.DietaAlimenticia ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@acceso_calle", (object)consulta.AccesoCalle ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@contacto_enfermos", (object)consulta.ContactoEnfermos ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@enfermedades_Ant", (object)consulta.EnfermedadesAnt ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@habitat", (object)consulta.Habitat ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@sintomas_obs", (object)consulta.SintomasObs ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@med_Adm_Casa", (object)consulta.MedAdmCasa ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@stAspecto", (object)consulta.StAspecto ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@stLesiones", (object)consulta.StLesiones ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@stAlopecia", (object)consulta.StAlopecia ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@stParasitos", (object)consulta.StParasitos ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@smeMovimeinto", (object)consulta.SmeMovimeinto ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@sdApetito", (object)consulta.SdApetito ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@sdIngestoAgua", (object)consulta.SdIngestoAgua ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@sdVomito", (object)consulta.SdVomito ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@sdVomitoFrecuencia", (object)consulta.SdVomitoFrecuencia ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@sdAspecto", (object)consulta.SdAspecto ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@sdDefeca", (object)consulta.SdDefeca ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@sdDefecaFrecuencia", (object)consulta.SdDefecaFrecuencia ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@sdColor", (object)consulta.SdColor ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@sdAspectoDefeca", (object)consulta.SdAspectoDefeca ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@sdEstreñimiento", (object)consulta.SdEstreñimiento ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@sdFlatulencia", (object)consulta.SdFlatulencia ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@sdDeglucion", (object)consulta.SdDeglucion ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@srTos", (object)consulta.SrTos ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@srTipo", (object)consulta.SrTipo ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@srDisnea", (object)consulta.SrDisnea ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@srEstornudos", (object)consulta.SrEstornudos ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@srDescargaNasal", (object)consulta.SrDescargaNasal ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@scFF", (object)consulta.ScFF ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@scClanosis", (object)consulta.ScClanosis ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@scTosNocturna", (object)consulta.ScTosNocturna ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@suOrina", (object)consulta.SuOrina ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@suCastrado", (object)consulta.SuCastrado ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@suCruzadoRaza", (object)consulta.SuCruzadoRaza ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@suGestante", (object)consulta.SuGestante ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@suPsudociesis", (object)consulta.SuPsudociesis ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@suUltimoCelo", (object)consulta.SuUltimoCelo ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@suUltimo_parto", (object)consulta.SuUltimoParto ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@suDescarga_PreVa", (object)consulta.SuDescargaPreVa ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@snComportamiento", (object)consulta.SnComportamiento ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@snIncoordinacion", (object)consulta.SnIncoordinacion ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@snDismetria", (object)consulta.SnDismetria ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@snGolpe_Previo", (object)consulta.SnGolpePrevio ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@snResponde_llamado", (object)consulta.SnRespondeLlamado ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@snOjos", (object)consulta.SnOjos ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@snSecrecion", (object)consulta.SnSecrecion ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@snCeguera", (object)consulta.SnCeguera ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@snOidos", (object)consulta.SnOidos ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@snSeRasca", (object)consulta.SnSeRasca ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@snMalOlor", (object)consulta.SnMalOlor ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@snEscucha", (object)consulta.SnEscucha ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@snParasitos", (object)consulta.SnParasitos ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@snDescarga", (object)consulta.SnDescarga ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@snAfectado", (object)consulta.SnAfectado ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@idMascota", (object)consulta.IdMascota);
            Comando.Parameters.AddWithValue("@fecha_realizado", (object)consulta.FechaRealizado ?? DBNull.Value);
            Comando.Parameters.AddWithValue("@motivo_consulta", consulta.MotivoConsulta ?? (object)DBNull.Value);

            try
            {
                Comando.ExecuteNonQuery();
                MessageBox.Show("Consulta registrada de manera exitosa", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar la consulta " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                Conexion.cerrarConexion();
            }

        }
        public DataGridView ListarConsultas(DataGridView dataGridView, int id)
        {
            // Consulta SQL para obtener los datos requeridos de ambas tablas
            string consulta = $@"SELECT idConsulta AS ConsultaID, fecha_realizado AS Fecha_Realizado, 
                                motivo_consulta AS Motivo_Consulta FROM tb_consulta WHERE idMascota = {id}";

            // Crear un objeto DataTable para almacenar los datos
            DataTable dtDatos = new DataTable();

            // Establecer una conexión y ejecutar la consulta
            using (MySqlCommand comando = new MySqlCommand(consulta, Conexion.abrirConexion()))
            {
                Conexion.abrirConexion();

                // Crear un SqlDataAdapter para ejecutar la consulta y llenar el DataTable con los resultados
                MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                adapter.Fill(dtDatos);
            }



            // Llenar el DataGridView con los datos del DataTable
            dataGridView.DataSource = dtDatos;
            dataGridView.Columns["ConsultaID"].Visible = false;
            Conexion.cerrarConexion();

            // Devolver el DataGridView actualizado
            return dataGridView;
        }

        public Consulta getConsulta(int id) {
            Consulta consulta = new Consulta();
            Comando.Connection = Conexion.abrirConexion();
            Comando.CommandText = $"SELECT * FROM tb_consulta WHERE idConsulta = {id}";
            Comando.CommandType = CommandType.Text;
            MySqlDataReader dr = Comando.ExecuteReader();

            if (dr.Read())
            {
                consulta.IdConsulta = dr.GetInt32(0);
                consulta.InVacunas = dr.GetInt32(1);
                consulta.InQuintuple = dr.GetInt32(2);
                consulta.InTripleFelina = dr.GetInt32(3);
                consulta.InParvovirus = dr.GetInt32(4);
                consulta.InRabia = dr.GetInt32(5);
                consulta.InGiardia = dr.GetInt32(6);
                consulta.InBordetella = dr.GetInt32(7);
                consulta.InLeucemia = dr.GetInt32(8);
                consulta.InOtra = dr.GetString(9);
                consulta.InDesparacitacion = dr.GetInt32(10);
                consulta.FechaDesparacitacion = dr.GetString(11);
                consulta.MedicamentoDesparacitacion = dr.GetString(12);
                consulta.InControlGarrapata = dr.GetInt32(13);
                consulta.FechaControlGarrapata = dr.GetString(14);
                consulta.MedicamentoControlGarrapata = dr.GetString(15);
                consulta.TiempoMascota = dr.GetString(16);
                consulta.OtrasMascotas = dr.GetString(17);
                consulta.DietaAlimenticia = dr.GetString(18);
                consulta.AccesoCalle = dr.GetInt32(19);
                consulta.ContactoEnfermos = dr.GetInt32(20);
                consulta.EnfermedadesAnt = dr.GetString(21);
                consulta.Habitat = dr.GetString(22);
                consulta.SintomasObs = dr.GetString(23);
                consulta.MedAdmCasa = dr.GetString(24);
                consulta.StAspecto = dr.GetString(25);
                consulta.StLesiones = dr.GetString(26);
                consulta.StAlopecia = dr.GetString(27);
                consulta.StParasitos = dr.GetString(28);
                consulta.SmeMovimeinto = dr.GetString(29);
                consulta.SdApetito = dr.GetString(30);
                consulta.SdIngestoAgua = dr.GetString(31);
                consulta.SdVomito = dr.GetInt32(32);
                consulta.SdVomitoFrecuencia = dr.GetString(33);
                consulta.SdAspecto = dr.GetString(34);
                consulta.SdDefeca = dr.GetInt32(35);
                consulta.SdDefecaFrecuencia = dr.GetString(36);
                consulta.SdColor = dr.GetString(37);
                consulta.SdAspectoDefeca = dr.GetString(38);
                consulta.SdEstreñimiento = dr.GetInt32(39);
                consulta.SdFlatulencia = dr.GetInt32(40);
                consulta.SdDeglucion = dr.GetInt32(41);
                consulta.SrTos = dr.GetString(42);
                consulta.SrTipo = dr.GetString(43);
                consulta.SrDisnea = dr.GetString(44);
                consulta.SrEstornudos = dr.GetString(45);
                consulta.SrDescargaNasal = dr.GetString(46);
                consulta.ScFF = dr.GetString(47);
                consulta.ScClanosis = dr.GetString(48);
                consulta.ScTosNocturna = dr.GetString(49);
                consulta.SuOrina = dr.GetString(50);
                consulta.SuCastrado = dr.GetString(51);
                consulta.SuCruzadoRaza = dr.GetInt32(52);
                consulta.SuGestante = dr.GetInt32(53);
                consulta.SuPsudociesis = dr.GetString(54);
                consulta.SuUltimoCelo = dr.GetString(55);
                consulta.SuUltimoParto = dr.GetString(56);
                consulta.SuDescargaPreVa = dr.GetString(57);
                consulta.SnComportamiento = dr.GetString(58);
                consulta.SnIncoordinacion = dr.GetString(59);
                consulta.SnDismetria = dr.GetString(60);
                consulta.SnGolpePrevio = dr.GetInt32(61);
                consulta.SnRespondeLlamado = dr.GetInt32(62);
                consulta.SnOjos = dr.GetString(63);
                consulta.SnSecrecion = dr.GetString(64);
                consulta.SnCeguera = dr.GetString(65);
                consulta.SnOidos = dr.GetString(66);
                consulta.SnSeRasca = dr.GetString(67);
                consulta.SnMalOlor = dr.GetString(68);
                consulta.SnEscucha = dr.GetString(69);
                consulta.SnParasitos = dr.GetString(70);
                consulta.SnDescarga = dr.GetString(71);
                consulta.SnAfectado = dr.GetString(72);
                consulta.IdMascota = dr.GetInt32(73);
                consulta.FechaRealizado = dr.GetString(74);
                consulta.MotivoConsulta = dr.GetString(75);
                Conexion.cerrarConexion();
                return consulta;
            }
            else
            {
                Conexion.cerrarConexion();
                MessageBox.Show("Error al cargar la informacion de la consulta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return consulta;
            }
        }
        public void editarConsulta(Consulta consulta)
        {
            try
            {
                Comando.Connection = Conexion.abrirConexion();
                Comando.CommandText = $@"UPDATE tb_consulta
                         SET 
                            in_vacunas = {consulta.InVacunas},
                            in_quintuple = {consulta.InQuintuple},
                            in_tripleFelina = {consulta.InTripleFelina},
                            in_parvovirus = '{consulta.InParvovirus}',
                            in_rabia = '{consulta.InRabia}',
                            in_giardia = '{consulta.InGiardia}',
                            in_bordetella = '{consulta.InBordetella}',
                            in_leucemia = '{consulta.InLeucemia}',
                            in_otra = '{consulta.InOtra}',
                            in_desparacitacion = {consulta.InDesparacitacion},
                            fecha_desparacitacion = '{consulta.FechaDesparacitacion}',
                            medicamento_desparacitacion = '{consulta.MedicamentoDesparacitacion}',
                            in_controlGarrapata = {consulta.InControlGarrapata},
                            fecha_controlGarrapata = '{consulta.FechaControlGarrapata}',
                            medicamento_controlGarrapata = '{consulta.MedicamentoControlGarrapata}',
                            tiempo_mascota = '{consulta.TiempoMascota}',
                            otras_mascotas = '{consulta.OtrasMascotas}',
                            dieta_alimenticia = '{consulta.DietaAlimenticia}',
                            acceso_calle = {consulta.AccesoCalle},
                            contacto_enfermos = {consulta.ContactoEnfermos},
                            enfermedades_Ant = '{consulta.EnfermedadesAnt}',
                            habitat = '{consulta.Habitat}',
                            sintomas_obs = '{consulta.SintomasObs}',
                            med_Adm_Casa = '{consulta.MedAdmCasa}',
                            stAspecto = '{consulta.StAspecto}',
                            stLesiones = '{consulta.StLesiones}',
                            stAlopecia = '{consulta.StAlopecia}',
                            stParasitos = '{consulta.StParasitos}',
                            smeMovimeinto = '{consulta.SmeMovimeinto}',
                            sdApetito = '{consulta.SdApetito}',
                            sdIngestoAgua = '{consulta.SdIngestoAgua}',
                            sdVomito = {consulta.SdVomito},
                            sdVomitoFrecuencia = '{consulta.SdVomitoFrecuencia}',
                            sdAspecto = '{consulta.SdAspecto}',
                            sdDefeca = {consulta.SdDefeca},
                            sdDefecaFrecuencia = '{consulta.SdDefecaFrecuencia}',
                            sdColor = '{consulta.SdColor}',
                            sdAspectoDefeca = '{consulta.SdAspectoDefeca}',
                            sdEstreñimiento = {consulta.SdEstreñimiento},
                            sdFlatulencia = {consulta.SdFlatulencia},
                            sdDeglucion = {consulta.SdDeglucion},
                            srTos = '{consulta.SrTos}',
                            srTipo = '{consulta.SrTipo}',
                            srDisnea = '{consulta.SrDisnea}',
                            srEstornudos = '{consulta.SrEstornudos}',
                            srDescargaNasal = '{consulta.SrDescargaNasal}',
                            scFF = '{consulta.ScFF}',
                            scClanosis = '{consulta.ScClanosis}',
                            scTosNocturna = '{consulta.ScTosNocturna}',
                            suOrina = '{consulta.SuOrina}',
                            suCastrado = '{consulta.SuCastrado}',
                            suCruzadoRaza = {consulta.SuCruzadoRaza},
                            suGestante = {consulta.SuGestante},
                            suPsudociesis = '{consulta.SuPsudociesis}',
                            suUltimoCelo = '{consulta.SuUltimoCelo}',
                            suUltimo_parto = '{consulta.SuUltimoParto}',
                            suDescarga_PreVa = '{consulta.SuDescargaPreVa}',
                            snComportamiento = '{consulta.SnComportamiento}',
                            snIncoordinacion = '{consulta.SnIncoordinacion}',
                            snDismetria = '{consulta.SnDismetria}',
                            snGolpe_Previo = {consulta.SnGolpePrevio},
                            snResponde_llamado = {consulta.SnRespondeLlamado},
                            snOjos = '{consulta.SnOjos}',
                            snSecrecion = '{consulta.SnSecrecion}',
                            snCeguera = '{consulta.SnCeguera}',
                            snOidos = '{consulta.SnOidos}',
                            snSeRasca = '{consulta.SnSeRasca}',
                            snMalOlor = '{consulta.SnMalOlor}',
                            snEscucha = '{consulta.SnEscucha}',
                            snParasitos = '{consulta.SnParasitos}',
                            snDescarga = '{consulta.SnDescarga}',
                            snAfectado = '{consulta.SnAfectado}',
                            motivo_consulta = '{consulta.MotivoConsulta}'
                        WHERE idConsulta = {consulta.IdConsulta}";
                Comando.CommandType = CommandType.Text;
                Comando.ExecuteNonQuery();
                Conexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al editar los datos de la consulta. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                Conexion.cerrarConexion();
            }
        }
        public void insertarExamenFisico(ExamenFisico examen)
        {
            Comando.Connection = Conexion.abrirConexion();
            Comando.CommandText = @"
                INSERT INTO tb_examenfisico (fc, temp, sonido_cardiaco, reflejo_pupilar, fr, pulso, anisocoria, dentadura, mucosas, tonsi, refl_tusigeno, tllc, plp_Abdominal, deshidratado, palmopercusion, riñon, vejiga, dedos, higado, prepucio, intestino, testi_vulva, condi_corporal, otras_observaciones, dx_presuntivo, dx_diferencial, examenes_lab, idMascota, idConsulta)
                VALUES (@Fc, @Temp, @SonidoCardiaco, @ReflejoPupilar, @Fr, @Pulso, @Anisocoria, @Dentadura, @Mucosas, @Tonsi, @ReflTusigeno, @Tllc, @PlpAbdominal, @Deshidratado, @Palmopercusion, @Rinon, @Vejiga, @Dedos, @Higado, @Prepucio, @Intestino, @TestiVulva, @CondiCorporal, @OtrasObservaciones, @DxPresuntivo, @DxDiferencial, @ExamenesLab, @IdMascota22, @IdConsulta)";
            Comando.Parameters.AddWithValue("@Fc", examen.Fc ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@Temp", examen.Temp ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@SonidoCardiaco", examen.SonidoCardiaco ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@ReflejoPupilar", examen.ReflejoPupilar ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@Fr", examen.Fr ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@Pulso", examen.Pulso ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@Anisocoria", examen.Anisocoria ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@Dentadura", examen.Dentadura ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@Mucosas", examen.Mucosas ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@Tonsi", examen.Tonsi ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@ReflTusigeno", examen.ReflTusigeno ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@Tllc", examen.Tllc ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@PlpAbdominal", examen.PlpAbdominal ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@Deshidratado", examen.Deshidratado ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@Palmopercusion", examen.Palmopercusion ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@Rinon", examen.Rinon ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@Vejiga", examen.Vejiga ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@Dedos", examen.Dedos ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@Higado", examen.Higado ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@Prepucio", examen.Prepucio ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@Intestino", examen.Intestino ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@TestiVulva", examen.TestiVulva ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@CondiCorporal", examen.CondiCorporal ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@OtrasObservaciones", examen.OtrasObservaciones ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@DxPresuntivo", examen.DxPresuntivo ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@DxDiferencial", examen.DxDiferencial ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@ExamenesLab", examen.ExamenesLab ?? (object)DBNull.Value);
            Comando.Parameters.AddWithValue("@IdMascota22", examen.IdMascota);
            Comando.Parameters.AddWithValue("@IdConsulta", examen.IdConsulta ?? (object)DBNull.Value);

            try
            {
                Comando.ExecuteNonQuery();
                MessageBox.Show("Examen fisico registrado de manera exitosa", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el examen fisico " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Conexion.cerrarConexion();
            }
        }
        public void editarExamenFisico(ExamenFisico exp)
        {
            try
            {
                Comando.Connection = Conexion.abrirConexion();
                Comando.CommandText = $@"
                UPDATE tb_examenfisico
                SET 
                    fc = '{exp.Fc}',
                    temp = '{exp.Temp}',
                    sonido_cardiaco = '{exp.SonidoCardiaco}',
                    reflejo_pupilar = '{exp.ReflejoPupilar}',
                    fr = '{exp.Fr}',
                    pulso = '{exp.Pulso}',
                    anisocoria = '{exp.Anisocoria}',
                    dentadura = '{exp.Dentadura}',
                    mucosas = '{exp.Mucosas}',
                    tonsi = '{exp.Tonsi}',
                    refl_tusigeno = '{exp.ReflTusigeno}',
                    tllc = '{exp.Tllc}',
                    plp_Abdominal = '{exp.PlpAbdominal}',
                    deshidratado = '{exp.Deshidratado}',
                    palmopercusion = '{exp.Palmopercusion}',
                    riñon = '{exp.Rinon}',
                    vejiga = '{exp.Vejiga}',
                    dedos = '{exp.Dedos}',
                    higado = '{exp.Higado}',
                    prepucio = '{exp.Prepucio}',
                    intestino = '{exp.Intestino}',
                    testi_vulva = '{exp.TestiVulva}',
                    condi_corporal = '{exp.CondiCorporal}',
                    otras_observaciones = '{exp.OtrasObservaciones}',
                    dx_presuntivo = '{exp.DxPresuntivo}',
                    dx_diferencial = '{exp.DxDiferencial}',
                    examenes_lab = '{exp.ExamenesLab}'
                WHERE idConsulta = {exp.IdConsulta}";
                Comando.CommandType = CommandType.Text;
                Comando.ExecuteNonQuery();
                Conexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al editar los datos del examen. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                Conexion.cerrarConexion();
            }

        }
        public ExamenFisico GetExamenFisico(int idExamen)
        {
            ExamenFisico exam = new ExamenFisico();
            Comando.Connection = Conexion.abrirConexion();
            Comando.CommandText = $"SELECT * FROM tb_examenfisico WHERE idConsulta = {idExamen}";
            Comando.CommandType = CommandType.Text;
            MySqlDataReader dr = Comando.ExecuteReader();
            if (dr.Read()) {
                exam.IdExamenPrimaria = dr.GetInt32("idExamen");
                exam.Fc = dr.IsDBNull(dr.GetOrdinal("fc")) ? null : dr.GetString("fc");
                exam.Temp = dr.IsDBNull(dr.GetOrdinal("temp")) ? null : dr.GetString("temp");
                exam.SonidoCardiaco = dr.IsDBNull(dr.GetOrdinal("sonido_cardiaco")) ? null : dr.GetString("sonido_cardiaco");
                exam.ReflejoPupilar = dr.IsDBNull(dr.GetOrdinal("reflejo_pupilar")) ? null : dr.GetString("reflejo_pupilar");
                exam.Fr = dr.IsDBNull(dr.GetOrdinal("fr")) ? null : dr.GetString("fr");
                exam.Pulso = dr.IsDBNull(dr.GetOrdinal("pulso")) ? null : dr.GetString("pulso");
                exam.Anisocoria = dr.IsDBNull(dr.GetOrdinal("anisocoria")) ? null : dr.GetString("anisocoria");
                exam.Dentadura = dr.IsDBNull(dr.GetOrdinal("dentadura")) ? null : dr.GetString("dentadura");
                exam.Mucosas = dr.IsDBNull(dr.GetOrdinal("mucosas")) ? null : dr.GetString("mucosas");
                exam.Tonsi = dr.IsDBNull(dr.GetOrdinal("tonsi")) ? null : dr.GetString("tonsi");
                exam.ReflTusigeno = dr.IsDBNull(dr.GetOrdinal("refl_tusigeno")) ? null : dr.GetString("refl_tusigeno");
                exam.Tllc = dr.IsDBNull(dr.GetOrdinal("tllc")) ? null : dr.GetString("tllc");
                exam.PlpAbdominal = dr.IsDBNull(dr.GetOrdinal("plp_Abdominal")) ? null : dr.GetString("plp_Abdominal");
                exam.Deshidratado = dr.IsDBNull(dr.GetOrdinal("deshidratado")) ? null : dr.GetString("deshidratado");
                exam.Palmopercusion = dr.IsDBNull(dr.GetOrdinal("palmopercusion")) ? null : dr.GetString("palmopercusion");
                exam.Rinon = dr.IsDBNull(dr.GetOrdinal("riñon")) ? null : dr.GetString("riñon");
                exam.Vejiga = dr.IsDBNull(dr.GetOrdinal("vejiga")) ? null : dr.GetString("vejiga");
                exam.Dedos = dr.IsDBNull(dr.GetOrdinal("dedos")) ? null : dr.GetString("dedos");
                exam.Higado = dr.IsDBNull(dr.GetOrdinal("higado")) ? null : dr.GetString("higado");
                exam.Prepucio = dr.IsDBNull(dr.GetOrdinal("prepucio")) ? null : dr.GetString("prepucio");
                exam.Intestino = dr.IsDBNull(dr.GetOrdinal("intestino")) ? null : dr.GetString("intestino");
                exam.TestiVulva = dr.IsDBNull(dr.GetOrdinal("testi_vulva")) ? null : dr.GetString("testi_vulva");
                exam.CondiCorporal = dr.IsDBNull(dr.GetOrdinal("condi_corporal")) ? null : dr.GetString("condi_corporal");
                exam.OtrasObservaciones = dr.IsDBNull(dr.GetOrdinal("otras_observaciones")) ? null : dr.GetString("otras_observaciones");
                exam.DxPresuntivo = dr.IsDBNull(dr.GetOrdinal("dx_presuntivo")) ? null : dr.GetString("dx_presuntivo");
                exam.DxDiferencial = dr.IsDBNull(dr.GetOrdinal("dx_diferencial")) ? null : dr.GetString("dx_diferencial");
                exam.ExamenesLab = dr.IsDBNull(dr.GetOrdinal("examenes_lab")) ? null : dr.GetString("examenes_lab");
                exam.IdMascota = dr.GetInt32("idMascota");
                exam.IdConsulta = dr.IsDBNull(dr.GetOrdinal("idConsulta")) ? 0 : dr.GetInt32("idConsulta");
                Conexion.cerrarConexion();
                return exam;
            }
            else
            {
                Conexion.cerrarConexion();
                MessageBox.Show("Error al cargar la informacion del Examen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return exam;
            }
        }
        public int getUltimaConsulta()
        {
            string consulta = "SELECT MAX(idConsulta) AS ultID FROM tb_consulta";
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

        public DataGridView ListarBusquedaPaciente(DataGridView dataGridView, string busqueda)
        {
            if (busqueda != "Busca algo...")
            {
                // Consulta SQL para obtener los datos requeridos de ambas tablas
                string consulta = $@"SELECT d.idDueño AS DueñoID, d.nombre AS Responsable,
                                  m.idMascota AS MascotaID, m.nombre AS Paciente,
                                  m.fecha_ingreso AS Fecha_Ingreso
                            FROM tb_dueño d
                            INNER JOIN tb_mascota m ON d.idDueño = m.idDueño 
                            WHERE d.nombre LIKE '%{busqueda}%' OR m.nombre LIKE '%{busqueda}%'; ";

                // Crear un objeto DataTable para almacenar los datos
                DataTable dtDatos = new DataTable();

                // Establecer una conexión y ejecutar la consulta
                using (MySqlCommand comando = new MySqlCommand(consulta, Conexion.abrirConexion()))
                {

                    // Crear un SqlDataAdapter para ejecutar la consulta y llenar el DataTable con los resultados
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    adapter.Fill(dtDatos);
                }




                // Llenar el DataGridView con los datos del DataTable
                dataGridView.DataSource = dtDatos;
                dataGridView.Columns["DueñoID"].Visible = false;
                dataGridView.Columns["MascotaID"].Visible = false;
                Conexion.cerrarConexion();
                // Devolver el DataGridView actualizado
                return dataGridView;
            }
            return dataGridView;
        }
        public DataGridView ListarConsultasBusqueda(DataGridView dataGridView, int id, string busqueda)
        {
            if (busqueda != "Busca algo...")
            {
                // Consulta SQL para obtener los datos requeridos de ambas tablas
                string consulta = $@"SELECT idConsulta AS ConsultaID, fecha_realizado AS Fecha_Realizado, 
                                motivo_consulta AS Motivo_Consulta FROM tb_consulta WHERE idMascota = {id} 
                                AND Fecha_Realizado LIKE '%{busqueda}%' OR Motivo_Consulta LIKE '%{busqueda}%'";

                // Crear un objeto DataTable para almacenar los datos
                DataTable dtDatos = new DataTable();

                // Establecer una conexión y ejecutar la consulta
                using (MySqlCommand comando = new MySqlCommand(consulta, Conexion.abrirConexion()))
                {
                    Conexion.abrirConexion();

                    // Crear un SqlDataAdapter para ejecutar la consulta y llenar el DataTable con los resultados
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    adapter.Fill(dtDatos);
                }



                // Llenar el DataGridView con los datos del DataTable
                dataGridView.DataSource = dtDatos;
                dataGridView.Columns["ConsultaID"].Visible = false;
                Conexion.cerrarConexion();

                // Devolver el DataGridView actualizado
                return dataGridView;
            }
            return dataGridView;
        }
        public bool ingresarVacuna(Vacunas vacuna)
        {

            Comando.Connection = Conexion.abrirConexion();
            Comando.CommandText = "INSERT INTO tb_vacunas (nombre, fechaUltAplicacion, fechaProxAplicacion, nombre_doctor, idMascota) VALUES (@Nombre, @FechaUltAplicacion, @FechaProxAplicacion, @NombreDoctor, @IdMascota)";
            Comando.Parameters.AddWithValue("@Nombre", vacuna.Nombre);
            Comando.Parameters.AddWithValue("@FechaUltAplicacion", vacuna.FechaUltAplicacion);
            Comando.Parameters.AddWithValue("@FechaProxAplicacion", vacuna.FechaProxAplicacion);
            Comando.Parameters.AddWithValue("@NombreDoctor", vacuna.NombreDoctor);
            Comando.Parameters.AddWithValue("@IdMascota", vacuna.IdMascota);

            try
            {
                Comando.ExecuteNonQuery();
                MessageBox.Show("Vacuna ingresada de manera exitosa", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar la vacuna " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                Conexion.cerrarConexion();
            }
        }

        public List<Vacunas> obtenerVacunas(int idMascota)
        {
            List<Vacunas> vac = new List<Vacunas>();

            try
            {
                Comando.Connection = Conexion.abrirConexion();
                Comando.CommandText = $"SELECT * FROM tb_vacunas WHERE idMascota = {idMascota}";
                Comando.CommandType = CommandType.Text;
                var dr = Comando.ExecuteReader();

                while (dr.Read())
                {
                    Vacunas vacuna = new Vacunas
                    {
                        IdVacuna = dr.GetInt32("idVacuna"),
                        Nombre = dr.GetString("nombre"),
                        FechaUltAplicacion = dr.GetString("fechaUltAplicacion"),
                        FechaProxAplicacion = dr.GetString("fechaProxAplicacion"),
                        NombreDoctor = dr.GetString("nombre_doctor"),
                        IdMascota = dr.GetInt32("idMascota")
                    };

                    vac.Add(vacuna);
                }

                // Ordenar la lista por la fecha de próxima aplicación más cercana a la fecha actual
                vac = vac.OrderBy(v => DateTime.ParseExact(v.FechaProxAplicacion, "dd/MM/yyyy", null)).ToList();

                return vac;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al obtener las vacunas " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return vac;
            }
            finally
            {
                Conexion.cerrarConexion();
            }
        }

            public List<ids> obtenerMascotas()
            {
                List<ids> vac = new List<ids>();

                try
                {
                    Comando.Connection = Conexion.abrirConexion();
                    Comando.CommandText = $@"SELECT d.idDueño AS DueñoID,
       m.idMascota AS MascotaID
FROM tb_dueño d
INNER JOIN tb_mascota m ON d.idDueño = m.idDueño; ";
                    Comando.CommandType = CommandType.Text;
                    var dr = Comando.ExecuteReader();

                    while (dr.Read())
                    {
                        ids idss = new ids
                        {
                            idMascota = dr.GetInt32("MascotaID"),
                            idDueño = dr.GetInt32("DueñoID")
                        };

                        vac.Add(idss);
                    }

                    return vac;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error al obtener las vacunas " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return vac;
                }
                finally
                {
                    Conexion.cerrarConexion();
                }
            }
    }
}   


