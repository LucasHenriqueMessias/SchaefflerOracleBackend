using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using oracle_backend.Models;
using oracle_backend.Repository;
using oracle_backend.Repository.Interface;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Threading.Tasks;

namespace oracle_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MvSysSjpJobParameterController : ControllerBase
    {
        private readonly IMvSysSjpJobParameterRepository _repository;
        public MvSysSjpJobParameterController(IMvSysSjpJobParameterRepository repository)
        {
            _repository = repository;
        }

        [HttpDelete("delete/{SjpProcedureName}/{sjpParameterName}")]
        public async Task<ActionResult<MvSysSjpJobParameter>> DeleteParam(string SjpProcedureName, string sjpParameterName)
        {
            bool saida = await _repository.DeleteParam(SjpProcedureName, sjpParameterName);
            return Ok(saida);
        }

        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<MvSysSjpJobParameter>>> FilterParam([FromQuery]string SjpProcedureName)
        {
            try
            {
                var name = await _repository.FilterParam(SjpProcedureName);
                if (name == null)
                    return NotFound();
                return Ok(name);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("get/{SjpProcedureName}/{sjpParameterName}")]
        public async Task<ActionResult<MvSysSjpJobParameter>> GetParam(string SjpProcedureName, string sjpParameterName)
        {
            MvSysSjpJobParameter param = await _repository.GetParam(SjpProcedureName, sjpParameterName);
            return Ok(param);
        }

        [HttpGet]
        public async Task<ActionResult<List<MvSysSjpJobParameter>>> ListParam()
        {
            List<MvSysSjpJobParameter> param = await _repository.ListParam();
            return Ok(param);
        }

        [HttpPost]
        public async Task<ActionResult<MvSysSjpJobParameter>> PostParam(MvSysSjpJobParameter param)
        {
            try
            {
                await _repository.PostParam(param);
                if (param == null)
                    return NotFound();
                return Ok(param);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("put/{SjpProcedureName}/{sjpParameterName}")]
        public async Task<ActionResult<MvSysSjpJobParameter>> PutParam(MvSysSjpJobParameter param, string SjpProcedureName, string sjpParameterName)
        {
            if(param.SjpProcedureName == SjpProcedureName && param.SjpParameterName == sjpParameterName)
            {
                await _repository.PutParam(param);
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
