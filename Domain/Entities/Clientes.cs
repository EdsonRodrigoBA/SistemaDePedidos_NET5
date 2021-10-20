using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Clientes : BaseDomain, IExibivel
    {
        public String nome { get; set; }
        public String cpfcnpj { get; set; }
        public virtual Enderecos Endereco { get; set; }
        public int id_endereco { get; set; }
        public string active { get; set; }

        public virtual List<Pedidos> pedidos { get; set; }

    }
}
