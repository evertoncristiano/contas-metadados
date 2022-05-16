using ContasApi.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ContasApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Conta> Contas { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conta>()
                .Property(p => p.Nome)
                    .HasMaxLength(100)
                    .IsRequired();

            modelBuilder.Entity<Conta>()
                .Property(p => p.ValorOriginal)
                    .HasPrecision(10, 2);

            modelBuilder.Entity<Conta>()
                .Property(p => p.ValorCorrigido)
                    .HasPrecision(10, 2);

            modelBuilder.Entity<Conta>()
                .HasData(
                    new Conta { 
                        Id = 1, 
                        Nome = "Internet", 
                        ValorOriginal = 129.90M, 
                        DataDeVencimento = DateTime.Parse("2022-04-08"), 
                        DataDePagamento = DateTime.Parse("2022-04-08"), 
                        ValorCorrigido = 129.90M, 
                        DiasDeAtraso = 0, 
                        RegraDeAtraso = ""
                    },
                    new Conta { 
                        Id = 2, 
                        Nome = "Energia", 
                        ValorOriginal = 500.00M, 
                        DataDeVencimento = DateTime.Parse("2022-04-10"), 
                        DataDePagamento = DateTime.Parse("2022-04-12"), 
                        ValorCorrigido = 511.00M, 
                        DiasDeAtraso = 2, 
                        RegraDeAtraso = "Multa de 2% + Juros de 0,1% ao dia"
                    },
                    new Conta { 
                        Id = 3, 
                        Nome = "Aluguel", 
                        ValorOriginal = 1500.00M, 
                        DataDeVencimento = DateTime.Parse("2022-04-10"), 
                        DataDePagamento = DateTime.Parse("2022-04-18"), 
                        ValorCorrigido = 1569.00M, 
                        DiasDeAtraso = 8,
                        RegraDeAtraso = "Multa de 3% + Juros de 0,2% ao dia"
                    },
                    new Conta { 
                        Id = 4, 
                        Nome = "Telefone", 
                        ValorOriginal = 150.00M, 
                        DataDeVencimento = DateTime.Parse("2022-04-10"), 
                        DataDePagamento = DateTime.Parse("2022-04-30"), 
                        ValorCorrigido = 166.50M, 
                        DiasDeAtraso = 20,
                        RegraDeAtraso = "Multa de 5% + Juros de 0,3% ao dia"
                    });
        }
    }
}