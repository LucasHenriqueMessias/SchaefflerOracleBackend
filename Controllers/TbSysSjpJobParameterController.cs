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
    public class TbSysSjpJobParameterController : ControllerBase
    {
        private readonly ITbSysSjpJobParameters _controller;
        public TbSysSjpJobParameterController(ITbSysSjpJobParameters param)
        {
            _controller = param;
        }

        [HttpGet]
        public async Task<ActionResult<List<TbSysSjpJobParameter>>> GetList()
        {
            List<TbSysSjpJobParameter> list = await _controller.GetList();
            return Ok(list);
        }
        [HttpPost]
       public async Task<ActionResult<TbSysSjpJobParameter>> Post(TbSysSjpJobParameter parameter)
        {
            try
            {
                await _controller.Post(parameter);
                if (parameter == null)
                    return NotFound();
                return Ok(parameter);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("put/{SjpProcedureName}/{SjpParameterName}")]
        public async Task<ActionResult<TbSysSjpJobParameter>> Put(TbSysSjpJobParameter parameter, string SjpProcedureName, string SjpParameterName)
        {
            if (parameter.SjpProcedureName == SjpProcedureName && parameter.SjpParameterName == SjpParameterName)
            {
                await _controller.Put(parameter);
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

       [HttpDelete("delete/{SjpProcedureName}/{SjpParameterName}")]
        public async Task<ActionResult<TbSysSjpJobParameter>> Delete(string SjpProcedureName, string SjpParameterName)
        {
            try
            {
                TbSysSjpJobParameter param = await _controller.Select(SjpProcedureName, SjpParameterName);
                if (param != null)
                {
                    await _controller.Delete(param);
                    return Ok(param);
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

        [HttpGet("get/{SjpProcedureName}/{SjpParameterName}")]
        public async Task<ActionResult<TbSysSjpJobParameter>> Select(string SjpProcedureName, string SjpParameterName)
        {
            try
            {
                var parameter = await _controller.Select(SjpProcedureName, SjpParameterName);
                if (parameter == null)
                    return NotFound();
                return Ok(parameter);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("list/{SjpProcedureName}")]
        public async Task<ActionResult<TbSysSjpJobParameter>> SelectList(string SjpProcedureName)
        {
            try
            {
               List<TbSysSjpJobParameter> parameter = await _controller.SelectList(SjpProcedureName);
                if (parameter == null)
                    return NotFound();
                return Ok(parameter);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
