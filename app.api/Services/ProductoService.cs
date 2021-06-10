using app.api.Entities;
using app.api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.api.Services
{
    public class ProductoService : IProductoService
    {

        private readonly IUnitOfWork _unitOfWork;
        public ProductoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Producto> CrearProductoAsync(Producto producto)
        {
            _unitOfWork.Repository<Producto>().Add(producto);

            var result = await _unitOfWork.Complete();

            if (result <= 0) return null;

            return await _unitOfWork.Repository<Producto>().GetByIdAsync(producto.Id);
        }

        public async Task<Producto> EditarProductoAsync(Producto producto)
        {
            _unitOfWork.Repository<Producto>().Update(producto);

            var result = await _unitOfWork.Complete();

            if (result <= 0) return null;

            return await _unitOfWork.Repository<Producto>().GetByIdAsync(producto.Id);
        }

        public async Task EliminarProductoAsync(Producto producto)
        {
            _unitOfWork.Repository<Producto>().Delete(producto);

            await _unitOfWork.Complete();
        }

        public async Task<IReadOnlyList<Producto>> GetProductosAsync()
        {
            return await _unitOfWork.Repository<Producto>().ListAllAsync();
        }
    }
}
