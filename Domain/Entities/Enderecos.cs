using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Enderecos : BaseDomain
    {
        public TipoEnderecoEnum tipo { get; set; }
        public String logradouro { get; set; }
        public String bairro { get; set; }
        public String numero { get; set; }
        public String complemento { get; set; }
        public String cep { get; set; }
        public int id_cidade { get; set; }
        public virtual Cidades Cidade { get; set; }
        public virtual Clientes Clientes { get; set; }


    }
}
