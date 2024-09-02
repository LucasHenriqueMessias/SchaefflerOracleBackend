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
    public class MvSysSemEmailGroupMemberController : ControllerBase
    {
        private readonly IMvSysSemEmailGroupMember _repository;
        public MvSysSemEmailGroupMemberController(IMvSysSemEmailGroupMember repository)
        {
            _repository = repository;
        }

        [HttpGet("get/{semGroupName}")]
        public async Task<ActionResult<MvSysSemEmailGroupMember>> Select(string semGroupName)
        {
            List<MvSysSemEmailGroupMember> member = await _repository.Select(semGroupName);
            return Ok(member);
        }

        [HttpPost]
        public async Task<ActionResult<MvSysSemEmailGroupMember>> Post(MvSysSemEmailGroupMember semMember)
        {
            try
            {
                await _repository.Post(semMember);
                if (semMember == null)
                    return NotFound();
                return Ok(semMember);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
