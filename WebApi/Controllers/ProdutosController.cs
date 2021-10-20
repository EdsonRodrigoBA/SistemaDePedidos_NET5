using Domain.Entities;
using Interface.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    //[Route("api/[controller]")]
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController :  AppBaseController
    {

        public ProdutosController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        [HttpGet]
        public  dynamic Get([FromQuery] string ordem = "")
        {
            var repositorio = (IProdutoRepository)_serviceProvider.GetService(typeof(IProdutoRepository));
            return  repositorio.Get(ordem);
        }

        [HttpGet]
        [Route("Search/{param}/{pagina?}")]
        public dynamic GetSearchAsync(string param, int pagina = 1, [FromQuery] string ordem = "")
        {
            var repositorio = (IProdutoRepository)_serviceProvider.GetService(typeof(IProdutoRepository));
            return   repositorio.Search(param, pagina, ordem);
        }

        [HttpGet]
        [Route("Detalhes/{id}")]
        public dynamic GetDetalhes(int? id)
        {
            if((id ??0 )> 0)
            {
                var repositorio = (IProdutoRepository)_serviceProvider.GetService(typeof(IProdutoRepository));
                return  repositorio.Detalhes(id.Value);
            }
            else
            {
                return null;
            }
       
        }

        [HttpGet]
        [Route("Detalhes/{id}/imagens")]
        public dynamic GetImagens(int? id)
        {
            if ((id ?? 0) > 0)
            {
                var repositorio = (IProdutoRepository)_serviceProvider.GetService(typeof(IProdutoRepository));
                return repositorio.Imagens(id.Value);
            }
            else
            {
                return null;
            }

        }

    }
}
