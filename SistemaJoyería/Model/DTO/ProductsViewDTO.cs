using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaJoyería.Model.DTO
{
    internal class ProductsViewDTO : dbContext
    {
        private int IDProducto;
        private string NombreProducto;
        private string MaterialProducto;
        private int IDProveedor;
        private string DescripcionProducto;
        private int Stock;
        private float Price;
        private DateTime Fecha;

        public int IDProducto1 { get => IDProducto; set => IDProducto = value; }
        public string NombreProducto1 { get => NombreProducto; set => NombreProducto = value; }
        public string MaterialProducto1 { get => MaterialProducto; set => MaterialProducto = value; }
        public int IDProveedor1 { get => IDProveedor; set => IDProveedor = value; }
        public string DescripcionProducto1 { get => DescripcionProducto; set => DescripcionProducto = value; }
        public int Stock1 { get => Stock; set => Stock = value; }
        public float Price1 { get => Price; set => Price = value; }
        public DateTime Fecha1 { get => Fecha; set => Fecha = value; }
    }
}
