using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Registros.Models;

namespace Registros.Data
{
    public class SeedingService
    {
        private RegistrosContext _context;

        public SeedingService(RegistrosContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Pessoa.Any() )
            {
                return; // DB has been seeded
            }

            Pessoa p1 = new Pessoa("Jonatas Santos Sá","71991110795","86474711566","jonatas@gmail.com",DateTime.Parse("28/02/2000"));
            Pessoa p2 = new Pessoa("Higor carvalho", "71999999999", "99999999999", "higot@gmail.com", DateTime.Parse("12/02/2000"));
            Pessoa p3 = new Pessoa("Inocencio Moreira", "71988888888", "88888888888", "inocencio@gmail.com", DateTime.Parse("13/02/2000"));
            Pessoa p4 = new Pessoa("Icaro Carmona", "71977777777", "77777777777", "icaro@gmail.com", DateTime.Parse("24/02/2000"));
            Pessoa p5 = new Pessoa("Alvaro de Oliveira Sá", "71966666666", "66666666666", "Alvaro@gmail.com", DateTime.Parse("12/12/1968"));
            _context.Pessoa.AddRange(p1, p2, p3, p4, p5);
            _context.SaveChanges();
        }
        
    }
}
