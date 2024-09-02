using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using oracle_backend.Models;
using oracle_backend.Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace oracle_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MvSysSehExhangeHostController : ControllerBase
    {
        private readonly IMvSysSehExchangeHostRepository _mvSysSehExchangeHostRepository;

        public MvSysSehExhangeHostController(IMvSysSehExchangeHostRepository mvSysSehExchangeHostRepository)
        {
            _mvSysSehExchangeHostRepository = mvSysSehExchangeHostRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<MvSysSehExchangeHost>>> ListarExchangeHost()
        {
            List<MvSysSehExchangeHost> Lista = await _mvSysSehExchangeHostRepository.ListarExchangeHost();
            return Ok(Lista);
        }

        [HttpGet("get/{sehCompany}/{sehHost}/{sehUsername}")]
        public async Task<ActionResult<MvSysSehExchangeHost>> SearchExchangeHost(string sehCompany, string sehHost, string sehUsername)
        {
            MvSysSehExchangeHost exchangeHost = await _mvSysSehExchangeHostRepository.SearchExchangeHost(sehCompany, sehHost, sehUsername);
            return Ok(exchangeHost);
        }

        [HttpPost]
        public async Task<ActionResult<MvSysSehExchangeHost>> AddExchangeHost([FromBody]MvSysSehExchangeHost exchangeHost)
        {
            try
            {
                await _mvSysSehExchangeHostRepository.AddExchangeHost(exchangeHost);
                if (exchangeHost == null)
                    return NotFound();
                return Ok(exchangeHost);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("put/{SehCompany}/{sehHost}/{sehUsername}")]
        public async Task<ActionResult<MvSysSehExchangeHost>> UpdateExchangeHost([FromBody] MvSysSehExchangeHost exchangeHost, string SehCompany, string sehHost, string sehUsername)
        {
            if(exchangeHost.SehCompany == SehCompany && exchangeHost.SehHost == sehHost && exchangeHost.SehUsername == sehUsername)
            {
                await _mvSysSehExchangeHostRepository.UpdateExchangeHost(exchangeHost);
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete/{sehCompany}/{sehHost}/{sehUsername}")]
        public async Task<ActionResult<MvSysSehExchangeHost>> DeleteExchangeHost(string sehCompany, string sehHost, string sehUsername)
        {
            var exchangeHost = await _mvSysSehExchangeHostRepository.SearchExchangeHost(sehCompany, sehHost, sehUsername);  
            bool saida = await _mvSysSehExchangeHostRepository.DeleteExchangeHost(exchangeHost);
            return Ok(saida);
        }
    }
}
