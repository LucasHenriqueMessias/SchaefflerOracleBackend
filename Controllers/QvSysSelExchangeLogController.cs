using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using oracle_backend.Models;
using oracle_backend.Repository;
using oracle_backend.Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace oracle_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QvSysSelExchangeLogController : ControllerBase
    {
        private readonly IQvSysSelExchangeLogRepository _qvSysSelExchangeLogRepository;
        public QvSysSelExchangeLogController(IQvSysSelExchangeLogRepository qvSysSelExchangeLogRepository)
        {
            _qvSysSelExchangeLogRepository = qvSysSelExchangeLogRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<QvSysSelExchangeLog>>> ListarExchangeFileLog()
        {
            List<QvSysSelExchangeLog> Lista = await _qvSysSelExchangeLogRepository.ListarExchangeLog();
            return Ok(Lista);
        }
        
        [HttpGet("get/{SelID}")]
        public async Task<ActionResult<QvSysSelExchangeLog>> SearchExchangeLog(long SelId)
        {
            QvSysSelExchangeLog Lista = await _qvSysSelExchangeLogRepository.SearchExchangeLog(SelId);
            return Ok(Lista);
        }

        [HttpPost]
        public async Task<ActionResult<QvSysSelExchangeLog>> AddExchangeLog([FromBody] QvSysSelExchangeLog ExchangeLog)
        {
            try
            {
                await _qvSysSelExchangeLogRepository.AddExchangeLog(ExchangeLog);
                if (ExchangeLog == null)
                    return NotFound();
                return Ok(ExchangeLog);
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPut("put/{SelId}")]
        public async Task<ActionResult<QvSysSelExchangeLog>> UpdateExchangeLog([FromBody] QvSysSelExchangeLog exchangeLog, long SelId)
        {
            if(exchangeLog.SelId == SelId)
            {
                await _qvSysSelExchangeLogRepository.UpdateExchangeLog(exchangeLog);
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete/{SelId}")]
        public async Task<ActionResult<QvSysSelExchangeLog>> DeleteExchangeLog(long SelId)
        {
            bool Lista = await _qvSysSelExchangeLogRepository.DeleteExchangeLog(SelId);
            return Ok(Lista);
        }
    }
}
