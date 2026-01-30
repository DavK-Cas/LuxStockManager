using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaJoyería.Model
{
    public class dbContext
    {
        public static SqlConnection getConnection()
        {
            //Conexion
            try
            {
                String test = "Server = SQL8005.site4now.net; Database = db_aacc95_dbluxst; User Id = db_aacc95_dbluxst_admin; Password = leoabarca091;";

                //string server = "";

                //string database = "";

                //Creamos la conexión 
                SqlConnection conexion = new SqlConnection(test);
                conexion.Open();
                //Retornamos la conexion abierta
                return conexion;
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"{ex.Message} No fue posible conectarse a la base de datos, favor verifique las credenciales o que tenga acceso al sistema.", "Error crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static SqlConnection testConnection(string server, string database, string user, string password)
        {
            try
            {
                //MessageBox.Show($"{DTOdbContext.Server}, {DTOdbContext.Database}, {DTOdbContext.User}, {DTOdbContext.Password}");
                SqlConnection conexion = new SqlConnection($"Server = {server}; DataBase = {database}; User Id = {user}; Password = {password}");
                conexion.Open();
                return conexion;
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"{ex.Message} Código de error: EC-001 \nNo fue posible conectarse a la base de datos, verifique las credenciales, consulte el manual de usuario.", "Error crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

    }
}