using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaJoyería.Controller.ClientsController;
using SistemaJoyería.Model.DTO;

namespace SistemaJoyería.Model.DAO
{
    public class AddClientsDAO : ClientsViewDTO
    {
        SqlCommand command = new SqlCommand();

        public int RegisterClients()
        {
            try
            {
                //Establecemos una conexión
                command.Connection = getConnection();
                //Definir que acción se desea realizar
                string queryInsert = "INSERT INTO Clients VALUES (@param1, @param2, @param3, @param4, @param5, @param6, @param7)";
                //Creamos un Obj donde se guardará la información guardada y de dónde proviene
                SqlCommand cmdInsert = new SqlCommand(queryInsert, command.Connection);
                //Asignamos el valor a cada parámetro con DTO
                cmdInsert.Parameters.AddWithValue("param1", FirstName);
                cmdInsert.Parameters.AddWithValue("param2", LastName);
                cmdInsert.Parameters.AddWithValue("param3", Phone);
                cmdInsert.Parameters.AddWithValue("param4", Email);
                cmdInsert.Parameters.AddWithValue("param5", BirthDate);
                cmdInsert.Parameters.AddWithValue("param6", IdentityDocument);
                cmdInsert.Parameters.AddWithValue("param7", AddressClient);
                //Retornamos la consulta
                return cmdInsert.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} No se pudo registrar cliente, verifique su conexión a internet o que los servicios esten activos", "Error de inserción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            finally
            {
                command.Connection.Close();
            }
        }

    }
}