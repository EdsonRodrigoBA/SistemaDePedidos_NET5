using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProdutosCombo
    {
        public int id_produto { get; set; }
        public virtual Produtos Produtos { get; set; }

        public int id_combo { get; set; }
        public virtual Combos Combos { get; set; }
    }
}
