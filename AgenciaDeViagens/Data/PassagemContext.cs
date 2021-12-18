using AgenciaDeViagens.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgenciaDeViagens.Data
{
    public class PassagemContext : DbContext
    {
        public PassagemContext(DbContextOptions<PassagemContext> opt) : base(opt)
        {
        }
        public DbSet<Passagem> Passagens { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Agencia> Agencias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder OptionBuilder)
        {
            OptionBuilder.UseSqlServer(connectionString: @"Server=DESKTOP-G0012E3;Database=AgenciaDeViagens;Integrated Security=true");
        }
    }
}