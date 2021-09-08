using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Registros.Models;
using Registros.Data;
using Microsoft.EntityFrameworkCore;

namespace Registros.Services
{
    public class PessoaService
    {
        private readonly RegistrosContext _context;
        public PessoaService(RegistrosContext context)
        {
            _context = context;
        }

        public async Task<List<Pessoa>> FindAllAsync()
        {
            return await _context.Pessoa.OrderBy(p => p.Name).ToListAsync();
        }

        public async Task InsertAsync(Pessoa obj)
        {

            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Pessoa> FindByIdAsync(Guid id)
        {
            return await _context.Pessoa.FirstOrDefaultAsync(obj => obj.Id == id);
        }


    }
}
