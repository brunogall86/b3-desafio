using b3.Desafio.WebApi.Domain.Entities.Enumeradores;
using b3.Desafio.WebApi.Domain.Service;
using b3.Desafio.WebApi.Models.Requests;
using b3.Desafio.WebApi.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace b3.Desafio.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvestimentoCdbController : Controller
    {
        private readonly IInvestimentoService _investimentoService;

        public InvestimentoCdbController(IInvestimentoService investimentoService)
        {
            _investimentoService = investimentoService;
        }

        [HttpGet]
        [Route("health-check")]
        public IActionResult Index()
        {
            return Ok(new { response = "Api respondendo" });
        }
        [HttpPost]
        [Route("calcular-investimento")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessageBase))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseMessageBase))]
        public async Task<ActionResult<ResponseMessageBase>> CalcularInvestimento([FromBody] InvestimentoModelRequest model)
        {
            if (!model.EhValido())
            {
                return BadRequest(new ResponseMessageBase(StatusCodes.Status400BadRequest, model, true, model));
            }

            var dado = await _investimentoService.CalcularInvestimento(model.ValorInicial, model.Prazo, TipoInvestimento.CDB);
            return Ok(new ResponseMessageBase(StatusCodes.Status200OK,InvestimentoCalculadoResponse.ModelToResponse(dado)));
        }
    }
}
