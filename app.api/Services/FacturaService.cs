using app.api.Entities;
using app.api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.api.Services
{
    public class FacturaService : IFacturaService
    {

        private readonly IUnitOfWork _unitOfWork;
        public FacturaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Factura> CrearFacturaAsync(Factura factura)
        {
            _unitOfWork.Repository<Factura>().Add(factura);

            var result = await _unitOfWork.Complete();

            if (result <= 0) return null;

            return await _unitOfWork.Repository<Factura>().GetByIdAsync(factura.Id);
        }

        public async Task<Factura> EditarFacturaAsync(Factura factura)
        {
            _unitOfWork.Repository<Factura>().Update(factura);

            var result = await _unitOfWork.Complete();

            if (result <= 0) return null;

            return await _unitOfWork.Repository<Factura>().GetByIdAsync(factura.Id);
        }

        public async Task EliminarFacturaAsync(Factura factura)
        {
            _unitOfWork.Repository<Factura>().Delete(factura);

            await _unitOfWork.Complete();
        }

        public async Task<IReadOnlyList<Factura>> GetFacturasAsync()
        {
            return await _unitOfWork.Repository<Factura>().ListAllAsync();
        }
    }
}
