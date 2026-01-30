using SistemaJoyería.Model.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaJoyería.Model.DAO
{
    internal class DAOSecurityQuestions : DTOSecurityQuestions
    {
        readonly SqlCommand Command = new SqlCommand();

        public int ingresarPreguntas()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "INSERT INTO Questions (Usuario, Pregunta1, pregunta2, pregunta3) VALUES(@param1, @param2, @param3,@param4)";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("param1", Usuario);
                cmd.Parameters.AddWithValue("param2", Pregunta1);
                cmd.Parameters.AddWithValue("param3", Pregunta2);
                cmd.Parameters.AddWithValue("param4", Pregunta3);
                int respuesta = cmd.ExecuteNonQuery();
                return respuesta;


            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("No se pudieron registrar las preguntas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }



        }
        public bool LeerRespuestas()
        {
            try
            {
                Command.Connection = getConnection();
                string queryReader = "SELECT Pregunta1, pregunta2, pregunta3 FROM Questions WHERE Pregunta1 = @param1 AND pregunta2 = @param2 AND pregunta3 = @param3 AND Usuario = @param4";
                SqlCommand cmd = new SqlCommand(queryReader, Command.Connection);
                cmd.Parameters.AddWithValue("param1", Pregunta1);
                cmd.Parameters.AddWithValue("param2", Pregunta2);
                cmd.Parameters.AddWithValue("param3", Pregunta3);
                cmd.Parameters.AddWithValue("param4", Usuario);
                SqlDataReader reader = cmd.ExecuteReader();
                return reader.HasRows;

            }
            catch (SqlException ex)
            {
                MessageBox.Show($"{ex.Message}");
                return false;

            }
        }
    }
}
