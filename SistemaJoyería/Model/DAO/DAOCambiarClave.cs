using SistemaJoyería.Model.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace SistemaJoyería.Model.DAO
{
    internal class DAOCambiarClave : DTOLogin
    {
        SqlCommand SqlCommand = new SqlCommand();


        public bool ComprobarUsuario(string username)
        {
            SqlCommand.Connection = getConnection();
            string query = "SELECT * FROM Users  WHERE UserEmail=@usuario";
            SqlCommand cmd = new SqlCommand(query, SqlCommand.Connection);
            cmd.Parameters.AddWithValue("usuario", username);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader.HasRows;



        }

        public bool ComprobarusuarioPorAdmin()
        {
            SqlCommand.Connection = getConnection();
            string query = "SELECT * FROM  Users WHERE LoginName = @usuario AND Estado = @status";
            SqlCommand cmd = new SqlCommand(query, SqlCommand.Connection);
            cmd.Parameters.AddWithValue("Usuario", LoginName1);
            cmd.Parameters.AddWithValue("status", true);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader.HasRows;
        }


        public bool DAOCambiarclave()
        {
            try
            {
                SqlCommand.Connection = getConnection();
                string query = "UPDATE Users SET Password = @contraseñaNueva WHERE  LoginName =@usuario";
                SqlCommand cmd = new SqlCommand(query, SqlCommand.Connection);
                cmd.Parameters.AddWithValue("usuario", LoginName1);

                string encrypted = Password1;

                using (SHA256 sha256Hash = SHA256.Create())
                {

                    // Computar el hash - Esta retorna un arreglo de bytes
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(encrypted));

                    // Convertir byte array a string
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }
                    encrypted = builder.ToString();
                }

                cmd.Parameters.AddWithValue("contraseñaNueva", encrypted);

                int lineasAfectadas = cmd.ExecuteNonQuery();
                cmd.Parameters.AddWithValue("status", true);
                SqlDataReader reader = cmd.ExecuteReader();
                return reader.HasRows;
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
                return false;


            }
            catch (Exception ex)
            {

                {
                    MessageBox.Show(ex.Message);
                    return false;


                }

            }
            finally
            {
                getConnection().Close();
            }
        }
    }
}
