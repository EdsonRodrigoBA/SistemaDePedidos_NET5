using Domain.Dtos;
using Interface.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CidadesController : AppBaseController
    {
        public CidadesController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }



        [HttpGet]
   
        public dynamic Get()
        {
            var repositorio = (ICidadesRepository)_serviceProvider.GetService(typeof(ICidadesRepository));
            return repositorio.Get();
        }

        [HttpPost]
        public int Criar(CidadesDTO model)
        {
            var repositorio = (ICidadesRepository)_serviceProvider.GetService(typeof(ICidadesRepository));
            return repositorio.Criar(model);
        }

        [HttpPut]
        public dynamic Alterar(CidadesDTO model)
        {
            var repositorio = (ICidadesRepository)_serviceProvider.GetService(typeof(ICidadesRepository));
            return StatusCode(200, repositorio.Alterar(model));
        }

        [HttpDelete]
       [Route("{id}")]
        public bool Deletar(int id)
        {
            var repositorio = (ICidadesRepository)_serviceProvider.GetService(typeof(ICidadesRepository));
            return repositorio.Deletar(id);
        }
    }
}
