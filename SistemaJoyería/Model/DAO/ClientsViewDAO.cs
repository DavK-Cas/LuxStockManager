using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaJoyería.Model.DAO;
using SistemaJoyería.Model.DTO;
using System.Collections;

namespace SistemaJoyería.Model.DAO
{
    public class ClientsViewDAO : ClientsViewDTO
    {
        SqlCommand command = new SqlCommand();

        public DataSet ShowDGV()
        {
            try
            {
                //Establecemos la conexión para el command
                command.Connection = getConnection();
                //Definimos la consulta para seleccionar datos
                string query = "SELECT * FROM vw_ClientesInfo";
                SqlCommand cmdSelect = new SqlCommand(query, command.Connection);
                //Ejecutamos la consulta y obtenemos los datos
                cmdSelect.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmdSelect);
                DataSet ds = new DataSet();
                adp.Fill(ds, "vw_ClientesInfo");
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

        public int UpdateClients ()
        {
            try
            {
                //Establecemos una conexión
                command.Connection = getConnection();
                //Definir que acción se desea realizar
                string queryUpdate = "UPDATE Clients SET  FirstName = @param1, LastName = @param2,  Phone = @param3, Email= @param4, BirthDate = @param5,  IdentityDocument = @param6, AddressClient = @param7 WHERE  IDClient = @param8";
                SqlCommand cmdUpdate = new SqlCommand(queryUpdate, command.Connection);
                cmdUpdate.Parameters.AddWithValue("param1", FirstName);
                cmdUpdate.Parameters.AddWithValue("param2", LastName);
                cmdUpdate.Parameters.AddWithValue("param3", Phone);
                cmdUpdate.Parameters.AddWithValue("param4", Email);
                cmdUpdate.Parameters.AddWithValue("param5", BirthDate);
                cmdUpdate.Parameters.AddWithValue("param6", IdentityDocument);
                cmdUpdate.Parameters.AddWithValue("param7", AddressClient);
                cmdUpdate.Parameters.AddWithValue("param8", IdClient);
                //Retornamos la consulta
                return cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} No se pudo actualizar la información de libro, verifique su conexión a internet o que los servicios esten activos", "Error de inserción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public DataSet SearchClients(string valor)
        {
            try
            {
                command.Connection = getConnection();
                string query = $"SELECT * FROM vw_ClientesInfo WHERE [Nombre] Like '%{valor}%'";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                //cmd.Parameters.AddWithValue("@Valor", valor);
                cmd.ExecuteScalar();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "vw_ClientesInfo");
                return dataSet;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                command.Connection.Close();
            }
        }

    }
}
