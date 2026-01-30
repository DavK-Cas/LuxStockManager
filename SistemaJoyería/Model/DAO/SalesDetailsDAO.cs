using SistemaJoyería.Model.DTO;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaJoyería.Model.DAO
{
    internal class SalesDetailsViewDAO : SalesDetailsDTO
    {
        SqlCommand command = new SqlCommand();

        // Mostrar detalles de ventas en DataGridView
        public DataSet ShowDGV()
        {
            try
            {
                command.Connection = getConnection();
                string query = "SELECT * FROM vw_Details";
                SqlCommand cmdSelect = new SqlCommand(query, command.Connection);
                cmdSelect.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmdSelect);
                DataSet ds = new DataSet();
                adp.Fill(ds, "vw_Details");
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} Error al intentar mostrar los detalles de venta.", "Error de ejecución", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        // Registrar detalles de venta
        public int RegisterSaleDetails()
        {
            try
            {
                command.Connection = getConnection();
                string queryInsert = "INSERT INTO SalesDetails (IDProduct, IDEmployees, IDClient, DayToSale, Quantity, Price) VALUES (@param1, @param2, @param3, @param4, @param5, @param6)";
                SqlCommand cmdInsert = new SqlCommand(queryInsert, command.Connection);
                cmdInsert.Parameters.AddWithValue("param1", IDProduct1);
                cmdInsert.Parameters.AddWithValue("Param2", IDEmployee1);
                cmdInsert.Parameters.AddWithValue("param3", IDClient1);
                cmdInsert.Parameters.AddWithValue("param4", DayToSale1);
                cmdInsert.Parameters.AddWithValue("param5", Quantity1);
                cmdInsert.Parameters.AddWithValue("param6", Price1);

                return cmdInsert.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} No se pudo registrar los detalles de la venta.", "Error de inserción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            finally
            {
                command.Connection.Close();
            }
        }
        public int DeleteSale()
        {
            try
            {
                //Establecemos una conexion
                command.Connection = getConnection();
                //Definir que accion se desea realizar   (un parametro para cada campo
                string queryInsert = "Delete SalesDetails Where IDSaleDetail = @param1";
                SqlCommand cmdInsert = new SqlCommand(queryInsert, command.Connection);
                cmdInsert.Parameters.AddWithValue("param1", IDSaleDetail1);
                return cmdInsert.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"{ex.Message} No se puede eliminar la venta, verifique su conexion a internet o que los servicios esten activos", "Error de insercción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        // Buscar detalles de venta
        public DataSet SearchSalesDetails(string valor)
        {
            try
            {
                command.Connection = getConnection();
                string query = $"SELECT * FROM vw_Details WHERE [Nombre del Producto] Like '%{valor}%'";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                //cmd.Parameters.AddWithValue("@Valor", valor);
                cmd.ExecuteScalar();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "vw_Details");
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

        public DataSet GetProducts()
        {
            try
            {
                command.Connection = getConnection();
                //Definir instrucción de lo que se quiere hacer
                string query = "SELECT IDProduct, ProductName FROM Products";
                //Creando un objeto de tipo comando donde recibe la instrucción y la conexión
                SqlCommand cmdSelect = new SqlCommand(query, command.Connection);
                //Se ejecuta el comando cmdSelect con la instrucción y la conexión
                cmdSelect.ExecuteNonQuery();
                //Se crea un objeto de tipo SqlDataAdapter para facilitar el llenado del dataset
                SqlDataAdapter adp = new SqlDataAdapter(cmdSelect);
                //Se crea un dataset que contendrá los datos encontrados
                DataSet ds = new DataSet();
                //rellenamos el dataset con el objeto SqlDataAdapter
                adp.Fill(ds, "Products");
                //Se retorna el dataset
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} Error al obtener los el producto, verifique su conexión a internet o que el acceso al servidor o base de datos esten activos", "Error de ejecución", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public DataSet GetEmployees()
        {
            try
            {
                command.Connection = getConnection();
                //Definir instrucción de lo que se quiere hacer
                string query = "SELECT IDEmployees,  FirstNameEmployees FROM Employees";
                //Creando un objeto de tipo comando donde recibe la instrucción y la conexión
                SqlCommand cmdSelectE = new SqlCommand(query, command.Connection);
                //Se ejecuta el comando cmdSelect con la instrucción y la conexión
                cmdSelectE.ExecuteNonQuery();
                //Se crea un objeto de tipo SqlDataAdapter para facilitar el llenado del dataset
                SqlDataAdapter adpE = new SqlDataAdapter(cmdSelectE);
                //Se crea un dataset que contendrá los datos encontrados
                DataSet dsE = new DataSet();
                //rellenamos el dataset con el objeto SqlDataAdapter
                adpE.Fill(dsE, "Employees");
                //Se retorna el dataset
                return dsE;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} Error al obtener el empleado, verifique su conexión a internet o que el acceso al servidor o base de datos esten activos", "Error de ejecución", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public DataSet GetClients()
        {
            try
            {
                command.Connection = getConnection();
                //Definir instrucción de lo que se quiere hacer
                string query = "SELECT IDClient, FirstName FROM Clients";
                //Creando un objeto de tipo comando donde recibe la instrucción y la conexión
                SqlCommand cmdSelectC = new SqlCommand(query, command.Connection);
                //Se ejecuta el comando cmdSelect con la instrucción y la conexión
                cmdSelectC.ExecuteNonQuery();
                //Se crea un objeto de tipo SqlDataAdapter para facilitar el llenado del dataset
                SqlDataAdapter adpC = new SqlDataAdapter(cmdSelectC);
                //Se crea un dataset que contendrá los datos encontrados
                DataSet dsC = new DataSet();
                //rellenamos el dataset con el objeto SqlDataAdapter
                adpC.Fill(dsC, "Clients");
                //Se retorna el dataset
                return dsC;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} Error al obtener el cliente, verifique su conexión a internet o que el acceso al servidor o base de datos esten activos", "Error de ejecución", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public decimal GetProductPrice(int productId)
        {
            try
            {
                command.Connection = getConnection();
                string query = "SELECT Price FROM Products WHERE IDProduct = @ProductID";
                SqlCommand cmdSelect = new SqlCommand(query, command.Connection);
                cmdSelect.Parameters.AddWithValue("@ProductID", productId);
                object result = cmdSelect.ExecuteScalar(); // Ejecuta la consulta y obtiene el primer valor de la primera fila

                if (result != null && decimal.TryParse(result.ToString(), out decimal price))
                {
                    return price;
                }
                else
                {
                    return -1; // Si no se encuentra el producto o hay algún error
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} Error al obtener el precio del producto.", "Error de ejecución", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            finally
            {
                command.Connection.Close();
            }
        }


    }
}