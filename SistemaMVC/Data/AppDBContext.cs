using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiniMundo.Models;

namespace MiniMundo.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext (DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        public DbSet<MiniMundo.Models.Produto> Produto { get; set; } = default!;
        public DbSet<MiniMundo.Models.Funcionario> Funcionario { get; set; } = default!;
        public DbSet<MiniMundo.Models.Venda> Venda { get; set; } = default!;
    }
}
