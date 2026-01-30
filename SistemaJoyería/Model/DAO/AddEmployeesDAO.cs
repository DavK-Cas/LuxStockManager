using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Windows.Forms;
using SistemaJoyería.Model.DTO;
using System.Web.UI.Design;

namespace SistemaJoyería.Model.DAO
{
    internal class AddEmployeesDAO: EmployeesViewDTO
    {
        SqlCommand command = new SqlCommand();

        public int RegisterEmployees()
        {
            try
            {
                //Establecemos una conexión
                command.Connection = getConnection();
                //Definir que acción se desea realizar
                string queryInsert = "INSERT INTO Employees VALUES (@param1, @param2, @param3, @param4, @param5, @param6, @param7)";
                //Creamos un Obj donde se guardará la información guardada y de dónde proviene
                SqlCommand cmdInsert = new SqlCommand(queryInsert, command.Connection);
                //Asignamos el valor a cada parámetro con DTO
                cmdInsert.Parameters.AddWithValue("param1", FirstNameEmployees);
                cmdInsert.Parameters.AddWithValue("param2", LastNameEmployees1);
                cmdInsert.Parameters.AddWithValue("param3", PhoneEmployees1);
                cmdInsert.Parameters.AddWithValue("param4", EmailEmployees1);
                cmdInsert.Parameters.AddWithValue("param5", BirthDateEmployees1);
                cmdInsert.Parameters.AddWithValue("param6", IdentityDocumentEmployees1);
                cmdInsert.Parameters.AddWithValue("param7", AddressEmployees1);
                //Retornamos la consulta
                return cmdInsert.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} No se pudo registrar el Empleado, verifique su conexión a internet o que los servicios esten activos", "Error de inserción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            finally
            {
                command.Connection.Close();
            }
        }
    }
}
