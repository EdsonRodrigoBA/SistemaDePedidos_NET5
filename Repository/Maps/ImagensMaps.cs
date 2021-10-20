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
    public class ImagensMaps : BaseDomainMaps<Imagens>
    {
        public ImagensMaps() : base("Imagens")
        {

        }
        public override void Configure(EntityTypeBuilder<Imagens> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.nome).HasColumnType("char(250)").IsRequired();
            builder.Property(x => x.principal).HasColumnType("char(1)").IsRequired();
            builder.Property(x => x.caminhoarquivo).HasColumnType("char(250)").IsRequired();
        }
    }
}
