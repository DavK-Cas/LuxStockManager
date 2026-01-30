using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaJoyeria.Model.DTO;
using SistemaJoyería.Model.DTO;

namespace SistemaJoyería.Model.DAO
{
    internal class DAOverificarAdmin : DTOLogin
    {
        SqlCommand SqlCommand = new SqlCommand();

        public bool VerificarContraseñaAdmin()
        {
            try
            {
                SqlCommand.Connection = getConnection();
                string query = "SELECT Password FROM Users WHERE idRoles = 1  AND Estado = @Estado AND Password = @ContraseñaAdmin";
                SqlCommand cmd = new SqlCommand(query, SqlCommand.Connection);
                cmd.Parameters.AddWithValue("ContraseñaAdmin", Password1);
                cmd.Parameters.AddWithValue("Estado", true);
                SqlDataReader reader = cmd.ExecuteReader();
                return reader.HasRows;
            }
            catch (SqlException Sqlex)
            {
                MessageBox.Show(Sqlex.Message);
                return false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            {

            }


        }
    }
}
