using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using oracle_backend.Models;
using oracle_backend.Repository;
using oracle_backend.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace oracle_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QvSysSsmSystemMailController : ControllerBase
    {
        private readonly IQvSysSsmSystemMailRepository _iqvSysSsmSystemMailRepository;

        public QvSysSsmSystemMailController(IQvSysSsmSystemMailRepository iqvSysSsmSystemMailRepository)
        {
            _iqvSysSsmSystemMailRepository = iqvSysSsmSystemMailRepository;
        }

        [HttpGet("list/{Skip:int}/{Take:int}")]
        public async Task<ActionResult<List<QvSysSsmSystemMail>>> ListarEmailSistema(int Skip, int Take)
        {
            List<QvSysSsmSystemMail> Lista = await _iqvSysSsmSystemMailRepository.ListarEmailSistema(Skip, Take);
            return Ok(Lista);
        }


        [HttpGet("get/{SsmSentDateTime}")]
        public async Task<ActionResult<QvSysSsmSystemMail>> SearchEmailSistema(DateTime SsmSentDatetime)
        {
            QvSysSsmSystemMail Lista = await _iqvSysSsmSystemMailRepository.SearchEmailSistema(SsmSentDatetime);
            return Ok(Lista);
        }

        [HttpPost]
        public async Task<ActionResult<QvSysSsmSystemMail>> AddEmailSistema([FromBody] QvSysSsmSystemMail Mail)
        {
            try
            {
                await _iqvSysSsmSystemMailRepository.AddEmailSistema(Mail);
                if (Mail == null)
                    return NotFound();
                return Ok(Mail);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("put/{SsmSentDatetime}")]
        public async Task<ActionResult<QvSysSsmSystemMail>> UpdateEmailSistema([FromBody] QvSysSsmSystemMail Mail, DateTime SsmSentDatetime)
        {
            if( Mail.SsmSentDatetime == SsmSentDatetime )
            {
                await _iqvSysSsmSystemMailRepository.UpdateEmailSistema(Mail);
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete/{SsmSentDatetime}")]
        public async Task<ActionResult<QvSysSsmSystemMail>> DeleteEmailSistema(DateTime SsmSentDatetime)
        {
            bool Lista = await _iqvSysSsmSystemMailRepository.DeleteEmailSistema(SsmSentDatetime);
            return Ok(Lista);
        }
    }
}
