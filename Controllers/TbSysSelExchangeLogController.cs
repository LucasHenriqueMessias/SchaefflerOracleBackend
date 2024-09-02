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
    public class TbSysSelExchangeLogController : ControllerBase
    {
        private readonly ITbSysSelExchangeLog _repository;

        public TbSysSelExchangeLogController(ITbSysSelExchangeLog repository)
        {
            _repository = repository;
        }

        [HttpGet("list/{Skip}/{Take}")]
        public async Task<ActionResult<List<TbSysSelExchangeLog>>> GetSysSelExchangeLogAsync(int Skip, int Take)
        {
            List<TbSysSelExchangeLog> Lista = await _repository.GetSysSelExchangeLogAsync(Skip, Take);
            return Ok(Lista);

        }
        [HttpGet]
        public async Task<ActionResult<List<TbSysSelExchangeLog>>> ListarExchangeLog()
        {
            List<TbSysSelExchangeLog> Lista = await _repository.ListarExchangeLog();
            return Ok(Lista);
        }


    }
}
