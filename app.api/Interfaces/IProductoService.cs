using app.api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.api.Interfaces
{
    public interface IProductoService
    {
        Task<Producto> CrearProductoAsync(Producto producto);
        Task<Producto> EditarProductoAsync(Producto producto);
        Task EliminarProductoAsync(Producto producto);
        Task<IReadOnlyList<Producto>> GetProductosAsync();
    }
}
