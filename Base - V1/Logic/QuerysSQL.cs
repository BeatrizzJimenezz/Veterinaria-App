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
                MessageBox.Show("Error al cargar la informacion del dueño","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
                MessageBox.Show("Error al editar los datos del paciente. Error: "+ ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Error al editar los datos del dueño. Error: "+ ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                Conexion.cerrarConexion();
            }



        }
        public void InsertarConsulta(Consulta consulta)
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
        public DataGridView ListarConsultas(DataGridView dataGridView, int id)
        {
            // Consulta SQL para obtener los datos requeridos de ambas tablas
            string consulta = $@"SELECT idConsulta AS ConsultaID, fecha_realizado AS Fecha_Realizado, 
                                motivo_consulta AS Motivo_Consulta FROM tb_consulta WHERE idMascota = {id}";

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
    }
}
