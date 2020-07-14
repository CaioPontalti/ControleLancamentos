using Controle.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controle.Infra.Context
{
    public class ControleContext : DbContext
    {
        public ControleContext(DbContextOptions<ControleContext> opt) : base(opt) { }

        public DbSet<ContaCorrente> ContaCorrente { get; set; }
        public DbSet<Lancamento> Lancamento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                 e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

           
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ControleContext).Assembly);
        }
    }
}
