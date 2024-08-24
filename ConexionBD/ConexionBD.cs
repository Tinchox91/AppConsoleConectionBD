using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConexionBD
{
    internal class ConexionBD
    {
        public MySqlConnection conexion()
        {
            string servidor = "localhost";
            string usuario = "root";
            string puerto = "3306";
            string contraseña = "root";
            string baseDatos = "club";

            string cadenaConexion = $"server={servidor};port={puerto};user id={usuario};password={contraseña};database={baseDatos} ;";
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                conexionBD.Open();
                //Console.WriteLine("Conexion Exitosa!");

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al establecer la conexión: " + ex.Message);
                conexionBD.Close();
            }
            finally
            {
                if (conexionBD.State == System.Data.ConnectionState.Open)
                {
                    conexionBD.Close();
                }

            }
            return new MySqlConnection(cadenaConexion);
        }

    }
}

