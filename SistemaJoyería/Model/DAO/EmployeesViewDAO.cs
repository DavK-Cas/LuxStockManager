using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaJoyería.Model.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Net.Sockets;

namespace SistemaJoyería.Model.DAO
{
    internal class EmployeesViewDAO : EmployeesViewDTO
    {
        SqlCommand command = new SqlCommand();

        public DataSet ShowDGV()
        {
            try
            {
                //Establecemos la conexión para el command
                command.Connection = getConnection();
                //Definimos la consulta para seleccionar datos
                string query = "SELECT * FROM vw_EmployeesInfo";
                SqlCommand cmdSelect = new SqlCommand(query, command.Connection);
                //Ejecutamos la consulta y obtenemos los datos
                cmdSelect.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmdSelect);
                DataSet ds = new DataSet();
                adp.Fill(ds, "vw_EmployeesInfo");
                return ds;
            }
            catch (Exception)
            {
                MessageBox.Show($"Error al intentar mostrar datos, verifique su conexión a internet o acceso al servidor o base de datos estén activos", "Error de ejecución", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                //Cerramos conexión
                command.Connection.Close();
            }
        }
        public int DeleteEmployees()
        {
            try
            {
                //Establecemos una conexion
                command.Connection = getConnection();
                //Definir que accion se desea realizar   (un parametro para cada campo
                string queryInsert = "Delete Employees Where IDEmployees = @param1";
                SqlCommand cmdInsert = new SqlCommand(queryInsert, command.Connection);
                cmdInsert.Parameters.AddWithValue("param1", IdEmployees);
                return cmdInsert.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"{ex.Message} No se puede eliminar el Usuario, verifique su conexion a internet o que los servicios esten activos", "Error de insercción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public int UpdateEmployees()
        {
            try
            {
                //Establecemos una conexión
                command.Connection = getConnection();
                //Definir que acción se desea realizar
                string queryUpdate = "UPDATE Employees SET   FirstNameEmployees = @param1, LastNameEmployees = @param2,  PhoneEmployees = @param3," +
                                     " EmailEmployees = @param4, BirthDateEmployees = @param5,  IdentityDocumentEmployees = @param6, AddressEmployees = @param7 WHERE  IDEmployees = @param8";
                SqlCommand cmdUpdate = new SqlCommand(queryUpdate, command.Connection);
                cmdUpdate.Parameters.AddWithValue("param1", FirstNameEmployees);
                cmdUpdate.Parameters.AddWithValue("param2", LastNameEmployees1);
                cmdUpdate.Parameters.AddWithValue("param3", PhoneEmployees1);
                cmdUpdate.Parameters.AddWithValue("param4", EmailEmployees1);
                cmdUpdate.Parameters.AddWithValue("param5", BirthDateEmployees1);
                cmdUpdate.Parameters.AddWithValue("param6", IdentityDocumentEmployees1);
                cmdUpdate.Parameters.AddWithValue("param7", AddressEmployees1);
                cmdUpdate.Parameters.AddWithValue("param8", IdEmployees);
                //Retornamos la consulta
                return cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} No se pudo actualizar la información del Cliente, verifique su conexión a internet o que los servicios esten activos", "Error de inserción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            finally
            {
                command.Connection.Close();
            }
        }
    }
}
