using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app.api.Entities
{
 
    public class Factura : BaseEntity
    {
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public float Total { get; set; }
    }
}