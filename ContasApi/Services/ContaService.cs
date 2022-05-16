using System.Collections.Generic;
using System.Threading.Tasks;
using ContasApi.Models;
using ContasApi.Repositories;
using ContasApi.ViewModels;

namespace ContasApi.Services
{
    public class ContaService
    {
        private readonly ContaRepository _repository;
        public ContaService(ContaRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Conta>> BuscarContas()
        {
            return await _repository.BuscarContas();
        }

        public async Task<Conta> CriarConta(CriarContaViewModel model)
        {
            var conta = new Conta(model);
            return await _repository.CriarConta(conta);
        }
    }
}