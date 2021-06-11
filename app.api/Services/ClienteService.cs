using app.api.Entities;
using app.api.Interfaces;
using app.api.Specifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace app.api.Services
{
    public class ClienteService : IClienteService
    {

        private readonly IUnitOfWork _unitOfWork;
        public ClienteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Cliente> CrearClienteAsync(Cliente cliente)
        {
            _unitOfWork.Repository<Cliente>().Add(cliente);
            
            var result = await _unitOfWork.Complete();

            if (result <= 0) return null;

            return await _unitOfWork.Repository<Cliente>().GetByIdAsync(cliente.Id);
        }

        public async Task<Cliente> EditarClienteAsync(Cliente cliente)
        {
            _unitOfWork.Repository<Cliente>().Update(cliente);

            var result = await _unitOfWork.Complete();

            if (result <= 0) return null;

            return await _unitOfWork.Repository<Cliente>().GetByIdAsync(cliente.Id);
        }

        public async Task EliminarClienteAsync(int id)
        {
            Cliente cliente = await _unitOfWork.Repository<Cliente>().GetByIdAsync(id);
            _unitOfWork.Repository<Cliente>().Delete(cliente);
             
             await _unitOfWork.Complete();
        }

        public async Task<IReadOnlyList<Cliente>> GetClientesAsync()
        {
            return await _unitOfWork.Repository<Cliente>().ListAllAsync();
        }
    }
}
