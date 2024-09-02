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
    public class MvSysSjqJobQueueController : ControllerBase
    {
        private readonly IMvSysSjqJobQueueRepository _repository;

        public MvSysSjqJobQueueController(IMvSysSjqJobQueueRepository repository)
        {
            _repository = repository;   
        }

        [HttpGet]
        public async Task<ActionResult<List<MvSysSjqJobQueue>>> APIJobQueues()
        {
            List<MvSysSjqJobQueue> Lista = await _repository.APIJobQueues();
            return Ok(Lista);
        }

        [HttpGet("get/{SjqProcedureName}")]
        public async Task<ActionResult<MvSysSjqJobQueue>> SearchByProcedureName(string SjqProcedureName)
        {
            MvSysSjqJobQueue Lista = await _repository.SearchByProcedureName(SjqProcedureName);
            return Ok(Lista);
        }

        [HttpPost]
        public async Task<ActionResult<MvSysSjqJobQueue>> AddQueue([FromBody] MvSysSjqJobQueue q)
        {
            MvSysSjqJobQueue Lista = await _repository.AddQueue(q);
            return Ok(Lista);
        }

        [HttpPut("put/{SjqProcedureName}")]
        public async Task<ActionResult<MvSysSjqJobQueue>> UpdateQueue([FromBody] MvSysSjqJobQueue q, string SjqProcedureName)
        {
            if(q.SjqProcedureName == SjqProcedureName)
            {
                await _repository.UpdateQueue(q);
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("delete/{SjqProcedureName}")]
        public async Task<ActionResult<MvSysSjqJobQueue>> DeleteQueue(string SjqProcedureName)
        {
            bool Lista = await _repository.DeleteQueue(SjqProcedureName);
            return Ok(Lista);
        }
    }
}
