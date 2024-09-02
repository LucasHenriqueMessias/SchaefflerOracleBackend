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
    public class TbSysSemEmailGroupMemberController : ControllerBase
    {
        private readonly ITbSysSemEmailGroupMember _repository;
        public TbSysSemEmailGroupMemberController(ITbSysSemEmailGroupMember tbSysSemEmailGroupMemberRepository)
        {
            _repository = tbSysSemEmailGroupMemberRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TbSysSemEmailGroupMember>>> GetList()
        {
            List<TbSysSemEmailGroupMember> Lista = await _repository.GetList();
            return Lista;
        }
        [HttpPost]
        public async Task<ActionResult<TbSysSemEmailGroupMember>> Post([FromBody] TbSysSemEmailGroupMember member)
        {
            try
            {
                await _repository.Post(member);
                if (member == null)
                    return NotFound();
                return Ok(member);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("put/{semCompany}/{semGroupName}/{semGroupMember}")]
        public async Task<ActionResult<TbSysSemEmailGroupMember>> Put([FromBody]TbSysSemEmailGroupMember member, string semCompany, string semGroupName, string semGroupMember)
        {
            if(member.SemCompany == semCompany && member.SemGroupName == semGroupName && member.SemGroupMember == semGroupMember)
            {
                await _repository.Put(member);
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("delete/{semCompany}/{semGroupName}/{semGroupMember}")]
         public async Task<ActionResult<TbSysSemEmailGroupMember>> Delete(string semCompany, string semGroupName, string semGroupMember)
        {
            var member = await _repository.SelectByMember(semCompany, semGroupName, semGroupMember);
            var saida = await _repository.Delete(member);
            return Ok(saida);
        } 
      [HttpGet("get/{semCompany}/{semGroupName}")]
      public async Task<ActionResult<TbSysSemEmailGroupMember>> Select(string semCompany, string semGroupName)
        {
            List<TbSysSemEmailGroupMember>  member = await _repository.Select(semCompany, semGroupName);
            return Ok(member);
        }

        [HttpGet("getbymember/{semCompany}/{semGroupName}/{semGroupMember}")]
        public async Task<ActionResult<TbSysSemEmailGroupMember>> SelectByMember(string semCompany, string semGroupName, string semGroupMember)
        {
            var member = await _repository.SelectByMember(semCompany, semGroupName, semGroupMember);
            return Ok(member);
        }
    }
}
