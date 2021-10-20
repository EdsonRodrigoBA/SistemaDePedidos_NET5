using Domain.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Repositories
{
    public interface IPedidosRepository
    {

        decimal TicketMaximo();
        //Task<List<Produtos>> Get();
        //dynamic Search(String param, int pagina);
        //Task<Produtos> Detalhes(int id);

        dynamic PedidosPorCliente();

        Pedidos CriarPedido(PedidosDTO pedidosDTO);
    }
}
