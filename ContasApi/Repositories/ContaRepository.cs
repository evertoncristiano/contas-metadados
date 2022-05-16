using Microsoft.EntityFrameworkCore;
using ContasApi.Data;
using ContasApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContasApi.Repositories
{
    public class ContaRepository
    {
        private readonly AppDbContext _context;
        public ContaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Conta>> BuscarContas()
        {
            return await _context.Contas.ToListAsync();
        }

        public async Task<Conta> CriarConta(Conta conta)
        {
            await _context.Contas.AddAsync(conta);
            await _context.SaveChangesAsync();

            return conta;
        }

    }
}