using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProduto.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //O entity framework vai utilizar essas configurações na migração de dados 
            modelBuilder.Entity<Produto>().Property(p => p.Nome).HasMaxLength(80);
            modelBuilder.Entity<Produto>().Property(p => p.Preco).HasPrecision(10,2);


            //Incluindo dados iniciais na tabela Produto, quando o banco de dados for criado
            modelBuilder.Entity<Produto>().HasData(
                new Produto { Id = 1, Nome = "Caderno", Preco = 7.95M, Estoque = 10 },
                new Produto { Id = 2, Nome = "Borracha", Preco = 2.45M, Estoque = 30 },
                new Produto { Id = 3, Nome = "Estojo", Preco = 6.25M, Estoque = 15 }
                );

        }


    }
}
