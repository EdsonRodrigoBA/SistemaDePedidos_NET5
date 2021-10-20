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
    public class EnderecosMaps : BaseDomainMaps<Enderecos>
    {
        public EnderecosMaps() : base("Enderecos")
        {

        }
        public override void Configure(EntityTypeBuilder<Enderecos> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.tipo).IsRequired();
            builder.Property(x => x.logradouro).HasColumnType("varchar(350)").IsRequired();
            builder.Property(x => x.bairro).HasColumnType("char(250)").IsRequired();
            builder.Property(x => x.numero).HasColumnType("char(50)").IsRequired();
            builder.Property(x => x.complemento).HasColumnType("char(250)");
            builder.Property(x => x.cep).HasColumnType("char(20)");

            builder.HasOne(x => x.Clientes).WithOne(x => x.Endereco).HasForeignKey<Clientes>(x => x.id_endereco);
            builder.Property(x => x.id_cidade).IsRequired();
            builder.HasOne(x => x.Cidade).WithMany().HasForeignKey(x => x.id_cidade);


        }
    }
}
