using Domain.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Repositories
{
    public interface ICidadesRepository
    {

        
        //Task<List<Produtos>> Get();
        //dynamic Search(String param, int pagina);
        //Task<Produtos> Detalhes(int id);

        dynamic Get();

        int Criar(CidadesDTO model);
        dynamic Alterar(CidadesDTO model);
        bool Deletar(int id);
    }
}
