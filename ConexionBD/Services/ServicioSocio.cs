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
    internal class ServicioSocio:ConexionBD
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

    }
}

