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
    public class CombosMaps : BaseDomainMaps<Combos>
    {
        public CombosMaps() : base("Combos")
        {

        }
        public override void Configure(EntityTypeBuilder<Combos> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.active).HasColumnType("char(1)").IsRequired();
            builder.Property(x => x.nome).HasColumnType("char(250)").IsRequired();
            builder.Property(x => x.preco).HasColumnType("decimal(18,5)").IsRequired();


            builder.Property(x => x.id_imagem).IsRequired();
            builder.HasOne(x => x.Imagens).WithMany().HasForeignKey(x => x.id_imagem);

            builder.HasMany(x => x.Produtos).WithMany(x => x.Combos).UsingEntity<ProdutosCombo>(
                x => x.HasOne(f => f.Produtos).WithMany().HasForeignKey(f => f.id_produto),
                x => x.HasOne(f => f.Combos).WithMany().HasForeignKey(f => f.id_combo),
                x =>
                {
                    x.ToTable("ProdutosCombo");
                    x.HasKey(x => new { x.id_produto, x.id_combo });
                    x.Property(x => x.id_produto).IsRequired();
                    x.Property(x => x.id_combo).IsRequired();

                }

            );



        }
    }
}
