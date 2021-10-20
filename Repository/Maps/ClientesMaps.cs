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
    public class ClientesMaps : BaseDomainMaps<Clientes>
    {
        public ClientesMaps() : base("Clientes")
        {

        }
        public override void Configure(EntityTypeBuilder<Clientes> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.cpfcnpj).HasColumnType("char(20)").IsRequired();
            builder.Property(x => x.nome).HasColumnType("char(150)").IsRequired();
            builder.Property(x => x.active).HasColumnType("char(1)").IsRequired();
            builder.Property(x => x.id_endereco).IsRequired();


        }
    }
}
