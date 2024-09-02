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
    public class MvSysSxExceptionController : ControllerBase
    {
        private readonly IMvSysSxExceptionRepository _repository;

        public MvSysSxExceptionController(IMvSysSxExceptionRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<MvSysSxException>>> ExceptionAPI()
        {
            List<MvSysSxException> Lista = await _repository.ExceptionAPI();
            return Ok(Lista);
        }

        [HttpGet ("get/{sxCompany}")]
        public async Task<ActionResult<MvSysSxException>> SearchByException(string sxCompany)
        {
            MvSysSxException Lista = await _repository.SearchByException(sxCompany);
            return Ok(Lista);
        }

        [HttpPost]
        public async Task<ActionResult<MvSysSxException>> AddException([FromBody] MvSysSxException Exception)
        {
            try
            {
                await _repository.AddException(Exception);
                if (Exception == null)
                    return NotFound();
                return Ok(Exception);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("put/{sxCompany}")]
        public async Task<ActionResult<MvSysSxException>> UpdateByException([FromBody] MvSysSxException Exception, string sxCompany)
        {
            if(Exception.SxCompany == sxCompany)
            {
                await _repository.UpdateByException(Exception);
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete/{sxCompany}")]
        public async Task<ActionResult<MvSysSxException>> DeleteByException(string sxCompany)
        {
            bool Lista = await _repository.DeleteByException(sxCompany);
            return Ok(Lista);
        }
    }
}
