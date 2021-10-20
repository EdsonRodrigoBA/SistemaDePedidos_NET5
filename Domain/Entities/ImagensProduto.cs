using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ImagensProduto
    {
        public int id_imagem { get; set; }
        public virtual Imagens Imagens { get; set; }
        public int id_produto { get; set; }

        public virtual Produtos Produtos { get; set; }
    }
}
