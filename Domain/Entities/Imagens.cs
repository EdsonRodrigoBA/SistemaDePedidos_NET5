using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Imagens : BaseDomain
    {
        public String nome { get; set; }
        public String caminhoarquivo { get; set; }

        public String principal { get; set; }

        public virtual List<Produtos> Produtos { get; set; }

    }
}
