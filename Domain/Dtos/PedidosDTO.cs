using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class PedidosDTO
    {
        public int id_cliente { get; set; }

        public virtual List<ProdutosPedidoDTO> Produtos { get; set; }
    }
}
