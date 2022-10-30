using MySql.Data.MySqlClient;

namespace microservicios.Datos
{
    public class ConexionBD
    {
        MySqlConnection con = new MySqlConnection();

        static string servidor = "34.134.205.131";
        static string bd = "sofydb";
        static string ususario = "root";
        static string pass = "seminario_proy_soby_bd_2022";
        static int puerto = 3306;

        string cadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + ususario + ";" + "password=" + pass + ";" + "database=" + bd + ";";

        public MySqlConnection conectarBD()
        {
            try
            {
                con.ConnectionString = cadenaConexion;
                con.Open();
            }
            catch (MySqlException e)
            {

            }
            return con;
        }

        public MySqlConnection desconectarBD()
        {
            try
            {
                con.Close();
            }
            catch (MySqlException e)
            {

            }
            return con;
        }
    }
}
