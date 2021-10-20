using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class ProdutosPedidoDTO
    {
        public int id_produto { get; set; }
        public int quantidade { get; set; }
        public decimal valor { get; set; }
    }
}
