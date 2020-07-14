using Controle.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controle.Infra.Mappings
{
    public class LancamentoMapping : IEntityTypeConfiguration<Lancamento>
    {
        public void Configure(EntityTypeBuilder<Lancamento> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.NumeroContaOrigem)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.Property(l => l.NumeroContaDestino)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.Property(l => l.Valor)
                .IsRequired()
                .HasColumnType("numeric(18,2)");

            builder.Property(l => l.DataLancamento)
                .IsRequired()
                .HasColumnType("DateTime");
        }
    }
}
