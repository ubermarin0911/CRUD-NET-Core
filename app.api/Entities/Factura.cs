using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace app.api.Entities
{
    public class Factura : BaseEntity
    {
        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public float Total { get; set; }
    }
}