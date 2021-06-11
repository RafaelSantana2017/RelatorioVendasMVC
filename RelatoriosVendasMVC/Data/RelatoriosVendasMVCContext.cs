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

        public DbSet<RelatoriosVendasMVC.Models.Departamento> Departamento { get; set; }
    }
}
