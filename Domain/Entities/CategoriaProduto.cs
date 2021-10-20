using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CategoriaProduto : BaseDomain, IExibivel
    {
        public String nome { get; set; }
        public string active { get; set ; }

        public virtual List<Produtos> Produtos { get; set; }
    }
}
