using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.api.Entities
{
    public class Cliente : BaseEntity
    {
        public string NombreCompleto { get; set; }
        public bool Estado { get; set; }
    }
}
