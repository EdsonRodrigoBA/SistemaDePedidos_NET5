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
    public class PedidosMaps : BaseDomainMaps<Pedidos>
    {
        public PedidosMaps() : base("Pedidos")
        {

        }
        public override void Configure(EntityTypeBuilder<Pedidos> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.numero).HasColumnType("char(250)").IsRequired();
            builder.Property(x => x.valor).HasColumnType("decimal(18,5)").IsRequired();

            builder.Property(x => x.id_cliente).IsRequired();
            builder.HasOne(x => x.clientes).WithMany(x => x.pedidos).HasForeignKey(x => x.id_cliente);

        }
    }
}
