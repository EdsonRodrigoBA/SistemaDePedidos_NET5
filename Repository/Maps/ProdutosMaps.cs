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
    public class ProdutosMaps : BaseDomainMaps<Produtos>
    {
        public ProdutosMaps() : base("Produtos")
        {

        }
        public override void Configure(EntityTypeBuilder<Produtos> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.descricao).HasColumnType("char(250)").IsRequired();
            builder.Property(x => x.nome).HasColumnType("char(150)").IsRequired();
            builder.Property(x => x.preco).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.ean).HasColumnType("char(30)").IsRequired();
            builder.Property(x => x.codigo).HasColumnType("char(50)").IsRequired();
            builder.Property(x => x.active).HasColumnType("char(1)").IsRequired();

            builder.Property(x => x.id_categoria).IsRequired();
            builder.HasOne(x => x.CategoriaProduto).WithMany(x => x.Produtos).HasForeignKey(x => x.id_categoria);


                    builder.HasMany(x => x.Imagens).WithMany(x => x.Produtos).UsingEntity<ImagensProduto>(
                 x => x.HasOne(f => f.Imagens).WithMany().HasForeignKey(f => f.id_imagem),
                 x => x.HasOne(f => f.Produtos).WithMany().HasForeignKey(f => f.id_produto),
                 x =>
                 {
                     x.ToTable("ImagensProdutos");
                     x.HasKey(x => new { x.id_imagem, x.id_produto });
                     x.Property(x => x.id_imagem).IsRequired();
                     x.Property(x => x.id_produto).IsRequired();

                 }

             );
        }
    }
}
