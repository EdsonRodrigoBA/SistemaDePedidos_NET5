using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Produtos : BaseDomain, IExibivel
    {
        public String nome { get; set; }
        public String descricao { get; set; }
        public decimal preco { get; set; }
        public String codigo { get; set; }

        public String ean { get; set; }
        public int id_categoria { get; set; }
        public virtual CategoriaProduto CategoriaProduto { get; set; }
        public virtual List<Imagens> Imagens { get; set; }
        public virtual List<PromocaoProduto> PromocaoProdutos { get; set; }

        public virtual List<Combos> Combos { get; set; }


        public string active { get; set ; }
    }
}
