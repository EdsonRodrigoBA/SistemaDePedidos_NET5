using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProdutosPedidos: BaseDomain
    {
        public int quantidade { get; set; }
        public decimal preco { get; set; }
        public int id_produto { get; set; }
        public virtual Produtos Produtos { get; set; }

        public int id_pedido { get; set; }

        public virtual Pedidos Pedidos { get; set; }

    }
}
