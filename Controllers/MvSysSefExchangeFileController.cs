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
    public class MvSysSefExchangeFileController : ControllerBase
    {
        private readonly IMvSysSefExchangeFileRepository _mvSysSefExchangeFileRepository;
        public MvSysSefExchangeFileController(IMvSysSefExchangeFileRepository mvSysSefExchangeFileRepository)
        {
            _mvSysSefExchangeFileRepository = mvSysSefExchangeFileRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<MvSysSefExchangeFile>>> ListarExchangeFile()
        {
            List<MvSysSefExchangeFile> Lista = await _mvSysSefExchangeFileRepository.ListarExchangeFile();
            return Ok(Lista);
        }

        [HttpGet("get/{SefID}")]
        public async Task<ActionResult<MvSysSefExchangeFile>> SearchExchangeFile(int SefID)
        {
            try
            {
                var exchangeFile = await _mvSysSefExchangeFileRepository.SearchExchangeFile(SefID);
                if (exchangeFile == null)
                {
                    return NotFound();
                }
                return Ok(exchangeFile);
            } catch { return BadRequest(); }
        }

        [HttpPost]
        public async Task<ActionResult<MvSysSefExchangeFile>> AddExchangeFile(MvSysSefExchangeFile exchangeFile)
        {
            try
            {
                await _mvSysSefExchangeFileRepository.AddExchangeFile(exchangeFile);
                if (exchangeFile == null)
                    return NotFound();
                return Ok(exchangeFile);
            }
            catch
            {
                return BadRequest();  
            }
        }

        [HttpPut("put/{SefID}")]
        public async Task<ActionResult<MvSysSefExchangeFile>> UpdateExchangeFile([FromBody] MvSysSefExchangeFile exchangeFile, int SefID)
        {
            if(exchangeFile.SefId == SefID)
            {
                await _mvSysSefExchangeFileRepository.UpdateExchangeFile(exchangeFile);
                return NoContent();
            } else
            {
                return BadRequest();
            }
            
        }

        [HttpDelete("delete/{SefID}")]
        public async Task<ActionResult<MvSysSefExchangeFile>> DeleteExchangeFile(int SefID)
        {
            try
            {
                MvSysSefExchangeFile exchangeFile = await _mvSysSefExchangeFileRepository.SearchExchangeFile(SefID);
                if (exchangeFile != null)
                {
                  await _mvSysSefExchangeFileRepository.DeleteExchangeFile(exchangeFile);
                    return Ok(exchangeFile);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
