using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Combos : BaseDomain, IExibivel
    {
        public String nome { get; set; }
        public decimal preco { get; set; }
        public int id_imagem { get; set; }
 
        public virtual Imagens Imagens { get; set; }
        public int id_produto { get; set; }
        public virtual List<Produtos> Produtos { get; set; }
        public string active { get; set; }

    }
}
