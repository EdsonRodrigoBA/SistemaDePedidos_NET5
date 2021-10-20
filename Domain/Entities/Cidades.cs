using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cidades : BaseDomain , IExibivel
    {
        public String nome { get; set; }
        public String uf { get; set; }
        public int codigo_ibge { get; set; }
        public string active { get; set; }
    }
}
