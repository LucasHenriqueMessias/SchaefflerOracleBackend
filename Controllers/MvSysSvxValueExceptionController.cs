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
    public class MvSysSvxValueExceptionController : ControllerBase
    {
        private readonly IMvSysSvxValueExceptionRepository _repository;

        public MvSysSvxValueExceptionController(IMvSysSvxValueExceptionRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("list/{Skip}/{Take}")]
        public async Task<ActionResult<List<MvSysSvxValueException>>> ValueExceptionAPI(int Skip, int Take)
        {

            List<MvSysSvxValueException> Lista = await _repository.ValueExceptionAPI(Skip, Take);
            return Ok(Lista);
        }

        [HttpGet("get/{SvxException}")]
        public async Task<ActionResult<MvSysSvxValueException>> SearchByValue(int SvxException)
        {
            MvSysSvxValueException Lista = await _repository.SearchByValue(SvxException);
            return Ok(Lista);
        }

        [HttpPost]
        public async Task<ActionResult<MvSysSvxValueException>> AddValueException([FromBody] MvSysSvxValueException e)
        {
            try
            {
                await _repository.AddValueException(e);
                if (e == null)
                    return NotFound();
                return Ok(e);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("put/{SvxException}")]
        public async Task<ActionResult<MvSysSvxValueException>> UpdateValueException([FromBody] MvSysSvxValueException e, int SvxException)
        {
            if(e.SvxException == SvxException)
            {
                await _repository.UpdateValueException(e);
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete/{SvxException}")]
        public async Task<ActionResult<MvSysSvxValueException>> DeleteValueException(int SvxException)
        {
            bool Lista = await _repository.DeleteValueException(SvxException);
            return Ok(Lista);
        }
    }
}
