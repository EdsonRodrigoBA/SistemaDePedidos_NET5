using Domain.Dtos;
using Interface.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PedidosController : AppBaseController
    {
        public PedidosController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        [HttpGet]
        [Route("TicketMaximo")]
        public decimal TicketMaximo()
        {
            var repositorio = (IPedidosRepository)_serviceProvider.GetService(typeof(IPedidosRepository));
            return repositorio.TicketMaximo();
        }

        [HttpGet]
        [Route("PedidosPorCliente")]
        public dynamic PedidosPorCliente()
        {
            var repositorio = (IPedidosRepository)_serviceProvider.GetService(typeof(IPedidosRepository));
            return repositorio.PedidosPorCliente();
        }

        [HttpPost]
        
        public IActionResult CriarPedido(PedidosDTO pedidosDTO)
        {
            try
            {


                var repositorio = (IPedidosRepository)_serviceProvider.GetService(typeof(IPedidosRepository));
                return StatusCode(201, repositorio.CriarPedido(pedidosDTO));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
