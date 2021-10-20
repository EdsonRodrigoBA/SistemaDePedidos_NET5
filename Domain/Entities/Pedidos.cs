using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Pedidos : BaseDomain
    {
        public String numero { get; set; }
        public decimal valor { get; set; }
        public TimeSpan dt_entrega { get; set; }

        public int id_cliente { get; set; }
        public virtual Clientes clientes { get; set; }
        public virtual  List<ProdutosPedidos> ProdutosPedidos { get; set; }

    }
}
