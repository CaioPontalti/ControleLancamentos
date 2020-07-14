using Controle.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controle.Infra.Mappings
{
    public class ContaMapping : IEntityTypeConfiguration<ContaCorrente>
    {
        public void Configure(EntityTypeBuilder<ContaCorrente> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.NumeroConta)
                .IsRequired()
                .HasColumnType("varchar(10)");
        }
    }
}
