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
    public class MvSysSjJobController : ControllerBase
    {
        private readonly IMvSysSjJobRepository _repository;

        public MvSysSjJobController(IMvSysSjJobRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<MvSysSjJob>>> APISjob()
        {
            List<MvSysSjJob> Lista = await _repository.APISjJob();
            return Ok(Lista);
        }

        [HttpGet("get/{ProcedureName}")]
        public async Task<ActionResult<MvSysSjJob>> Searchjob(string ProcedureName)
        {
            MvSysSjJob Lista = await _repository.SearchJob(ProcedureName);
            return Ok(Lista);
        }

        [HttpPost]
        public async Task<ActionResult<MvSysSjJob>> Addjob([FromBody] MvSysSjJob job)
        {
            try
            {
                await _repository.AddJob(job);
                if (job == null)
                    return NotFound();
                return Ok(job);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("put/{ProcedureName}")]
        public async Task<ActionResult<MvSysSjJob>> Updatejob([FromBody] MvSysSjJob job, string ProcedureName)
        {
            if(job.SjProcedureName == ProcedureName)
            {
                await _repository.UpdateJob(job);
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("delete/{ProcedureName}")]
        public async Task<ActionResult<MvSysSjJob>> Deletejob(string ProcedureName)
        {
            try
            {
                MvSysSjJob job = await _repository.SearchJob(ProcedureName);
                if (job != null)
                {
                    await _repository.DeleteJob(job);
                    return Ok(job);
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
