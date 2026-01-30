using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaJoyería.Model.DTO;
using System.Windows.Forms;
using System.Data;
using System.Security.Cryptography;

namespace SistemaJoyería.Model.DAO
{
    internal class DAOLogin : DTOLogin
    {
        SqlCommand Command = new SqlCommand();
        //metodo para validar que el inicio de seccion es correcto
        public bool LoginValidation()
        {
            try
            {
                Command.Connection = getConnection();
                //busca en la tabla "Users" los datos de los usuarios cuyo nombre de login y contraseña coincidan con los valores proporcionados en los parámetros "@user" y "@pass".
                string query = "SELECT * FROM Users WHERE LoginName = @user and Password = @pass";
                //mandando la consulta a la base
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                //admitiendo parametros a la base

                string encriptada;
                using (SHA256 sha256Hash = SHA256.Create())
                {

                    // Computar el hash - Esta retorna un arreglo de bytes
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(Password1));

                    // Convertir byte array a string
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }
                    encriptada = builder.ToString();
                }

                cmd.Parameters.AddWithValue("user", LoginName1);
                cmd.Parameters.AddWithValue("pass", encriptada);
                SqlDataReader reader = cmd.ExecuteReader();
                //si las credenciales son correctas retornara un 1
                return reader.HasRows;
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
                return false;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                getConnection().Close();
            }
        }

        public int ValidarPrimerUsuario()
        {
            try
            {
                Command.Connection = getConnection();

                string query = "SELECT COUNT(*) FROM Users";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                int TotalUsuarios = (int)cmd.ExecuteScalar();
                return TotalUsuarios;
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
                return -1;
            }
            finally
            {
                getConnection().Close();
            }
        }

        public int RegistrarPrimerUsuario()
        {
            try
            {
                Command.Connection = getConnection();

                string query = "INSERT INTO Users (LoginName, Password,  UserEmail, Estado, idRoles) VALUES (@LoginName, @Password, @UserEmail, @Estado, 1 )";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("LoginName", LoginName1);
                cmd.Parameters.AddWithValue("Password", Password1);
                cmd.Parameters.AddWithValue("UserEmail", UserEmail1);
                cmd.Parameters.AddWithValue("Estado", true);
                int valor = cmd.ExecuteNonQuery();
                if (valor == 1)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            catch (SqlException ex)
            {

                MessageBox.Show($"Error EC-001 {ex.Message}", "Error Critico", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;

            }

        }


        public bool IsFirstTimeLogin()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT FirstTimeLogin FROM Users WHERE LoginName = @user";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("@user", LoginName1);
                Command.Connection.Open();
                bool isFirstTime = (bool)cmd.ExecuteScalar();
                return isFirstTime;
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show($"Error al verificar el estado de FirstTimeLogin: {sqlex.Message}");
                return false;
            }
            finally
            {
                getConnection().Close();
            }
        }

        public int RegistrarUsuario()
        {
            try
            {
                Command.Connection = getConnection();

                string query = "INSERT INTO Users (LoginName, Password,  UserEmail, Estado, idRoles) VALUES (@LoginName, @Password, @UserEmail, @Estado, @idRoles)";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("LoginName", LoginName1);
                cmd.Parameters.AddWithValue("Password", Password1);
                cmd.Parameters.AddWithValue("UserEmail", UserEmail1);
                cmd.Parameters.AddWithValue("Estado", true);
                cmd.Parameters.AddWithValue("idRoles", IdRol);
                int valor = cmd.ExecuteNonQuery();
                if (valor == 1)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            catch (SqlException ex)
            {

                MessageBox.Show($"Error EC-001 {ex.Message}", "Error Critico", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;

            }


        }


        public DataSet LlenarCombo(string table)
        {
            try
            {
                Command.Connection = getConnection();

                string query = $"SELECT * FROM {table}";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, $"{table}");
                return ds;
            }
            catch (SqlException ex)
            {

                MessageBox.Show($"EC_004 {ex.Message}", "Error Critico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                getConnection().Close();
            }
        }

    }

}
