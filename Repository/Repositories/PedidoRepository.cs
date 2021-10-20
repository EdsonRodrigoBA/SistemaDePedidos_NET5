using Domain.Dtos;
using Domain.Entities;
using Interface.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class PedidoRepository : BaseRepository, IPedidosRepository
    {
        public PedidoRepository(MyAppContext context) : base(context)
        {
        }

        public String PegarProximoNumero()
        {
            var ret = 1.ToString("0000");
            var ultimonumero = _context.pedidos.Max(x => x.numero);
            if (!String.IsNullOrEmpty(ultimonumero))
            {
                ret = (Convert.ToInt32(ultimonumero) + 1).ToString("0000").Trim();
            }

            return ret;
        }
        public dynamic PedidosPorCliente()
        {
            var hoje = DateTime.Today;
            var inicio_mes = new DateTime(hoje.Year, hoje.Month, 1);
            var fim_mes = new DateTime(hoje.Year, hoje.Month, DateTime.DaysInMonth(hoje.Year, hoje.Month));

            return _context.pedidos.Where(x => x.created_at.Date >= inicio_mes & x.created_at.Date <= fim_mes)
                .GroupBy(pedido => new { pedido.id_cliente, pedido.clientes.nome },
                (chave, Pedidos) => new
                {
                    Clientes = chave.nome,
                    Pedidos = Pedidos.Count(),
                    Total = Pedidos.Sum(vl => vl.valor)
                })
                .ToList();

            //return _context.pedidos.Where(x => x.created_at.Date >= inicio_mes & x.created_at.Date <= fim_mes)
            //       .GroupBy(pedido => new { pedido.id_cliente, pedido.clientes.nome  })
            //       .Select(x => new
            //       {
            //           Clientes = x.Key.nome,
            //           Pedidos = x.Count(),
            //           Total = x.Sum(vl => vl.valor)
            //       })
            //       .ToList(); 
        }

        public decimal TicketMaximo()
        {
            var hoje = DateTime.Today;
            return _context.pedidos.Where(x => x.created_at.Date == hoje)
                .Max(x => (decimal?)x.valor) ?? 0;
        }

        public Pedidos CriarPedido(PedidosDTO model)
        {
            try
            {
                using (var transaction = _context.Database.BeginTransaction())
                {



                    try
                    {
                        var pedido = new Pedidos()
                        {
                            id_cliente = model.id_cliente,
                            created_at = DateTime.Now,
                            numero = PegarProximoNumero(),
                            ProdutosPedidos = new List<ProdutosPedidos>()


                        };

                        decimal totalPedido = 0;
                        foreach (var item in model.Produtos)
                        {
                            var precoproduto = _context.produtos.Where(x => x.id == item.id_produto)
                                .Select(x => x.preco).FirstOrDefault();

                            if (precoproduto > 0)
                            {
                                totalPedido += item.quantidade * precoproduto;
                                pedido.ProdutosPedidos.Add(new ProdutosPedidos()
                                {
                                    id_produto = item.id_produto,
                                    quantidade = item.quantidade,
                                    preco = precoproduto,
                                    created_at = DateTime.Now,

                                });
                            }
                        }

                        pedido.valor = totalPedido;
                        _context.Add(pedido);
                        int id = pedido.id;
                        _context.SaveChanges();
                        transaction.Commit();
                        return pedido;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
