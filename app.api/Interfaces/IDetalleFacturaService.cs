using app.api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.api.Interfaces
{
    public interface IDetalleFacturaService
    {
        Task<DetalleFactura> CrearDetalleFacturaAsync(DetalleFactura detalleFactura);
        Task<DetalleFactura> EditarDetalleFacturaAsync(DetalleFactura detalleFactura);
        Task EliminarDetalleFacturaAsync(DetalleFactura detalleFactura);
        Task<IReadOnlyList<DetalleFactura>> GetDetallesFacturaAsync();
    }
}
