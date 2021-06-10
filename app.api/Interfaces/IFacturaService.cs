using app.api.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace app.api.Interfaces
{
    public interface IFacturaService
    {
        Task<Factura> CrearFacturaAsync(Factura factura);
        Task<Factura> EditarFacturaAsync(Factura factura);
        Task EliminarFacturaAsync(Factura factura);
        Task<IReadOnlyList<Factura>> GetFacturasAsync();
    }
}