using ContasApi.Models;
using ContasApi.Services;
using ContasApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ContasApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class ContaController : ControllerBase
    {
        private readonly ContaService _service;

        public ContaController(ContaService service)
        {
            _service = service;
        }

        [HttpGet("contas")]
        public async Task<IActionResult> BuscarContasAsync()
        {
            var contas = await _service.BuscarContas();

            return Ok(contas);
        }

        [HttpPost("contas")]
        public async Task<ActionResult<Conta>> CriarContaAsync([FromBody] CriarContaViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var conta = await _service.CriarConta(model);

            return Ok(conta);
        }
    }
}
