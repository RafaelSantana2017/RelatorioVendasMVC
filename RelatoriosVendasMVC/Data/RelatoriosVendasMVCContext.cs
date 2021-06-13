using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RelatoriosVendasMVC.Models;

namespace RelatoriosVendasMVC.Data
{
    public class RelatoriosVendasMVCContext : DbContext
    {
        public RelatoriosVendasMVCContext (DbContextOptions<RelatoriosVendasMVCContext> options)
            : base(options)
        {
        }

        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }
        public DbSet<Vendas> Vendas { get; set; }
    }
}
