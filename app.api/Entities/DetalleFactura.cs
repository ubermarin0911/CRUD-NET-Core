using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace app.api.Entities
{
    public class DetalleFactura
    {
        [ForeignKey("Producto")]
        public int IdProducto { get; set; }
        public Producto Producto { get; set; }
        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }
        [ForeignKey("Factura")]
        public int IdFactura { get; set; }
        public Factura Factura { get; set; }
        public float Cantidad { get; set; }
        public float Subtotal { get; set; }
    }
}
