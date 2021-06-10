using app.api.Dtos;
using app.api.Entities;
using app.api.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<ActionResult<IReadOnlyList<ClienteDatosDto>>> GetClientes()
        {
            var clientes = await _clienteService.GetClientesAsync();

            var data = _mapper.Map<IReadOnlyList<Cliente>, IReadOnlyList<ClienteDatosDto>>(clientes);

            return Ok(data);
        }

        [HttpPost]
        public async Task<ClienteDatosDto> CrearCliente(ClienteDatosDto clienteParam)
        {
            var cliente = _mapper.Map<ClienteDatosDto, Cliente>(clienteParam);

            var clienteCreado = await _clienteService.CrearClienteAsync(cliente);

            return _mapper.Map<Cliente, ClienteDatosDto>(clienteCreado);
        }

        [HttpPut]
        public async Task<ClienteDatosDto> EditarCliente(ClienteDto clienteParam)
        {
            var cliente = _mapper.Map<ClienteDto, Cliente>(clienteParam);

            var clienteCreado = await _clienteService.EditarClienteAsync(cliente);

            return _mapper.Map<Cliente, ClienteDatosDto>(clienteCreado);
        }

        [HttpDelete]
        public async Task EliminarCliente(ClienteDto clienteParam)
        {
            var cliente = _mapper.Map<ClienteDto, Cliente>(clienteParam);

            await _clienteService.EliminarClienteAsync(cliente);
        }
    }
}
