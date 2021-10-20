using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Maps
{
    public class ProdutosPedidosMaps : BaseDomainMaps<ProdutosPedidos>
    {
        public ProdutosPedidosMaps() : base("ProdutosPedidos")
        {

        }
        public override void Configure(EntityTypeBuilder<ProdutosPedidos> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.preco).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.id_pedido).IsRequired();
            builder.HasOne(x => x.Pedidos).WithMany(x => x.ProdutosPedidos).HasForeignKey(x => x.id_pedido);

            builder.Property(x => x.id_produto).IsRequired();      
            builder.HasOne(x => x.Produtos).WithMany().HasForeignKey(x => x.id_produto);


        }
    }
}
