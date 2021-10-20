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
    public class BaseDomainMaps<TDomain> : IEntityTypeConfiguration<TDomain> where TDomain : BaseDomain
    {

        private readonly string _tablename;
        public BaseDomainMaps(String tablename = "")
        {
            this._tablename = tablename;
        }

        public virtual void Configure(EntityTypeBuilder<TDomain> builder)
        {
            if (!String.IsNullOrEmpty(_tablename))
            {
                builder.ToTable(_tablename).HasKey(x => x.id);
                builder.Property(x => x.id).ValueGeneratedOnAdd();
                builder.Property(x => x.created_at).IsRequired();
            }
        }
    }
}
