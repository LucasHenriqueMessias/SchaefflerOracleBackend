using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using oracle_backend.Models;
using oracle_backend.Repository;
using oracle_backend.Repository.Interface;
using System.Threading.Tasks;

namespace oracle_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TbSysSefExchangeFileController : ControllerBase
    {
        private readonly ITbSysSefExchangeFile _exchangefile;
        public TbSysSefExchangeFileController(ITbSysSefExchangeFile tbSysSefExchangeFileRepository)
        {
            _exchangefile = tbSysSefExchangeFileRepository;
        }

        [HttpPost]
        public async Task<ActionResult<TbSysSefExchangeFile>> Add(TbSysSefExchangeFile exchangeFile)
        {
            try
            {
                await _exchangefile.Add(exchangeFile);
                if (exchangeFile == null)
                    return NotFound();
                return Ok(exchangeFile);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
