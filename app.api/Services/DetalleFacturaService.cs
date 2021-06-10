using app.api.Entities;
using app.api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.api.Services
{
    public class DetalleFacturaService : IDetalleFacturaService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DetalleFacturaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DetalleFactura> CrearDetalleFacturaAsync(DetalleFactura detalleFactura)
        {
            _unitOfWork.Repository<DetalleFactura>().Add(detalleFactura);

            var result = await _unitOfWork.Complete();

            if (result <= 0) return null;

            return await _unitOfWork.Repository<DetalleFactura>().GetByIdAsync(detalleFactura.Id);
        }

        public async Task<DetalleFactura> EditarDetalleFacturaAsync(DetalleFactura DetalleFactura)
        {
            _unitOfWork.Repository<DetalleFactura>().Update(DetalleFactura);

            var result = await _unitOfWork.Complete();

            if (result <= 0) return null;

            return await _unitOfWork.Repository<DetalleFactura>().GetByIdAsync(DetalleFactura.Id);
        }

        public async Task EliminarDetalleFacturaAsync(DetalleFactura DetalleFactura)
        {
            _unitOfWork.Repository<DetalleFactura>().Delete(DetalleFactura);

            await _unitOfWork.Complete();
        }

        public async Task<IReadOnlyList<DetalleFactura>> GetDetallesFacturaAsync()
        {
            return await _unitOfWork.Repository<DetalleFactura>().ListAllAsync();
        }

    }
}
