using app.api.Dtos;
using app.api.Entities;
using app.api.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace app.api.Controllers
{
    public class ClientesController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IClienteService _clienteService;
        
        public ClientesController(IClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ClienteDto>>> GetClientes()
        {
            var clientes = await _clienteService.GetClientesAsync();

            var data = _mapper.Map<IReadOnlyList<Cliente>, IReadOnlyList<ClienteDto>>(clientes);

            return Ok(data);
        }

        [HttpPost]
        public async Task<ClienteDto> CrearCliente(ClienteDto clienteParam)
        {
            var cliente = _mapper.Map<ClienteDto, Cliente>(clienteParam);

            var clienteCreado = await _clienteService.CrearClienteAsync(cliente);

            return _mapper.Map<Cliente, ClienteDto>(clienteCreado);
        }

        [HttpPut]
        public async Task<ClienteDto> EditarCliente(ClienteDto clienteParam)
        {
            var cliente = _mapper.Map<ClienteDto, Cliente>(clienteParam);

            var clienteCreado = await _clienteService.EditarClienteAsync(cliente);

            return _mapper.Map<Cliente, ClienteDto>(clienteCreado);
        }

        [HttpDelete("{id}")]
        public async Task EliminarCliente(int id)
        {
            await _clienteService.EliminarClienteAsync(id);
        }
    }
}
