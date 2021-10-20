using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;

namespace Repository
{
    public class MyAppContext : DbContext
    {
        private readonly IConfiguration _config;

        public DbSet<Cidades> cidades { get; set; }
        public DbSet<Clientes> clientes { get; set; }
        public DbSet<CategoriaProduto> categoriaProdutos { get; set; }
        public DbSet<Produtos> produtos { get; set; }
        public DbSet<PromocaoProduto> promocaoProdutos { get; set; }
        public DbSet<Combos> combos { get; set; }
        public DbSet<Pedidos> pedidos { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(messagem => Debug.WriteLine(messagem));
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public MyAppContext()
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;

        }



    }
}
