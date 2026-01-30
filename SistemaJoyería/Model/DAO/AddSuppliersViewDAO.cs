using SistemaJoyeria.Model.DTO;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaJoyería.Model.DAO
{
    public class AddSuppliersDAO : SupplierDTO
    {
        private SqlCommand command = new SqlCommand();

        public int RegisterSupplier(SupplierDTO supplier)
        {
            try
            {
                command.Connection = getConnection();

                string queryInsert = "INSERT INTO Suppliers (CompanyName, ContactName, Phone, Email, Direction, DayAdded) VALUES (@CompanyName, @ContactName, @Phone, @Email, @Direction, @DayAdded)";

                SqlCommand cmdInsert = new SqlCommand(queryInsert, command.Connection);

                cmdInsert.Parameters.AddWithValue("@CompanyName", supplier.CompanyName);
                cmdInsert.Parameters.AddWithValue("@ContactName", supplier.ContactName);
                cmdInsert.Parameters.AddWithValue("@DayAdded", supplier.DayAdded);
                cmdInsert.Parameters.AddWithValue("@Phone", supplier.Phone);
                cmdInsert.Parameters.AddWithValue("@Email", supplier.Email);
                cmdInsert.Parameters.AddWithValue("@Direction", supplier.Direction);

                int respuesta = cmdInsert.ExecuteNonQuery();
                return respuesta;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} No se pudo registrar proveedor, verifique su conexión a internet o que los servicios estén activos", "Error de inserción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        public int UpdateSupplier(SupplierDTO supplier)
        {
            try
            {
                command.Connection = getConnection();
                command.Connection.Open();

                string queryUpdate = "UPDATE Suppliers SET CompanyName = @CompanyName, ContactName = @ContactName, Phone = @Phone, Email = @Email, Direction = @Direction, DayAdded = @DayAdded WHERE IDSupplier = @IDSupplier";

                SqlCommand cmdUpdate = new SqlCommand(queryUpdate, command.Connection);

                cmdUpdate.Parameters.AddWithValue("@CompanyName", supplier.CompanyName);
                cmdUpdate.Parameters.AddWithValue("@ContactName", supplier.ContactName);
                cmdUpdate.Parameters.AddWithValue("@DayAdded", supplier.DayAdded);
                cmdUpdate.Parameters.AddWithValue("@Phone", supplier.Phone);
                cmdUpdate.Parameters.AddWithValue("@Email", supplier.Email);
                cmdUpdate.Parameters.AddWithValue("@Direction", supplier.Direction);

                return cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} No se pudo actualizar proveedor", "Error de actualización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public int DeleteSupplier(int id)
        {
            try
            {
                command.Connection = getConnection();
                command.Connection.Open();

                string queryDelete = "DELETE FROM Suppliers WHERE IDSupplier = @IDSupplier";

                SqlCommand cmdDelete = new SqlCommand(queryDelete, command.Connection);

                cmdDelete.Parameters.AddWithValue("@IDSupplier", id);

                return cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} No se pudo eliminar proveedor", "Error de eliminación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            finally
            {
                command.Connection.Close();
            }
        }
    }
}