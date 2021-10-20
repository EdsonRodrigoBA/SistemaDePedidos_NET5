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
    public class CidadesMaps : BaseDomainMaps<Cidades>
    {
        public CidadesMaps() : base("Cidades")
        {

        }
        public override void Configure(EntityTypeBuilder<Cidades> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.nome).HasColumnType("varchar(250)").IsRequired();
            builder.Property(x => x.uf).HasColumnType("char(2)").IsRequired();
            builder.Property(x => x.codigo_ibge).IsRequired();
            builder.Property(x => x.active).HasColumnType("char(1)").IsRequired();
        }
    }
}
