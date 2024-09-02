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
    public class MvSysSegEmailGroupController : ControllerBase
    {
        private readonly IMvSysSegEmailGroupRepository _repository;

        public MvSysSegEmailGroupController(IMvSysSegEmailGroupRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<MvSysSegEmailGroup>>> ListarEmails()
        {
            List<MvSysSegEmailGroup> Lista = await _repository.ListarEmails();
            return Ok(Lista);
        }

        [HttpGet("get/{segGroupName}")]
        public async Task<ActionResult<MvSysSegEmailGroup>> SearchByGroupEmail(string segGroupName)
        {
            MvSysSegEmailGroup EmailSearch = await _repository.SearchByGroupEmail(segGroupName);
            return Ok(EmailSearch);
        }

        [HttpPost]
        public async Task<ActionResult<MvSysSegEmailGroup>> AddEmail([FromBody] MvSysSegEmailGroup emailGroup)
        {
            try
            {
                await _repository.AddEmail(emailGroup);
                if (emailGroup == null)
                    return NotFound();
                return Ok(emailGroup);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("put/{segGroupName}")]
        public async Task<ActionResult<MvSysSegEmailGroup>> UpdateEmail([FromBody] MvSysSegEmailGroup emailGroup, string segGroupName)
        {  
            if (emailGroup.SegGroupName == segGroupName)
            {
                await _repository.UpdateEmail(emailGroup);
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete/{segGroupName}")]
        public async Task<ActionResult<MvSysSegEmailGroup>> DeleteEmail(string segGroupName)
        {
            bool saida = await _repository.DeleteEmail(segGroupName);
            return Ok(saida);
        }
    }
}
