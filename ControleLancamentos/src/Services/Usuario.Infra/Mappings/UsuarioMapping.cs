using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Usuario.Infra.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Domain.Models.Usuario>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Usuario> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Login)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.Property(c => c.Senha)
                .IsRequired()
                .HasColumnType("varchar(6)");
        }
    }
}
