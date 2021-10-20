using Interface.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    public class DependencyInjection
    {
        public static void Register(IServiceCollection servicesColetion)
        {
            RepositoryDependence(servicesColetion);
        }

        private static void RepositoryDependence(IServiceCollection servicesColetion)
        {
            servicesColetion.AddScoped<IProdutoRepository, ProdutosRepository>();
            servicesColetion.AddScoped<IPedidosRepository, PedidoRepository>();
            servicesColetion.AddScoped<ICidadesRepository, CidadesRepository>();


        }
    }
}
