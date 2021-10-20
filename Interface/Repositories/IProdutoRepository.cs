using Domain.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Repositories
{
    public interface IProdutoRepository
    {

        dynamic Get(string ordem);
        dynamic Search(String param, int pagina, string ordem);
        dynamic Detalhes(int id);

        dynamic Imagens(int id);

        dynamic CriarProdutos(ProdutosDTO model);



    }
}
