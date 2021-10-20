using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class ProdutosDTO
    {

        public String nome { get; set; }
        public String descricao { get; set; }
        public decimal preco { get; set; }
        public String codigo { get; set; }

        public String ean { get; set; }
        public int id_categoria { get; set; }
        public List<ImagensDTO> imagensDTOs { get; set; }

    }
}
