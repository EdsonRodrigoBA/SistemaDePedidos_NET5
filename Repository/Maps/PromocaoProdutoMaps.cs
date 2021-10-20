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
    public class PromocaoProdutoMaps : BaseDomainMaps<PromocaoProduto>
    {
        public PromocaoProdutoMaps() : base("PromocaoProduto")
        {

        }
        public override void Configure(EntityTypeBuilder<PromocaoProduto> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.nome).HasColumnType("char(150)").IsRequired();

            builder.Property(x => x.active).HasColumnType("char(1)").IsRequired();

            builder.Property(x => x.preco).HasColumnType("decimal(18,2)").IsRequired();

            builder.Property(x => x.id_imagem).IsRequired();
            builder.HasOne(x => x.Imagens).WithMany().HasForeignKey(x => x.id_imagem);

            builder.Property(x => x.id_produto).IsRequired();
            builder.HasOne(x => x.Produtos).WithMany(x => x.PromocaoProdutos).HasForeignKey(x => x.id_produto);

        }
    }
}
