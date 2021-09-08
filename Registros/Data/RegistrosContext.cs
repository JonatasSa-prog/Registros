using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Registros.Controllers;

namespace Registros.Data
{
    public class RegistrosContext : DbContext
    {
        public RegistrosContext(DbContextOptions<RegistrosContext> options)
            : base(options)
        {
        }

        public DbSet<Registros.Models.Pessoa> Pessoa { get; set; }
    }
}

