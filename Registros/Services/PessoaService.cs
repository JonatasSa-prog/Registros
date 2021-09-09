using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Registros.Models;
using Registros.Data;
using Microsoft.EntityFrameworkCore;
using Registros.Services.Exceptions;

namespace Registros.Services
{
    public class PessoaService
    {
        private readonly RegistrosContext _context;
        public PessoaService(RegistrosContext context)
        {
            _context = context;
        }

        public async Task<List<Pessoa>> FindAllAsync( )
        {
            return await _context.Pessoa.OrderBy(p => p.Name).ToListAsync();       
        }

        public async Task<List<Pessoa>> FindAllByNameAsync(string name)
        {
            return await _context.Pessoa.Where(p => p.Name.Contains(name)).OrderBy(p => p.Name).ToListAsync();
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

        public async Task UpdateAsync(Pessoa obj)
        {

            if (!await _context.Pessoa.AnyAsync(x => x.Id == obj.Id))
                throw new NotFoundException("Id not found");

            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }

        public async Task RemoveAsync(Guid id)
        {
            try
            {
                var obj = await _context.Pessoa.FindAsync(id);
                _context.Pessoa.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }

        }


    }
}
