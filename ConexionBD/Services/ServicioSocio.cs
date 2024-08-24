using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConexionBD;
using ConexionBD.Entidades;
using MySql.Data.MySqlClient;

namespace ConexionBD.Services
{
    internal class ServicioSocio : ConexionBD
    {
        public List<Socio> consulta(string dato)
        {
            MySqlDataReader reader;
            List<Socio> lista = new List<Socio>();
            string sql;
            if (dato == null)
            {
                sql = "SELECT * FROM socio ORDER BY nombre ASC";
            }
            else
            {
                sql = "SELECT * FROM socio WHERE id LIKE '%" + dato + "%' OR nombre LIKE '%" + dato + "%'  ORDER BY nombre ASC";
            }
            try
            {

                MySqlConnection con = base.conexion();
                con.Open();
                MySqlCommand comando = new MySqlCommand(sql, con);
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Socio _socio = new Socio();
                    _socio.id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0); // Usar GetInt32 si la columna es de tipo INT
                    _socio.nombre = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                    _socio.direccion = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                    _socio.mail = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                    _socio.telefono = reader.IsDBNull(4) ? 0 : reader.GetInt64(4); // Usar GetInt64 para columnas BIGINT
                    _socio.deportes = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);

                    lista.Add(_socio);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());

            }
            return lista;

        }
        public void updateSocio(Socio dato)
        {
            // Definir la consulta SQL utilizando parámetros
            string sql = "UPDATE socio SET nombre = @nombre, direccion = @direccion, mail = @mail, telefono = @telefono, deportes = @deportes WHERE id = @id";

            // Abrir la conexión a la base de datos
            using (MySqlConnection con = base.conexion())
            {
                con.Open();

                // Crear el comando SQL y asignar la conexión
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    // Asignar valores a los parámetros de la consulta
                    cmd.Parameters.AddWithValue("@nombre", dato.nombre);
                    cmd.Parameters.AddWithValue("@direccion", dato.direccion);
                    cmd.Parameters.AddWithValue("@mail", dato.mail);
                    cmd.Parameters.AddWithValue("@telefono", dato.telefono);
                    cmd.Parameters.AddWithValue("@deportes", dato.deportes);
                    cmd.Parameters.AddWithValue("@id", dato.id);

                    // Ejecutar la consulta SQL
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void deleteSocio(long ide)
        {
            string sql = "DELETE FROM socio WHERE id = @ide";


            using (MySqlConnection con = base.conexion())
            {
                con.Open();


                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    // Asignar el valor del parámetro
                    cmd.Parameters.AddWithValue("@ide", ide);
                    cmd.ExecuteNonQuery();

                }


            }
        }
        public void createSocio(Socio socio)
        {
            string sql = "INSERT INTO socio (nombre, direccion, mail, telefono, deportes) VALUES (@nombre, @direccion, @mail, @telefono, @deportes)";

            using (MySqlConnection con = base.conexion())
            {
                con.Open();

                // Crear el comando SQL y asignar la conexión
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        // Asignar valores a los parámetros de la consulta
                        cmd.Parameters.AddWithValue("@nombre", socio.nombre);
                        cmd.Parameters.AddWithValue("@direccion", socio.direccion);
                        cmd.Parameters.AddWithValue("@mail", socio.mail);
                        cmd.Parameters.AddWithValue("@telefono", socio.telefono);
                        cmd.Parameters.AddWithValue("@deportes", socio.deportes);


                        // Ejecutar la consulta SQL
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Usuario creado con exito!");
                    }
                }
                catch (MySqlException e)
                {

                    Console.WriteLine(e.ToString());
                }

            }
        }

    }
        }
    


